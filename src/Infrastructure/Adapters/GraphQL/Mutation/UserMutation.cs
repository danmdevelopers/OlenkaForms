using BibliotecasBase.Utils.Log.Services.Controllers;
using BibliotecasBase.Utils.Log.Services.Entities;
using HotChocolate;
using HotChocolate.Types;
using OlenkaForms.src.Domain.Entities.Queries;
using OlenkaForms.src.Infrastructure.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlenkaForms.src.Infrastructure.Adapters.GraphQL.Mutation
{
    [ExtendObjectType("Mutation")]
    public class UserMutation
    {
        private readonly UserController _method;

        public UserMutation(UserController method)
        {
            _method = method;
        }

        public async Task<Code<bool>> CreateUser(UserRequest user)
        {
            Code<bool> result = new();
            try
            {
                //Consulta al controlleer
                var res = await _method.CreateUser(user);
                result = Code<bool>.parseResult<bool>(res);
            }
            catch (Excepciones ex)
            {
                result.Message = ex.DatosAdicionales.Message ?? ex.Message;
                result.StatusCode = ex.DatosAdicionales.StatusCode ?? ex.HResult.ToString();
                result.Data = false;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.StatusCode = ex.HResult.ToString();
                result.Data = false;
            }

            return result;
        }


        public async Task<Code<bool>> UpdateUser(UserRequest user)
        {
            Code<bool> result = new();
            try
            {
                //Consulta al controlleer
                var res = await _method.UpdateUser(user);
                result = Code<bool>.parseResult<bool>(res);
            }
            catch (Excepciones ex)
            {
                result.Message = ex.DatosAdicionales.Message ?? ex.Message;
                result.StatusCode = ex.DatosAdicionales.StatusCode ?? ex.HResult.ToString();
                result.Data = false;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.StatusCode = ex.HResult.ToString();
                result.Data = false;
            }

            return result;
        }

        public async Task<Code<bool>> ResetPasswordUser(UserRequest user)
        {
            Code<bool> result = new();
            try
            {
                //Consulta al controlleer
                var res = await _method.ResetPasswordUser(user);
                result = Code<bool>.parseResult<bool>(res);
            }
            catch (Excepciones ex)
            {
                result.Message = ex.DatosAdicionales.Message ?? ex.Message;
                result.StatusCode = ex.DatosAdicionales.StatusCode ?? ex.HResult.ToString();
                result.Data = false;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.StatusCode = ex.HResult.ToString();
                result.Data = false;
            }

            return result;
        }

        public async Task<Code<bool>> LogoutUser(UserRequest user)
        {
            Code<bool> result = new();
            try
            {
                //Consulta al controlleer
                var res = await _method.LogoutUser(user);
                result = Code<bool>.parseResult<bool>(res);
            }
            catch (Excepciones ex)
            {
                result.Message = ex.DatosAdicionales.Message ?? ex.Message;
                result.StatusCode = ex.DatosAdicionales.StatusCode ?? ex.HResult.ToString();
                result.Data = false;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.StatusCode = ex.HResult.ToString();
                result.Data = false;
            }

            return result;
        }

    }


}
