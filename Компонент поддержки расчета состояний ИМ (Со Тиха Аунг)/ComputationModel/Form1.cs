using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Timers;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Xml;

namespace ComputationModel
{
    public partial class Form1 : Form
    {
        static string filePath;
        static int input = 0;
        static int tAmount;
        static System.Timers.Timer tmr;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.InitialDirectory + openFileDialog1.FileName;
                MessageBox.Show(filePath);
                XmlDocument doc = new XmlDocument();
                doc.Load("ResourceParameters.xml");
                doc.DocumentElement.RemoveAll();
                doc.Save("ResourceParameters.xml");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tAmount = Convert.ToInt32(timeAmount.Text);
            tmr = new System.Timers.Timer(Convert.ToInt32(timeLength.Text)*1000);
            tmr.Elapsed+=new ElapsedEventHandler(tmr_Elapsed);
            tmr.Start();
            timer1.Start();

        }
        static void tmr_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (input == tAmount)
            {
                tmr.Stop();
                MessageBox.Show("Расчет состояний ИМ завершен!", "Расчет состояний ИМ",MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Environment.Exit(0);
            }
            else
            {
                input = input + 1;
                
                string str1 = "name";
                object obj = new object();

                object[] parameters = new object[3] { str1, input.ToString(), obj };


                Assembly SampleAssembly;
                SampleAssembly = Assembly.LoadFrom(filePath);
                System.Type type = SampleAssembly.GetType("Model.ATModel");
                Object o = Activator.CreateInstance(type);
                // Obtain a reference to a method known to exist in assembly.
                MethodInfo Method = type.GetMethod("ProcessMessage");

                Method.Invoke(o, parameters);
                
            }
            

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            tmr.Stop();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tmr.Stop();
            timeLength.Text = "";
            timeAmount.Text = "";
            input = 0;
            tAmount = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            currentTact.Text = input.ToString();
        }



    }
}
