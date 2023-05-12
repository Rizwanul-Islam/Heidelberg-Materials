namespace SpaceXLaunchService.Domain.Entities
{
    public record Core
    {
        public string Core_Serial { get; init; } = null!;
        public int? Flight { get; init; }
        public int? Block { get; init; }
        public bool? Gridfins { get; init; }
        public bool? Legs { get; init; }
        public bool?  Reused { get; init; }
        public bool? Land_Success { get; init; }
        public bool? Landing_Intent { get; init; }
        public string? Landing_Type { get; init; }
        public string? Landing_Vehicle { get; init; }
    }

}
