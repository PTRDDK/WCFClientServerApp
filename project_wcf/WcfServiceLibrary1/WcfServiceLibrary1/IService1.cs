using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę interfejsu „IService1” w kodzie i pliku konfiguracji.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Timetable> getAllConnections();

        [OperationContract]
        void addConnection(string startCity, DateTime startTime, string endCity, DateTime endTime);

        [OperationContract]
        [FaultContract(typeof(CityException))]
        List<Timetable> getAllConnectionsFromCity(string startCityName, string endCityName, DateTime currentTime);

        [OperationContract]
        [FaultContract(typeof(CityException))]
        List<TimetableCrossed> getAllCrossedConnectionsFromCity(string startCityName, string endCityName, DateTime currentTime);
    }
}
