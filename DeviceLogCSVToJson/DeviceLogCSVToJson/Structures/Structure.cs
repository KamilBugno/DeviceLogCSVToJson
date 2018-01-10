using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DeviceLogCSVToJson.Structures
{
    [DataContract]
    class Structure
    {
        [DataMember]
        public string _key { get; set; }

        [DataMember]
        public string device_SN { get; set; }

        [DataMember]
        public string date { get; set; }

        [DataMember]
        public string type { get; set; }

        [DataMember]
        public string source { get; set; }
    }
}
