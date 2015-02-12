using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figury
{
    class Prostokat : Figura
    {

        public decimal A { get; set; }
        public decimal B { get; set; }




        protected override void ZrobPowiekszenie(decimal multi)
        {
            A *= (decimal)Math.Sqrt((double)multi);
            B *= (decimal)Math.Sqrt((double)multi);

        }

        protected override decimal WyliczPole()
        {
            return A*B;
        }
    }
}
