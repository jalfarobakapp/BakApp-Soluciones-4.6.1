﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SemillaCertificacion
{
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "CrSeedSoapBinding", Namespace = "https://maullin.sii.cl/DTEWS/CrSeed.jws")]
    public partial class CrSeedService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback getSeedOperationCompleted;

        /// <remarks/>
        public CrSeedService()
        {
            this.Url = "https://maullin.sii.cl/DTEWS/CrSeed.jws";
        }

        /// <remarks/>
        public event getSeedCompletedEventHandler getSeedCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace = "https://maullin.sii.cl/DTEWS/CrSeed.jws", ResponseNamespace = "https://maullin.sii.cl/DTEWS/CrSeed.jws")]
        [return: System.Xml.Serialization.SoapElementAttribute("getSeedReturn")]
        public string getSeed()
        {
            object[] results = this.Invoke("getSeed", new object[0]);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BegingetSeed(System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("getSeed", new object[0], callback, asyncState);
        }

        /// <remarks/>
        public string EndgetSeed(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void getSeedAsync()
        {
            this.getSeedAsync(null);
        }

        /// <remarks/>
        public void getSeedAsync(object userState)
        {
            if ((this.getSeedOperationCompleted == null))
            {
                this.getSeedOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetSeedOperationCompleted);
            }
            this.InvokeAsync("getSeed", new object[0], this.getSeedOperationCompleted, userState);
        }

        private void OngetSeedOperationCompleted(object arg)
        {
            if ((this.getSeedCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getSeedCompleted(this, new getSeedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    public delegate void getSeedCompletedEventHandler(object sender, getSeedCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getSeedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal getSeedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}