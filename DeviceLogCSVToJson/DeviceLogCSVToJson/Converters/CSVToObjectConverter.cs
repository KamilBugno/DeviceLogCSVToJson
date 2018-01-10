using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceLogCSVToJson
{
    class CSVToObjectConverter : IConverter
    {
        public List<BasicFullStructure> BasicJsonStructureList{ get; set; }
        public List<ComplexFullStructure> ComplexJsonStructureList { get; set; }

        public CSVToObjectConverter()
        {
            BasicJsonStructureList = new List<BasicFullStructure>();
            ComplexJsonStructureList = new List<ComplexFullStructure>();
        }

        public void Convert()
        {
            using (var reader = new StreamReader(ConstantData.CSVfileName))
            {
                if (reader.EndOfStream)
                    return;

                SkipHeader(reader);

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (IsBasicStructure(values))
                    {
                        BasicJsonStructureList.Add(CreateBasicStructure(values));
                    }
                    else
                    {
                        ComplexJsonStructureList.Add(CreateComplexStructure(values));
                    }
                }
            }
        }

        private BasicFullStructure CreateBasicStructure(string[] values)
        {
            BasicFullStructure basicJsonStructure = new BasicFullStructure();
            basicJsonStructure._key = values[0];
            basicJsonStructure.device_SN = values[1];
            basicJsonStructure.date = values[2];
            basicJsonStructure.type = values[3];
            basicJsonStructure.source = values[4];
            basicJsonStructure.information = values[5];
            return basicJsonStructure;
        }

        private ComplexFullStructure CreateComplexStructure(string[] values)
        {
            ComplexFullStructure complexJsonStructure = new ComplexFullStructure();
            complexJsonStructure._key = values[0];
            complexJsonStructure.device_SN = values[1];
            complexJsonStructure.date = values[2];
            complexJsonStructure.type = values[3];
            complexJsonStructure.source = values[4];
            complexJsonStructure.information = new ComplexInformation(values[6], values[7], values[8]);
            return complexJsonStructure;
        }

        private void SkipHeader(StreamReader reader)
        {
            reader.ReadLine();
        }

        private bool IsBasicStructure(string[] values)
        {
            return values[5].Length != 0 &&
                values[6].Length == 0 &&
                values[7].Length == 0 &&
                values[8].Length == 0;
        }
    }
}
