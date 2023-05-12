using SpaceXLaunchService.Domain.Entities;

namespace SpaceXLaunchService.UnitTests.Mocks
{
    public static class MockLaunchObject
    {
        private static readonly Launch _launch;

        static MockLaunchObject()
        {
            _launch = new Launch
            {
                Flight_Number = 1,
                Mission_Name = "Test Mission",
                Mission_Id = new List<string> { "mission-id-1", "mission-id-2" },
                Upcoming = false,
                Launch_Year = "2023",
                Launch_Date_Unix = 1652764800,
                Launch_Date_Utc = new DateTime(2022, 5, 16, 0, 0, 0, DateTimeKind.Utc),
                Launch_Date_Local = new DateTimeOffset(new DateTime(2022, 5, 16, 0, 0, 0)),
                Is_Tentative = false,
                Tentative_Max_Precision = "hour",
                Tbd = false,
                Launch_Window = 3600,
                Rocket = new Rocket { Rocket_Id = "falcon9", Rocket_Name = "Falcon 9", },
                Ships = new List<string> { "ship-1", "ship-2" },
                Telemetry = new Telemetry { Flight_Club = "https://www.flightclub.io/result?code=IRD8" },
                Launch_Site = new LaunchSite { Site_Id = "vafb_slc_4e" },
                Launch_Success = true,
                Launch_Failure_Details = new LaunchFailureDetails { Reason = "None" },
                Links = new Links { Mission_Patch = "https://images2.imgbox.com/80/ae/1JL1ZzXD_o.png" },
                Details = "Test launch details",
                Static_Fire_Date_Utc = new DateTime(2022, 5, 15, 0, 0, 0, DateTimeKind.Utc),
                Static_Fire_Date_Unix = 1652678400,
                Timeline = new Timeline { Webcast_Liftoff = 960 },
                Crew = null,
                Last_Date_Update = new DateTime(2022, 5, 15, 0, 0, 0),
                Last_Ll_LaunchDate = new DateTime(2022, 5, 15, 0, 0, 0),
                Last_Ll_Update = new DateTime(2022, 5, 15, 0, 0, 0),
                Last_Wiki_Launch_Date = new DateTime(2022, 5, 15, 0, 0, 0),
                Last_Wiki_Revision = "123456",
                Last_Wiki_Update = new DateTime(2022, 5, 15, 0, 0, 0),
                Launch_Date_Source = "LaunchSource"
            };
        }

        public static Launch GetLaunchObject()
        {
            return _launch;
        }

        public static List<Launch> GetLaunchList()
        {
            return new List<Launch> { _launch };
        }
    }
}
