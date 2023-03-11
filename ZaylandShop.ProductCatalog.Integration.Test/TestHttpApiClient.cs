using ZaylandShop.ProductCatalog.Abstractions.HttpClients;
using ZaylandShop.ProductCatalog.Utils.Http;

namespace ZaylandShop.ProductCatalog.Integration.Test;

public class TestHttpApiClient : JsonHttpApiClient, ITestHttpApiClient
{
    public TestHttpApiClient(HttpClient httpClient) : base(httpClient)
    {
    }
}