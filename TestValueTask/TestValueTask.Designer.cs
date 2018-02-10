using System;

namespace TestValueTask
{
    partial class TestValueTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.testAsyncButton = new System.Windows.Forms.Button();
            this.testAsyncTextBox = new System.Windows.Forms.TextBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.testAsyncTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // testAsyncButton
            // 
            this.testAsyncButton.AutoSize = true;
            this.testAsyncButton.Location = new System.Drawing.Point(13, 13);
            this.testAsyncButton.Name = "testAsyncButton";
            this.testAsyncButton.Size = new System.Drawing.Size(123, 35);
            this.testAsyncButton.TabIndex = 0;
            this.testAsyncButton.Text = "TestAsync";
            this.testAsyncButton.UseVisualStyleBackColor = true;
            this.testAsyncButton.Click += new System.EventHandler(this.TestAsyncButton_Click);
            // 
            // testAsyncTextBox
            // 
            this.testAsyncTextBox.Location = new System.Drawing.Point(157, 12);
            this.testAsyncTextBox.Name = "testAsyncTextBox";
            this.testAsyncTextBox.Size = new System.Drawing.Size(342, 31);
            this.testAsyncTextBox.TabIndex = 1;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(12, 62);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(70, 25);
            this.timerLabel.TabIndex = 2;
            this.timerLabel.Text = "label1";
            // 
            // testAsyncTimer
            // 
            this.testAsyncTimer.Interval = 1000;
            this.testAsyncTimer.Tick += new System.EventHandler(this.TestAsyncTimer_Tick);
            // 
            // TestValueTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 119);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.testAsyncTextBox);
            this.Controls.Add(this.testAsyncButton);
            this.Name = "TestValueTask";
            this.Text = "Test ValueTask<T>";
            this.Load += new System.EventHandler(this.TestValueTask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testAsyncButton;
        private System.Windows.Forms.TextBox testAsyncTextBox;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Timer testAsyncTimer;

        double timeToLiveValue = 10.0D;
        private DateTime timeToLive;
        private int cacheValue;
    }
}

