using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FARGCore;
using MusicatViewers;

namespace Musicat {
    public partial class FormMain : Form {

		#region Private data

		private Musicat musicat;

		private MusicatOptionsForm.OptionsFormData optionsMusicat;
		private OptionsForm.OptionsFormData optionsCore;

		#endregion

		#region Initialization

		public FormMain() {
            InitializeComponent();

			// Load saved settings.
			LoadSettings();

			// Create objects.
			musicat = new Musicat();

			// Set up the form.
			SetupInitialForm();
		}

		#endregion

		#region GUI Event Handlers

		// Change the visible view.
        private void cbView_SelectedIndexChanged(object sender, EventArgs e) {
            viewContainer.Text = cbView.Text;

            switch (cbView.Text) {
                case "Coderack":
                    viewContainer.Viewer = new FARGViewers.CoderackView(musicat.CodeRack);
                    break;
                case "Slipnet":
					viewContainer.Viewer = new FARGViewers.SlipnetView();
                    break;
                case "Workspace":
					viewContainer.Viewer = new MusicatViewers.WorkspaceStaffView(musicat.Workspace);
                    break;
            }
        }

        private void txtInput_TextUpdate(object sender, EventArgs e) {
            validateGo();
        }
        private void validateGo() {
            // Validate input melody string.
            try {
                MusicatCore.NoteStream ns = new MusicatCore.NoteStream(txtInput.Text);
                btnGo.Enabled = true;
                // Also show a preview.
                PreviewMelody();
            } catch (ArgumentException) {
                // Couldn't validate. Disable Go button.
                btnGo.Enabled = false;
                // Clear preview.
                ClearPreview();                
            }
        }

        private void txtInput_SelectedIndexChanged(object sender, EventArgs e) {
            validateGo();
        }
      

        private void musicatSpecificToolStripMenuItem_Click(object sender, EventArgs e) {
			MusicatOptionsForm frm = new MusicatOptionsForm();
			// set form state.
			frm.UseHierarchy = optionsMusicat.useHierarchy;

			if (frm.ShowDialog() == DialogResult.OK) {
				// record form state.
				optionsMusicat.useHierarchy = frm.UseHierarchy;
			}
        }

        private void fARGCoreToolStripMenuItem_Click(object sender, EventArgs e) {
			OptionsForm frm = new OptionsForm();
			// set form state.
			frm.ParallelCodelets = optionsCore.parallelCodelets;

			if (frm.ShowDialog() == DialogResult.OK) {
				// record form state.
				optionsCore.parallelCodelets = frm.ParallelCodelets;
			}
		}
		#endregion

		#region Drawing and Resizing

		///////////////////////////////////////
		/// Drawing.
		///////////////////////////////////////

		private void grpOutput_Paint(object sender, PaintEventArgs e) {
			/*viewContainer.Height = (grpOutput.Height - 28) * 2 / 3;
			txtOutput.Top = viewContainer.Top + viewContainer.Height + 6;
			txtOutput.Height = (grpOutput.Height - 28) * 1 / 3;*/
            viewContainer.Height = (grpOutput.Height - 28) * 7 / 8;
            txtOutput.Top = viewContainer.Top + viewContainer.Height + 6;
            txtOutput.Height = (grpOutput.Height - 28) * 1 / 8;
		}

		#endregion

		#region Running and Background Processing

		private void btnGo_Click(object sender, EventArgs e) {
			txtOutput.Text = "";
			btnGo.Enabled = false;
			btnCancel.Enabled = true;

			// Set up the run options.
			MusicatRunParams p = new MusicatRunParams(txtInput.Text, optionsCore, optionsMusicat);

			// Now create the new thread and pass in the parameters.
			try {
				backgroundWorkerMain.RunWorkerAsync(p);
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
				btnGo.Enabled = true;
				btnCancel.Enabled = false;
			}
		}
		
		///////////////////////////////////////
		// Background Worker methods -- these handle the asynchronous running of the engine.
		///////////////////////////////////////

		private void backgroundWorkerMain_DoWork(object sender, DoWorkEventArgs e) {
			// Get the parameters to use.
			MusicatRunParams p = (MusicatRunParams)e.Argument;
			// Run Musicat on the thread.
			string result = musicat.Run(backgroundWorkerMain, e, txtOutput, p.userInput);
			// Return the results.
			e.Result = result;
		}

		private void backgroundWorkerMain_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			// TODO.
		}

		private void backgroundWorkerMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			// Display final results.
			txtOutput.Text = (string)e.Result;

			btnGo.Enabled = true;
			btnCancel.Enabled = false;
		}

		#endregion

		#region Load and Save program state

		/// <summary>
		/// Sets the initial form GUI state.
		/// </summary>
		private void SetupInitialForm() {
			// Set up form size/location.
			this.StartPosition = FormStartPosition.Manual;
			this.Location = Properties.Settings.Default.MainFormLoc;
			this.Size = Properties.Settings.Default.MainFormSize;
			this.WindowState = Properties.Settings.Default.MainFormState;

			// Setup GUI.
			cbView.SelectedItem = cbView.Items[2];
			validateGo();
		}

		/// <summary>
		/// Load special program options.
		/// </summary>
		private void LoadSettings() {
			// Load settings.
			// Core.
			optionsCore = FARGCore.Utilities.LoadSettings();
			// Musicat.
			optionsMusicat.useHierarchy = Properties.Settings.Default.OptionMusicatUseHierarchy;
		}

		// Handle saving settings when the form closes.
		private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
			// Save settings.
			if (this.WindowState == FormWindowState.Normal) {
				Properties.Settings.Default.MainFormLoc = this.Location;
				Properties.Settings.Default.MainFormSize = this.Size;
			} else {
				Properties.Settings.Default.MainFormLoc = this.RestoreBounds.Location;
				Properties.Settings.Default.MainFormSize = this.RestoreBounds.Size;
			}
			Properties.Settings.Default.MainFormState = this.WindowState;

			// Core.
			FARGCore.Utilities.SaveSettings(optionsCore);

			// Musicat.
			Properties.Settings.Default.OptionMusicatUseHierarchy = optionsMusicat.useHierarchy;

			// Save.
			Properties.Settings.Default.Save();
		}
		#endregion

		private void btnCancel_Click(object sender, EventArgs e) {
			
			// TODO?
			this.backgroundWorkerMain.CancelAsync();
		}

        private void PreviewMelody() {
            // Display.
            musicat.Workspace.Layers = new List<MusicatCore.HierarchyLayer>();
            MusicatCore.HierarchyLayer layer = new MusicatCore.HierarchyLayer(0, musicat.Workspace);
            layer.Notes = new MusicatCore.NoteStream(txtInput.Text);             // Parse the input melody string.
            musicat.Workspace.Layers.Add(layer);
            musicat.Workspace.UpdateView();
        }

        private void ClearPreview() {
            musicat.Workspace.Layers = new List<MusicatCore.HierarchyLayer>();
            MusicatCore.HierarchyLayer layer = new MusicatCore.HierarchyLayer(0, musicat.Workspace);
            musicat.Workspace.Layers.Add(layer);
            musicat.Workspace.UpdateView();
        }
	}
}