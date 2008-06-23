using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FARGViewers {
	public partial class ViewContainer : GroupBox {

		private ViewControl viewer;

		public ViewContainer() {
			InitializeComponent();
		}

		public ViewControl Viewer {
			set {
				// Remove the current view.
				if (viewer != null)
					this.Controls.Remove(viewer);
				
				// Record and add the new view.
				viewer = value;
				this.Controls.Add(viewer);
			}
		}

		private void ViewContainer_Paint(object sender, PaintEventArgs e) {
			if (viewer != null) {
				// Set sizes.
				viewer.Height = this.Height - 28;
				viewer.Width = this.Width - 12;
				viewer.Top = 22;
				viewer.Left = 6;
			}
		}

	}
}