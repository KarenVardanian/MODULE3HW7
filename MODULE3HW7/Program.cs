using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using StyleCop.FileService;

namespace StyleCop
{
   public class Program
    {
        private static object locker = new object();

        public static void Main(string[] args)
        {
            Task.Run(() => Console.WriteLine(" "));
            Starter starter = new Starter();
            int n = starter.GetN();
            starter.Run(n);
            lock (locker)
            {
                Task.Delay(1000).Wait();
            }

            starter.Run(n);
        }
    }
}
