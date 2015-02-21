using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Osobowka : PojazdMechaniczny, IKlimatyzowany
    {
        bool    _klimatyzacjaWlaczona;
        decimal _pojemnosc; 

        public Osobowka(decimal spalanieNa100, decimal pojemnoscBaku) 
            : base(App.Paliwo.Benzyna,spalanieNa100)
        {
            _pojemnosc = pojemnoscBaku;
        }

        public new void Tankuj(decimal ilosc, Paliwo paliwo)
        {
            if( Paliwo + ilosc > _pojemnosc)
            {
                ilosc = _pojemnosc - Paliwo;
            }
            base.Tankuj(ilosc, paliwo);
        }

        public bool Klimatyzacja
        {
            get
            {
                return _klimatyzacjaWlaczona;
            }
            set
            {
                _klimatyzacjaWlaczona = value;
                if(value == true)
                {
                    base._spalanieNa100 += 1;
                }
                else
                {
                    base._spalanieNa100 -= 1;
                }
            }
        }

        public decimal Pojemnosc
        {
            get { return _pojemnosc; }
        }
    }
}
