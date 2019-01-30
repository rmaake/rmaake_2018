using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Employees;

namespace BaseAPI.Models.Internal.Clients
{
    public class FeedbackComment
    {
        public int FeedbackCommentId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int ClientFeedbackId { get; set; }
        public int? ClientContactInfoId { get; set; }
        public int? EmployeeId { get; set; }
        public virtual ClientContactInfo Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ClientFeedback Feedback { get; set; }
    }
}
