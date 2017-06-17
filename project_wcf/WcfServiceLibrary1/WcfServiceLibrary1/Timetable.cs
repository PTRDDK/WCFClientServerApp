using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    [DataContract]
    public class Timetable
    {

        [DataMember]
        public string startCity { get; set; }

        [DataMember]
        public DateTime startTime { get; set; }

        [DataMember]
        public string endCity { get; set; }

        [DataMember]
        public DateTime endTime { get; set; }

        public Timetable(string startCity, DateTime startTime, string endCity, DateTime endTime)
        {
            this.startCity = startCity;
            this.startTime = startTime;
            this.endCity = endCity;
            this.endTime = endTime;
        }
    }
}
