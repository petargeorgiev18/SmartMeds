using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMeds.Data.Entities
{
    public class Hospital
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string City {  get; set; } = null!;
        public string Address { get; set; } = null!;
        public ICollection<Request> SentRequests { get; set; } = new List<Request>();
        public ICollection<Request> ReceivedRequests { get; set; } = new List<Request>();
    }
}
