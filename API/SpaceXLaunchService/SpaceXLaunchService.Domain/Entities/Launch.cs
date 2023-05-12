using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXLaunchService.Domain.Entities
{
    public record Launch
    {
        public int Flight_Number { get; init; }
        public string? Mission_Name { get; init; } = null!;
        public List<string> Mission_Id { get; init; } = null!;
        public bool? Upcoming { get; init; }
        public string Launch_Year { get; init; } = null!;
        public long? Launch_Date_Unix { get; init; }
        public DateTime? Launch_Date_Utc { get; init; }
        public DateTimeOffset Launch_Date_Local { get; init; }
        public bool? Is_Tentative { get; init; }
        public string Tentative_Max_Precision { get; init; } = null!;
        public bool? Tbd { get; init; }
        public int? Launch_Window { get; init; }
        public Rocket Rocket { get; init; } = null!;
        public List<string> Ships { get; init; } = null!;
        public Telemetry Telemetry { get; init; } = null!;
        public LaunchSite Launch_Site { get; init; } = null!;
        public bool? Launch_Success { get; init; }
        public LaunchFailureDetails Launch_Failure_Details { get; init; } = null!;
        public Links Links { get; init; } = null!;
        public string Details { get; init; } = null!;
        public DateTime? Static_Fire_Date_Utc { get; set; }
        public long? Static_Fire_Date_Unix { get; init; }
        public Timeline Timeline { get; init; } = null!;
        public object Crew { get; init; } = null!;
        public DateTime? Last_Date_Update { get; set; }
        public DateTime? Last_Ll_LaunchDate { get; set; }
        public DateTime? Last_Ll_Update { get; set; }
        public DateTime? Last_Wiki_Launch_Date { get; set; }
        public string? Last_Wiki_Revision { get; set; }
        public DateTime? Last_Wiki_Update { get; set; }
        public string? Launch_Date_Source { get; set; }
    }

}
