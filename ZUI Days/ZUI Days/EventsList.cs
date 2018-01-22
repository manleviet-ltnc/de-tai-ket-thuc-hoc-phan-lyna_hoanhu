using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZUI_Days
{
    public class EventsList
    {
        public List<Events> events = new List<Events>();

        public void AddEvent(Events events)
        {
            this.events.Add(events);
        }
    }
}