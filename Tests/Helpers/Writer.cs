using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using App;

namespace Tests.Helpers
{
    public class Writer : IWriter
    {
        public List<string> Strings = new List<string> {""}; 

        public void Write(object obj)
        {
            Strings[Strings.Count - 1] += obj.ToString();
        }

        public void WriteLine(object obj)
        {
            Write(obj);
            Strings.Add("");
        }

        public bool EqualsTo(params String[] strings)
        {
            return strings.Zip(strings, (s1, s2) => s1 == s2).All(b => b);
        }
    }
}
