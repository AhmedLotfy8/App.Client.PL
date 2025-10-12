using System.Net;
using System.Net.Mail;

namespace App.Client.PL.Helper {
    public class EmailSettings {

        public static bool SendEmail(Email email) {


            try {
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("soradoxd@gmail.com", "oasbjkpehnupdjyp");
                client.Send("soradoxd@gmail.com", email.To, email.Subject, email.Body);

                return true;

            }

            catch (Exception e) {
                return false;
            }

        }

    }
}
