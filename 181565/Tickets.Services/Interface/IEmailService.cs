using Tickets.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Service.Interface
{
    public interface IEmailService
    {
        Task SendEmails(List<EmailMessage> allMails);
    }
}
