using ConsoleApp1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IService1 server = new Service1Client();

            string startCity = "A";
            DateTime startTime = new DateTime(2017, 5, 28, 12, 0, 0);
            string endCity = "B";
            DateTime endTime = new DateTime(2017, 5, 28, 13, 0, 0);

            string startCity1 = "A";
            DateTime startTime1 = new DateTime(2017, 5, 29, 12, 0, 0);
            string endCity1 = "B";
            DateTime endTime1 = new DateTime(2017, 5, 29, 13, 0, 0);

            string startCity2 = "A";
            DateTime startTime2 = new DateTime(2017, 5, 27, 12, 0, 0);
            string endCity2 = "B";
            DateTime endTime2 = new DateTime(2017, 5, 27, 13, 0, 0);

            string startCity3 = "A";
            DateTime startTime3 = new DateTime(2017, 5, 27, 12, 30, 0);
            string endCity3 = "C";
            DateTime endTime3 = new DateTime(2017, 5, 27, 13, 30, 0);

            string startCity4 = "A";
            DateTime startTime4 = new DateTime(2017, 5, 28, 12, 30, 0);
            string endCity4 = "C";
            DateTime endTime4 = new DateTime(2017, 5, 28, 13, 30, 0);

            string startCity5 = "A";
            DateTime startTime5 = new DateTime(2017, 5, 29, 12, 30, 0);
            string endCity5 = "C";
            DateTime endTime5 = new DateTime(2017, 5, 29, 13, 30, 0);

            string startCity6 = "C";
            DateTime startTime6 = new DateTime(2017, 5, 28, 13, 40, 0);
            string endCity6 = "B";
            DateTime endTime6 = new DateTime(2017, 5, 28, 14, 30, 0);

            string startCity7 = "C";
            DateTime startTime7 = new DateTime(2017, 5, 29, 13, 40, 0);
            string endCity7 = "B";
            DateTime endTime7 = new DateTime(2017, 5, 29, 14, 30, 0);

            string startCity8 = "C";
            DateTime startTime8 = new DateTime(2017, 5, 27, 13, 40, 0);
            string endCity8 = "B";
            DateTime endTime8 = new DateTime(2017, 5, 27, 14, 30, 0);


            server.addConnection(startCity, startTime, endCity, endTime);
            server.addConnection(startCity1, startTime1, endCity1, endTime1);
            server.addConnection(startCity2, startTime2, endCity2, endTime2);
            server.addConnection(startCity3, startTime3, endCity3, endTime3);
            server.addConnection(startCity4, startTime4, endCity4, endTime4);
            server.addConnection(startCity5, startTime5, endCity5, endTime5);
            server.addConnection(startCity6, startTime6, endCity6, endTime6);
            server.addConnection(startCity7, startTime7, endCity7, endTime7);
            server.addConnection(startCity8, startTime8, endCity8, endTime8);

            int i = 1;
            Console.WriteLine("ALL CONNECTIONS:");
            Timetable[] listOfConnections = server.getAllConnections();
            foreach(Timetable timetable in listOfConnections)
            {
                Console.WriteLine(i + "." + timetable.startCity + " " + timetable.startTime + " " + timetable.endCity + " " + timetable.endTime);
                i++;
            }

            try
            {
                int l = 1;
                DateTime testDate3 = new DateTime(2017, 5, 30, 11, 59, 0);
                Console.WriteLine(" ");
                Console.WriteLine("EMPTY LIST TEST: ");
                Timetable[] listOfStraightConnections3 = server.getAllConnectionsFromCity("B", "A", testDate3);
                Console.WriteLine("List size: " + listOfStraightConnections3.Length);
            }
            catch (FaultException<CityException> e)
            {
                Console.WriteLine(e.Detail.ThrowException);
            }

            try
            {
                int j = 1;
                DateTime testDate = new DateTime(2017, 5, 28, 11, 59, 0);
                Console.WriteLine(" ");
                Console.WriteLine("TO ONE CITY STRAIGHT: ");
                Timetable[] listOfStraightConnections = server.getAllConnectionsFromCity("A", "B", testDate);
                foreach (Timetable timetable in listOfStraightConnections)
                {
                    Console.WriteLine(j + "." + timetable.startCity + " " + timetable.startTime + " " + timetable.endCity + " " + timetable.endTime);
                    j++;
                }
            }
            catch(FaultException<CityException> e)
            {
                Console.WriteLine(e.Detail.ThrowException);
            }

            try
            {
                int k = 1;
                DateTime testDate2 = new DateTime(2017, 5, 28, 11, 59, 0);
                Console.WriteLine(" ");
                Console.WriteLine("TO ONE CITY CROSSED: ");
                TimetableCrossed[] listOfCrossedConnections = server.getAllCrossedConnectionsFromCity("A", "B", testDate2);
                foreach (TimetableCrossed timetableCrossed in listOfCrossedConnections)
                {
                    Console.WriteLine(k + "." + timetableCrossed.firstConnection.startCity + " " + timetableCrossed.firstConnection.startTime + " " + timetableCrossed.firstConnection.endCity + " " + timetableCrossed.firstConnection.endTime + " TRAIN CHANGE\n\t" +
                        timetableCrossed.secondConnection.startCity + " " + timetableCrossed.secondConnection.startTime + " " + timetableCrossed.secondConnection.endCity + " " + timetableCrossed.secondConnection.endTime);
                    k++;
                }
            }
            catch (FaultException<CityException> e)
            {
                Console.WriteLine(e.Detail.ThrowException);
            }

            try
            {
                int l = 1;
                DateTime testDate = new DateTime(2017, 5, 28, 11, 59, 0);
                Console.WriteLine(" ");
                Console.WriteLine("ERROR TEST: ");
                Timetable[] listOfStraightConnections2 = server.getAllConnectionsFromCity("E", "E", testDate);
                foreach (Timetable timetable in listOfStraightConnections2)
                {
                    Console.WriteLine(l + "." + timetable.startCity + " " + timetable.startTime + " " + timetable.endCity + " " + timetable.endTime);
                    l++;
                }
            }
            catch (FaultException<CityException> e)
            {
                Console.WriteLine(e.Detail.ThrowException);
            }
            Console.ReadKey();
        }
    }
}
