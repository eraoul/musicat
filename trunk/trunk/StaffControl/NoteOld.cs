using System;
using System.Collections.Generic;
using System.Text;

namespace TwoNoteModel {
	public class Note {
		/// <summary>
		/// The MIDI pitch
		/// </summary>
		private int midi;
		/// <summary>
		/// Contains perceived attributes of the note; these are subjective, while the exact midi pitch and duration are fixed.
		/// </summary>
		//private List<Perception> perceptions;
		/// <summary>
		/// Exact start time from start of piece
		/// </summary>
		private int start_time;

		public int StartTime {
			get { return start_time; }
			set { start_time = value; }
		}

		///// <summary>
		///// Link to the note's containing layer.
		///// </summary>
		//private HierarchyLayer layer;

		//public HierarchyLayer Layer {
		//    get { return layer; }
		//    set { layer = value; }
		//}

		/// <summary>
		/// A link to the version of this note in the next-higher layer.
		/// </summary>
		private Note noteLinkedAbove;
		/// <summary>
		/// A link to the version of this note in the next-lower-layer.
		/// </summary>
		private Note noteLinkedBelow;
		/// <summary>
		/// List of groups this note belongs to.
		/// </summary>
		//private List<NoteGroup> groupMemberships;

		/// <param name="midi">The actual MIDI # of the note.</param>
		/// <param name="start_time">The start time of the note.</param>
		public Note(int midi, int start_time) {
			this.midi = midi;
			this.start_time = start_time;
		}

		/// <summary>
		/// Converts the MIDI # to a name (using sharps). No perception involved.
		/// </summary>
		public String GetName() {
			switch (midi % 12) {
				case 0:
					return "C";
				case 1:
					return "C#";
				case 2:
					return "D";
				case 3:
					return "D#";
				case 4:
					return "E";
				case 5:
					return "F";
				case 6:
					return "F#";
				case 7:
					return "G";
				case 8:
					return "G#";
				case 9:
					return "A";
				case 10:
					return "A#";
				case 11:
					return "B";
				default:
					return "ERROR";
			}
		}

		/// <summary>
		/// Converts the MIDI # to an octave. No perception involved.
		/// </summary>
		public int GetOctave() {
			return midi / 12 - 1;
		}

		public override string ToString() {
			//return GetName() + ", start_time=" + start_time;
			return GetName() + GetOctave().ToString();
		}

		/// <summary>
		/// Builds a link to a note at a higher layer.
		/// </summary>
		public void LinkToNoteAbove(Note n) {
			noteLinkedAbove = n;
			n.noteLinkedBelow = this;
		}

		/// <summary>
		/// Builds a link to a note at a lower layer.
		/// </summary>
		public void LinkToNoteBelow(Note n) {
			noteLinkedBelow = n;
			n.noteLinkedAbove = this;
		}
	}
}
