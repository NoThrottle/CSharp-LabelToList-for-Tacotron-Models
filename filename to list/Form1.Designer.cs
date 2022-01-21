namespace filename_to_list
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
            this.inbrowse = new System.Windows.Forms.Button();
            this.filepath = new System.Windows.Forms.TextBox();
            this.outbrowse = new System.Windows.Forms.Button();
            this.outpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.logs = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.start = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inbrowse
            // 
            this.inbrowse.Location = new System.Drawing.Point(248, 27);
            this.inbrowse.Name = "inbrowse";
            this.inbrowse.Size = new System.Drawing.Size(75, 23);
            this.inbrowse.TabIndex = 0;
            this.inbrowse.Text = "Browse";
            this.inbrowse.UseVisualStyleBackColor = true;
            this.inbrowse.Click += new System.EventHandler(this.inbrowse_Click);
            // 
            // filepath
            // 
            this.filepath.Location = new System.Drawing.Point(13, 28);
            this.filepath.Name = "filepath";
            this.filepath.Size = new System.Drawing.Size(229, 20);
            this.filepath.TabIndex = 1;
            // 
            // outbrowse
            // 
            this.outbrowse.Location = new System.Drawing.Point(248, 65);
            this.outbrowse.Name = "outbrowse";
            this.outbrowse.Size = new System.Drawing.Size(75, 23);
            this.outbrowse.TabIndex = 2;
            this.outbrowse.Text = "Browse";
            this.outbrowse.UseVisualStyleBackColor = true;
            this.outbrowse.Click += new System.EventHandler(this.outbrowse_Click);
            // 
            // outpath
            // 
            this.outpath.Location = new System.Drawing.Point(13, 67);
            this.outpath.Name = "outpath";
            this.outpath.Size = new System.Drawing.Size(229, 20);
            this.outpath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "List and Logs output.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Path of .wav files.";
            // 
            // logs
            // 
            this.logs.Location = new System.Drawing.Point(13, 145);
            this.logs.Multiline = true;
            this.logs.Name = "logs";
            this.logs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logs.Size = new System.Drawing.Size(310, 253);
            this.logs.TabIndex = 6;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 116);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(230, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 7;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(248, 116);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 8;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Waiting for job:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 410);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.start);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.logs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outpath);
            this.Controls.Add(this.outbrowse);
            this.Controls.Add(this.filepath);
            this.Controls.Add(this.inbrowse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filename to List";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inbrowse;
        private System.Windows.Forms.TextBox filepath;
        private System.Windows.Forms.Button outbrowse;
        private System.Windows.Forms.TextBox outpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox logs;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Label label3;
    }
}

