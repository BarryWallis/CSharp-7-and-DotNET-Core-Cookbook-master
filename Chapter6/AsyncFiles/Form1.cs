using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncFiles
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cancellationTokenSource = null;
        int elapsedTime = 0;
        const string copyFilesAsyncText = "Copy Files Async";
        const string cancelAsyncCopyText = "Cancel Async Copy";

        public Form1()
        {
            InitializeComponent();

            TimerLabel.Text = "Timer Stopped";
        }

        private async void CopyFilesAsyncButton_Click(object sender, EventArgs e)
        {
            if (CopyFilesAsyncButton.Text.Equals(copyFilesAsyncText))
            {
                string sourceDirectory = @"C:\Users\barry\Source\Repos\CSharp-7-and-DotNET-Core-Cookbook-master\Chapter6\AsyncSource";
                string destinationDirectory = @"C:\Users\barry\Source\Repos\CSharp-7-and-DotNET-Core-Cookbook-master\Chapter6\AsyncDestination";
                CopyFilesAsyncButton.Text = cancelAsyncCopyText;
                cancellationTokenSource = new CancellationTokenSource();
                elapsedTime = 0;
                AsyncTimer.Start();

                IEnumerable<string> fileEntries = Directory.EnumerateFiles(sourceDirectory);
                foreach (string sourceFile in fileEntries)
                {
                    using (FileStream sourceFileStream = File.Open(sourceFile, FileMode.Open))
                    {
                        string destinationFilePath = $"{destinationDirectory}{Path.GetFileName(sourceFile)}";
                        using (FileStream destinationFileStream = File.Create(destinationFilePath))
                        {
                            try
                            {
                                await sourceFileStream.CopyToAsync(destinationFileStream, 81920, cancellationTokenSource.Token);
                            }
                            catch (OperationCanceledException)
                            {
                                AsyncTimer.Stop();
                                TimerLabel.Text = $"Cancelled after {elapsedTime} seconds";
                            }
                        }
                    }
                }
            }
            if (!cancellationTokenSource.IsCancellationRequested)
            {
                AsyncTimer.Stop();
                TimerLabel.Text = $"Completed in {elapsedTime} seconds";
            }
            if (CopyFilesAsyncButton.Text.Equals(cancelAsyncCopyText))
            {
                CopyFilesAsyncButton.Text = copyFilesAsyncText;
                Debug.Assert(cancellationTokenSource != null);
                cancellationTokenSource.Cancel();
            }
        }

        private void AsyncTimer_Tick(object sender, EventArgs e) => TimerLabel.Text = $"Duration = {elapsedTime += 1} seconds";
    }
}
