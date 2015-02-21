using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public abstract class PojazdMechaniczny : IPojazd
    {
        App.Paliwo _rodzajPaliwa;
        protected decimal _spalanieNa100;
        private decimal _iloscPaliwa = 0;
        private decimal _przejechane = 0;

        protected PojazdMechaniczny(Paliwo paliwo, decimal spalanieNa100)
        {
            _rodzajPaliwa = paliwo;
            if(spalanieNa100 <= 0)
            {
                throw new ArgumentException();
            }
            _spalanieNa100 = spalanieNa100;

        }

        public void Jedz(decimal kilometry)
        {

            decimal spalonePaliwo = _spalanieNa100 * kilometry / 100;
            if(spalonePaliwo>Paliwo)
            {
                Przejechane += Paliwo * 100 / _spalanieNa100;
                Paliwo = 0;
            }
            else
            {
                Przejechane += kilometry;
                Paliwo -= spalonePaliwo;
            }
            
        }

        public void Tankuj(decimal ilosc, Paliwo paliwo)
        {
            
            if(paliwo !=_rodzajPaliwa)
            {
                throw new ArgumentException();
            }
            else
            {
                Paliwo += ilosc;
            }
        }

        public decimal Przejechane
        {
            get { return _przejechane; }
            private set { _przejechane = value; }
        }

        public decimal Paliwo
        {
            get { return _iloscPaliwa; }
            private set {_iloscPaliwa = value;}
        }


    }
}
