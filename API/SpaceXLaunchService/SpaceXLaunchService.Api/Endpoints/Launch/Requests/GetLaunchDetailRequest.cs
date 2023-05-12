namespace SpaceXLaunchService.Api.Endpoints.Launch.Requests
{
    public class GetLaunchDetailRequest
    {
        /// <summary>
        /// The Id of the Launch.
        /// </summary>
        public string Id { get; set; } = default!;
    }
}
