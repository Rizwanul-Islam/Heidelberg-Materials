using MediatR;
using SpaceXLaunchService.Api.Endpoints.Launch.Requests;
using SpaceXLaunchService.Application.Features.Launch.Requests.Queries;
using IMapper = AutoMapper.IMapper;

namespace SpaceXLaunchService.Api.Endpoints.Launch
{
    public class GetAllLaunchSummary : Summary<GetAllLaunchEndpoint>
    {
        public GetAllLaunchSummary()
        {
            Summary = "Get All launch from SpaceX API";
            Description =
                "This endpoint will give a list of launch.";
            Response(500, "Internal server error.");
        }
    }
    public class GetAllLaunchEndpoint : BaseEndpoint<GetAllLaunchRequest>
    {
        public GetAllLaunchEndpoint(ISender mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        public override void Configure()
        {
            base.Configure();
            Get("launches");
            AllowAnonymous();
            Description(
                d => d.WithTags("Launch")
            );
            Summary(new GetAllLaunchSummary());
        }

        public override async Task HandleAsync(GetAllLaunchRequest req, CancellationToken ct)
        {
            var result = await Mediator.Send(
                new GetLaunchListRequest
                {
                    
                },
                ct
            );
            await SendOkAsync(result);
        }

    }
}
