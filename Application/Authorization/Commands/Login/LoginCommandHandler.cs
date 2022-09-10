using MediatR;
using System.Net.Http.Json;
using UserApplication.Authorization.Dto;

namespace UserApplication.Authorization.Commands.Login
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginDto = new LoginDto()
            {
                UserName = request.UserName,
                Password = request.Password,
            };

            var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(request.Address, loginDto);

            string token = await response.Content.ReadAsStringAsync();

            return token;
        }
    }
}
