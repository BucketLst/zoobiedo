using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoobiedo.WebAPI.Helper;

namespace TestWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSerialize obj = new TestSerialize();
            obj.TestSerialization();
        }
    }
}
