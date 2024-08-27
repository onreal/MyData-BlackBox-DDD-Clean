using System.ComponentModel;
using System.Threading.Tasks;
using Upio.MyData.BlackBox.Core.Schema.Catalog;
using Upio.MyData.BlackBox.Core.Services.Http;
using Upio.MyData.BlackBox.Service.Client.Contract;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Service.Client.Implementation
{
    public class HttpClient : BaseHttpClient, IHttpClient
    {
        public async Task<IHttpResponse> SendAsync(InvoicesDoc invoicesDoc)
        {
            await Post(API.SendInvoice(), invoicesDoc);
            
            return GetResponse();
        }

        public Task<IHttpResponse> Cancel(string mark)
        {
            throw new System.NotImplementedException();
        }

        // public async Task<HttpResponse> Send(InvoicesDoc invoicesDoc, HttpCredentials httpCredentials)
        // {
        //     var queryString = HttpUtility.ParseQueryString(string.Empty);
        //     var uri = $"{httpCredentials.Url}/SendInvoices?{queryString}"; // https://mydata-dev.azure-api.net/SendInvoices?
        //     
        //     // Request headers
        //     _httpClient.DefaultRequestHeaders.Add("aade-user-id", httpCredentials.AadeUserId); // another_reality
        //     _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", httpCredentials.ApiSubscriptionKey); // 34bbea9952ca4a048f5bdd8e7b696854
        //     
        //     // Set request body
        //     var byteData = XMLtoByte<InvoicesDoc>(invoicesDoc);
        //     HttpResponseMessage response;
        //     using (var content = new ByteArrayContent(byteData))
        //     {
        //         content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
        //         response =  await _httpClient.PostAsync(uri, content);
        //     }
        //
        //     var responseDoc = new ClientResponseModel();
        //     // if not success code check response
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         responseDoc.IsError = true;
        //         responseDoc.Message = await response.Content.ReadAsStringAsync();
        //         return responseDoc;
        //     }
        //
        //     responseDoc.ResponseDoc = ResponseDoc.Parse(await response.Content.ReadAsStringAsync());
        //
        //     // reset http client
        //     _httpClient.DefaultRequestHeaders.Remove("aade-user-id");
        //     _httpClient.DefaultRequestHeaders.Remove("Ocp-Apim-Subscription-Key");
        //     
        //     _httpClient.Dispose();
        //     
        //     return responseDoc;
        // }
        //
        // public async Task<ResponseDoc> SendInvoiceCancellationPost(string mark, MyDataRequestCredentialsModel myDataRequestCredentialsModel)
        // {
        //     var queryString = HttpUtility.ParseQueryString(string.Empty);
        //     var uri = $"{myDataRequestCredentialsModel.Url}/CancelInvoice?mark={mark}"; // https://mydata-dev.azure-api.net/SendInvoices?
        //     
        //     // Request headers
        //     _httpClient.DefaultRequestHeaders.Add("aade-user-id", myDataRequestCredentialsModel.AadeUserId); // another_reality
        //     _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", myDataRequestCredentialsModel.ApiSubscriptionKey); // 34bbea9952ca4a048f5bdd8e7b696854
        //     
        //     // TODO check if this post request a body
        //     var response =  await _httpClient.PostAsync(uri, null);
        //     
        //     if (!response.IsSuccessStatusCode)
        //     {
        //     }
        //
        //     var responseDoc = ResponseDoc.Parse(await response.Content.ReadAsStringAsync());
        //
        //     // reset http client
        //     _httpClient.DefaultRequestHeaders.Remove("aade-user-id");
        //     _httpClient.DefaultRequestHeaders.Remove("Ocp-Apim-Subscription-Key");
        //     
        //     return responseDoc;
        // }

        public Task<IHttpResponse> Request(string action)
        {
            throw new System.NotImplementedException();
        }

        public Task<IHttpResponse> RequestTransmitted(string action)
        {
            throw new System.NotImplementedException();
        }

        public Task<IHttpResponse> SendIncome(string action)
        {
            throw new System.NotImplementedException();
        }

        public Task<IHttpResponse> SendExpenses(string action)
        {
            throw new System.NotImplementedException();
        }
    }
}