using OlenkaForms.src.Domain.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlenkaForms.src.Aplication.Ports.Secondary
{
    public interface IMappingUser
    {
        Task<bool> CreateUser(UserRequest user);
        Task<bool> UpdateUser(UserRequest user);
        Task<bool> ResetPasswordUser(UserRequest user);
        Task<bool> ValidateCodeUser(string codeUser, string email);
        Task<bool> UpdateCodeUser(string codeUser, string email);
        Task<bool> LoginUser(string email, string password, string code);
        Task<bool> Logout(string email);
    }
}
