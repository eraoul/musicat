using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MusicatCore {
	public class Note {

        private static readonly int[] pitchOffsets = { 9, 11, 0, 2, 4, 5, 7 };    // # half steps above C, where index is the # white keys above A.

        private int userOctave;

        private HierarchyLayer layer;

        /// <summary>
        /// Link to the containing layer for this note.
        /// </summary>
        public HierarchyLayer Layer {
            get { return layer; }
            set { layer = value; }
        }

        /// <summary>
        /// This is the user-specified octave from the constructor, if specified. This differs from MIDI octave for notes like Cb.
        /// </summary>
        public int UserOctave {
            get { return userOctave; }
            set { userOctave = value; }
        }
		
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
		private List<Perception> perceptions;
		/// <summary>
		/// Exact start time from start of piece
		/// </summary>
		private int start_time;

		public int StartTime {
			get { return start_time; }
			set { start_time = value; }
		}
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
		private List<NoteGroup> groupMemberships;


        /// <summary>
        /// Regular expression used to parse note names from strings.
        /// </summary>
        private static Regex regexNote = new Regex(@"
            ^                   # be sure to match start of token, so Bbb works, etc.
            [a-gA-G]            # note name (not grouped, since we just get it from the string)
            (\#|b|x|bb)?        # 1) optional accidental
            (\d)?               # 2) optional octave
            $                   # as above, also match end of token
            ", RegexOptions.IgnorePatternWhitespace);
            
		/// <param name="midi">The actual MIDI # of the note.</param>
		/// <param name="start_time">The start time of the note.</param>
		public Note(int midi, int start_time) {
            this.midi = midi;
            this.start_time = start_time;
            userOctave = -1;        //undefined
		}

        /// <summary>
        /// Generates a note from the token and default octave.
        /// </summary>
        /// <param name="token">Note tokens can be notes with or without octave info. 
        // Ex: C4 or C#4 or D5. </param>
        /// <param name="octave">If no octave is specified in the token,
        /// we use default octave. </param>
        public Note(string token, int default_octave) {
            // Split note into letter+accidental+numeral.
            Match m = regexNote.Match(token);
            if (!m.Success)
                throw new ArgumentException("Pitch '" + token + "' not recognized in Note constructor.");
            char pitch = token[0];
            string accidental = m.Groups[1].Value;
            string octaveString = m.Groups[2].Value;

            userOctave = (octaveString.Length == 0) ? default_octave : int.Parse(octaveString);
            
            // Calculate the # of white keys above A.
            int whiteKeyOffset = (pitch >= 'a' && pitch <= 'g') ? (int)(pitch - 'a') :
                                                               (int)(pitch - 'A');
            // Convert to # half steps above C with a lookup table.
            int pitchOffset = pitchOffsets[whiteKeyOffset];

            int accidentalOffset;
            switch (accidental) {
                case "#":
                    accidentalOffset = 1;
                    break;
                case "b":
                    accidentalOffset = -1;
                    break;
                case "x":
                    accidentalOffset = 2;
                    break;
                case "bb":
                    accidentalOffset = -2;
                    break;
                default:
                    accidentalOffset = 0;
                    break;
            }

            this.midi = (userOctave + 1) * 12 + pitchOffset + accidentalOffset;
        }

		/// <summary>
		/// Converts the MIDI # to a name (using sharps). No perception involved.
		/// </summary>
		public String GetName() {
			switch (midi%12) {
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
            return GetName() + GetOctave(); // +", start_time=" + start_time;
		}

        public int GetIndexInLayer() {
            return layer.Notes.IndexOf(this);
        }

    }
}
