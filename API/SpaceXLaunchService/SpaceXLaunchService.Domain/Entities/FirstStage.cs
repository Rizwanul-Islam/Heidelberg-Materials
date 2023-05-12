namespace SpaceXLaunchService.Domain.Entities
{
    public record FirstStage
    {
        public List<Core> Cores { get; init; } = null!;
    }

}
