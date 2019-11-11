using Data;
using Data.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Services
{
    public class UserService: IDataRepository<User>
    {
        readonly AppSettings _appSettings;
        readonly BlogContext _blogContext;

        public UserService(IOptions<AppSettings> appSettings,BlogContext blogContext)
        {
            _appSettings = appSettings.Value;
            _blogContext = blogContext;
        }

        public User Authenticate(string email, string password)
        {
            var user = _blogContext.Users.SingleOrDefault(x => x.Email == email && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.ID.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }
        public IEnumerable<User> GetAll()
        {
            return _blogContext.Users.ToList();
        }

        public User Get(int id)
        {
            return _blogContext.Users
                  .FirstOrDefault(e => e.ID == id);
        }
        public IEnumerable<User> GetPageData(int count, int page = 1)
        {
            return _blogContext
            .Users
            .Skip((page - 1) * count)
            .Take(count)
            .ToList();
        }
        public void Add(User entity)
        {
            _blogContext.Users.Add(entity);
            _blogContext.SaveChanges();
        }

        public void Update(User user, User entity)
        {
            user.Name = entity.Name;
            user.Email = entity.Password;
            user.Password = entity.Password;
            user.Token = entity.Token;
            _blogContext.Users.Update(user);
            _blogContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _blogContext.Users.Remove(user);
            _blogContext.SaveChanges();
        }
    }
}
