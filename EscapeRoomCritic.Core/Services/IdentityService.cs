﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using EscapeRoomCritic.Core.Models;
using EscapeRoomCritic.Core.Repositories;
using Microsoft.IdentityModel.Tokens;

namespace EscapeRoomCritic.Core.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecretProvider _secretProvider;

        public IdentityService(IUserRepository userRepository, ISecretProvider secretProvider)
        {
            _userRepository = userRepository;
            _secretProvider = secretProvider;
        }
        public User Authenticate(string username, string password)
        {
            var user = _userRepository.CheckCredentials(username, password);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretProvider.GetSecret());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }
    }
}