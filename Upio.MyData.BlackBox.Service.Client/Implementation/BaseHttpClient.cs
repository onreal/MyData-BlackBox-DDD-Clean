using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Upio.MyData.BlackBox.Core.Schema;
using Upio.MyData.BlackBox.Infrastructure;
using www.aade.gr.myDATA.invoice.v1.Item0;

namespace Upio.MyData.BlackBox.Service.Client.Implementation;

public abstract class BaseHttpClient : System.Net.Http.HttpClient
{
    private readonly HttpResponse httpResponse;

    protected BaseHttpClient()
    {
        this.httpResponse = new HttpResponse();

        DefaultRequestHeaders.Add("Accept", new MediaTypeHeaderValue("application/xml").ToString());
        DefaultRequestHeaders.Add("Content-Type", new MediaTypeHeaderValue("application/xml").ToString());
    }
    
    protected async Task Post(string uri, object request = null)
    {
        HttpResponseMessage response = await this.PostAsync(uri, await GetRequest(request));
        if (!response.IsSuccessStatusCode)
        {
            this.httpResponse.IsError = true;
            this.httpResponse.Message = await response.Content.ReadAsStringAsync();
        }
        else
        {
            this.httpResponse.ResponseDoc = ResponseDoc.Parse(await response.Content.ReadAsStringAsync()); 
        }
    }
    
    protected async Task Get(string uri)
    {
        HttpResponseMessage response =  await this.GetAsync(uri);
        if (!response.IsSuccessStatusCode)
        {
            this.httpResponse.IsError = true;
            this.httpResponse.Message = await response.Content.ReadAsStringAsync();
        }
        else
        {
            this.httpResponse.RequestedDoc = RequestedDoc.Parse(await response.Content.ReadAsStringAsync()); 
        }
    }

    private static byte[] XMLtoByte<T>(T xmlData)
    {
        return Encoding.UTF8.GetBytes(xmlData.ToString() ?? throw new InvalidOperationException());
    }
    
    private static async Task<ByteArrayContent?> GetRequest(object? request)
    {
        if (request == null)
        {
            return await Task.FromResult<ByteArrayContent>(null);
        }
        
        var byteData = XMLtoByte(request);
        using var content = new ByteArrayContent(byteData);
        return await Task.FromResult(content);;
    }

    protected HttpResponse GetResponse()
    {
        return this.httpResponse;
    }
}