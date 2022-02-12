using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusyAPI.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string WorkspaceId { get; set; }
        public string AccountId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
