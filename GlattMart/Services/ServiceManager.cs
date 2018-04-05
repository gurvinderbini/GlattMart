using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using GlattMart.Helper;
using Newtonsoft.Json;

namespace GlattMart
{
    public class ServiceManager
    {
        public static ServiceResponse<String> GenericRestCallUsingHttpClient<T, Tr>(string endpoint, HttpMethod method, Tr content)
        {
            var serviceResponse = new ServiceResponse<String> { IsSuccess = false };
            string returnValue = string.Empty;
           
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConstantData.ServiceBaseUrl+endpoint);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(ConstantData.token);
                        HttpResponseMessage response = null;
                        if (method == HttpMethod.Get || method == HttpMethod.Delete)
                        {

                            if (method == HttpMethod.Get)
                            {
                                response = client.GetAsync(endpoint).Result;

                            }
                            else
                            {
                                response = client.DeleteAsync(endpoint).Result;

                            }

                            if (response.IsSuccessStatusCode)
                            {
                                serviceResponse.IsSuccess = true;
                                serviceResponse.Data = response.Content.ReadAsStringAsync().Result;
                            }
                            else
                            {
                                //serviceResponse.Data = response.Content.ReadAsStringAsync().Result;

                                serviceResponse.IsSuccess = false;
                                serviceResponse.Message = response.Content.ReadAsStringAsync().Result;
                            }
                        }
                        else
                        {

                            string Body = JsonConvert.SerializeObject(content, Formatting.None,
                                                                                    new JsonSerializerSettings
                                                                                    {
                                                                                        NullValueHandling = NullValueHandling.Ignore
                                                                                    });

                            switch (method.Method)
                            {
                                case "POST":
                                    response = client.PostAsync("", new StringContent(Body, Encoding.UTF8, "application/json")).Result;
                                    break;
                                case "PUT":
                                    response = client.PutAsync(endpoint, new StringContent(Body, Encoding.UTF8, "application/json")).Result;
                                    break;
                            }
                            if (response.IsSuccessStatusCode)
                            {
                                serviceResponse.IsSuccess = true;
                                serviceResponse.Data = response.Content.ReadAsStringAsync().Result;
                            }
                            else
                            {
                                //serviceResponse.Data = response.Content.ReadAsStringAsync().Result;

                                serviceResponse.IsSuccess = false;
                                serviceResponse.Message = response.Content.ReadAsStringAsync().Result;
                            }
                        }


                }
            }
            catch (Exception ex)
            {
                serviceResponse.IsSuccess = false;
                serviceResponse.Message = "Exception generated: " + ex.Message;
                //returnValue = "Exception generated: " + ex.Message; //report the exception message if one was hit
            }
            return serviceResponse;
        }
    }
}
