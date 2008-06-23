using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MusicatCore {
	public class NoteStream : IEnumerable<Note>, ICloneable {
		private List<Note> notes;

        public int Count {
            get { return notes.Count; }
        }

        public Note this[int index] {
            get { return notes[index]; }
            set { notes[index] = value; }
        }	

		/// <summary>
		/// Gets the start time of the first note in the stream, or 0 if empty.
		/// </summary>
		/// <returns></returns>
		public int GetStartTime() {
			if (notes.Count == 0)
				return 0;
			else
				return notes[0].StartTime;
		}

		/// <summary>
		/// Gets the start time of the final note in the stream, or 0 if empty.
		/// </summary>
		/// <returns></returns>
		public int GetLastTime() {
			if (notes.Count == 0)
				return 0;
			else
				return notes[notes.Count - 1].StartTime;
		}

		public NoteStream() {
			notes = new List<Note>();
		}

        public NoteStream(string melody) {
            int default_octave = 4;
            
            notes = new List<Note>();

            string[] tokens = melody.Trim().Split(' ');
            foreach (string token in tokens) {
                Note n = new Note(token, default_octave);
                AddNote(n.Midi);
                default_octave = n.UserOctave;  // Maintain the explicit user-specified octave as the default octave, 
                                                // even if MIDI octave changes.
            }
        }

		/// <summary>
		/// Adds a fully-constructed Note object to the end of the stream.
		/// </summary>
		/// <param name="note">The new note to add at the end of the stream.</param>
		public void AddNote(Note note) {
			// Validate the note's start-time to make sure it is after the last item in the list.
			if (note.StartTime <= GetLastTime())
				throw new System.ArgumentException("Note start time is earlier than stream end time.", "note");
					
			notes.Add(note);
		}

		/// <summary>
		/// Adds a note with the given midi value to the end of the stream.
		/// If the stream is empty, the note has start time 1. Otherwise it
		/// starts at end_time + 1.
		/// </summary>
		public Note AddNote(int midi) {
			Note note = new Note(midi, GetLastTime() + 1);
			notes.Add(note);
			return note;
		}

        /// <summary>
        /// Check if the given note object exists in the stream.
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public bool Contains(Note note) {
            return notes.Contains(note);
        }

		public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (Note n in notes) {
                sb.Append(n.ToString());
                sb.Append(' ');
            }
            return sb.ToString();
		}

        public int IndexOf(Note note) {
            return notes.IndexOf(note);
        }

        public Note[] CloneNotes() {
            Note[] noteArray = new Note[notes.Count];
            notes.CopyTo(noteArray);
            return noteArray;
        }

        #region IEnumerable<Note> Members

        public IEnumerator<Note> GetEnumerator() {
            return notes.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region ICloneable Members

        public object Clone() {
            NoteStream ns = new NoteStream();
            ns.notes.AddRange(notes);
            return ns;
        }

        #endregion
    }
}
