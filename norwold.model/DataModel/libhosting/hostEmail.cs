using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;

namespace DataModel.libHosting
{
    public class hostEmail
    {
        private static string uname = "openworldthegame@gmail.com";
        private static string pword = "However66$";
        private static string server = "smtp.gmail.com";
        
        protected SmtpClient MailClient;
        protected bool useSSL;
        protected string Username;
        protected string Password;
        protected MailAddress From;


        
        public hostEmail() {
            MailClient = new SmtpClient(server);
            MailClient.EnableSsl = true;
            
            MailClient.Port = 587;
            MailClient.Credentials = new NetworkCredential(uname, pword);
            // MailClient.UseDefaultCredentials = true;
            From = new MailAddress(uname);
        }



        public bool SendMessage(string to, string subject, string body) {
            bool res = true;
            Debug.Print("Send Message called to:" + to + " \nSubject" + subject + " \nBody" + body);
            try
            {
                MailMessage Msg = new MailMessage();
                Msg.From = this.From;
                Msg.To.Add(new MailAddress(to));
                Msg.Subject = subject;
                Msg.Body = body;
                MailClient.Send(Msg);
                Debug.Print("Sent OK");
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
                res = false;
            }
            return res;
        }



    }
}
