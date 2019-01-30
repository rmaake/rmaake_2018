using BaseAPI.Models.Internal.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models.Internal.Clients
{
    public class ClientFeedback
    {
        public int ClientFeedbackId { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string VoiceNotePath { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int? TimelineId { get; set; }
        public int ClientContactInfoId { get; set; }
        public virtual ClientContactInfo Client { get; set; }
        
        public virtual List<FeedbackComment> Comments { get; set; }
    }
}
