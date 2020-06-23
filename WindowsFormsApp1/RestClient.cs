using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WindowsFormsApp1
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public enum authenticationType
    {
        Basic,
        NTLM
    }
    public enum authenticationTechnique
    {
        RollYourOwn,
        NerworkCredential
    }

    class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb  httpMethod { get; set; }
        public authenticationType authType { get; set; }
        public authenticationTechnique authTech { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }

        public string strResponseValue  { get; set; }


    public RestClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.POST;
            ServicePointManager.ServerCertificateValidationCallback +=
  (sender, certificate, chain, errors) => {
      return true;
  };
        }
        //public string makeRequest()
        //{
        //    string strResponseValue = string.Empty;

        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint) ;

        //    request.Method = httpMethod.ToString() ;

        //    if (authTech == authenticationTechnique.RollYourOwn)
        //    {
        //        String authHeader = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(userName + ":" + userPassword));
        //        request.Headers.Add("Authorization", authType.ToString() + " " + authHeader);
        //    }
        //    else
        //    {
        //        NetworkCredential netCred = new NetworkCredential(userName, userPassword);
        //        request.Credentials = netCred;
        //    }
        //    HttpWebResponse response = null;
        //    try 
        //    {
        //        response = (HttpWebResponse)request.GetResponse();
        //        if (response.StatusCode!=HttpStatusCode.OK)
        //        {
        //            throw new ApplicationException("error code: " + response.StatusCode.ToString());
        //        }

        //        using (Stream responseStream = response.GetResponseStream())
        //        {
        //            if(responseStream !=null)
        //            {
        //                using(StreamReader reader=new StreamReader (responseStream))
        //                {
        //                    strResponseValue = reader.ReadToEnd();
        //                }
        //            }
        //        }


        //    }catch(Exception ex )
        //    {
        //        strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";  
        //    }

        //    finally
        //    {
        //        if(response!=null)
        //        {
        //            ((IDisposable)response).Dispose(); 
        //        }
        //    }




        //        return strResponseValue;
        //}
        public async Task makeRequest()
        {
           

          

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);

            //request.Method = httpMethod.ToString();
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            HttpClient client = new HttpClient(clientHandler);

            //using var client = new HttpClient();
            var authToken = Encoding.ASCII.GetBytes($"{userName}:{userPassword}");


            if (authTech == authenticationTechnique.RollYourOwn)
            {
                //String authHeader = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(userName + ":" + userPassword));
                //request.Headers.Add("Authorization", authType.ToString() + " " + authHeader);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(authToken));
            }
            else
            {
                //NetworkCredential netCred = new NetworkCredential(userName, userPassword);
                //request.Credentials = netCred;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("NTLM",
                    Convert.ToBase64String(authToken));
            }
         HttpResponseMessage response = null;
            HttpContent ures = null;

            if (httpMethod == httpVerb.GET)
                response = await client.GetAsync(endPoint);
            else
                response = await client.PostAsync(endPoint, ures); 

            var resp = response.Content.ReadAsStringAsync();

            MessageBox.Show(resp.Result);
            strResponseValue = resp.Result;

            //return strResponseValue;
        }

        public string asyncVissza()
        {
            return strResponseValue;
        }


    }
}
