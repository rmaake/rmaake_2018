using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseAPI.Models.Internal.Projects.Defaults
{
    public class DefaultType
    {
        public int DefaultTypeId { get; set; }
        public string Description { get; set; }

       public virtual List<Default> Default { get; set; }
    }
}
