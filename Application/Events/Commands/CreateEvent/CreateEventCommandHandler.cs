using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UserApplication.Authorization.Services;

namespace UserApplication.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, string>
    {
        TokenService _tokenService;
        public CreateEventCommandHandler(TokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public async Task<string> Handle(CreateEventCommand request,
            CancellationToken cancellationToken)
        {
            var dto = new CreateEventDto
            {
                Title = request.Title,
                Details = request.Details,
                Image = request.Image,
                Price = request.Price,
                Date = request.Date,
            };

            HttpClient httpClient = new HttpClient();

            var httpMessage = new HttpRequestMessage(HttpMethod.Post, request.Address)
            {
                Version = HttpVersion.Version10
            };

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _tokenService.Token);

            HttpResponseMessage response = await httpClient.SendAsync(httpMessage);

            string eventId = await response.Content.ReadAsStringAsync();

            return eventId;
        }
    }
}
