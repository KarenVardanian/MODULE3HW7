using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StyleCop.FileService;

namespace StyleCop
{
    public class Starter
    {
        private readonly Actions _action = new Actions();
        private readonly Logger _logger = new Logger();
        private static Semaphore sem = new Semaphore(1, 1);
        private readonly string _n = "N.txt";
        public async void Run(double n)
        {
            var rnd = new Random();
            var result = new Result();
            var b = " ";
            StringBuilder stringBuilder = new StringBuilder();
            var c = " ";
            _logger.StartStream2();

            _logger.Handler += _logger.WriteToFile2;
            for (var i = 1; i < n; i++)
            {
                var log = $"{DateTime.UtcNow}:";

                switch (rnd.Next(3))
                {
                    case 0:
                        b = log + $"Start method: {nameof(_action.Method_1)}\n";
                        break;
                    case 1:
                        b = log + $"Skipped logic in method: {nameof(_action.Method_2)}\n";
                        break;
                    case 3:
                        b = log + $"Action failed by a reason: {result.ErrorMessage}\n";
                        break;
                }

                c += b.ToString();
                if (i % 5 == 0)
                {
                    Console.WriteLine(c);
                    _logger.Handler?.Invoke("\n---------------------------------------------------\n");
                    _logger.Handler?.Invoke(c);
                }
            }

            await _logger.CloseStream();
        }

        public int GetN()
        {
            var number = 0;

            using (StreamReader sr = new StreamReader(_n))
            {
                string line = sr.ReadLine();
                number = Convert.ToInt32(line);
                Console.WriteLine(number);
            }

            return number;
        }
    }
}
