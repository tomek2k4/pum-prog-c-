using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figury
{
    class Program
    {
        static void PrintPoleIPowieksz2(IFigura fig)
        {
            Console.WriteLine(fig.Pole);
            fig.Powieksz(2);
            Console.WriteLine(fig.Pole);
        }

        interface IDoSmth
        {
            void DoSmth();
        }

        interface IDoSmthElse
        {
            void DoSmth();
        }

        class Bazowa : IDoSmth, IDoSmthElse
        {
            public void metoda()
            {
                Console.WriteLine("Bazowa.Zwyczajna");
            }
            public virtual void metodaWirtualna()
            {
                Console.WriteLine("Bazowa.Wirtualna");
            }

            internal void DoSmth()
            {
                (this as IDoSmthElse).DoSmth();
            }

            void IDoSmth.DoSmth()
            {
                Console.WriteLine("IDoSmth.DoSth()");
            }

            void IDoSmthElse.DoSmth()
            {
                Console.WriteLine("IDoSmthElse.DoSth()");
            }
        }

        class Dziedziczaca : Bazowa
        {
            public new void metoda()
            {
                Console.WriteLine("Dziedziczaca.Zwyczajna");
            }

            public override sealed void metodaWirtualna()
            {
                Console.WriteLine("Dziedziczaca.Wirtualna");
            }
        }

        class trzeci : Dziedziczaca
        {
            public new void metodaWirtualna()
            {
                Console.WriteLine("trzeci.Wirtualna");
            }
        }

         

        static void Main(string[] args)
        {
            var k = new KoloJednostkowe();
            var p = new Prostokat { A = 2, B = 4 };
            PrintPoleIPowieksz2(k);

            PrintPoleIPowieksz2(p);

            //Bazowa b = new Bazowa();
            //Dziedziczaca d = new Dziedziczaca();
            
            //b.metoda();
            //b.metodaWirtualna();
            //d.metoda();
            //d.metodaWirtualna();

            //b = d;
            //b.metoda();
            //b.metodaWirtualna();

            //b = new trzeci();
            //b.metodaWirtualna();

            //b.DoSmth();
            //(b as IDoSmthElse).DoSmth();
            //(b as IDoSmth).DoSmth();
            
            Console.ReadKey();
        }
    }
}
