using BibliotecasBase.Utils.DataBase.Controllers;
using BibliotecasBase.Utils.DataBase.Interfaces;
using BibliotecasBase.Utils.Log.Services.Controllers;
using Domain.Utils;
using Microsoft.Extensions.Configuration;
using OlenkaForms.src.Aplication.Ports.Secondary;
using OlenkaForms.src.Domain.Entities.Queries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlenkaForms.src.Infrastructure.Repositories
{
    public class UserRepository:MapeoDatosBase, IMappingUser
    {
        static string conn;
        public UserRepository(ISqlServer _sqlServer, IConfiguration configuration) 
        :base(_sqlServer)
        {
            conn = configuration.GetConnectionString(StringHandler.SqlContectionStandard);
        }

        public async Task<bool> CreateUser(UserRequest user)
        {

            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_idUser", SqlDbType.UniqueIdentifier, Guid.NewGuid());
            SqlServer.AddParameter("@i_DNI", SqlDbType.VarChar, user.DNI);
            SqlServer.AddParameter("@i_FirstName", SqlDbType.VarChar, user.FirstName);
            SqlServer.AddParameter("@i_LastName", SqlDbType.VarChar, user.LastName);
            SqlServer.AddParameter("@i_Email", SqlDbType.VarChar, user.Email);
            SqlServer.AddParameter("@i_Country", SqlDbType.VarChar, user.Country);
            SqlServer.AddParameter("@i_Phone", SqlDbType.VarChar, user.Phone);
            SqlServer.AddParameter("@i_Password", SqlDbType.VarChar, user.Password);
            SqlServer.AddParameter("@i_CodeValidation", SqlDbType.VarChar, user.CodeValidation);

            // Se realiza la consulta a la base de datos
            var dataSet = await SqlServer.ExecuteProcedureAsync(conn, "GENERIC_SECURITY.spi_InsertUser");

            if (dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString()== "DB_0004")
            {
                return true;
            }
            else
            {
                var code = dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString();
                var message = dataSet.Tables[0].Rows[0]["STATUS_MESSAGE"].ToString();

                throw new Excepciones(message, code);
            }

        }

        public async Task<bool> UpdateUser(UserRequest user)
        {

            SqlServer.AddParameter("@i_DNI", SqlDbType.VarChar, user.DNI);
            SqlServer.AddParameter("@i_FirstName", SqlDbType.VarChar, user.FirstName);
            SqlServer.AddParameter("@i_LastName", SqlDbType.VarChar, user.LastName);
            SqlServer.AddParameter("@i_Email", SqlDbType.VarChar, user.Email);
            SqlServer.AddParameter("@i_Country", SqlDbType.VarChar, user.Country);
            SqlServer.AddParameter("@i_Phone", SqlDbType.VarChar, user.Phone);
            SqlServer.AddParameter("@i_Password", SqlDbType.VarChar, user.Password);
            SqlServer.AddParameter("@i_CodeValidation", SqlDbType.VarChar, user.CodeValidation);

            // Se realiza la consulta a la base de datos
            var dataSet = await SqlServer.ExecuteProcedureAsync(conn, "GENERIC_SECURITY.spu_UpdateUser");

            if (dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString() == "DB_0004")
            {
                return true;
            }
            else
            {
                var code = dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString();
                var message = dataSet.Tables[0].Rows[0]["STATUS_MESSAGE"].ToString();

                throw new Excepciones(message, code);
            }

        }

        public async Task<bool> ResetPasswordUser(UserRequest user)
        {

            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_Email", SqlDbType.VarChar, user.Email);
            SqlServer.AddParameter("@i_Password", SqlDbType.VarChar, user.Password);

            // Se realiza la consulta a la base de datos
            var dataSet = await SqlServer.ExecuteProcedureAsync(conn, "GENERIC_SECURITY.spu_ResetPasswordUser");

            if (dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString() == "DB_0004")
            {
                return true;
            }
            else
            {
                var code = dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString();
                var message = dataSet.Tables[0].Rows[0]["STATUS_MESSAGE"].ToString();

                throw new Excepciones(message, code);
            }

        }

        public async Task<bool> UpdateCodeUser(string codeUser, string email)
        {

            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_CodeValidation", SqlDbType.VarChar, codeUser);
            SqlServer.AddParameter("@i_Email", SqlDbType.VarChar, email);

            // Se realiza la consulta a la base de datos
            var dataSet = await SqlServer.ExecuteProcedureAsync(conn, "GENERIC_SECURITY.spu_UpdateCodeUser");

            if (dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString() == "DB_0004")
            {
                return true;
            }
            else
            {
                var code = dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString();
                var message = dataSet.Tables[0].Rows[0]["STATUS_MESSAGE"].ToString();

                throw new Excepciones(message, code);
            }

        }


        public async Task<bool> ValidateCodeUser(string email, string codeUser)
        {

            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_CodeValidation", SqlDbType.VarChar, codeUser);
            SqlServer.AddParameter("@i_Email", SqlDbType.VarChar, email);

            // Se realiza la consulta a la base de datos
            var dataSet = await SqlServer.ExecuteProcedureAsync(conn, "GENERIC_SECURITY.spu_UpdateCodeUser");

            if (dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString() == "DB_0004")
            {
                return true;
            }
            else
            {
                var code = dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString();
                var message = dataSet.Tables[0].Rows[0]["STATUS_MESSAGE"].ToString();

                throw new Excepciones(message, code);
            }

        }


        public async Task<bool> LoginUser(string email, string password, string codeValidation)
        {

            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_Email", SqlDbType.VarChar, email);
            SqlServer.AddParameter("@i_Password", SqlDbType.VarChar, password);
            SqlServer.AddParameter("@i_Code", SqlDbType.VarChar, codeValidation);

            // Se realiza la consulta a la base de datos
            var dataSet = await SqlServer.ExecuteProcedureAsync(conn, "GENERIC_SECURITY.sps_LoginUser");

            if (dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString() == "DB_0004")
            {
                return true;
            }
            else
            {
                var code = dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString();
                var message = dataSet.Tables[0].Rows[0]["STATUS_MESSAGE"].ToString();

                throw new Excepciones(message, code);
            }

        }

        public async Task<bool> Logout(string email)
        {

            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_Email", SqlDbType.VarChar, email);

            // Se realiza la consulta a la base de datos
            var dataSet = await SqlServer.ExecuteProcedureAsync(conn, "GENERIC_SECURITY.spu_UpdateLogoutUser");

            if (dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString() == "DB_0004")
            {
                return true;
            }
            else
            {
                var code = dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString();
                var message = dataSet.Tables[0].Rows[0]["STATUS_MESSAGE"].ToString();

                throw new Excepciones(message, code);
            }

        }


       
        public async Task<bool> SearchCodeUser(string codeUser, string email)
        {

            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_CodeValidation", SqlDbType.VarChar, codeUser);
            SqlServer.AddParameter("@i_Email", SqlDbType.VarChar, email);

            // Se realiza la consulta a la base de datos
            var dataSet = await SqlServer.ExecuteProcedureAsync(conn, "GENERIC_SECURITY.spu_UpdateCodeUser");

            if (dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString() == "DB_0004")
            {
                return true;
            }
            else
            {
                var code = dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString();
                var message = dataSet.Tables[0].Rows[0]["STATUS_MESSAGE"].ToString();

                throw new Excepciones(message, code);
            }

        }



    }
}
