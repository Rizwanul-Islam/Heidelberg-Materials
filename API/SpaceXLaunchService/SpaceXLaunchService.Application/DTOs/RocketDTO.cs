using SpaceXLaunchService.Domain.Entities;

namespace SpaceXLaunchService.Application.DTOs
{
    public record RocketDTO
    {
        public string Rocket_Id { get; init; } = null!;
        public string? Rocket_Name { get; init; }
        public string? Rocket_Type { get; init; }
        public FirstStage First_Stage { get; init; } = null!;
        public SecondStage Second_Stage { get; init; } = null!;
        public Fairings Fairings { get; init; } = null!;
    }

}
