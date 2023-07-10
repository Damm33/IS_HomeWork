using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using NETCore.MailKit.Core;
using NETCore.MailKit.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domain;
using Tickets.Domain.DomainModels;
using Tickets.Repository.Interface;

namespace Tickets.Services.Implementation
{
    public class EmailService : IEmailService
    {
        public readonly EmailSettings _settings;
        public readonly IRepository<EmailMessage> _mailRepository;
        public EmailService(EmailSettings settings, IRepository<EmailMessage> mailRepository)
        {
            _settings = settings;
            _mailRepository = mailRepository;
        }

        public void Send(string mailTo, string subject, string message, bool isHtml = false, SenderInfo sender = null)
        {
            throw new NotImplementedException();
        }

        public void Send(string mailTo, string subject, string message, Encoding encoding, bool isHtml = false, SenderInfo sender = null)
        {
            throw new NotImplementedException();
        }

        public void Send(string mailTo, string mailCc, string mailBcc, string subject, string message, bool isHtml = false, SenderInfo sender = null)
        {
            throw new NotImplementedException();
        }

        public void Send(string mailTo, string mailCc, string mailBcc, string subject, string message, Encoding encoding, bool isHtml = false, SenderInfo sender = null)
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(string mailTo, string subject, string message, bool isHtml = false, SenderInfo sender = null)
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(string mailTo, string subject, string message, Encoding encoding, bool isHtml = false, SenderInfo sender = null)
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(string mailTo, string mailCc, string mailBcc, string subject, string message, bool isHtml = false, SenderInfo sender = null)
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(string mailTo, string mailCc, string mailBcc, string subject, string message, Encoding encoding, bool isHtml = false, SenderInfo sender = null)
        {
            throw new NotImplementedException();
        }

        public async Task SendEmails(List<EmailMessage> allMails)
        {

            List<MimeMessage> messages = new List<MimeMessage>();

            foreach (var item in allMails)
            {
                var emailMessage = new MimeMessage
                {
                    Sender = new MailboxAddress(_settings.SendersName, _settings.SmtpUserName),
                    Subject = item.Subject
                };

                emailMessage.From.Add(new MailboxAddress(_settings.EmailDisplayName, _settings.SmtpUserName));

                emailMessage.Body = new TextPart(TextFormat.Plain) { Text = item.Content };

                emailMessage.To.Add(new MailboxAddress(item.MailTo));

                item.Status = true;
                _mailRepository.Update(item);

                messages.Add(emailMessage);
            }



            try
            {
                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    var socketOption = _settings.EnableSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto;
                    await smtp.ConnectAsync(_settings.SmtpServer, _settings.SmtpServerPort, socketOption);

                    if (!string.IsNullOrEmpty(_settings.SmtpUserName))
                    {
                        await smtp.AuthenticateAsync(_settings.SmtpUserName, _settings.SmtpPassword);
                    }

                    foreach (var item in messages)
                    {
                        await smtp.SendAsync(item);
                    }

                    await smtp.DisconnectAsync(true);
                }

            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }
    }
}
