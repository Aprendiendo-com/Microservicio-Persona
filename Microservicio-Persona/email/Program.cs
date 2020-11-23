using System;
using System.Net;
using System.Net.Mail;

namespace email
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string SendersAddress = "octaviojorge37@gmail.com";

            string ReceiversAddress = "octaviojorge37@gmail.com";

            const string SendersPassword = "octaguitarra98";

            const string subject = "Prueba";



            const string body = "<body style='margin: 0; padding: 0; '>" +
                "<div class='contenedor' style='background-color:red;'>" +
                "Hola" +
                "</div>" +
                "</body>";
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(SendersAddress, SendersPassword),
                    Timeout = 3000
                };

                MailMessage message = new MailMessage(SendersAddress, ReceiversAddress, subject, body);

                /*PARA AÑADIR TEXTO HTML*/
                message.IsBodyHtml = true;
                smtp.Send(message);
                Console.WriteLine("Se envió correctamente");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}
