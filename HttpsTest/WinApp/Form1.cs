using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(
                        delegate (object MySender, System.Security.Cryptography.X509Certificates.X509Certificate MyCertificate,
                        System.Security.Cryptography.X509Certificates.X509Chain MyChain, System.Net.Security.SslPolicyErrors MyErrors)
                        {
                            if (MySender is System.Net.WebRequest)
                            {
                                //忽略凭证检查，一律回传true
                                return true;
                            }
                            return false;
                        });

            //Request("http");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Request("http");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Request("https");
        }

        private void Request(string endpoint)
        {
            DemoServiceRef.DemoServiceClient client = new DemoServiceRef.DemoServiceClient(endpoint);
            string s = client.Hello("ss");
            textBox1.Text = endpoint + ": " + s;
        }

    }
}
