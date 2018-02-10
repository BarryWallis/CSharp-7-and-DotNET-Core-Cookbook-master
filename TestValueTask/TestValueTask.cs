using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestValueTask
{
    public partial class TestValueTask : Form
    {
        public TestValueTask()
        {
            InitializeComponent();
        }

        private void TestValueTask_Load(object sender, EventArgs e)
        {
            timerLabel.Text = $"Timer TTL {timeToLiveValue} sec (Stopped)";
        }

        private void TestAsyncTimer_Tick(object sender, EventArgs e)
        {
            if (timeToLiveValue <= 0)
            {
                timeToLiveValue = 5.0D;
            }
            else
            {
                timeToLiveValue -= 1;
            }

            timerLabel.Text = $"Timer TTL {timeToLiveValue} sec (Running)";
        }

        public async Task<int> GetValue()
        {
            await Task.Delay(1000);
            Random random = new Random();
            cacheValue = random.Next();
            timeToLive = DateTime.Now.AddSeconds(timeToLiveValue);
            testAsyncTimer.Start();
            return cacheValue;
        }

         public ValueTask<int> LoadReadCache(out bool isCached)
        {
            if (timeToLive < DateTime.Now)
            {
                isCached = false;
                return new ValueTask<int>(GetValue());
            }
            else
            {
                isCached = true;
                return new ValueTask<int>(cacheValue);
            }
        }

        private async void TestAsyncButton_Click(object sender, EventArgs e)
        {
            int value = await LoadReadCache(out bool isCached);
            if (isCached)
            {
                testAsyncTextBox.Text = "Cached";
            }
            else
            {
                testAsyncTextBox.Text = "New";
            }
            testAsyncTextBox.Text += $" value {value} read";
        }
    }
}
