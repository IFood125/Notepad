namespace _7Notepad
{
    partial class NotepadForm
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
            this.txtContent = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblRevisionNumber = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.btnOlderRevision = new System.Windows.Forms.Button();
            this.btnNewerRevision = new System.Windows.Forms.Button();
            this.tmrAutoSave = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtContent
            // 
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContent.Location = new System.Drawing.Point(12, 41);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(678, 542);
            this.txtContent.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(722, 83);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFileName.Location = new System.Drawing.Point(722, 57);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(114, 20);
            this.txtFileName.TabIndex = 2;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(719, 41);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(57, 13);
            this.lblFileName.TabIndex = 3;
            this.lblFileName.Text = "File Name:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(722, 125);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(114, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load File";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblRevisionNumber
            // 
            this.lblRevisionNumber.AutoSize = true;
            this.lblRevisionNumber.Location = new System.Drawing.Point(33, 9);
            this.lblRevisionNumber.Name = "lblRevisionNumber";
            this.lblRevisionNumber.Size = new System.Drawing.Size(0, 13);
            this.lblRevisionNumber.TabIndex = 5;
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Location = new System.Drawing.Point(294, 9);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(0, 13);
            this.lblDateTime.TabIndex = 6;
            // 
            // btnOlderRevision
            // 
            this.btnOlderRevision.Location = new System.Drawing.Point(722, 195);
            this.btnOlderRevision.Name = "btnOlderRevision";
            this.btnOlderRevision.Size = new System.Drawing.Size(133, 23);
            this.btnOlderRevision.TabIndex = 7;
            this.btnOlderRevision.Text = "Show Older Revision";
            this.btnOlderRevision.UseVisualStyleBackColor = true;
            this.btnOlderRevision.Click += new System.EventHandler(this.btnOlderRevision_Click);
            // 
            // btnNewerRevision
            // 
            this.btnNewerRevision.Location = new System.Drawing.Point(722, 224);
            this.btnNewerRevision.Name = "btnNewerRevision";
            this.btnNewerRevision.Size = new System.Drawing.Size(133, 23);
            this.btnNewerRevision.TabIndex = 8;
            this.btnNewerRevision.Text = "Show Newer Revision";
            this.btnNewerRevision.UseVisualStyleBackColor = true;
            this.btnNewerRevision.Click += new System.EventHandler(this.btnNewerRevision_Click);
            // 
            // tmrAutoSave
            // 
            this.tmrAutoSave.Enabled = true;
            this.tmrAutoSave.Interval = 60000;
            this.tmrAutoSave.Tick += new System.EventHandler(this.tmrAutoSave_Tick);
            // 
            // NotepadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 618);
            this.Controls.Add(this.btnNewerRevision);
            this.Controls.Add(this.btnOlderRevision);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblRevisionNumber);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtContent);
            this.Name = "NotepadForm";
            this.Text = "My Notepad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblRevisionNumber;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Button btnOlderRevision;
        private System.Windows.Forms.Button btnNewerRevision;
        private System.Windows.Forms.Timer tmrAutoSave;
    }
}

