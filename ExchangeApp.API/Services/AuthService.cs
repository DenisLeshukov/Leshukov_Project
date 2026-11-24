using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using ExchangeApp.API.Models.Entities;
using ExchangeApp.API.Data;
using Microsoft.AspNetCore.Identity;
using ExchangeApp.Shared.DTOs;
namespace ExchangeApp.API.Services
{
    public class AuthService
    {
        private readonly IPasswordHasher<User> _hasher;
        private readonly List<User> _users;
        private readonly ApplicationDbContext _db;
        public AuthService(IPasswordHasher<User> hasher, ApplicationDbContext db)
        {
            _hasher = hasher;
            _db = db;
        }
        public bool RegisterUser(UserDTO user)
        {
            

            var _user = new User
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                PasswordHash = user.Password,
                Rate = null,
                RegistrationDate = DateOnly.FromDateTime(DateTime.Now),
                PhotoUrl = user.PhotoUrl,
            };
            _user.PasswordHash = _hasher.HashPassword(_user,user.Password);
            _db.Users.Add(_user);
            _db.SaveChanges();
            return true;
        }
    }
}
