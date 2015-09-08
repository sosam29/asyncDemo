using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var wc = new WebClient();
            var rets = new List<string>();
            var websites = new[] { "http://www.bing.com", "http://www.microsoft.com", "http://www.msdn.com", "http://www.pluralsight.com" };
            foreach (var site in websites)
            {                    
                var ret = await wc.DownloadStringTaskAsync(site);
                rets.Add(ret);
                //TextBox lst = new TextBox();
                this.textBox1.Text += site + " downloaded " + ret.Length  + Environment.NewLine;
                //lst.Text += site + " Downloaded " + ret.Length;
                this.Text = "Downloaded " + ret.Length;
            }
                this.Text = "Done!!!";
        }
    }
}
