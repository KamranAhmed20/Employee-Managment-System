namespace WindowsFormsApp2
{
    partial class CloseUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label1 = new System.Windows.Forms.Label();
            this.OkayBtn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Label1.Location = new System.Drawing.Point(36, 26);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(459, 35);
            this.Label1.TabIndex = 10;
            this.Label1.Text = "Make Sure to Log out, before Exit";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OkayBtn
            // 
            this.OkayBtn.AutoSize = true;
            this.OkayBtn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OkayBtn.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkayBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.OkayBtn.Location = new System.Drawing.Point(241, 73);
            this.OkayBtn.Name = "OkayBtn";
            this.OkayBtn.Size = new System.Drawing.Size(40, 26);
            this.OkayBtn.TabIndex = 32;
            this.OkayBtn.Text = "OK";
            this.OkayBtn.Click += new System.EventHandler(this.OkayBtnClicked);
            // 
            // CloseUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Controls.Add(this.OkayBtn);
            this.Controls.Add(this.Label1);
            this.Name = "CloseUserControl";
            this.Size = new System.Drawing.Size(546, 108);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label OkayBtn;
    }
}
