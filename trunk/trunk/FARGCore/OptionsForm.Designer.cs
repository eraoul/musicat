namespace FARGCore {
    partial class OptionsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.grpCoderack = new System.Windows.Forms.GroupBox();
			this.chkParallelCodelets = new System.Windows.Forms.CheckBox();
			this.btnCanel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.grpCoderack.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpCoderack
			// 
			this.grpCoderack.Controls.Add(this.chkParallelCodelets);
			this.grpCoderack.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpCoderack.Location = new System.Drawing.Point(0, 0);
			this.grpCoderack.Name = "grpCoderack";
			this.grpCoderack.Size = new System.Drawing.Size(629, 114);
			this.grpCoderack.TabIndex = 1;
			this.grpCoderack.TabStop = false;
			this.grpCoderack.Text = "Coderack";
			// 
			// chkParallelCodelets
			// 
			this.chkParallelCodelets.AutoSize = true;
			this.chkParallelCodelets.Location = new System.Drawing.Point(6, 19);
			this.chkParallelCodelets.Name = "chkParallelCodelets";
			this.chkParallelCodelets.Size = new System.Drawing.Size(136, 17);
			this.chkParallelCodelets.TabIndex = 0;
			this.chkParallelCodelets.Text = "Run codelets in parallel";
			this.chkParallelCodelets.UseVisualStyleBackColor = true;
			// 
			// btnCanel
			// 
			this.btnCanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCanel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCanel.Location = new System.Drawing.Point(542, 300);
			this.btnCanel.Name = "btnCanel";
			this.btnCanel.Size = new System.Drawing.Size(75, 23);
			this.btnCanel.TabIndex = 4;
			this.btnCanel.Text = "Cancel";
			this.btnCanel.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(461, 300);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// OptionsForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCanel;
			this.ClientSize = new System.Drawing.Size(629, 335);
			this.Controls.Add(this.btnCanel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.grpCoderack);
			this.Name = "OptionsForm";
			this.Text = "Options";
			this.Load += new System.EventHandler(this.OptionsForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OptionsForm_FormClosing);
			this.grpCoderack.ResumeLayout(false);
			this.grpCoderack.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCoderack;
        private System.Windows.Forms.CheckBox chkParallelCodelets;
		private System.Windows.Forms.Button btnCanel;
		private System.Windows.Forms.Button btnOk;
    }
}