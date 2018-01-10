using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DeviceLogCSVToJson
{
    class ObjectToJsonConverter : IConverter
    {

        public List<BasicFullStructure> BasicJsonStructureList { get; set; }
        public List<ComplexFullStructure> ComplexJsonStructureList { get; set; }
        public Stream stream;

        public ObjectToJsonConverter(List<BasicFullStructure> BasicJsonStructureList, List<ComplexFullStructure> ComplexJsonStructureList)
        {
            this.BasicJsonStructureList = BasicJsonStructureList;
            this.ComplexJsonStructureList = ComplexJsonStructureList;
            this.stream = File.Create(ConstantData.JsonFileName);
        }

        public void Convert()
        {
            DataContractJsonSerializer basicJsonSerializer = new DataContractJsonSerializer(typeof(BasicFullStructure));
            DataContractJsonSerializer complexJsonSerializer = new DataContractJsonSerializer(typeof(ComplexFullStructure));
            
            SerializeDataFromList(BasicJsonStructureList, basicJsonSerializer);
            SerializeDataFromList(ComplexJsonStructureList, complexJsonSerializer);

        }

        private void SerializeDataFromList<StructureType>(List<StructureType> structuresList, 
            DataContractJsonSerializer serializer)
        {
            foreach (StructureType structure in structuresList)
            {
                serializer.WriteObject(stream, structure);
                AddSeparator();
            }
        }

        private void AddSeparator()
        {
            string newLine = "," + Environment.NewLine; 
            byte[] bytes = new UTF8Encoding(true).GetBytes(newLine);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
