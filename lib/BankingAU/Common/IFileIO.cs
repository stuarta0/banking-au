using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Banking.AU.Common
{
    public interface IFileIO<T>
        where T : class
    {
        T Read(string filename);
        T Read(TextReader stream);

        void Write(string filename, T file);
        void Write(TextWriter stream, T file);
    }
}
