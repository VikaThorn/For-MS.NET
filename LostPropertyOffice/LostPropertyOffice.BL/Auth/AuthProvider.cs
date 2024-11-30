using System;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using IdentityModel.Client;
using LostPropertyOffice.BL.Auth.Entities;
using LostPropertyOffice.BL.Users.Entity;
using LostPropertyOffice.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;

namespace LostPropertyOffice.BL.Auth
{
    public class AuthProvider : IAuthProvider
    {
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _identityServerUri;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly IMapper _mapper;

        public AuthProvider(
            SignInManager<UserEntity> signInManager,
            UserManager<UserEntity> userManager,
            IHttpClientFactory httpClientFactory,
            string identityServerUri,
            string clientId,
            string clientSecret,
            IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _identityServerUri = identityServerUri;
            _httpClientFactory = httpClientFactory;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _mapper = mapper;
        }

        public async Task<TokensResponse> AuthorizeUser(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
            {
                throw new Exception("User not found");
            }

            var verificationPasswordResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!verificationPasswordResult.Succeeded)
            {
                throw new Exception("Invalid credentials");
            }

            var client = _httpClientFactory.CreateClient();
            var discoveryDoc = await client.GetDiscoveryDocumentAsync(_identityServerUri);
            if (discoveryDoc.IsError)
            {
                throw new Exception("Failed to retrieve discovery document");
            }

            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = discoveryDoc.TokenEndpoint,
                GrantType = "password",
                ClientId = _clientId,
                ClientSecret = _clientSecret,
                UserName = user.Login,
                Password = password,
                Scope = "api offline_access"
            });

            if (tokenResponse.IsError)
            {
                throw new Exception("Failed to retrieve access token");
            }

            return new TokensResponse
            {
                AccessToken = tokenResponse.AccessToken,
                RefreshToken = tokenResponse.RefreshToken
            };
        }

        public async Task<UserModel> RegisterUser(string email, string password)
        {
            var existingUser = await _userManager.FindByEmailAsync(email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var user = new VisitorEntity
            {
                Login = email,
                PasswordHash = password,
                EmailAddress = email
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to create user");
            }

            return _mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> RegisterEmployee(string password, string position)
        {
            var existingUser = await _userManager.FindByNameAsync(position);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }

            var user = new EmployeeEntity
            {
                Login = position,
                PasswordHash = password,
                Position = position
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to create user");
            }

            return _mapper.Map<UserModel>(user);
        }
    }
}
