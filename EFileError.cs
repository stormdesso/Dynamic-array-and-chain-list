using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class EFileError : Exception
    {
        public string FileName { get; private set; }
        public EFileError(string fileName)
        {
            FileName = fileName;
        }
    }
}
