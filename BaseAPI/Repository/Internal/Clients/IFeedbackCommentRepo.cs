using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseAPI.Models.Internal.Clients;

namespace BaseAPI.Repository.Internal.Clients
{
    public interface IFeedbackCommentRepo
    {
        IEnumerable<FeedbackComment> getAll();
        FeedbackComment getById(int id);
        bool add(FeedbackComment feedback);
        bool update(int id, FeedbackComment feedback);
        bool delete(int id);
    }
}
