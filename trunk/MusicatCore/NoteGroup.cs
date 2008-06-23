using System;
using System.Collections.Generic;
using System.Text;
using FARGCore;

namespace MusicatCore {
	public class NoteGroup {
		/// <summary>
		/// in time-sequential order, left-to-right
		/// </summary>
		private List<Note> notes;
		
        /// <summary>
		/// Strength of group.
		/// </summary>
        private int strength;

        public int Strength {
            get { return strength; }
            set { strength = value; }
        }

        public NoteGroup() {
            notes = new List<Note>();
        }

        public NoteGroup(int strength, List<Note> notes) {
            this.strength = strength;
            this.notes = notes;
        }

        public bool Contains(Note n) {
            return notes.Contains(n);
        }


        public Note PickRandomNote() {
            return notes[Utilities.rand.Next(notes.Count)];
        }

		public override string ToString() {
			StringBuilder sb = new StringBuilder();
            sb.Append("(");
            foreach (Note n in notes) {
                sb.Append(n.ToString() + " ");
            }
            sb.Append(")");

            return sb.ToString();
		}
	}
}
