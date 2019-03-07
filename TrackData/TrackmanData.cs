using System;

namespace TrackData
{
    class TrackmanReport
    {
        public string ReportId;

        public TrackmanReport(string reportId)
        {
            ReportId = reportId;
        }
    }
    public class TrackmanData
    {
        public string Kind { get; set; }
        public Strokegroup[] StrokeGroups { get; set; }
        public Settings Settings { get; set; }
        public Environment Environment { get; set; }
        public Client Client { get; set; }
        public User User { get; set; }
        public Group[] Groups { get; set; }
        public DateTime Time { get; set; }
        public string Id { get; set; }
        public DateTime Updated { get; set; }
        public string __d_schema { get; set; }
        public string ManifestId { get; set; }
        public object[] Sponsors { get; set; }
        public Facility Facility { get; set; }
    }

    public class Settings
    {
        public string SelectedOptimizedType { get; set; }
        public string SelectedDispersionMode { get; set; }
        public object[] SelectedVideoAngles { get; set; }
        public bool SkidAndRollOn { get; set; }
        public string ReportSelection { get; set; }
        public string SelectedView { get; set; }
        public string UnitSystem { get; set; }
        public bool ShowNormalizedData { get; set; }
        public string SelectedClubType { get; set; }
        public string SelectedOptimizerView { get; set; }
        public string[] SelectedStrokesGroups { get; set; }
        public object SelectedStroke { get; set; }
        public bool OptimizerOn { get; set; }
        public object[] HiddenShots { get; set; }
        public object SelectedGroupOfStrokes { get; set; }
        public bool SummaryOn { get; set; }
        public bool ShowBottomCommercial { get; set; }
        public bool VideoOn { get; set; }
        public bool ClubDataOn { get; set; }
        public string[] Tiles { get; set; }
        public bool DispersionOn { get; set; }
        public bool TrajectoryOn { get; set; }
        public string InstructorMessage { get; set; }
        public string Client { get; set; }
    }

    public class Environment
    {
        public float Altitude { get; set; }
        public float Temperature { get; set; }
    }

    public class Client
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }

    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Facility
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public object Description { get; set; }
        public string Logo { get; set; }
        public string Link { get; set; }
    }

    public class Strokegroup
    {
        public string Id { get; set; }
        public string Date { get; set; }
        public string Club { get; set; }
        public string Ball { get; set; }
        public Player Player { get; set; }
        public Stroke[] Strokes { get; set; }
    }

    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class Stroke
    {
        public DateTime Time { get; set; }
        public string Club { get; set; }
        public string Ball { get; set; }
        public Measurement Measurement { get; set; }
        public Normalizedmeasurement NormalizedMeasurement { get; set; }
        public string Id { get; set; }
        public Video[] Videos { get; set; }
    }

    public class Measurement
    {
        public float ClubSpeed { get; set; }
        public float SwingPlane { get; set; }
        public float LandingAngle { get; set; }
        public float SpinLoft { get; set; }
        public float Total { get; set; }
        public float SwingDirection { get; set; }
        public float CarrySide { get; set; }
        public float LowPointDistance { get; set; }
        public string Kind { get; set; }
        public float BallSpeed { get; set; }
        public float MaxHeight { get; set; }
        public Balltrajectory[] BallTrajectory { get; set; }
        public float[] TeePosition { get; set; }
        public float ClubPath { get; set; }
        public float DynamicLoft { get; set; }
        public float Carry { get; set; }
        public float AttackAngle { get; set; }
        public float LaunchAngle { get; set; }
        public int SpinRate { get; set; }
        public string[] ReducedAccuracy { get; set; }
        public float HangTime { get; set; }
        public float Curve { get; set; }
        public string Id { get; set; }
        public float FaceAngle { get; set; }
        public float FaceToPath { get; set; }
        public float SpinAxis { get; set; }
        public string PlayerDexterity { get; set; }
        public float TotalSide { get; set; }
        public float LaunchDirection { get; set; }
        public float SmashFactor { get; set; }
        public float LastData { get; set; }
        public object[] ClubTrajectory { get; set; }
    }

    public class Balltrajectory
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }

    public class Normalizedmeasurement
    {
        public float ClubSpeed { get; set; }
        public float SwingPlane { get; set; }
        public float LandingAngle { get; set; }
        public float SpinLoft { get; set; }
        public float Total { get; set; }
        public float SwingDirection { get; set; }
        public float CarrySide { get; set; }
        public float LowPointDistance { get; set; }
        public string Kind { get; set; }
        public float BallSpeed { get; set; }
        public float MaxHeight { get; set; }
        public float[] TeePosition { get; set; }
        public float ClubPath { get; set; }
        public float DynamicLoft { get; set; }
        public float Carry { get; set; }
        public float AttackAngle { get; set; }
        public float LaunchAngle { get; set; }
        public float SpinRate { get; set; }
        public string[] ReducedAccuracy { get; set; }
        public float HangTime { get; set; }
        public float Curve { get; set; }
        public string Id { get; set; }
        public float FaceAngle { get; set; }
        public float FaceToPath { get; set; }
        public float SpinAxis { get; set; }
        public string PlayerDexterity { get; set; }
        public float TotalSide { get; set; }
        public float LaunchDirection { get; set; }
        public float SmashFactor { get; set; }
        public float LastData { get; set; }
    }

    public class Video
    {
        public string Id { get; set; }
        public string Angle { get; set; }
        public string Uri { get; set; }
        public string Poster { get; set; }
        public Metadata Metadata { get; set; }
    }

    public class Metadata
    {
        public string CameraName { get; set; }
        public float FramesPrSecond { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float Rotation { get; set; }
        public string Duration { get; set; }
        public float SpeedFactor { get; set; }
    }

    public class Group
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class VideoDTO
    {
        public Video[] Videos { get; set; }
        public DateTime Time { get; set; }
    }

}
