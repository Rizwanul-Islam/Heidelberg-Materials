using AutoMapper;
using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using SpaceXLaunchService.Application.Common.Exceptions;
using SpaceXLaunchService.Application.DTOs;
using SpaceXLaunchService.Application.Features.Launch.Requests.Queries;
using System.Net;

namespace SpaceXLaunchService.Application.Features.Launch.Handlers.Queries
{
    public class RedirectToUrlCommandValidator : AbstractValidator<GetLaunchDetailsRequest>
    {
        public RedirectToUrlCommandValidator()
        {
            _ = RuleFor(v => v.Id)
              .NotEmpty()
              .WithMessage("Flight Id is required.");
        }
    }
    public class GetLaunchDetailRequestHandler : IRequestHandler<GetLaunchDetailsRequest, LaunchDTO>
    {
        private readonly IMapper _mapper;
        public GetLaunchDetailRequestHandler(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<LaunchDTO> Handle(GetLaunchDetailsRequest request, CancellationToken cancellationToken)
        {
            //TODO: Base api url Need to shift into configuiration file
            string apiUrl = $"https://api.spacexdata.com/v3/launches/{request.Id}";

            try
            {
                using var client = new HttpClient();
                var response = await client.GetAsync(apiUrl, cancellationToken);
                response.EnsureSuccessStatusCode(); // Throws an exception for non-success status codes

                var json = await response.Content.ReadAsStringAsync();
                var launch = JsonConvert.DeserializeObject<Domain.Entities.Launch>(json);
                var flightLaunch = _mapper.Map<LaunchDTO>(launch);

                return flightLaunch;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                throw new NotFoundException("No launch found");
            }

            catch (Exception ex)
            {
                throw new HttpRequestException(ex.Message);
            }
        }
    }
}
