using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace CITest
{
    public partial class Form1 : Form
    {
        Thread t;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t = new Thread(() =>
            {
                for (int i=0;i<10;i++)
                {
                    label1.Invoke((Action)(() =>
                    {
                        label1.Text = "Pasada: " + i.ToString();
                    }));
                    Thread.Sleep(200);
                }
            });
            t.Start() //sin punto y coma para que falle el build en travis ci
        }
    }
}
