namespace Musicat {
    partial class MusicatOptionsForm {
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
			this.grp = new System.Windows.Forms.GroupBox();
			this.chkHierarchy = new System.Windows.Forms.CheckBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCanel = new System.Windows.Forms.Button();
			this.grp.SuspendLayout();
			this.SuspendLayout();
			// 
			// grp
			// 
			this.grp.Controls.Add(this.chkHierarchy);
			this.grp.Dock = System.Windows.Forms.DockStyle.Top;
			this.grp.Location = new System.Drawing.Point(0, 0);
			this.grp.Name = "grp";
			this.grp.Size = new System.Drawing.Size(480, 93);
			this.grp.TabIndex = 0;
			this.grp.TabStop = false;
			this.grp.Text = "Workspace";
			// 
			// chkHierarchy
			// 
			this.chkHierarchy.AutoSize = true;
			this.chkHierarchy.Location = new System.Drawing.Point(6, 19);
			this.chkHierarchy.Name = "chkHierarchy";
			this.chkHierarchy.Size = new System.Drawing.Size(91, 17);
			this.chkHierarchy.TabIndex = 0;
			this.chkHierarchy.Text = "Use hierarchy";
			this.chkHierarchy.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(312, 257);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// btnCanel
			// 
			this.btnCanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCanel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCanel.Location = new System.Drawing.Point(393, 257);
			this.btnCanel.Name = "btnCanel";
			this.btnCanel.Size = new System.Drawing.Size(75, 23);
			this.btnCanel.TabIndex = 2;
			this.btnCanel.Text = "Cancel";
			this.btnCanel.UseVisualStyleBackColor = true;
			// 
			// MusicatOptionsForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCanel;
			this.ClientSize = new System.Drawing.Size(480, 292);
			this.Controls.Add(this.btnCanel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.grp);
			this.Name = "MusicatOptionsForm";
			this.Text = "Musicat Options";
			this.Load += new System.EventHandler(this.MusicatOptionsForm_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MusicatOptionsForm_FormClosing);
			this.grp.ResumeLayout(false);
			this.grp.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp;
        private System.Windows.Forms.CheckBox chkHierarchy;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCanel;
    }
}