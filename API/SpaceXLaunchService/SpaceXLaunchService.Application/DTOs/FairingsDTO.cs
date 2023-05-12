namespace SpaceXLaunchService.Application.DTOs
{
    public record FairingsDTO
    {
        public bool? Reused { get; init; }
        public bool? Recovery_Attempt { get; init; }
        public bool? Recovered { get; init; }
        public object Ship { get; init; } = null!;
    }

}
