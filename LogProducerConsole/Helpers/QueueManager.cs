using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace LogProducerConsole.Helpers
{
    public class QueueManager
    {
    
        public static void SendMessageToQueue(string queue_name, string queue_message)
        {
           

            CloudStorageAccount storageAccount;
            storageAccount = CloudStorageAccount.Parse($"DefaultEndpointsProtocol=https;AccountName={StorageAccountConfig.myStorageAccount};AccountKey={StorageAccountConfig.myStorageAccountKey};");
            CloudQueueClient queueClient;
            queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(queue_name);
            CloudQueueMessage message = new CloudQueueMessage(queue_message);
            queue.AddMessage(message);
            
        }

    }
}