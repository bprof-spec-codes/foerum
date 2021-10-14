﻿using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Class
{
    public class AuthLogic
    {
        private UserManager<MyUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AuthLogic(UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IEnumerable<MyUser> GetAllUsers()
        {
            return _userManager.Users;
        }

        public async Task<string> RegisterUser(RegisterViewModel model)
        {
            var user = new MyUser
            {
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            // TODO roles
            //if (result.Succeeded)
            //{
            //    await _userManager.AddToRoleAsync(user, "User");
            //}
            return user.UserName;
        }

        public async Task<TokenViewModel> LoginUser(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };

                var roles = await _userManager.GetRolesAsync(user);

                claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

                // TODO maybe change secu key, maybe add it as a secret.
                var signinKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("Akos Egy Kutya Amiert Rapakol A Github Pullrequestjeikre"));

                // TODO change for microsoft token
                var token = new JwtSecurityToken(
                  issuer: "http://www.security.org",
                  audience: "http://www.security.org",
                  claims: claims,
                  expires: DateTime.Now.AddMinutes(60),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );
                return new TokenViewModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }
            throw new ArgumentException("Login failed");
        }
    }
}
