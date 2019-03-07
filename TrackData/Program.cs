using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TrackData
{
    class Program
    {
        static readonly Uri url = new Uri("https://mytrackman.com/api/dynamicreports/getreport");

        static HttpClient client = new HttpClient();

        public static async Task Main(string[] args)
        {
            var taskList = new List<Task>();

            foreach (var id in args)
            {
                taskList.Add(GetReport(id));
            }

            await Task.WhenAll(taskList);
        }

        private static async Task GetReport(string item)
        {
            var report = new TrackmanReport(item);

            var json = JsonConvert.SerializeObject(report);
            var buffer = Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var result = await client.PostAsync(url, byteContent);

            if (result.IsSuccessStatusCode)
            {
                var res = JsonConvert.DeserializeObject<TrackmanData>(result.Content.ReadAsStringAsync().Result);
                await Save(res);
            }
        }

        private static async Task Save(TrackmanData tmData)
        {
            var json = JsonConvert.SerializeObject(tmData);
            var path = $".\\Trackman\\{tmData.Time.ToString("yyyyMMdd")}\\";
            var jsonFile = $"{path}{tmData.Id}-{tmData.StrokeGroups.First().Club}.json";
            var csvFile = $"{path}{tmData.Id}-{tmData.StrokeGroups.First().Club}-data.csv";
            var trajFile = $"{path}{tmData.Id}-{tmData.StrokeGroups.First().Club}-traj.csv";

            var di = Directory.CreateDirectory(path + "Videos");

            if (!File.Exists(jsonFile))
            {
                File.WriteAllText(jsonFile, json);
            }

            var strokes = tmData
                .StrokeGroups
                .SelectMany(x => x.Strokes
                    .Select(v => new VideoDTO { Time = v.Time, Videos = v.Videos }));

            foreach (var stroke in strokes)
            {
                string videoFile;

                if (stroke.Videos.Count() > 1)
                {
                    for (var i = 0; i < stroke.Videos.Count(); i++)
                    {
                        videoFile = $"{path}\\Videos\\{stroke.Time.ToString("yyyy-MM-dd HH.mm.ss")}-{i}.mp4";

                        if (!File.Exists(videoFile))
                        {
                            var dl = await GetVideo(stroke.Videos[i].Uri);
                            using (FileStream output = File.OpenWrite(videoFile))
                            {
                                dl.CopyTo(output);
                            }
                        }
                    }
                } else if (stroke.Videos.Count() == 1)
                {
                    videoFile = $"{path}\\Videos\\{stroke.Time.ToString("yyyy-MM-dd HH.mm.ss")}.mp4";

                    if (!File.Exists(videoFile))
                    {
                        var dl = await GetVideo(stroke.Videos.First().Uri);
                        using (FileStream output = File.OpenWrite(videoFile))
                        {
                            dl.CopyTo(output);
                        }
                    }
                }
            }

            var measurments = tmData.StrokeGroups.SelectMany(x => x.Strokes.Select(s => s.NormalizedMeasurement));

            if (!File.Exists(csvFile))
            {
                using (var writer = new StreamWriter(csvFile))
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(measurments);
                }
            }

            var traj = tmData.StrokeGroups.SelectMany(x => x.Strokes.SelectMany(s => s.Measurement.BallTrajectory));

            if (!File.Exists(trajFile))
            {
                using (var writer = new StreamWriter(trajFile))
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecords(traj);
                }
            }
        }

        private static async Task<Stream> GetVideo(string url)
        {
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStreamAsync();
            }

            throw new Exception();
        }
    }


}
