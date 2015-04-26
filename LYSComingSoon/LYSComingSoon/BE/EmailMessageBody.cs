using System;
using LYSComingSoon.BE;

namespace LYSComingSoon.BE
{
    public class EmailMessageBody
    {
        public string CreateBody(User user, string messagebodyPath)
        {
            string message = System.IO.File.ReadAllText(messagebodyPath);
            message = message.Replace("#first_name", user.first_name);
            message = message.Replace("#last_name", user.last_name);
            message = message.Replace("#contact_email", user.contact_email);
            message = message.Replace("#contact_subject", user.contact_subject);
            message = message.Replace("#message", user.message);           

            return message.ToString();
        }
    }
}