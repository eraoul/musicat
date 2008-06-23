using System;
using System.Collections.Generic;
using System.Text;
//using FARGV
namespace MusicPrimitives {
	public class Note {
		/// <summary>
		/// The MIDI pitch
		/// </summary>
		private int midi;

		public int Midi {
			get { return midi; }
			set { midi = value; }
		}
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
		/// </summary
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

		public Pitch GetPitch(Key k) {

			return new Pitch(midi, k);

			//int offset;
			//bool preferSharps;

			/*// Get the offset within the C-based octave.
			p.octave = GetOctave();

			offset = midi % 12;
			// Allow for going below 0; this is used for PitchClass calculations.
			if (offset < 0)
				offset += 12; // Correct for the mod operator % returning a negative result for negative numbers.

		
			// Pick accidental class based on key.

			
			// Assume natural.
			p.accidental = Accidental.Natural;	
		
			// The note name and accidental are defined in a lookup table:
			switch (offset) 
			{
				case 0:
					//name = 'C';		
					p.WhiteOffset = 0;
					break;

				case 1:
					if (preferSharps) 
					{
						p.WhiteOffset = 0;
						//name = 'C';
						accidental = Accidental.Sharp;
					} 
					else 
					{
						p.WhiteOffset = 1;
						//name = 'D';
						accidental = Accidental.Flat;
					}
					break;
			
				case 2:
					p.WhiteOffset = 1;
					//name = 'D';		
					break;

				case 3:
					if (preferSharps) 
					{
						p.WhiteOffset = 1;
						//name = 'D';
						accidental = Accidental.Sharp;
					} 
					else 
					{
						p.WhiteOffset = 2;
						//name = 'E';
						accidental = Accidental.Flat;
					}
					break;

				case 4:
					p.WhiteOffset = 2;
					//name = 'E';		
					break;
			
				case 5:
					p.WhiteOffset = 3;
					//name = 'F';		
					break;

				case 6:
					if (preferSharps) 
					{
						p.WhiteOffset = 3;
						//name = 'F';
						accidental = Accidental.Sharp;
					} 
					else 
					{
						p.WhiteOffset = 4;
						//name = 'G';
						accidental = Accidental.Flat;
					}
					break;

				case 7:
					p.WhiteOffset = 4;
					//name = 'G';		
					break;

				case 8:
					if (preferSharps) 
					{
						p.WhiteOffset = 4;
						//name = 'G';
						accidental = Accidental.Sharp;
					} 
					else 
					{
						p.WhiteOffset = 5;
						//name = 'A';
						accidental = Accidental.Flat;
					}
					break;

				case 9:
					p.WhiteOffset = 5;
					//name = 'A';		
					break;

				case 10:
					if (preferSharps) 
					{
						p.WhiteOffset = 5;
						//name = 'A';
						accidental = Accidental.Sharp;
					} 
					else 
					{
						p.WhiteOffset = 6;
						//name = 'B';
						accidental = Accidental.Flat;
					}
					break;

				case 11:
					p.WhiteOffset = 6;
					//name = 'B';		
					break;
			}

			// Finally set the note name.
			Name = name;
			*/
		}
	}
}
