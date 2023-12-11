using PayRoll.Application.DTOs.Auth;
using PayRoll.Application.DTOs;
using PayRoll.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Application.Repository.IRepository
{
    public interface IAuthRepository
    {
        Task<string> GenerateTokenString(ApplicationUser user);
        Task<ApplicationUser> Login(LoginRequestDto user);
        Task<bool> RegisterUser(UserCreationDto user);
    }
}
