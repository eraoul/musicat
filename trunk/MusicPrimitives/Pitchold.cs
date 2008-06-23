using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPrimitives {
	struct Pitch {
		/// <summary>The note number used here corresponds to a natural, white key note.  Each note number can be 
		/// combined with one of the 5 accidentals to represent one of 5 different pitches.  Natural note number 0 
		/// corresponds to MIDI 0, C in octave -1.  Middle C is natural note number 35, MIDI 60, C4.  G4 is natural 
		/// note number 39, C5 is note number 42, etc.
		/// </summary>
		public int noteNumber;	// white-key number.
		
		/// <summary>
		/// Octave must be at least -1.  C4 is middle C (octave = 4)
		/// </summary>
		public int octave;

		public Accidental accidental;
		
		/// <summary>
		/// The white key in the octavte: 0=C, 1=D, 2=E, 3=F, 4=G, 5=A, 6=B
		/// </summary>
		public int WhiteOffset;	
	}
}
