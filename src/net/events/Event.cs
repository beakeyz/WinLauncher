using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLauncher.src.net.events
{
    public class Event
    {
        public long id;

        public long getId()
        {
            return id;
        }

        public void setId(long pId)
        {
            this.id = pId;
        }
    }
}
