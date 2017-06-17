using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WcfServiceLibrary1
{
    [DataContract]
    public class TimetableCrossed
    {

        [DataMember]
        public Timetable firstConnection { get; set; }

        [DataMember]
        public Timetable secondConnection { get; set; }

        public TimetableCrossed( Timetable firstConnection, Timetable secondConnection)
        {
            this.firstConnection = firstConnection;
            this.secondConnection = secondConnection;
        }
    }
}
