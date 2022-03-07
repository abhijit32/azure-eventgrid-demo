using Azure.Messaging.EventGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Demos.EventGrid.Publisher
{
    internal class EventGridPublisher
    {
        // Dont worry. These wont work anymore :)
        static string topicName = "egt-landingzone";
        static string region = "westeurope-1";
        static string accessKey = "EnRfkg82Q0BWbTtCUtdASqjtBit7cl8b/wumAK5VpE4=";

        internal async Task PublishEventGridAsync()
        {
            EventGridPublisherClient client = new EventGridPublisherClient(
                new Uri($"https://{topicName}.{region}.eventgrid.azure.net/api/events"),
                new AzureKeyCredential(accessKey)
                );

            List<EventGridEvent> eventsList = new List<EventGridEvent>
            {
                new EventGridEvent(
                    "Vanderlande.LandingZones/Jde",
                    "Vanderlande.LandingZone.Ingestion.Succes",
                    "1.0",
                    new MetaData()
                    {
                        LandingZone = "JDE",
                        AccountName = "SOMEACCOUNTNAME",
                        SourcePath = "/ingestion/2202-03-06",
                        SourceType = "StorageV2",
                        Table = "SomeTableName"
                    }),
                new EventGridEvent(
                    "Vanderlande.LandingZones/TimeEntryBox",
                    "Vanderlande.LandingZone.Ingestion.Succes",
                    "1.0",
                    new MetaData()
                    {
                        LandingZone = "JDE",
                        AccountName = "SOMEACCOUNTNAME",
                        SourcePath = "/ingestion/latest",
                        SourceType = "StorageV2",
                        Table = "SomeTableName"
                    })
            };

            await client.SendEventsAsync(eventsList);
        }
    }
}
