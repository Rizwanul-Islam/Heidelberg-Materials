namespace SpaceXLaunchService.Application.DTOs
{
    public record FirstStageDTO
    {
        public List<CoreDTO> Cores { get; init; } = null!;
    }

}
