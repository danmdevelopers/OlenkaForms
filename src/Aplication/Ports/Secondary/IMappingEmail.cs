using OlenkaForms.src.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlenkaForms.src.Aplication.Ports.Secondary
{
    public interface IMappingEmail
    {
        Task<EmailResponse> GetServerSMTP();
    }
}
