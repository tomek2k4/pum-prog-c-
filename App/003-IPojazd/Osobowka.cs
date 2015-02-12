using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Osobowka : PojazdMechaniczny, IKlimatyzowany
    {
        bool _klimatyzacjaWlaczona;

        public Osobowka(decimal spalanieNa100, decimal pojemnoscBaku) 
            : base(App.Paliwo.Benzyna,spalanieNa100)
        {

        }

        public bool JestWlaczona
        {
            get
            {
                return _klimatyzacjaWlaczona;
            }
            set
            {
                _klimatyzacjaWlaczona = value;
            }
        }
    }
}
