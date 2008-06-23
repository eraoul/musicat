using System;

namespace MusicStaffDrawer {
	/*/// <summary>
	/// Summary description for Clef.
	/// </summary>
	public enum Clef
	{
		Treble,
		Bass,
		Alto,
		Tenor
	}*/
	public abstract class Clef {
		protected string name;
		protected int staffLine;
		protected char clefChar;
		protected int numberCenter;

		public Clef(string name, int staffLine, char clefChar, int numberCenter) {
			this.name = name;
			this.staffLine = staffLine;
			this.clefChar = clefChar;
			this.numberCenter = numberCenter;
		}


		public string Name {
			get { return name; }
		}
		public int StaffLine {
			get { return staffLine; }
		}
		public char ClefChar {
			get { return clefChar; }
		}
		public int NumberCenter {
			get { return numberCenter; }
		}

	}

}
