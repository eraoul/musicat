using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FARGCore {
    public partial class OptionsForm : Form {

		/// <summary>
		/// Struct to store form data.
		/// </summary>
		[Serializable]
		public struct OptionsFormData {
			// Coderack options.
			public bool parallelCodelets;
		}


		public bool ParallelCodelets {
			get { return chkParallelCodelets.Checked; }
			set { chkParallelCodelets.Checked = value; }
		}

		
		public OptionsForm() {
            InitializeComponent();
        }


		private void OptionsForm_Load(object sender, EventArgs e) {
			this.Size = Settings.Default.MySize;
			this.Location = Settings.Default.MyLoc;
		}

		private void OptionsForm_FormClosing(object sender, FormClosingEventArgs e) {
			Settings.Default.MySize = this.Size;
			Settings.Default.MyLoc = this.Location;
			Settings.Default.Save();
		}

    }
}