namespace MusicatViewers {
	partial class WorkspaceStaffView {
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            MusicStaffDrawer.ClefTreble clefTreble7 = new MusicStaffDrawer.ClefTreble();
            MusicStaffDrawer.ClefTreble clefTreble8 = new MusicStaffDrawer.ClefTreble();
            MusicStaffDrawer.ClefTreble clefTreble9 = new MusicStaffDrawer.ClefTreble();
            MusicStaffDrawer.ClefTreble clefTreble10 = new MusicStaffDrawer.ClefTreble();
            MusicStaffDrawer.ClefTreble clefTreble11 = new MusicStaffDrawer.ClefTreble();
            MusicStaffDrawer.ClefTreble clefTreble12 = new MusicStaffDrawer.ClefTreble();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblMotives = new System.Windows.Forms.Label();
            this.lblLayer2 = new System.Windows.Forms.Label();
            this.labelLayer1 = new System.Windows.Forms.Label();
            this.staff1 = new StaffControl.Staff();
            this.staffTop = new StaffControl.Staff();
            this.staff5 = new StaffControl.Staff();
            this.staff4 = new StaffControl.Staff();
            this.staff3 = new StaffControl.Staff();
            this.staff2 = new StaffControl.Staff();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNotes
            // 
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtNotes.Location = new System.Drawing.Point(0, 374);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(760, 189);
            this.txtNotes.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelLayer1);
            this.splitContainer1.Panel1.Controls.Add(this.lblLayer2);
            this.splitContainer1.Panel1.Controls.Add(this.staff1);
            this.splitContainer1.Panel1.Controls.Add(this.staffTop);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblMotives);
            this.splitContainer1.Panel2.Controls.Add(this.staff5);
            this.splitContainer1.Panel2.Controls.Add(this.staff4);
            this.splitContainer1.Panel2.Controls.Add(this.staff3);
            this.splitContainer1.Panel2.Controls.Add(this.staff2);
            this.splitContainer1.Size = new System.Drawing.Size(760, 368);
            this.splitContainer1.SplitterDistance = 545;
            this.splitContainer1.TabIndex = 1;
            // 
            // lblMotives
            // 
            this.lblMotives.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblMotives.AutoSize = true;
            this.lblMotives.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotives.Location = new System.Drawing.Point(67, 3);
            this.lblMotives.Name = "lblMotives";
            this.lblMotives.Size = new System.Drawing.Size(91, 13);
            this.lblMotives.TabIndex = 4;
            this.lblMotives.Text = "Active Motives";
            // 
            // lblLayer2
            // 
            this.lblLayer2.AutoSize = true;
            this.lblLayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLayer2.Location = new System.Drawing.Point(3, 3);
            this.lblLayer2.Name = "lblLayer2";
            this.lblLayer2.Size = new System.Drawing.Size(49, 13);
            this.lblLayer2.TabIndex = 5;
            this.lblLayer2.Text = "Layer 2";
            // 
            // labelLayer1
            // 
            this.labelLayer1.AutoSize = true;
            this.labelLayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLayer1.Location = new System.Drawing.Point(3, 163);
            this.labelLayer1.Name = "labelLayer1";
            this.labelLayer1.Size = new System.Drawing.Size(49, 13);
            this.labelLayer1.TabIndex = 6;
            this.labelLayer1.Text = "Layer 1";
            // 
            // staff1
            // 
            this.staff1.Clef = clefTreble7;
            this.staff1.Dock = System.Windows.Forms.DockStyle.Top;
            this.staff1.Location = new System.Drawing.Point(0, 160);
            this.staff1.Measures = null;
            this.staff1.Name = "staff1";
            this.staff1.PointSize = 36;
            this.staff1.Size = new System.Drawing.Size(545, 160);
            this.staff1.TabIndex = 4;
            this.staff1.Text = "staff1";
            this.staff1.TimeSignatureDenominator = 4;
            this.staff1.TimeSignatureNumerator = 4;
            this.staff1.DrawStaffLines = true;
            // 
            // staffTop
            // 
            this.staffTop.Clef = clefTreble8;
            this.staffTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.staffTop.Location = new System.Drawing.Point(0, 0);
            this.staffTop.Measures = null;
            this.staffTop.Name = "staffTop";
            this.staffTop.PointSize = 36;
            this.staffTop.Size = new System.Drawing.Size(545, 160);
            this.staffTop.TabIndex = 3;
            this.staffTop.Text = "staffTop";
            this.staffTop.TimeSignatureDenominator = 4;
            this.staffTop.TimeSignatureNumerator = 4;
            this.staffTop.DrawStaffLines = true;
            
            // 
            // staff5
            // 
            this.staff5.Clef = clefTreble9;
            this.staff5.Dock = System.Windows.Forms.DockStyle.Top;
            this.staff5.Location = new System.Drawing.Point(0, 236);
            this.staff5.Measures = null;
            this.staff5.Name = "staff5";
            this.staff5.PointSize = 20;
            this.staff5.Size = new System.Drawing.Size(211, 84);
            this.staff5.TabIndex = 3;
            this.staff5.Text = "staff5";
            this.staff5.TimeSignatureDenominator = 4;
            this.staff5.TimeSignatureNumerator = 4;
            this.staff5.DrawStaffLines = false;
            
            // 
            // staff4
            // 
            this.staff4.Clef = clefTreble10;
            this.staff4.Dock = System.Windows.Forms.DockStyle.Top;
            this.staff4.Location = new System.Drawing.Point(0, 170);
            this.staff4.Measures = null;
            this.staff4.Name = "staff4";
            this.staff4.PointSize = 20;
            this.staff4.Size = new System.Drawing.Size(211, 66);
            this.staff4.TabIndex = 2;
            this.staff4.Text = "staff4";
            this.staff4.TimeSignatureDenominator = 4;
            this.staff4.TimeSignatureNumerator = 4;
            this.staff4.DrawStaffLines = false;

            // 
            // staff3
            // 
            this.staff3.Clef = clefTreble11;
            this.staff3.Dock = System.Windows.Forms.DockStyle.Top;
            this.staff3.Location = new System.Drawing.Point(0, 87);
            this.staff3.Measures = null;
            this.staff3.Name = "staff3";
            this.staff3.PointSize = 20;
            this.staff3.Size = new System.Drawing.Size(211, 83);
            this.staff3.TabIndex = 1;
            this.staff3.Text = "staff3";
            this.staff3.TimeSignatureDenominator = 4;
            this.staff3.TimeSignatureNumerator = 4;
            this.staff3.DrawStaffLines = false;

            // 
            // staff2
            // 
            this.staff2.Clef = clefTreble12;
            this.staff2.Dock = System.Windows.Forms.DockStyle.Top;
            this.staff2.Location = new System.Drawing.Point(0, 0);
            this.staff2.Measures = null;
            this.staff2.Name = "staff2";
            this.staff2.PointSize = 20;
            this.staff2.Size = new System.Drawing.Size(211, 87);
            this.staff2.TabIndex = 0;
            this.staff2.Text = "staff2";
            this.staff2.TimeSignatureDenominator = 4;
            this.staff2.TimeSignatureNumerator = 4;
            this.staff2.DrawStaffLines = false;

            // 
            // WorkspaceStaffView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtNotes);
            this.Name = "WorkspaceStaffView";
            this.Size = new System.Drawing.Size(760, 563);
            this.Resize += new System.EventHandler(this.WorkspaceStaffView_Resize);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private StaffControl.Staff staff1;
        private StaffControl.Staff staffTop;
        private StaffControl.Staff staff5;
        private StaffControl.Staff staff4;
        private StaffControl.Staff staff3;
        private StaffControl.Staff staff2;
        private System.Windows.Forms.Label labelLayer1;
        private System.Windows.Forms.Label lblLayer2;
        private System.Windows.Forms.Label lblMotives;
	}
}
