using MediatR;
using SpaceXLaunchService.Api.Endpoints.Launch.Requests;
using SpaceXLaunchService.Application.Features.Launch.Requests.Queries;
using IMapper = AutoMapper.IMapper;

namespace SpaceXLaunchService.Api.Endpoints.Launch
{
    public class GetLaunchDetailSummary : Summary<GetLaunchDetailEndpoint>
    {
        public GetLaunchDetailSummary()
        {
            Summary = "Get launch details for a specific launch";
            Description =
                "This endpoint will give details of a launch.";
            Response(500, "Internal server error.");
        }
    }
    public class GetLaunchDetailEndpoint : BaseEndpoint<GetLaunchDetailRequest>
    {
        public GetLaunchDetailEndpoint(ISender mediator, IMapper mapper)
        : base(mediator, mapper) { }

        public override void Configure()
        {
            base.Configure();
            Get("launch/{Id}");
            AllowAnonymous();
            Description(
                d => d.WithTags("Launch Details")
            );
            Summary(new GetAllLaunchSummary());
        }

        public override async Task HandleAsync(GetLaunchDetailRequest req, CancellationToken ct)
        {
            var result = await Mediator.Send(
                new GetLaunchDetailsRequest
                {
                    Id = req.Id
                },
                ct
            );
            await SendOkAsync(result);
        }

    }
}
