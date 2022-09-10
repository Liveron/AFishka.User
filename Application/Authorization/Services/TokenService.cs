using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApplication.Authorization.Services
{
    public class TokenService
    {
		private string token;
		private string userName;

		public string Token
		{
			get => token;
			set 
			{
				token = String.IsNullOrEmpty(token) ? value : token;
			}
		}

		public string UserName
		{
			get => userName;
			set
			{
				userName = String.IsNullOrEmpty(userName) ? value : userName;
			}
		}

		public void DeleteUserName() =>
			userName = String.Empty;

		public bool IsTokenAlive() => 
			String.IsNullOrEmpty(token) ? false : true;

		public void DeleteToken() =>
			token = String.Empty;
	}
}
