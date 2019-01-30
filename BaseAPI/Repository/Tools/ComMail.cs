using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using BaseAPI.Models.Internal;

namespace BaseAPI.Repository.Tools
{
    public class ComMail : IComMail
    {
        private IMailService _mail;

        public ComMail(IMailService mail)
        {


            _mail = mail;
        }

        public void SendMailToPar(ComMails data)
        {
            this.sendMail(data);
        }

        /// <summary>
        /// This method gets a teamsId, finds the nearest participant that isn't
        /// team leader and that participant's Id is returned
        /// </summary>
        /// <param name="id">TeamsId</param>
        /// <returns>ParticipantsId</returns>
        private void sendMail(ComMails comEmails)
        {
            //var team = _context.Teams.Where(opt => opt.TeamsId == part.TeamsId).SingleOrDefault();
            var body = string.Empty;

            //using streamreader for reading the htmltemplate   

            using (StreamReader reader = new StreamReader("wwwroot/CredentialTemplate.html"))

            {

                body = reader.ReadToEnd();

            }

            //body = body.Replace("{Name}", part.FirstName + " " + part.LastName); //replacing the required things  

            body = body.Replace("{Subject}", comEmails.Subject);

            body = body.Replace("{Signature}", "NRP - HR");

            body = body.Replace("{Message}", comEmails.Message);
            for (var i = 0; i < comEmails.Email.Count; i++)
            {
                _mail.SendMail(comEmails.Email[i], body, comEmails.Subject);
            }
        }
    }
}
