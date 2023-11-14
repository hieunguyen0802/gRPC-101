using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcGreeterClient;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("http://localhost:5054");


var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(
                  new HelloRequest { Name = "GreeterClient" });
Console.WriteLine("Greeting: " + reply.Message);

var productClient = new Product.ProductClient(channel);
var product = new GetProductDetail
{
    ProductId = 3
};
var serverReply = await productClient.GetProductsInformationAsync(product);
Console.WriteLine(serverReply);
//Console.WriteLine($"{serverReply.ProductName} | {serverReply.ProductDescription} | {serverReply.ProductPrice} | {serverReply.ProductStock}");

using (var clientData = productClient.GetProducts(new GetProductsRequest()))
{
    
    while (await clientData.ResponseStream.MoveNext(new System.Threading.CancellationToken()))
    {
        var thisProduct = clientData.ResponseStream.Current;
        Console.WriteLine($"item" + thisProduct);
    }
}

var productList = productClient.GetProductList(new GetProductsRequest(),  new Grpc.Core.Metadata());

Console.WriteLine("list nè" + productList);
