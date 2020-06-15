using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;

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




        public RestClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.POST;
        }
        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint) ;

            request.Method = httpMethod.ToString() ;
            String authHeader = System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(userName + ":" + userPassword));
            request.Headers.Add("Authorization",authType.ToString()+ " " + authHeader); 

            HttpWebResponse response = null;
            try 
            {
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode!=HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code: " + response.StatusCode.ToString());
                }

                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream !=null)
                    {
                        using(StreamReader reader=new StreamReader (responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }


            }catch(Exception ex )
            {
                strResponseValue = "{\"errorMessages\":[\"" + ex.Message.ToString() + "\"],\"errors\":{}}";  
            }

            finally
            {
                if(response!=null)
                {
                    ((IDisposable)response).Dispose(); 
                }
            }




                return strResponseValue;
        }
    }
}
