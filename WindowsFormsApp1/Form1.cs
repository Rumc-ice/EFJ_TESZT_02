using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
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
    }
}
