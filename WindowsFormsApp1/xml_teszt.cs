using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    public class xml_teszt
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class ugyfel_adatok
        {

            private uint azonositoField;

            private string nevField;

            private ushort iranyitoszamField;

            private string helysegField;

            private string utcaField;

            private uint megallapodasField;

            private string engedelyszamField;

            /// <remarks/>
            public uint azonosito
            {
                get
                {
                    return this.azonositoField;
                }
                set
                {
                    this.azonositoField = value;
                }
            }

            /// <remarks/>
            public string nev
            {
                get
                {
                    return this.nevField;
                }
                set
                {
                    this.nevField = value;
                }
            }

            /// <remarks/>
            /// 
            public ushort iranyitoszam
            {
                get
                {
                    return this.iranyitoszamField;
                }
                set
                {
                    this.iranyitoszamField = value;
                }
            }

            /// <remarks/>
            public string helyseg
            {
                get
                {
                    return this.helysegField;
                }
                set
                {
                    this.helysegField = value;
                }
            }

            /// <remarks/>
            public string utca
            {
                get
                {
                    return this.utcaField;
                }
                set
                {
                    this.utcaField = value;
                }
            }

            /// <remarks/>
            public uint megallapodas
            {
                get
                {
                    return this.megallapodasField;
                }
                set
                {
                    this.megallapodasField = value;
                }
            }

            /// <remarks/>
            public string engedelyszam
            {
                get
                {
                    return this.engedelyszamField;
                }
                set
                {
                    this.engedelyszamField = value;
                }
            }
        }


    }
}
