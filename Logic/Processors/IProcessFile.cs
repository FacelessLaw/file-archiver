using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiedPiper
{
    interface IProcessFile
    {
        string ProcessExecute(string fileName);
        string BackProcessExecute(string fileName);
    }
}
