using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Autobus : PojazdMechaniczny
    {
        public Autobus()
            : base(App.Paliwo.Olej, 20){}
    }
}
