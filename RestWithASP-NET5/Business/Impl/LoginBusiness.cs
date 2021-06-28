using Microsoft.IdentityModel.JsonWebTokens;
using RestWithASP_NET5.Configurations;
using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Repository;
using RestWithASP_NET5.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace RestWithASP_NET5.Business.Impl
{
    public class LoginBusiness : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;

        private IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusiness(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            // Verify if a user is valid (return from database),
            // if valid, the token data is created and assigned to user properties
            var user = _repository.ValidateCredentials(userCredentials);
            if (user == null) return null;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };
            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);
            
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = createDate.AddDays(_configuration.DaysToExpiry);

            _repository.RefreshUserInfo(user);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
            );
        }
    }
}
