﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain.DomainModels;
using Tickets.Repository.Interface;
using Tickets.Service.Interface;

namespace Tickets.Service.Implementation
{
    public class BackgroundEmailSender : IBackgroundEmailSender
    {
        private readonly IEmailService _emailService;
        private readonly IRepository<EmailMessage> _mailRepository;

        public BackgroundEmailSender(IEmailService emailService, IRepository<EmailMessage> mailRepository)
        {
            _emailService = emailService;
            _mailRepository = mailRepository;
        }

        public async Task DoWork()
        {
            await _emailService.SendEmails(_mailRepository.GetAll().Where(z => z.Status != true).ToList());
        }
    }
}
