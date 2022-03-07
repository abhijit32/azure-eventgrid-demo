// See https://aka.ms/new-console-template for more information
using Azure.Demos.EventGrid.Publisher;

Console.WriteLine("Event Grid Publisher starting...");

EventGridPublisher eventGridPublisher = new EventGridPublisher();
await eventGridPublisher.PublishEventGridAsync();

Console.WriteLine("Done...");