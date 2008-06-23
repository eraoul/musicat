using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Threading;
using System.ComponentModel;

using FARGCore;
using MusicatCore;

namespace Musicat {
    public class Musicat {

		private Coderack codeRack;

		public Coderack CodeRack {
			get { return codeRack; }
		}
		private Slipnet slipnet;

		public Slipnet Slipnet {
			get { return slipnet; }
		}
		private MusicatWorkspace workspace;

		public MusicatWorkspace Workspace {
			get { return workspace; }
		}

        /// <summary>
        /// The notes to feed into the workspace as time progresses.
        /// </summary>
        private NoteStream inputMelody;

        private System.Windows.Forms.TextBox txtOut;

        /// <summary>
        /// Creates the Slipnet, Workspace, and Coderack.
        /// </summary>
        public Musicat() {
            workspace = new MusicatWorkspace();
            slipnet = new Slipnet();
            codeRack = new Coderack(workspace, slipnet);

            init();
        }

        /// <summary>
        /// Runs the model.
        /// </summary>
        public string Run(BackgroundWorker worker, DoWorkEventArgs e, System.Windows.Forms.TextBox txtOut, string melody) {
            // Record the output control.
            this.txtOut = txtOut;

            // Reset everything.
            init();

            // Parse the input melody string.
            inputMelody = new NoteStream(melody);
            
            // Main loop! Feed in the notes 1 at a time, running a certain # of codelets between each node.
            foreach(Note note in inputMelody) {
                workspace.AddInputNote(note);

                for (int i = 0; i < 10; i++) {
                    // Test for cancel request.
                    if (worker.CancellationPending) {
                        return "Cancelled.";
                    }

                    // TODO: test for pause button.

                    codeRack.RunNextCodelet();

                    //Thread.Sleep(10);
                }
            }


            //output("inputMelody = " + inputMelody.ToString());
			return "inputMelody = " + inputMelody.ToString();

        }

        // Initializes the workspace, coderack, etc. Wipes out old versions from previous runs.
        public void init() {
            workspace.Reset();
            codeRack.Reset();
            slipnet.Reset();
            
            List<Assembly> assemblies = new List<Assembly>();   // the list of assemblies containing codelets.
            
            assemblies.Add(Assembly.GetExecutingAssembly());    // Adds the musicat assembly.
            // Add the MusicatCore assembly.
            assemblies.Add(Assembly.GetAssembly(typeof(MusicatWorkspace)));
            
            // Prepopulate the coderack with the codelets found in the source code tagged with the CodeletAttribute.
            codeRack.Populate(assemblies);
        }

        /*private void output(string s) {
            txtOut.Text += s;
            txtOut.Refresh();
        }*/
    }
}
