using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StyleCop.Interface;

namespace StyleCop.FileService
{
    public class FileServices : IFileService
    {
        public async Task<StreamWriter> CreateFileStream(string path)
        {
            var fileInfo = new FileInfo(path);
            if (!fileInfo.Exists)
            {
                var newFile = fileInfo.Create();
                newFile.Close();
            }

            return await Task.Run(() => new StreamWriter(path, true));
     }

        public async Task WriteToFile(StreamWriter streamwriter, string message)
        {
            await Task.Run(() => streamwriter?.WriteLine("h"));
        }
    }
}
