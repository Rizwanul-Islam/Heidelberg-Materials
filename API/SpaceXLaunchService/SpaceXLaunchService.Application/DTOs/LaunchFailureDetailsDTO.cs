namespace SpaceXLaunchService.Application.DTOs
{
    public record LaunchFailureDetailsDTO
    {
        public int? Time { get; init; }
        public double? Altitude { get; init; }
        public string? Reason { get; init; }
    }

}
