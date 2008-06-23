namespace FARGViewers {
	partial class CoderackView {
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
			this.lvMain = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// lvMain
			// 
			this.lvMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvMain.Location = new System.Drawing.Point(0, 0);
			this.lvMain.Name = "lvMain";
			this.lvMain.Size = new System.Drawing.Size(663, 292);
			this.lvMain.TabIndex = 0;
			this.lvMain.UseCompatibleStateImageBehavior = false;
			this.lvMain.View = System.Windows.Forms.View.List;
			// 
			// CoderackView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lvMain);
			this.Name = "CoderackView";
			this.Size = new System.Drawing.Size(663, 292);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lvMain;

	}
}
