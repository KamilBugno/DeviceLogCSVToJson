using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceLogCSVToJson
{
    class Converter : IConverter
    {
        public void Convert()
        {
            CSVToObjectConverter CSVToObjectConverter = new CSVToObjectConverter();
            CSVToObjectConverter.Convert();
            var basicJsonStructureList = CSVToObjectConverter.BasicJsonStructureList;
            var complexJsonStructureList = CSVToObjectConverter.ComplexJsonStructureList;
            ObjectToJsonConverter ObjectToJsonConverter = new ObjectToJsonConverter(basicJsonStructureList,
                                                            complexJsonStructureList);
            ObjectToJsonConverter.Convert();
        }
    }
}
