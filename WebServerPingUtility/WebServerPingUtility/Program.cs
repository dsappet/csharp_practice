using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;                    // Added
using System.Net.NetworkInformation; // Added
using System.Threading;              // Added

namespace WebServerPingUtility
{
    class Program
    {
        
        static void Ping(Object stateInfo)
        {
            Ping pinger = new Ping();
            var StartPing = pinger.Send(IPAddress.Loopback);
            Console.WriteLine(StartPing.Status); //Reply ICMP echo request
        }

        static void Main(string[] args)
        {
            int StartTime = 0; //Start at midnight
            int StopTime = 4;  //Stop at 4AM

            while (true)
            {

                while (DateTime.Now.Hour <= StartTime || DateTime.Now.Hour <= StopTime) //Initialize between StartTime/StopTime
                {
                    TimerCallback callback = new TimerCallback(Ping);
                    Timer timer = new Timer(callback, null, 0, 300000); //Run every 5 minutes
                    for (; ; ) { Thread.Sleep(100); }                   //Sleep 100ms; reduce CPU usage
                }
            }
        }

    }
}
