using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;

namespace FARGCore {

    public class CoderackEventArgs : EventArgs {
        public Coderack coderack;

        public CoderackEventArgs(Coderack coderack) {
            this.coderack = coderack;
        }
    }


	public class Coderack : IEnumerable {
        private Workspace workspace;
        private Slipnet slipnet;

		private List<Codelet> codelets;
		private List<Codelet> codelets_finished;

        public event EventHandler<CoderackEventArgs> Update;

        public Coderack(Workspace workspace, Slipnet slipnet) {
            this.workspace = workspace;
            this.slipnet = slipnet;
		}

        public void Reset() {
            codelets = new List<Codelet>(500);
            codelets_finished = new List<Codelet>(10000);
        }

        public void Populate(List<Assembly> codeletAssemblies) {
            Reset();

            // Initialize Coderack with the codelets we find via reflection.
            // TODO: Do this at compile-time, with PostSharp

            foreach (Assembly asm in codeletAssemblies) {
                foreach (Type t in asm.GetExportedTypes()) {
                    foreach (Attribute a in t.GetCustomAttributes(false)) {
                        CodeletAttribute ca = a as CodeletAttribute;
                        if (ca != null) {
                            // Add 50 copies of each codelet.
                            for (int i = 0; i < 50; i++)
                                codelets.Add((Codelet)asm.CreateInstance(t.FullName, false, BindingFlags.CreateInstance, null, 
                                    new object[] { ca.DefaultUrgency, null, this, workspace, slipnet }, 
                                    null, null));
                        }
                    }
                }
            }

            UpdateView();
        }

		/// <summary>
		/// Picks a codelet based on urgency values, and runs it.
		/// Codelet is removed from rack when it starts running.
		/// TODO: could implement more efficiently if we persist the cumulative distribution
		/// values and update when codelets are removed.
		/// TODO: run in parallel instead of serial.
		/// </summary>
		public void RunNextCodelet() {
			int[] dist = new int[codelets.Count]; // stores the cumulative urgency distribution

            if (codelets.Count == 0)
                return;

			// Build cumulative prob. distribution.
			dist[0] = codelets[0].Urgency;
			for (int i = 1; i < codelets.Count; i++)
				dist[i] = dist[i - 1] + codelets[i].Urgency;

			int max = dist[codelets.Count - 1];

			// Choose a random-weighted codelet.
			int r = Utilities.rand.Next(max);	// generates a num from 0 to max-1

			for (int i = 0; i < codelets.Count; i++) {
				if (r < dist[i]) {
					// Remove the winner from the to-run list.
					Codelet c = codelets[i];
					codelets.RemoveAt(i);

                    UpdateView();
                    
                    // Run this codelet.
					Log("Running codelet " + c.ToString());
					c.Run();
					
					// Add to the completed list.
					codelets_finished.Add(c);

                    UpdateView();
					
					break;
				}
			}
		}

		public void AddCodelet(Codelet c) {
			codelets.Add(c);
            UpdateView();
		}

		public int Count {
			get {
				return codelets.Count;
			}
		}

		public Codelet this[int index] {
			get {
				return codelets[index];
			}
		}


		#region IEnumerable Members

		public IEnumerator GetEnumerator() {
			return codelets.GetEnumerator();
		}

		#endregion

		private void Log(string s) {
			Console.WriteLine(s);
		}

        /// <summary>
        /// Raise an event to let viewers update their views.
        /// </summary>
        private void UpdateView() {
            // Verify we have subsubscribed event handlers.
            if (Update != null) {
                CoderackEventArgs ea = new CoderackEventArgs(this);
                Update(this, ea);
            }
        }

	}
}
