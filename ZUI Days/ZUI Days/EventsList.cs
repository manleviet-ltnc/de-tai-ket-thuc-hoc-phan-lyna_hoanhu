using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZUI_Days
{
    class EventsList
    {
        List < Events > events ;
        public EventsList()
         {
              events = new List<Events>();
         }
        public void Setevents(Events events)
        {
             this.events.Add(events);
        }

        
           
        
    }
}
