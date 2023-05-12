using SpaceXLaunchService.Domain.Entities;

namespace SpaceXLaunchService.Application.DTOs
{
    public record SecondStageDTO
    {
        public int? Block { get; init; }
        public List<Payload> Payloads { get; init; } = null!;
    }

}
