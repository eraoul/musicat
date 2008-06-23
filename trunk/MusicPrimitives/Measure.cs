using System;
using System.Collections.Generic;
using System.Text;
using MusicPrimitives;

namespace MusicPrimitives {
	public class Measure {


		private int timeSigDenominator;

		public int TimeSigDenominator {
			get { return timeSigDenominator; }
			set { timeSigDenominator = value; }
		}
		private int timeSigNumerator;

		public int TimeSigNumerator {
			get { return timeSigNumerator; }
			set { timeSigNumerator = value; }
		}

		private NoteStream noteStream;

		public NoteStream Notes {
			get { return noteStream; }
			set { noteStream = value; }
		}

		public Measure() {
			Notes = new NoteStream();
		}
	}
}
