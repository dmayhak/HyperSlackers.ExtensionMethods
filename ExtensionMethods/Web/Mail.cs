using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HyperSlackers.Extensions
{
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Sends the specified message using smtp setting from config file.
        /// </summary>
        /// <param name="message">The message.</param>
        public static void Send(this MailMessage message)
        {
            SmtpClient smtp = new SmtpClient();

            smtp.Send(message);
        }

        /// <summary>
        /// Sends the specified messages using smtp setting from config file.
        /// </summary>
        /// <param name="messages">The messages.</param>
        /// <param name="pauseBetweenMessages">The number of milliseconds to pause between messages.</param>
        public static void Send(this IEnumerable<MailMessage> messages, int delay)
        {
            SmtpClient smtp = new SmtpClient();

            foreach (MailMessage message in messages)
            {
                smtp.Send(message);

                if (delay >= 0)
                {
                    Thread.Sleep(delay);
                }
            }
        }
    }
}
