using AutoMapper;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Shouldly;
using SpaceXLaunchService.Application.DTOs;
using SpaceXLaunchService.Application.Features.Launch.Handlers.Queries;
using SpaceXLaunchService.Application.Features.Launch.Requests.Queries;
using SpaceXLaunchService.Domain.Entities;
using SpaceXLaunchService.UnitTests.Mocks;
using System.Net;
using Xunit;

namespace SpaceXLaunchService.UnitTests
{
    public class GetLaunchListRequestHandlerTests
    {
        private readonly GetLaunchListRequestHandler _handler;
        private readonly Mock<IMapper> _mapperMock;
        private readonly List<LaunchDTO> _launchListDTO;

        public GetLaunchListRequestHandlerTests()
        {
            _mapperMock = new Mock<IMapper>();
            _handler = new GetLaunchListRequestHandler(_mapperMock.Object);
            _launchListDTO = new List<LaunchDTO>()
            { new LaunchDTO
              {
                Flight_Number = 1,
                Mission_Name = "Test Mission",
                Mission_Id = new List<string> { "mission-id-1", "mission-id-2" },
                Upcoming = false,
                Launch_Year = "2023",
                Launch_Date_Unix = 1652764800,
                Launch_Date_Utc = new DateTime(2022, 5, 16, 0, 0, 0, DateTimeKind.Utc),
                Launch_Date_Local = new DateTimeOffset(new DateTime(2022, 5, 16, 0, 0, 0)),
                Is_Tentative = false,
                Tentative_Max_Precision = "hour",
                Tbd = false,
                Launch_Window = 3600,
                Rocket = new Rocket { Rocket_Id = "falcon9", Rocket_Name = "Falcon 9", },
                Ships = new List<string> { "ship-1", "ship-2" },
                Telemetry = new Telemetry { Flight_Club = "https://www.flightclub.io/result?code=IRD8" },
                Launch_Site = new LaunchSite { Site_Id = "vafb_slc_4e" },
                Launch_Success = true,
                Launch_Failure_Details = new LaunchFailureDetails { Reason = "None" },
                Links = new Links { Mission_Patch = "https://images2.imgbox.com/80/ae/1JL1ZzXD_o.png" },
                Details = "Test launch details",
                Static_Fire_Date_Utc = new DateTime(2022, 5, 15, 0, 0, 0, DateTimeKind.Utc),
                Static_Fire_Date_Unix = 1652678400,
                Timeline = new Timeline { Webcast_Liftoff = 960 },
                Crew = null,
                Last_Date_Update = new DateTime(2022, 5, 15, 0, 0, 0),
                Last_Ll_LaunchDate = new DateTime(2022, 5, 15, 0, 0, 0),
                Last_Ll_Update = new DateTime(2022, 5, 15, 0, 0, 0),
                Last_Wiki_Launch_Date = new DateTime(2022, 5, 15, 0, 0, 0),
                Last_Wiki_Revision = "123456",
                Last_Wiki_Update = new DateTime(2022, 5, 15, 0, 0, 0),
                Launch_Date_Source = "LaunchSource"
              }
            };

        }
        [Fact]
        public async Task Handle_WithValidId_ReturnsLaunchDTO()
        {
            // Arrange
            var request = new GetLaunchListRequest();
            var _launchList = MockLaunchObject.GetLaunchList();
            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _ = httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(JsonConvert.SerializeObject(_launchList))
                });

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            httpClientFactoryMock
                .Setup(f => f.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);

            var cancellationToken = new CancellationToken();

            _mapperMock
                .Setup(m => m.Map<List<LaunchDTO>>(It.IsAny<List<Domain.Entities.Launch>>()))
                .Returns(_launchListDTO);

            // Act
            var result = await _handler.Handle(request, cancellationToken);

            // Assert
            result.ShouldNotBeNull(); // Ensure the result is not null
            result.ShouldBeOfType<List<LaunchDTO>>(); // Ensure the result is of type List<LaunchDTO>
            result.ShouldBeEquivalentTo(_launchListDTO); // Compare the result with the expected launch list DTO
        }
    }
}

