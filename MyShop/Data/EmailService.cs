using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using System;

namespace MyShop.Data
{
    public class EmailService
    {
        public void SendEmail(string messageBody)
        {
            MimeMessage message = new();
            message.From.Add(new MailboxAddress("Моя компания", "anufr8319@gmail.com")); //отправитель сообщения
            message.To.Add(new MailboxAddress("anufr8319@gmail.com")); //адресат сообщения
            message.Subject = "Новое сообщение"; //тема сообщения
            message.Body = new BodyBuilder() { HtmlBody = String.Format("<div>{0}</div>", messageBody) }.ToMessageBody(); //тело сообщения (так же в формате HTML)

            using (MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 25, false); //либо использум порт 465
                client.Authenticate("anufr8319@gmail.com", "22082007S"); //логин-пароль от аккаунта
                client.Send(message);

                client.Disconnect(true);
            }
        }
    }
}