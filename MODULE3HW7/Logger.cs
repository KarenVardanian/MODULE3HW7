using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using StyleCop.FileService;
using StyleCop.Interface;

namespace StyleCop
{
    public class Logger : IFileService
    {
        private readonly StringBuilder _logs;
        private readonly FileServices _fileServices = new FileServices();
        private StreamWriter _streamWriter;

        public Logger()
        {
            _logs = new StringBuilder();
        }

        public Func<string, Task> Handler { get; set; }
        public StreamWriter StreamWriter { get; set; }

        public string AllLogs => _logs.ToString();

        public Action<string> Action { get; set; }
        public async void LogInfo(string message)
        {
            await Task.Run(() => Log(LogType.Info, message));
            Console.WriteLine("LogInfo");
        }

        public async void LogError(string message)
        {
            await Task.Run(() => Log(LogType.Error, message));
            Console.WriteLine("LogError");
        }

        public async void LogWarning(string message)
        {
             await Task.Run(() => Log(LogType.Warning, message));
             Console.WriteLine("LogWarning");
        }

        public async Task Log(LogType type, string message)
        {
            var log = $"{DateTime.UtcNow}: {type.ToString()}: {message}";
            await Task.Run(() => _logs.AppendLine(log));

            // Task t = Task.Run(() => Console.WriteLine(log));
        }

        public async Task WriteToFile(StreamWriter streamWriter, string message)
        {
            await Task.Run(() => _streamWriter.WriteAsync(message));
            await Task.Run(() => Console.WriteLine("input"));
        }

        public async Task WriteToFile2(string message)
        {
            await Task.Run(() => _streamWriter.WriteAsync(message));

            // await Task.Run(() => Console.WriteLine("input"));
        }

        public async void StartStream2()
        {
            var filename = string.Format(
                 DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ss") + "..txt");
            var p = Directory.GetCurrentDirectory();
            _streamWriter = await _fileServices.CreateFileStream(filename);
        }

        public async Task StartStream()
        {
            var filename = string.Format(
                  DateTime.UtcNow.ToString("yyyy-MM-dd HH-mm-ss") + "..txt");
            var p = Directory.GetCurrentDirectory();

            await Task<StreamWriter>.Run(
                async () =>
                {
                    _streamWriter = await _fileServices.CreateFileStream(filename);

                    Console.WriteLine("StartStream");
                    return _streamWriter;
                });
        }

        public async Task CloseStream()
        {
            _streamWriter.AutoFlush = true;
            await Task.Run(() => _streamWriter.FlushAsync());
        }

        public Task Run()
        {
            return Task.Run(() => Console.WriteLine());
        }
    }
}
