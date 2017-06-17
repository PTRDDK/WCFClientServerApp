using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace WcfServiceLibrary1
{
    [DataContract]
    class CityException
    {
        private string exceptionMessage;

        public CityException(string exceptionMessage)
        {
            this.exceptionMessage = exceptionMessage;
        }

        [DataMember]
        public string ThrowException { get { return exceptionMessage; } set { exceptionMessage = value; } }
    }
}
