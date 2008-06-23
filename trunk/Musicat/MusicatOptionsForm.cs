using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Musicat {
    public partial class MusicatOptionsForm : Form {

		/// <summary>
		/// Struct to store form data.
		/// </summary>
		[Serializable]
		public struct OptionsFormData {
			// Workspace options.
			public bool useHierarchy;
		}


		public bool UseHierarchy {
			get { return chkHierarchy.Checked; }
			set { chkHierarchy.Checked = value; }
		}

        public MusicatOptionsForm() {
            InitializeComponent();
        }

		private void MusicatOptionsForm_Load(object sender, EventArgs e) {
			this.Size = Properties.Settings.Default.OptionsSize;
			this.Location = Properties.Settings.Default.OptionsLoc;
		}

		private void MusicatOptionsForm_FormClosing(object sender, FormClosingEventArgs e) {
			Properties.Settings.Default.OptionsSize = this.Size;
			Properties.Settings.Default.OptionsLoc = this.Location;
			Properties.Settings.Default.Save();
		}

    }
}