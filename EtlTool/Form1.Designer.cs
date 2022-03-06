namespace EtlTool
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPerformEtl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPerformEtl
            // 
            this.btnPerformEtl.Location = new System.Drawing.Point(255, 145);
            this.btnPerformEtl.Name = "btnPerformEtl";
            this.btnPerformEtl.Size = new System.Drawing.Size(181, 23);
            this.btnPerformEtl.TabIndex = 0;
            this.btnPerformEtl.Text = "Run Process";
            this.btnPerformEtl.UseVisualStyleBackColor = true;
            this.btnPerformEtl.Click += new System.EventHandler(this.btnPerformEtl_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPerformEtl);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnPerformEtl;
    }
}