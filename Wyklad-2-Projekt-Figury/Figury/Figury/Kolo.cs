using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Figury
{
    class Kolo : Figura
    {

        public Kolo(int promien)
        {
            Promien = promien;
        }

        private decimal _promien;

        public decimal Promien
        {
            get { return _promien; }
            set { _promien = value;  }
        }   

        protected override decimal WyliczPole()
        {
            return (decimal)Math.PI * Promien * Promien;
        }

        protected override void ZrobPowiekszenie(decimal multi)
        {
            Promien *= (decimal)Math.Sqrt((double)multi);
        }
    }
}
