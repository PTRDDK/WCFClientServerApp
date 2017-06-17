using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    public class Service1 : IService1
    {
        
        static List<Timetable> listOfConnections = new List<Timetable>();
        static List<Timetable> listOfConnectionsFromCity = new List<Timetable>();
        static List<Timetable> listOfConnectionsToDifferentCity = new List<Timetable>();
        static List<Timetable> listOfConnectionsToCityFromDifferentCity = new List<Timetable>();
        static List<TimetableCrossed> listOfCrossedConnections = new List<TimetableCrossed>();
        public List<Timetable> getAllConnections()
        {
            listOfConnections.Sort((x, y) => DateTime.Compare(x.startTime, y.startTime));
            return listOfConnections;
        }
        public void addConnection(string startCity, DateTime startTime, string endCity, DateTime endTime)
        {
            listOfConnections.Add(new Timetable(startCity, startTime, endCity, endTime));
        }

        public List<Timetable> getAllConnectionsFromCity(string cityName, string endCityName, DateTime currentTime)
        {
            if(listOfConnections.Exists(x => x.startCity == cityName) || listOfConnections.Exists(x => x.endCity == cityName))
            {
                if (listOfConnections.Exists(y => y.startCity == endCityName) || listOfConnections.Exists(y => y.endCity == endCityName))
                {
                    foreach (Timetable timetable in listOfConnections)
                    {
                        if (timetable.startCity == cityName)
                        {
                            int result = DateTime.Compare(timetable.startTime, currentTime);
                            if (result > 0)
                            {
                                if (timetable.endCity == endCityName)
                                {
                                    listOfConnectionsFromCity.Add(timetable);
                                }

                            }
                        }
                    }
                    listOfConnectionsFromCity.Sort((x, y) => DateTime.Compare(x.startTime, y.startTime));

                    return listOfConnectionsFromCity;
                }
                else
                {
                    throw new FaultException<CityException>(new CityException("City doesn't exist!"));
                }
            }
            else
            {
                throw new FaultException<CityException>(new CityException("City doesn't exist!"));
            }  
        }

        public List<TimetableCrossed> getAllCrossedConnectionsFromCity(string startCityName, string endCityName, DateTime currentTime)
        {
            if (listOfConnections.Exists(x => x.startCity == startCityName) || listOfConnections.Exists(x => x.startCity == endCityName))
            {
                if (listOfConnections.Exists(x => x.endCity == startCityName) || listOfConnections.Exists(x => x.endCity == endCityName))
                {
                    foreach (Timetable timetable in listOfConnections)
                    {
                        if (timetable.startCity == startCityName)
                        {
                            int result = DateTime.Compare(timetable.startTime, currentTime);
                            if (result > 0)
                            {
                                if (timetable.endCity != endCityName)
                                {
                                    listOfConnectionsToDifferentCity.Add(timetable);
                                }
                            }
                        }
                    }

                    foreach (Timetable timetable in listOfConnections)
                    {
                        if (timetable.startCity != startCityName)
                        {
                            int result = DateTime.Compare(timetable.startTime, currentTime);
                            if (result > 0)
                            {
                                if (timetable.endCity == endCityName)
                                {
                                    listOfConnectionsToCityFromDifferentCity.Add(timetable);
                                }
                            }
                        }
                    }

                    foreach (Timetable timetable1 in listOfConnectionsToDifferentCity)
                    {
                        foreach (Timetable timetable2 in listOfConnectionsToCityFromDifferentCity)
                        {
                            if (timetable1.endCity == timetable2.startCity)
                            {
                                int result = DateTime.Compare(timetable1.endTime, timetable2.startTime);
                                if (result < 0)
                                {
                                    TimetableCrossed timetableCrossed = new TimetableCrossed(timetable1, timetable2);
                                    listOfCrossedConnections.Add(timetableCrossed);
                                }
                            }
                        }
                    }

                    listOfCrossedConnections.Sort((x, y) => DateTime.Compare(x.firstConnection.startTime, y.firstConnection.startTime));

                    listOfCrossedConnections.Sort((x, y) => DateTime.Compare(x.secondConnection.startTime, y.secondConnection.startTime));


                    return listOfCrossedConnections;
                }
                else
                {
                    throw new FaultException<CityException>(new CityException("City doesn't exist!"));
                }
                }
            else
            {
                throw new FaultException<CityException>(new CityException("City doesn't exist!"));
            }
        }
    }
}
