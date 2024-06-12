using BibliotecasBase.Utils.DataBase.Controllers;
using BibliotecasBase.Utils.DataBase.Interfaces;
using BibliotecasBase.Utils.Log.Services.Controllers;
using Domain.Utils;
using Microsoft.Extensions.Configuration;
using OlenkaForms.src.Aplication.Ports.Secondary;
using OlenkaForms.src.Domain.Entities.Models;
using OlenkaForms.src.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OlenkaForms.src.Infrastructure.Repositories
{
    public class EmailRepository: MapeoDatosBase, IMappingEmail
    {
        private readonly string conn;


        public EmailRepository(ISqlServer _sqlServer, IConfiguration configuration)
            :base(_sqlServer)
        {

            conn = configuration.GetConnectionString(StringHandler.SqlContectionStandard);
        
        }

        public async Task<EmailResponse> GetServerSMTP()
        {
            EmailResponse response;

            // Se realiza la consulta a la base de datos
            var dataSet = await SqlServer.ExecuteProcedureAsync(conn, "GENERIC_SECURITY.sps_GetServerSMTP");

            if (dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString() == "DB_0004")
            {
                response = new EmailResponse(dataSet.Tables[0].Rows[0]["STATUS_CODE"].ToString(), dataSet.Tables[0].Rows[0]["STATUS_MESSAGE"].ToString());

                foreach (DataRow item in dataSet.Tables[0].Rows)
                {
                    if (item["Name"].ToString().Contains("HostServerEmail"))
                    {
                        response.Host = item["Value"].ToString();
                    }

                    if (item["Name"].ToString().Contains("Port"))
                    {
                        response.Port = int.Parse(item["Value"].ToString());
                    }

                    if (item["Name"].ToString().Contains("PasswordEmail"))
                    {
                        response.Password = item["Value"].ToString();
                    }

                    if (item["Name"].ToString().Contains("Body"))
                    {
                        response.Body = item["Value"].ToString();
                    }

                    if (item["Name"].ToString().Contains("EmailAddress"))
                    {
                        response.User = item["Value"].ToString();
                    }

                }

                return response;
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
