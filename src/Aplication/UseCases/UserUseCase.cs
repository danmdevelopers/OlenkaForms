using BibliotecasBase.Utils.Log.Services.Controllers;
using OlenkaForms.src.Aplication.Helper;
using OlenkaForms.src.Aplication.Ports.Primary;
using OlenkaForms.src.Aplication.Ports.Secondary;
using OlenkaForms.src.Domain.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OlenkaForms.src.Aplication.UseCases
{
    public class UserUseCase:IHandleUser
    {


        private readonly IMappingUser _user;
        private readonly IMappingEmail _email;
        public UserUseCase(IMappingUser user, IMappingEmail email)
        {
            _user=user;
            _email=email;
        }


        public async Task<bool> CreateUser(UserRequest user)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    //Crear Usuario
                    var result = await _user.CreateUser(user);
                    //Enviar Correo Electrónico
                    var dataSMTP = _email.GetServerSMTP();

                    Email correo = new Email(dataSMTP.Result.Host, dataSMTP.Result.User, dataSMTP.Result.Password, dataSMTP.Result.Port);
                    string body = correo.ValidationCorreo(user.CodeValidation,dataSMTP.Result.Body);
                    await correo.SendEmail("Welcome to Olenka Trade",body,user.Email);

                    scope.Complete();
                    return true;
                }   
                catch (Excepciones ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex);
                }
            }

        }


        public async Task<bool> UpdateUser(UserRequest user)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    //Actualizar Usuario
                    var result = await _user.UpdateUser(user);
                    //Enviar Correo Electrónico
                    var dataSMTP = _email.GetServerSMTP();

                    Email correo = new Email(dataSMTP.Result.Host, dataSMTP.Result.User, dataSMTP.Result.Password, dataSMTP.Result.Port);
                    string body = correo.ValidationCorreo(user.CodeValidation, dataSMTP.Result.Body);
                    await correo.SendEmail("Updated User - Olenka Trade", body, user.Email);

                    scope.Complete();
                    return true;
                }
                catch (Excepciones ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex);
                }
            }

        }

        public async Task<bool> ResetPasswordUser(UserRequest user)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    //resetear Contraseña
                    var result = await _user.ResetPasswordUser(user);
                    //Enviar Correo Electrónico
                    var dataSMTP = _email.GetServerSMTP();

                    Email correo = new Email(dataSMTP.Result.Host, dataSMTP.Result.User, dataSMTP.Result.Password, dataSMTP.Result.Port);
                    string body = correo.ValidationCorreo(user.CodeValidation, dataSMTP.Result.Body);
                    await correo.SendEmail("Password Reset - Olenka Trade", body, user.Email);

                    scope.Complete();
                    return true;
                }
                catch (Excepciones ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex);
                }
            }

        }

        public async Task<bool> LoginUser(UserRequest user)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    //Iniciar Sesión
                    var result = await _user.LoginUser(user.Email,user.Password, user.CodeValidation);
                    //Enviar Correo Electrónico
                    var dataSMTP = _email.GetServerSMTP();

                    Email correo = new Email(dataSMTP.Result.Host, dataSMTP.Result.User, dataSMTP.Result.Password, dataSMTP.Result.Port);
                    string body = correo.ValidationCorreo(user.CodeValidation, dataSMTP.Result.Body);
                    await correo.SendEmail("Login - Olenka Trade", body, user.Email);

                    scope.Complete();
                    return true;
                }
                catch (Excepciones ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex);
                }
            }

        }

        public async Task<bool> UpdateCodeUser(string codeUser, string email)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var result = await _user.UpdateCodeUser(codeUser, email);
                    scope.Complete();
                    return true;
                }
                catch (Excepciones ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex);
                }
            }

        }

        public async Task<bool> ValidateCodeUser(string codeUser, string email)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var result = await _user.ValidateCodeUser(codeUser,email);
                    scope.Complete();
                    return true;
                }
                catch (Excepciones ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex);
                }
            }

        }
               

        public async Task<bool> Logout(string email)
        {
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var result = await _user.Logout(email);
                    scope.Complete();
                    return true;
                }
                catch (Excepciones ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex.DatosAdicionales.Message, ex.DatosAdicionales.StatusCode);
                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    throw new Excepciones(ex);
                }
            }

        }

    }
}
