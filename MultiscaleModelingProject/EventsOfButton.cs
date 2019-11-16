using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelingProject
{
    public class EventsOfButton
    {

        public delegate void BoardClickLogic(int x, int y);
        public delegate void OnLogic();
        public delegate void OffLogic();

    }
}
