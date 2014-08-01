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
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSelTemp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWriteConfig
            // 
            this.btnWriteConfig.Location = new System.Drawing.Point(330, 25);
            this.btnWriteConfig.Name = "btnWriteConfig";
            this.btnWriteConfig.Size = new System.Drawing.Size(75, 23);
            this.btnWriteConfig.TabIndex = 0;
            this.btnWriteConfig.Text = "写配置";
            this.btnWriteConfig.UseVisualStyleBackColor = true;
            this.btnWriteConfig.Click += new System.EventHandler(this.btnWriteConfig_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(77, 12);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(100, 21);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.Text = "test";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(486, 36);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.Location = new System.Drawing.Point(12, 85);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(404, 417);
            this.propertyGrid1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "模板名称:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnSelTemp
            // 
            this.btnSelTemp.Location = new System.Drawing.Point(216, 9);
            this.btnSelTemp.Name = "btnSelTemp";
            this.btnSelTemp.Size = new System.Drawing.Size(75, 23);
            this.btnSelTemp.TabIndex = 6;
            this.btnSelTemp.Text = "选择模板";
            this.btnSelTemp.UseVisualStyleBackColor = true;
            this.btnSelTemp.Click += new System.EventHandler(this.btnSelTemp_Click);
            // 
            // FormLoadConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 502);
            this.Controls.Add(this.btnSelTemp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnWriteConfig);
            this.Name = "FormLoadConfig";
            this.Text = "FormLoadConfig";
            this.Load += new System.EventHandler(this.FormLoadConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWriteConfig;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSelTemp;
    }
}