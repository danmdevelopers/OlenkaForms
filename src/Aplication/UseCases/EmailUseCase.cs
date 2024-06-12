using OlenkaForms.src.Aplication.Ports.Primary;
using OlenkaForms.src.Aplication.Ports.Secondary;
using OlenkaForms.src.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlenkaForms.src.Aplication.UseCases
{
    public class EmailUseCase : IHandleEmail
    {

        private readonly IMappingEmail _email;


        public EmailUseCase(IMappingEmail email)
        {
            _email = email;
        }



        public Task<EmailResponse> GetServerSMTP()
        {
            return _email.GetServerSMTP();
        }
    }
}
