using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAsync
{
    public partial class Form1 : Form
    {
        public Form1() => InitializeComponent();

        private async void Button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Read backup file");
            int readResult = await AsyncDemo.ReadLogFile();
            Console.WriteLine($"Bytes read = {readResult}");

        }
    }
}
