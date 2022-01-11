using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleCop.Interface
{
    public interface IFileService
    {
        Task WriteToFile(StreamWriter streamwriter, string message);
    }
}
