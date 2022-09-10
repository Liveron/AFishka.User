using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
    }
}
