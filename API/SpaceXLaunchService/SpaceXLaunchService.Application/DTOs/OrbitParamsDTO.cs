namespace SpaceXLaunchService.Application.DTOs
{
    public record OrbitParamsDTO
    {
        public string Reference_System { get; init; } = null!;
        public string? Regime { get; init; }
        public double? Longitude { get; init; }
        public double? Semi_Major_Axis_Km { get; init; }
        public double? Eccentricity { get; init; }
        public double? Periapsis_Km { get; init; }
        public double? Apoapsis_Km { get; init; }
        public double? Inclination_Deg { get; init; }
        public double? Period_Min { get; init; }
        public double? Lifespan_Years { get; init; }
        public DateTime? Epoch { get; init; }
        public double? Mean_Motion { get; init; }
        public double? Raan { get; init; }
        public double? Arg_Of_Pericenter { get; init; }
        public double? Mean_Anomaly { get; init; }
    }

}
