using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public interface IZwierze
    {
        void Jedz(decimal ilosc);
        void Traw(decimal ilosc);

        bool Glodny { get; }
    }
}
