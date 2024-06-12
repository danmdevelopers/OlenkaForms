using BibliotecasBase.Utils.Log;
using BibliotecasBase.Utils.Log.Services.Controllers;
using Domain.Utils;
using HotChocolate.Execution;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OlenkaForms.src.Aplication.Ports.Primary;
using OlenkaForms.src.Domain.Entities.Queries;
using System;
using System.Threading.Tasks;

namespace OlenkaForms.src.Infrastructure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:UtilityController
    {

        private readonly IHandleUser _user;
        public UserController(ILogHandler _logHandler, IRequestContextAccessor _requestAccessor, IHandleUser user)
        : base(_logHandler, _requestAccessor)
        {
            _user= user;
        }



        #region Procesos POST

        [HttpPost("CreateUser/")]
        public async Task<IActionResult> CreateUser(UserRequest user)
        {

            try
            {
                InitLog(true, Environment.MachineName, Environment.ProcessId.ToString(), "Create User " + JsonConvert.SerializeObject(user));


                var response = await _user.CreateUser(user);

               
                return Ok(response);

            }
            catch (Excepciones ex)
            {
                throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
            }
            catch (Exception ex)
            {
                throw new Excepciones(ex);
            }

        }


        [HttpPost("UpdateUser/")]
        public async Task<IActionResult> UpdateUser(UserRequest user)
        {

            try
            {
                InitLog(true, Environment.MachineName, Environment.ProcessId.ToString(), "Update User " + JsonConvert.SerializeObject(user));


                var response = await _user.UpdateUser(user);


                return Ok(response);

            }
            catch (Excepciones ex)
            {
                throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
            }
            catch (Exception ex)
            {
                throw new Excepciones(ex);
            }

        }

        [HttpPost("ResetPasswordUser/")]
        public async Task<IActionResult> ResetPasswordUser(UserRequest user)
        {

            try
            {
                InitLog(true, Environment.MachineName, Environment.ProcessId.ToString(), "Reset Password User " + JsonConvert.SerializeObject(user));


                var response = await _user.ResetPasswordUser(user);


                return Ok(response);

            }
            catch (Excepciones ex)
            {
                throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
            }
            catch (Exception ex)
            {
                throw new Excepciones(ex);
            }

        }

        [HttpPost("ValidateCodeUser/")]
        public async Task<IActionResult> ValidateCodeUser(UserRequest user)
        {

            try
            {
                InitLog(true, Environment.MachineName, Environment.ProcessId.ToString(), "Reset Password User " + JsonConvert.SerializeObject(user));


                var response = await _user.ValidateCodeUser(user.Email, user.CodeValidation);


                return Ok(response);

            }
            catch (Excepciones ex)
            {
                throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
            }
            catch (Exception ex)
            {
                throw new Excepciones(ex);
            }

        }

        [HttpPost("LogoutUser/")]
        public async Task<IActionResult> LogoutUser(UserRequest user)
        {

            try
            {
                InitLog(true, Environment.MachineName, Environment.ProcessId.ToString(), "Reset Password User " + JsonConvert.SerializeObject(user));


                var response = await _user.Logout(user.Email);


                return Ok(response);

            }
            catch (Excepciones ex)
            {
                throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
            }
            catch (Exception ex)
            {
                throw new Excepciones(ex);
            }

        }

        #endregion



        #region Procesos GET

        [HttpGet("LoginUser/")]
        public async Task<IActionResult> LoginUser(UserRequest user)
        {

            try
            {
                InitLog(true, Environment.MachineName, Environment.ProcessId.ToString(), "Login User " + JsonConvert.SerializeObject(user));


                var response = await _user.LoginUser(user);


                return Ok(response);

            }
            catch (Excepciones ex)
            {
                throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
            }
            catch (Exception ex)
            {
                throw new Excepciones(ex);
            }

        }



        #endregion


    }
}
