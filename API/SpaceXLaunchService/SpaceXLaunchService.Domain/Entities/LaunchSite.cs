namespace SpaceXLaunchService.Domain.Entities
{
    public record LaunchSite
    {
        public string Site_Id { get; init; } = null!;     
        public string? Site_Name { get; init; }
        public string? Site_Name_Long { get; init; }
    }

}
