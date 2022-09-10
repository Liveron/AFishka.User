using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UserApplication.Authorization.Dto;

namespace UserApplication.Authorization.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        public async Task<string> Handle(RegisterCommand request, 
            CancellationToken cancellationToken)
        {
            var dto = new RegisterDto
            {
                UserName = request.UserName,
                Password = request.Password,
                ConfirmPassword = request.ConfirmPassword,
            };

            var httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(request.Address, dto);

            string token = await response.Content.ReadAsStringAsync();

            return token;
        }
    }
}
