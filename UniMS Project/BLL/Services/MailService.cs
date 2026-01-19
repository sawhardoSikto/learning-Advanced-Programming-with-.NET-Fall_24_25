using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace BLL.Services
{
    public class MailService
    {
        IConfiguration config;

        public MailService(IConfiguration config)
        {
            this.config = config;
        }

        public void SendProbationMail(string toEmail, string studentName, double cgpa)
        {
            var smtp = new SmtpClient
            {
                Host = config["EmailSettings:SmtpServer"],
                Port = int.Parse(config["EmailSettings:Port"]),
                EnableSsl = true,
                Credentials = new NetworkCredential(
                    config["EmailSettings:Username"],
                    config["EmailSettings:Password"]
                )
            };

            var mail = new MailMessage
            {
                From = new MailAddress(config["EmailSettings:From"]),
                Subject = "Academic Probation Notice",
                Body = $@"
                        Dear {studentName},

                        Your current CGPA is {cgpa}.
                        As it is below 2.50, you have been placed on ACADEMIC PROBATION.

                        Please consult your academic advisor.

                        Regards,
                        XYZ University"
            };

            mail.To.Add(toEmail);

            smtp.Send(mail);
        }
    }
}
