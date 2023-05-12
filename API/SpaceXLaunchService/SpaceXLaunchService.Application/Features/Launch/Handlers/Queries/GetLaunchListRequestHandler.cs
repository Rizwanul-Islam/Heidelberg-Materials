using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using SpaceXLaunchService.Application.Common.Exceptions;
using SpaceXLaunchService.Application.DTOs;
using SpaceXLaunchService.Application.Features.Launch.Requests.Queries;

namespace SpaceXLaunchService.Application.Features.Launch.Handlers.Queries
{
    public class GetLaunchListRequestHandler : IRequestHandler<GetLaunchListRequest, List<LaunchDTO>>
    {
        private readonly IMapper _mapper;
        public GetLaunchListRequestHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<List<LaunchDTO>> Handle(GetLaunchListRequest request, CancellationToken cancellationToken)
        {
            var launches = new List<Domain.Entities.Launch>();
            var flightLaunches = new List<LaunchDTO>();

            try
            {
                //TODO: Base api url Need to shift into configuiration file
                string apiUrl = $"https://api.spacexdata.com/v3/launches";
                using var client = new HttpClient();
                var response = await client.GetAsync(apiUrl, cancellationToken);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    launches = JsonConvert.DeserializeObject<List<Domain.Entities.Launch>>(json);
                }

                flightLaunches = _mapper.Map<List<LaunchDTO>>(launches);

                return flightLaunches;
            }

            catch (Exception ex)
            {
                throw new HttpRequestException(ex.InnerException!.Message);
            }
        }
    }
}
