using System.Threading.Tasks;
using Worldpay.Sdk;
using Worldpay.Sdk.Models;

namespace Worldpay.Sdk
{
    /// <summary>
    /// Class for interacting with the Worldpay authorization API
    /// </summary>
    public class AuthService : AbstractService
    {
        public AuthService(Http http) : base(http) { }

		/// <summary>
		/// Get a temporary access token
		/// </summary>
		public async Task<TokenResponse> GetToken( TokenRequest tokenRequest )
		{
			return await Http.Post<TokenRequest, TokenResponse>( Configuration.TokenUrl, tokenRequest );
		}
	}
}
