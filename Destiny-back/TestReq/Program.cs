using System;
using System.Net.Http;

namespace TestReq
{
    class Program
    {
        static void Main(string[] args)
        {

            //Class1 class1 = new Class1();
            //class1.Start();
            GetEntity getEntity = new GetEntity();
            getEntity.Start();
            Console.ReadKey();
            
        }
    }
}
