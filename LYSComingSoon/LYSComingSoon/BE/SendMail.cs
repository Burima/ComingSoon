﻿using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using LYSComingSoon.BE;

namespace LYSComingSoon.BE
{
    public class SendMail
    {
        public string SMTPUserName = ConfigurationManager.AppSettings.Get("SMTPUserName").ToString();
        public string SMTPPassword = ConfigurationManager.AppSettings.Get("SMTPPassword").ToString();
        public string SMTPServer = ConfigurationManager.AppSettings.Get("SMTPServer").ToString();
        public string AdminEmailAddress = ConfigurationManager.AppSettings.Get("AdminEmailAddress").ToString();

        //email 
        MailMessage message = new MailMessage();
        SmtpClient client = new SmtpClient();
        EmailMessageBody body = new EmailMessageBody();

        public bool SendMailToAdmin(User user, out String ErrrorMsg, string messagebodyPath)
        {

            ErrrorMsg = String.Empty;
            
            //MailMessage message = new MailMessage();
            //SmtpClient client = new SmtpClient();
            //EmailMessageBody body = new EmailMessageBody();

            try
            {

                message.From = new MailAddress(user.contact_email, user.first_name);
                message.To.Add(new MailAddress(AdminEmailAddress));           

                message.Subject = user.first_name+" Contacted You";
                message.IsBodyHtml = true;
                message.Body =body.CreateBody(user,messagebodyPath);
                client.Send(message);

                return true;
            }

            catch (Exception exception)
            {

                ErrrorMsg = exception.Message;
                return false;
            }
            
            
        }

        public bool SendSubscriptionMail(string subscribe_email, out String ErrrorMsg)
        {
            ErrrorMsg = String.Empty;
            try
            {

                message.From = new MailAddress(subscribe_email, subscribe_email);
                message.To.Add(new MailAddress(AdminEmailAddress));

                message.Subject = subscribe_email + " Subscribed You";
                message.IsBodyHtml = true;
                message.Body = "Hi Admin,<br/><br/>"+subscribe_email+" Subscribed for Your Application <br/<br/><br/>Regards,<br/>LYSAdmin";
                client.Send(message);

                return true;
            }

            catch (Exception exception)
            {

                ErrrorMsg = exception.Message;
                return false;
            }


        }
    }
}