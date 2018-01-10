using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DeviceLogCSVToJson
{
    class Program
    {
        static void Main(string[] args)
        {
            IConverter converter = new Converter();
            converter.Convert();
        }
    }
}
