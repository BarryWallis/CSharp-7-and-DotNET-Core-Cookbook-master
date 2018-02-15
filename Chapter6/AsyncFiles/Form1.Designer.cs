namespace AsyncFiles
{
    partial class Form1
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
            this.CopyFilesAsyncButton = new System.Windows.Forms.Button();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.AsyncTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // CopyFilesAsyncButton
            // 
            this.CopyFilesAsyncButton.AutoSize = true;
            this.CopyFilesAsyncButton.Location = new System.Drawing.Point(13, 13);
            this.CopyFilesAsyncButton.Name = "CopyFilesAsyncButton";
            this.CopyFilesAsyncButton.Size = new System.Drawing.Size(189, 35);
            this.CopyFilesAsyncButton.TabIndex = 0;
            this.CopyFilesAsyncButton.Text = "Copy Files Async";
            this.CopyFilesAsyncButton.UseVisualStyleBackColor = true;
            this.CopyFilesAsyncButton.Click += new System.EventHandler(this.CopyFilesAsyncButton_Click);
            // 
            // TimerLabel
            // 
            this.TimerLabel.Location = new System.Drawing.Point(236, 13);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(212, 35);
            this.TimerLabel.TabIndex = 1;
            this.TimerLabel.Text = "label1";
            // 
            // AsyncTimer
            // 
            this.AsyncTimer.Interval = 1000;
            this.AsyncTimer.Tick += new System.EventHandler(this.AsyncTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 229);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.CopyFilesAsyncButton);
            this.Name = "Form1";
            this.Text = "Asynchronous File IO";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CopyFilesAsyncButton;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Timer AsyncTimer;
    }
}

