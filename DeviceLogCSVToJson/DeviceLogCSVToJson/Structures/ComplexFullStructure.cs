using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DeviceLogCSVToJson
{
    [DataContract]
    class ComplexFullStructure : Structures.Structure
    {
        [DataMember]
        public ComplexInformation information { get; set; }
    }
}
