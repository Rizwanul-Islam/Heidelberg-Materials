namespace SpaceXLaunchService.Application.DTOs
{
    public record LinksDTO
    {
        public string Mission_Patch { get; init; } = null!;
        public string? Mission_Patch_Small { get; init; }
        public string? Reddit_Campaign { get; init; }
        public string? Reddit_Launch { get; init; }
        public string? Reddit_Recovery { get; init; }
        public string? Reddit_Media { get; init; }
        public string? Presskit { get; init; }
        public string? Article_Link { get; init; }
        public string? Wikipedia { get; init; }
        public string? Video_Link { get; init; }
        public string? Youtube_Id { get; init; }
        public List<string> Flickr_Images { get; init; } = null!;
    }

}
