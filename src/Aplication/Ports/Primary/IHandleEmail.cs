using OlenkaForms.src.Domain.Entities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlenkaForms.src.Aplication.Ports.Primary
{
    public interface IHandleEmail
    {
        Task<EmailResponse> GetServerSMTP();
    }
}
