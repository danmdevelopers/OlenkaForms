using BibliotecasBase.Utils.Log.Services.Controllers;
using Microsoft.Azure.WebJobs;
using Razor.Templating.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OlenkaForms.src.Aplication.Helper
{
    public class Email
    {
        SmtpClient Servidor = new SmtpClient();
        MailMessage Correo;
        private string UserEmail { get; set; } = string.Empty;
        private string Password { get; set; } = string.Empty;

        public Email(string server, string user, string password, int port)
        {
            UserEmail = user;
            Password = password;
            Servidor.Port = port;
            Servidor.Host = server;
            Servidor.EnableSsl = false;
            Servidor.UseDefaultCredentials = false;
            NetworkCredential network = new NetworkCredential(UserEmail, Password);
            Servidor.Credentials = network;
        }

        public async Task<bool> SendEmail (string subject, string body, string destinatary)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            try
            {
                using (Correo = new MailMessage(UserEmail, destinatary))
                {
                    Correo.Subject = subject;
                    Correo.Body = body;
                    Correo.IsBodyHtml = true;
                    await Servidor.SendMailAsync(Correo);
                }
                return true;
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


        public string ValidationCorreo( string code,string Template)
        {
            string html = Template.Replace("{codeValidation}", code);

            return html;

        }
    }
}
