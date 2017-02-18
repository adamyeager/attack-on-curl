namespace AttackOnCurl.Gui
{
    partial class DefaultView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultView));
            this.baseUrlLabel = new System.Windows.Forms.Label();
            this.baseUrlTextBox = new System.Windows.Forms.TextBox();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.startNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.startNumberLabel = new System.Windows.Forms.Label();
            this.endNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.endNumberLabel = new System.Windows.Forms.Label();
            this.currentProgressBar = new System.Windows.Forms.ProgressBar();
            this.startButton = new System.Windows.Forms.Button();
            this.saveFilePathSelectButton = new System.Windows.Forms.Button();
            this.folderBrowserDialogSaveFilePath = new System.Windows.Forms.FolderBrowserDialog();
            this.overallProgressBar = new System.Windows.Forms.ProgressBar();
            this.currentBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.startNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // baseUrlLabel
            // 
            this.baseUrlLabel.AutoSize = true;
            this.baseUrlLabel.Location = new System.Drawing.Point(32, 9);
            this.baseUrlLabel.Name = "baseUrlLabel";
            this.baseUrlLabel.Size = new System.Drawing.Size(59, 13);
            this.baseUrlLabel.TabIndex = 0;
            this.baseUrlLabel.Text = "Base URL:";
            // 
            // baseUrlTextBox
            // 
            this.baseUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.baseUrlTextBox.Location = new System.Drawing.Point(97, 6);
            this.baseUrlTextBox.Name = "baseUrlTextBox";
            this.baseUrlTextBox.Size = new System.Drawing.Size(281, 20);
            this.baseUrlTextBox.TabIndex = 1;
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePathTextBox.Location = new System.Drawing.Point(97, 60);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(199, 20);
            this.filePathTextBox.TabIndex = 4;
            this.filePathTextBox.Text = "E:\\Comics\\attack-on-titan";
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(12, 63);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(79, 13);
            this.filePathLabel.TabIndex = 5;
            this.filePathLabel.Text = "Save File Path:";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNameTextBox.Location = new System.Drawing.Point(97, 87);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(281, 20);
            this.fileNameTextBox.TabIndex = 6;
            this.fileNameTextBox.Text = "Attack On Titan";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(34, 90);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(57, 13);
            this.fileNameLabel.TabIndex = 7;
            this.fileNameLabel.Text = "File Name:";
            // 
            // startNumericUpDown
            // 
            this.startNumericUpDown.Location = new System.Drawing.Point(97, 114);
            this.startNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.startNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startNumericUpDown.Name = "startNumericUpDown";
            this.startNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.startNumericUpDown.TabIndex = 8;
            this.startNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.startNumericUpDown.ValueChanged += new System.EventHandler(this.startNumericUpDown_ValueChanged);
            // 
            // startNumberLabel
            // 
            this.startNumberLabel.AutoSize = true;
            this.startNumberLabel.Location = new System.Drawing.Point(19, 116);
            this.startNumberLabel.Name = "startNumberLabel";
            this.startNumberLabel.Size = new System.Drawing.Size(72, 13);
            this.startNumberLabel.TabIndex = 9;
            this.startNumberLabel.Text = "Start Number:";
            // 
            // endNumericUpDown
            // 
            this.endNumericUpDown.Location = new System.Drawing.Point(97, 141);
            this.endNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.endNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endNumericUpDown.Name = "endNumericUpDown";
            this.endNumericUpDown.Size = new System.Drawing.Size(54, 20);
            this.endNumericUpDown.TabIndex = 10;
            this.endNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.endNumericUpDown.ValueChanged += new System.EventHandler(this.endNumericUpDown_ValueChanged);
            // 
            // endNumberLabel
            // 
            this.endNumberLabel.AutoSize = true;
            this.endNumberLabel.Location = new System.Drawing.Point(22, 143);
            this.endNumberLabel.Name = "endNumberLabel";
            this.endNumberLabel.Size = new System.Drawing.Size(69, 13);
            this.endNumberLabel.TabIndex = 11;
            this.endNumberLabel.Text = "End Number:";
            // 
            // currentProgressBar
            // 
            this.currentProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentProgressBar.Location = new System.Drawing.Point(97, 167);
            this.currentProgressBar.Name = "currentProgressBar";
            this.currentProgressBar.Size = new System.Drawing.Size(281, 23);
            this.currentProgressBar.TabIndex = 12;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(303, 225);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 13;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // saveFilePathSelectButton
            // 
            this.saveFilePathSelectButton.Location = new System.Drawing.Point(302, 58);
            this.saveFilePathSelectButton.Name = "saveFilePathSelectButton";
            this.saveFilePathSelectButton.Size = new System.Drawing.Size(75, 23);
            this.saveFilePathSelectButton.TabIndex = 14;
            this.saveFilePathSelectButton.Text = "Select Path";
            this.saveFilePathSelectButton.UseVisualStyleBackColor = true;
            this.saveFilePathSelectButton.Click += new System.EventHandler(this.saveFilePathSelectButton_Click);
            // 
            // folderBrowserDialogSaveFilePath
            // 
            this.folderBrowserDialogSaveFilePath.Description = "Select a folder to save the files.";
            // 
            // overallProgressBar
            // 
            this.overallProgressBar.Location = new System.Drawing.Point(97, 196);
            this.overallProgressBar.Name = "overallProgressBar";
            this.overallProgressBar.Size = new System.Drawing.Size(280, 23);
            this.overallProgressBar.TabIndex = 15;
            // 
            // currentBackgroundWorker
            // 
            this.currentBackgroundWorker.WorkerReportsProgress = true;
            this.currentBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.currentBackgroundWorker_DoWork);
            this.currentBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.currentBackgroundWorker_ProgressChanged);
            this.currentBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.currentBackgroundWorker_RunWorkerCompleted);
            // 
            // DefaultView
            // 
            this.AcceptButton = this.startButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(390, 260);
            this.Controls.Add(this.overallProgressBar);
            this.Controls.Add(this.saveFilePathSelectButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.currentProgressBar);
            this.Controls.Add(this.endNumberLabel);
            this.Controls.Add(this.endNumericUpDown);
            this.Controls.Add(this.startNumberLabel);
            this.Controls.Add(this.startNumericUpDown);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.baseUrlTextBox);
            this.Controls.Add(this.baseUrlLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DefaultView";
            this.Text = "Attack On Curl";
            ((System.ComponentModel.ISupportInitialize)(this.startNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label baseUrlLabel;
        private System.Windows.Forms.TextBox baseUrlTextBox;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.NumericUpDown startNumericUpDown;
        private System.Windows.Forms.Label startNumberLabel;
        private System.Windows.Forms.NumericUpDown endNumericUpDown;
        private System.Windows.Forms.Label endNumberLabel;
        private System.Windows.Forms.ProgressBar currentProgressBar;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button saveFilePathSelectButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSaveFilePath;
        private System.Windows.Forms.ProgressBar overallProgressBar;
        private System.ComponentModel.BackgroundWorker currentBackgroundWorker;
    }
}

