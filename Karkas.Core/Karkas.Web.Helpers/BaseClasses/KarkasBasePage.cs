﻿using Karkas.Web.Helpers.HelperClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;


namespace Karkas.Web.Helpers.BaseClasses
{

    public abstract class KarkasBasePage : Page
    {
        static KarkasBasePage()
        {
            try
            {
                setPort();
                setProtocol();
                setBasePath();
            }
            catch
            {
                port = "";
                protocol = "http://";
                basePath = "http://localhost";
            }
        }

        private static string port = null;
        /// <summary>
        /// Sitenin çalıştığı Port numarasını verir. Eğer port yoksa, 443 ve 80 gibi standart portlar ise string.empty , boş string döner.
        /// </summary>
        public string Port
        {
            get
            {
                return port;
            }
        }
        private static void setPort()
        {
            if (port == null)
            {
                port = HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
            }
            if (port == null || port == "80" || port == "443")
            {
                port = "";
            }
            else
            {
                port = ":" + port;
            }
        }
        private static int? portAsInt;
        private static bool portHesaplandiMi = false;
        public int? PortAsInt
        {
            get
            {
                if (portHesaplandiMi)
                {
                    return portAsInt;
                }
                int sonuc = 0;
                string s = Port.Remove(0, 1);
                if (String.IsNullOrEmpty(Port)
                    &&
                    Int32.TryParse(s , out sonuc)
                    )
                {
                    portHesaplandiMi = true;
                    portAsInt =  null;
                }
                else
                {
                    portAsInt = sonuc;
                }
                return portAsInt;
            }
        }

        public bool YerelDeveloperMakinesiIstegiMi
        {
            get
            {
                
                if (BasePath.Contains("localhost") &&
                    PortAsInt.HasValue)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static string protocol;
        /// <summary>
        /// Sitenin çalıştığı protocol, http veya https döndürülür.
        /// </summary>
        public string Protocol
        {
            get
            {
                return protocol;
            }
        }
        private static void setProtocol()
        {

            if (protocol == null)
            {
                protocol = HttpContext.Current.Request.ServerVariables["SERVER_PORT_SECURE"];

            }
            if (protocol == null || protocol == "0")
            {
                protocol = "http://";

            }
            else
            {
                protocol = "https://";
            }
        }
        private static string basePath;
        /// <summary>
        /// Sitenin çalıştığı dizin döndürülür. Örnek: https://localhost/Karkas.Ornek.WebApp
        /// </summary>
        public string BasePath
        {
            get
            {
                return basePath;
            }
        }

        private static void setBasePath()
        {
            if (basePath == null)
            {
                basePath = protocol + HttpContext.Current.Request.ServerVariables["SERVER_NAME"] +

                                    port + HttpContext.Current.Request.ApplicationPath;

            }
        }


        public string RelativeURLdenAbsoulteURLVer(string relativeURL)
        {
            string replaceText;
            if (Request.ApplicationPath.Equals("/"))
                replaceText = Request.Url.Authority;
            else
                replaceText = Request.Url.Authority + Request.ApplicationPath;

            return String.Format("{0}{1}", this.BasePath, relativeURL.Replace("~", replaceText));
        }


        private readonly KarkasWebHelper.JavascriptHelper jsHelper;
        private readonly KarkasWebHelper.ListHelper listHelper;
        private readonly KarkasWebHelper.GridHelper gridHelper;
        private readonly KarkasWebHelper.QueryStringHelper queryStringHelper;
        private readonly KarkasWebHelper.ExportHelper exportHelper;

        ScriptManager scriptManager = null;

        public ScriptManager ScriptManagerSingleton
        {
            get
            {
                if (scriptManager == null)
                {
                    scriptManager = ScriptManager.GetCurrent(this);

                }
                return scriptManager;
            }
        }


        public KarkasWebHelper.ExportHelper ExportHelper
        {
            get { return exportHelper; }
        }


        public KarkasWebHelper.QueryStringHelper QueryStringHelper
        {
            get { return queryStringHelper; }
        }




        IMessageBox mBox = null;

        public KarkasBasePage()
        {
            this.jsHelper = new KarkasWebHelper.JavascriptHelper(this);
            this.listHelper = new KarkasWebHelper.ListHelper();
            this.gridHelper = new KarkasWebHelper.GridHelper(this);
            this.exportHelper = new KarkasWebHelper.ExportHelper(this);
            this.queryStringHelper = new KarkasWebHelper.QueryStringHelper();
        }




        public void MessageBox(string pMessage)
        {
            if (mBox != null)
            {
                this.mBox.Show(pMessage);
            }
            else
            {
                this.JavascriptHelper.Alert(pMessage);
            }
        }

        public void MessageBox(string[] pMessageList)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in pMessageList)
            {
                sb.Append(s + Environment.NewLine);
            }
            this.MessageBox(sb.ToString());
        }

        public void MessageBox(List<string> pMessageList)
        {
            this.MessageBox(pMessageList.ToArray());
        }

        public void MessageBox(string pMesaj, MesajTuruEnum pMesajTur)
        {
            if (mBox != null)
            {
                this.mBox.Show(pMesaj, pMesajTur);
            }
            else
            {
                this.JavascriptHelper.Alert(pMesaj);
            }
        }

        public void MessageBoxClose()
        {
            if (mBox != null)
            {
                this.mBox.Close();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            JavascriptDosyalariniEkle();
            if (base.Master != null)
            {
                this.mBox = base.Master.FindControl("MessageBox1") as IMessageBox;
            }
            if (mBox == null)
            {
                this.mBox = this.FindControl("MessageBox1") as IMessageBox;
            }


            base.OnLoad(e);
        }

        private void JavascriptDosyalariniEkle()
        {
            this.JavascriptHelper.ScriptRegisterFile("~/javascript/jquery.js", "jquery");
            this.JavascriptHelper.ScriptRegisterFile("~/javascript/jqDnR.js", "jqDnR");
            this.JavascriptHelper.ScriptRegisterFile("~/javascript/jqalert.js", "jqalert");
            this.JavascriptHelper.ScriptRegisterFile("~/javascript/Genel.js", "Genel");
        }

        public KarkasWebHelper.ListHelper ListHelper
        {
            get { return listHelper; }
        }

        public KarkasWebHelper.JavascriptHelper JavascriptHelper
        {
            get
            {
                return this.jsHelper;
            }
        }
        public KarkasWebHelper.GridHelper GridHelper
        {
            get { return gridHelper; }
        }

        /// <summary>
        /// Web sayfasında return'a basınca çalışacak olan, default button'ı setlemek için kullanılır.
        /// </summary>
        /// <param name="button"></param>
        public void DefaultButtonSetle(IButtonControl button)
        {
          this.Form.DefaultButton = ((WebControl)button).UniqueID;
        }


    }
}


