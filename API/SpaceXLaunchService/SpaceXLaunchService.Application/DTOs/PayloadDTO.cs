using SpaceXLaunchService.Domain.Entities;

namespace SpaceXLaunchService.Application.DTOs
{
    public record PayloadDTO
    {
        public string Payload_Id { get; init; } = null!;
        public List<object> Norad_Id { get; init; } = null!;
        public bool? Reused { get; init; }
        public List<string> Customers { get; init; } = null!;
        public string? Nationality { get; init; }
        public string? Manufacturer { get; init; }
        public string? Payload_Type { get; init; }
        public long? Payload_Mass_Kg { get; init; }
        public long? Payload_Mass_Lbs { get; init; }
        public string? Orbit { get; init; }
        public OrbitParams Orbit_Params { get; init; } = null!;
    }

}
