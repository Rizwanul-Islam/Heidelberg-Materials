namespace SpaceXLaunchService.Domain.Entities
{
    public record SecondStage
    {
        public int? Block { get; init; }
        public List<Payload> Payloads { get; init; } = null!;
    }

}
