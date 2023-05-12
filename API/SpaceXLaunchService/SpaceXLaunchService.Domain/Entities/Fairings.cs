namespace SpaceXLaunchService.Domain.Entities
{
    public record Fairings
    {
        public bool? Reused { get; init; }
        public bool? Recovery_Attempt { get; init; }  
        public bool? Recovered { get; init; }
        public object Ship { get; init; } = null!;
    }

}
