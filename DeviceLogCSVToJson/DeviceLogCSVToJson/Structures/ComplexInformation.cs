using System.Runtime.Serialization;

namespace DeviceLogCSVToJson
{
    [DataContract]
    public class ComplexInformation
    {
        public ComplexInformation(string status, string connection, string tcp4)
        {
            this.status = status;
            this.connection = connection;
            this.TCP4 = tcp4;
        }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string connection { get; set; }

        [DataMember]
        public string TCP4 { get; set; }
    }
}