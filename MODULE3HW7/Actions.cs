using System;
using System.Threading.Tasks;

namespace StyleCop
{
    public class Actions
    {
        private readonly Logger _logger = new Logger();
        public async Task<Result> Method_1()
        {
            _logger.LogInfo($"Start method: {nameof(Method_1)}");
            return await Task.Run(() => new Result() { Status = true });
        }

        public async Task<Result> Method_2()
        {
            _logger.LogWarning($"Skipped logic in method: {nameof(Method_2)}");
            return await Task.Run(() => new Result() { Status = true });
        }

        public async Task<Result> Method_3()
        {
            return await Task.Run(() => new Result() { ErrorMessage = "I broke a logic" });
        }
    }
}
