namespace WinApp
{
    partial class FormLoadConfig
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
            this.btnWriteConfig = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWriteConfig
            // 
            this.btnWriteConfig.Location = new System.Drawing.Point(28, 94);
            this.btnWriteConfig.Name = "btnWriteConfig";
            this.btnWriteConfig.Size = new System.Drawing.Size(75, 23);
            this.btnWriteConfig.TabIndex = 0;
            this.btnWriteConfig.Text = "写配置";
            this.btnWriteConfig.UseVisualStyleBackColor = true;
            this.btnWriteConfig.Click += new System.EventHandler(this.btnWriteConfig_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(47, 43);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(100, 21);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.Text = "test";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(136, 94);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // FormLoadConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnWriteConfig);
            this.Name = "FormLoadConfig";
            this.Text = "FormLoadConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWriteConfig;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnExport;
    }
}