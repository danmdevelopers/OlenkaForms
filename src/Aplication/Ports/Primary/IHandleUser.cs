using OlenkaForms.src.Domain.Entities.Models;
using OlenkaForms.src.Domain.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlenkaForms.src.Aplication.Ports.Primary
{
    public interface IHandleUser
    {
        Task<bool> CreateUser(UserRequest user);
        Task<bool> UpdateUser(UserRequest user);
        Task<bool> ResetPasswordUser(UserRequest user);
        Task<bool> ValidateCodeUser(string email, string code);
        Task<bool> LoginUser(UserRequest user);
        Task<bool> Logout(string email);
    }
}
