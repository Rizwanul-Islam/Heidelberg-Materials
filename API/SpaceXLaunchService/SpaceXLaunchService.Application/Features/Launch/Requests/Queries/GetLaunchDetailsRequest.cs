using MediatR;
using SpaceXLaunchService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceXLaunchService.Application.Features.Launch.Requests.Queries
{
    public class GetLaunchDetailsRequest : IRequest<LaunchDTO>
    {
        /// <summary>
        /// The Id of the Launch.
        /// </summary>
        public string Id { get; set; } = default!;
    }
}
