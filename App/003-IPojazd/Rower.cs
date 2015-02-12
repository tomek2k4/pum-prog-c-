using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Rower : IPojazd
    {

        decimal _przejechane;

        public decimal Przejechane
        {
            get { return _przejechane; }
            set { _przejechane = value; }
        }

        public decimal IloscPaliwa
        {
            get { return 0; }
        }

        public void Jedz(decimal kilometry)
        {
            Przejechane += kilometry;
        }

        public void Tankuj(decimal ilos, Paliwo paliwo)
        {
            throw new NotSupportedException();
        }
    }
}
