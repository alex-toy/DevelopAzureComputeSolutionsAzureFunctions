using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.IO;

namespace BlobTrigger
{
    public class GetBlob
    {
        [FunctionName("GetBlob")]
        public void Run([BlobTrigger("data/{name}", Connection = "storage_connection_string")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            StreamReader reader = new StreamReader(myBlob);

            log.LogInformation($"StreamReader and blob Name:{name} : {reader.ReadToEnd()}");

        }
    }
}
