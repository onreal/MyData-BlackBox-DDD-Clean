namespace Upio.MyData.BlackBox.Core.Services.Http;

public abstract class HttpCredentials
{
    public string Url { get; set; } = "https://mydatapi.aade.gr/myDATA/SendInvoices";
    public string AadeUserId { get; set; }
    public string ApiSubscriptionKey { get; set; }
}