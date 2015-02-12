using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public interface IPojazd
    {

        decimal Przejechane { get;}
        decimal IloscPaliwa  {get;}

        void Jedz(decimal kilometry);
        void Tankuj(decimal ilos, Paliwo paliwo);
    }
}
