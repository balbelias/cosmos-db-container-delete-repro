using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;

var endpoint = "";
var authKey = "";
var databaseId = "";
var containerId = "";

var client = new CosmosClientBuilder(endpoint, authKey)
    .WithSerializerOptions(new CosmosSerializationOptions
    {
        PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase
    })
    .Build();

var database = client.GetDatabase(databaseId);
await database.CreateContainerIfNotExistsAsync(new ContainerProperties(containerId, "/documentType"));

var container = database.GetContainer(containerId);
await container.DeleteContainerAsync();