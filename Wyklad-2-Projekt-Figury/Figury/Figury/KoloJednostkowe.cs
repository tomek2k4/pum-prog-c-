using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figury
{
    class KoloJednostkowe : Kolo
    {
        public KoloJednostkowe() : base(1)
        {
            
        }

        protected override void ZrobPowiekszenie(decimal multi)
        {
            throw new NotSupportedException(
                "Nie mozna powiekszac kola jednostkowego");
        }
    }
}
