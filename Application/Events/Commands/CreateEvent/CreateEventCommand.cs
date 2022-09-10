using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApplication.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<string>
    {
        public string Address { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
    }
}
