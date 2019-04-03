using System;
using Newtonsoft.Json;

namespace LogProducerConsole
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
               string strLog=  JsonConvert.SerializeObject( Helpers.LogProducer.ProduceLogEvent(i+1));
                Helpers.QueueManager.SendMessageToQueue("logevents", strLog);
                Console.WriteLine($"Sending Message Queue: {strLog}");
            }
            Console.ReadKey();
        }
    }
}
