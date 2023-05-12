using MediatR;
using SpaceXLaunchService.Application.DTOs;

namespace SpaceXLaunchService.Api.Endpoints.Launch.Requests
{
    public class GetAllLaunchRequest : IRequest<List<LaunchDTO>>
    {
    }
}
