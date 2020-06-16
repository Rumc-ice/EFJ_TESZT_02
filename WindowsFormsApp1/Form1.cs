using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        RestClient rClient = new RestClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ez 10" + Class1.Space(10) + "space");
            System.Text.EncodingProvider ppp = System.Text.CodePagesEncodingProvider.Instance;
            Encoding.RegisterProvider(ppp);
            XmlReader doc = XmlReader.Create("c://teszt_xml//teszt_xml.xml");
           StreamWriter doc_2 = new StreamWriter("c://teszt_xml//teszt_xml_new.xml",false,Encoding.GetEncoding(1250)  );
            xml_teszt.ugyfel_adatok  t = new xml_teszt.ugyfel_adatok(); 
            XmlSerializer alma = new XmlSerializer(t.GetType() );
             t =  (xml_teszt.ugyfel_adatok)alma.Deserialize(doc);
            t.nev = "Tomika";
            alma.Serialize(doc_2, t);
            doc_2.Flush();
            doc_2.Close();
            MessageBox.Show("ez 10" + Class1.Space(10) + "space");
        }

        private void btnWebapi_Click(object sender, EventArgs e)
        {
            //RestClient rClient = new RestClient();
            rClient.endPoint = textBox1.Text;
            debugOutput("Rest Client Created");
            //rClient.authTech = authenticationTechnique.RollYourOwn; 
            rClient.authType = authenticationType.Basic;
            rClient.userName = txtUserName.Text;
            rClient.userPassword = txtPassword.Text;

            string strResponse = string.Empty;

            strResponse = rClient.makeRequest();
            Sajat_class vissza;
            vissza = (Sajat_class)JsonConvert.DeserializeObject<Sajat_class>(strResponse); 

            //MessageBox.Show(vissza.Nev);  
            



            debugOutput(strResponse); 
        }

        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtResponse.Text = txtResponse.Text + strDebugText + Environment.NewLine;
                txtResponse.SelectionStart = txtResponse.TextLength;
                txtResponse.ScrollToCaret();
            }
            catch(Exception ex )
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton kuldo = (RadioButton)sender;
            if (kuldo.Checked)
                rClient.httpMethod = (httpVerb)int.Parse(kuldo.Tag.ToString()); 
               
        }

        dynamic sampleObj = new ExpandoObject();
        


        private void button2_Click(object sender, EventArgs e)
        {
            sampleObj.szam_1 = (double)2;
            sampleObj.szam_2 = (double)2.5;

            double alap_ossz()
            {
                double ret = 0;
                try
                {
                    ret = sampleObj.szam_1 + sampleObj.szam_2;
                }
                catch { };
                return ret;
            }

            Func<double, double, double> func = (szam_1, szam_2) => szam_1 + szam_2;
            Func<double> func_2 = alap_ossz;


            sampleObj.osszeg = func_2; 
            MessageBox.Show(sampleObj.szam_1.ToString());
            MessageBox.Show(sampleObj.szam_2.ToString());
            MessageBox.Show(sampleObj.osszeg().ToString());

            addInstance(sampleObj,"ujtag", "ujtag_értéke!");


            foreach (var property in (IDictionary<String, Object>)sampleObj)
            {
                MessageBox.Show(property.Value+": "+  property.Key);
            }

            void addInstance(object P_obj ,string name, string value)
            {
                ((IDictionary<String, Object>)P_obj).Add(name, value);
            }



        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
