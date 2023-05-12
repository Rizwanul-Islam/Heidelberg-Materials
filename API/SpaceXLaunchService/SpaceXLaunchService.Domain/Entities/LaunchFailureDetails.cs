namespace SpaceXLaunchService.Domain.Entities
{
    public record LaunchFailureDetails
    {
        public int? Time { get; init; }
        public double? Altitude { get; init; }
        public string? Reason { get; init; }
    }

}
