//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.Extensions.Options;
//using RitaApp.Data.Models;
//using System.Net.Http.Headers;
//using System.Security.Claims;
//using System.Text.Encodings.Web;
//using System.Text;
//using RitaApp.Repositories;

//namespace RitaApp.Authentication
//{
//	public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
//	{
//		private readonly IRepository<User> userRepository;

//		public BasicAuthenticationHandler(
//			IOptionsMonitor<AuthenticationSchemeOptions> options,
//			ILoggerFactory logger,
//			UrlEncoder encoder,
//			ISystemClock clock,
//			IRepository<User> userRepository)
//			: base(options, logger, encoder, clock)
//		{
//			this.userRepository = userRepository;
//		}

//		protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
//		{
//			// skip authentication if endpoint has [AllowAnonymous] attribute
//			var endpoint = Context.GetEndpoint();
//			if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
//			{
//				return AuthenticateResult.NoResult();
//			}

//			if (!Request.Headers.ContainsKey("Authorization"))
//			{
//				return AuthenticateResult.Fail("Missing Authorization Header");
//			}

//			User user = null;
//			try
//			{
//				var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
//				var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
//				var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
//				var username = credentials[0];
//				var password = credentials[1];
				
//				user = await this.userRepository.GetUserByEmail(username);

//				// TODO: HASH!

				
//				if (user == null || user.Password != password)
//				{
//					return AuthenticateResult.Fail("Invalid Authorization Header");
//				}
//			}
//			catch
//			{
//				return AuthenticateResult.Fail("Invalid Authorization Header");
//			}

//			var claims = new[] {
//				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//				new Claim(ClaimTypes.Name, user.Email),
//			};
//			var identity = new ClaimsIdentity(claims, Scheme.Name);
//			var principal = new ClaimsPrincipal(identity);
//			var ticket = new AuthenticationTicket(principal, Scheme.Name);
//			return AuthenticateResult.Success(ticket);
//		}
//	}

//}

