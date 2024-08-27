using System.Collections.Specialized;
using System.Web;

namespace Upio.MyData.BlackBox.Core.Schema.Catalog;

public abstract class API
{
    public static string SendInvoice()
    {
        return GetUri("SendInvoice");
    }

    public static string RequestDocs(string mark, string nextPartitionKey, string nextRowKey)
    {
        return GetUri("RequestDocs", new NameValueCollection
        {
            {
                "mark", mark
            },
            {
                "nextPartitionKey", nextPartitionKey
            },
            {
                "nextRowKey", nextRowKey
            }
        });
    }

    public static string RequestTransmittedDocs(string mark, string nextPartitionKey, string nextRowKey)
    {
        return GetUri("RequestTransmittedDocs", new NameValueCollection
        {
            {
                "mark", mark
            },
            {
                "nextPartitionKey", nextPartitionKey
            },
            {
                "nextRowKey", nextRowKey
            }
        });
    }
    
    public static string SendIncomeClassification()
    {
        return GetUri("SendIncomeClassification");
    }
    
    public static string SendExpensesClassification()
    {
        return GetUri("SendExpensesClassification");
    }
    
    public static string CancelInvoice(string mark)
    {
        return GetUri("CancelInvoice", new NameValueCollection { { "mark", mark } });
    }

    private static string GetUri(string service, NameValueCollection? query = null)
    {
        var uriBuilder = new UriBuilder($"https://mydata-dev.azure-api.net/{service}");
        var queryCollection = HttpUtility.ParseQueryString(uriBuilder.Query);

        if (query == null)
        {
            return uriBuilder.ToString();
        }
        
        foreach (var key in query.AllKeys)
        {
            queryCollection[key] = query[key];
        }

        uriBuilder.Query = queryCollection.ToString();
        return uriBuilder.ToString();
    }
}