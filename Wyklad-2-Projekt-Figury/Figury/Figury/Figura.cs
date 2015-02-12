using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figury
{
    abstract class Figura : IFigura
    {
        private decimal? _pole;
        public decimal Pole
        {
            get
            {
                if (!_pole.HasValue)
                {
                    _pole = WyliczPole();
                }

                return _pole.Value;
            }
        }

        protected abstract decimal WyliczPole();

        public void Powieksz(decimal multi)
        {
            ZrobPowiekszenie(multi);
            _pole = WyliczPole();
        }

        protected abstract void ZrobPowiekszenie(decimal multi);
    }
}
