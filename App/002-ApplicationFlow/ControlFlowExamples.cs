using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class ControlFlowExamples
    {

        /// <summary>
        /// This method should return true
        /// if the the second in the dateTime parameter
        /// is even.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>true if 'second' part of date is even</returns>
        public bool EvenSecond(DateTime dateTime)
        {
            if ((int)dateTime.Second % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method prints numbers from 1 to n
        /// in different lines
        /// </summary>
        /// <param name="n"></param>
        /// <param name="writer"></param>
        public void FromOneToN(int n, IWriter writer)
        {
            for (int i = 1; i <= n; ++i)
            {
                writer.WriteLine(i);
            }
        }

        /// <summary>
        /// Returns the name of the day of week
        /// For 1: "MON"
        /// 2: "TUE"
        /// 3: "WED"
        /// 4: "THR"
        /// 5: "FRI"
        /// 6: "SAT"
        /// 7: "SUN"
        /// "" for other values
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public string DayName(int dayOfWeek)
        {
            String s = "";
            switch (dayOfWeek)
            {
                case 1:
                    s = "MON";
                    break;
                case 2:
                    s = "TUE";
                    break;
                case 3:
                    s = "WED";
                    break;
                case 4:
                    s = "THR";
                    break;
                case 5:
                    s = "FRI";
                    break;
                case 6:
                    s = "SAT";
                    break;
                case 7:
                    s = "SUN";
                    break;
            }
            return s;
        }

        /// <summary>
        /// Writes the content of collection into the lines of writer
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="writer"></param>
        public void PrintAll(IEnumerable collection, IWriter writer)
        {
            foreach (var s in collection)
            {
                writer.WriteLine(s);
            }
        }

        /// <summary>
        /// Returns base 2 logarithm of x
        /// If x is not a power of 2 it should throw
        /// ArgumentException
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int log2(UInt32 x)
        {
            UInt32 a = x;
            int result = 0;

            if (1 == x)
                return 0;

            if (0 == x)
                throw new ArgumentException();

            while(a%2==0)
            {
                result++;
                a = a / 2;
            }

            if (a==1)
            {
                return result;
            }
            else
            {
                throw new ArgumentException();
            }

        }
    }
}
