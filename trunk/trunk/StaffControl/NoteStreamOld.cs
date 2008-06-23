using System;
using System.Collections.Generic;
using System.Text;

namespace TwoNoteModel {
	public class NoteStream {
		private List<Note> notes;

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

		public override string ToString() {
			if (notes.Count == 0)
				return "Empty note stream.";
			string s = "";
			foreach (Note n in notes)
				s += n.ToString() + " ";
			return s.Substring(0, s.Length-1) + Environment.NewLine; // strip off trailing space
		}
	}
}
