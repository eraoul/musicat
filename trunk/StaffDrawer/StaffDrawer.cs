using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using MusicPrimitives;


namespace MusicStaffDrawer
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class StaffDrawer
	{
		private const int BorderY = 20;
		private const int BorderX = 20;
		private const int NumStaffLines = 5;
     
		private const char QuarterHead = (char)207;
		private const char HalfHead = (char)205;
		private const char WholeHead = 'w';
		private const char Natural = 'n';
		private const char Sharp = (char)35;
		private const char Flat = 'b';
		private const char DoubleSharp = (char)220;
		private const char DoubleFlat = (char)186;

		public ClefTreble clefTreble = new ClefTreble();
		public ClefBass clefBass = new ClefBass();
		public ClefAlto clefAlto = new ClefAlto();
		public ClefTenor clefTenor = new ClefTenor();


		// User-settable properties.
		private int pointSize;
		private string fontPath;
        private Clef clef;
		private Key key = new Key();
		private int timeSigNumerator = 4;
		private int timeSigDenominator = 4;
		private List<Measure> measures;

        private bool drawStaffLines = true;

        public bool DrawStaffLines
        {
            get { return drawStaffLines; }
            set { drawStaffLines = value; }
        }

		public Key Key {
			get { return key; }
			set { key = value; }
		}
		public List<Measure> Measures {
			get { return measures; }
			set { measures = value; }
		}


		// Temp font data.
		private Graphics gr;
		private PrivateFontCollection pfc;
		private FontFamily ff;
		private Font myFont;
		//		private int emHeight;
		private float topStaffLine;
		private float staffLineSpace;
		private float ascent;
        float LEDGER_WIDTH;
        float LEDGER_X_OFFSET;
        float noteWidth;
        float noteLeftOffset;
        float octaveHeight;

		public StaffDrawer(string fontFolderPath)
		{
			// Find the Fughetta font file.
			//MessageBox.Show(fontFolderPath + @"\fughetta.ttf required!");
			fontPath = fontFolderPath + @"\fughetta.ttf";
			//throw new ArgumentException("Font = " + fontPath, "fontFolderPath");

			//fontPath = @"C:\WINDOWS\Fonts\fughetta.ttf";
			//			fontPath = @"C:\WINDOWS\Fonts\maestro_.ttf";
			PointSize = 36;

			// Set up the music font.
			pfc = new PrivateFontCollection();
			//MessageBox.Show("adding font " + fontPath);
			pfc.AddFontFile(fontPath);
			//MessageBox.Show("done adding font2");
		}

		// Draws a music staff given a graphics context to draw on and a staff data object.
		public void DrawStaff(Graphics g)
		{
          	float y;


			if (g == null)
				throw new ArgumentNullException("gr", "StaffDrawer.DrawStaff graphics object (g) is null");

			gr = g;

			//throw new ArgumentException("Font = " + fontPath, "fontFolderPath");


			//MessageBox.Show("setting font family");
			ff = new FontFamily("Fughetta", pfc);
			//			ff = new FontFamily("Maestro", pfc);
			//MessageBox.Show("done setting font family");
			
			myFont = new Font(ff, pointSize);
			int emHeight = ff.GetEmHeight(FontStyle.Regular);

			// Compute data.
			
			// Set Anti-aliasing.
			gr.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

			// Calculate metrics.
			gr.PageUnit = GraphicsUnit.Pixel;
			float lineSpace = myFont.GetHeight(gr);
			int cellSpace = ff.GetLineSpacing(FontStyle.Regular);
			int cellAscent = ff.GetCellAscent(FontStyle.Regular);
			ascent = lineSpace * cellAscent / cellSpace;

            noteWidth = pointSize * 0.35f;
            noteLeftOffset = pointSize * 0.225f;
            LEDGER_WIDTH = pointSize * 0.55f;
            LEDGER_X_OFFSET = pointSize * 0.40f;
                      

			// Calculate the staff line spacing and find a spot for the top line of the staff.
			staffLineSpace = myFont.SizeInPoints * (gr.DpiY/72) / (NumStaffLines-1);
			topStaffLine = BorderY + 2 * staffLineSpace;

            octaveHeight = staffLineSpace * 3.5f;
            
			// Draw the staff lines.
            if (drawStaffLines)
            {
                for (int i = 0; i < NumStaffLines; i++)
                {
                    y = GetStaffLineY(i + 1);
                    gr.DrawLine(Pens.Black, 0, y, gr.VisibleClipBounds.Width, y);
                }
            }

			// Draw the clef.
			float x = 0;
			DrawClef(ref x);	// moves x pointer to the right, past the clef.

			// Draw the time signature.
			DrawTimeSignature(ref x); // moves x pointer to the right, past the clef.

			// Draw measures!
			if (measures != null) {
				foreach (Measure m in measures) {
					foreach (Note n in m.Notes) {
						DrawNote(n, ref x);
					}
				}
			}


			// Clean up.
			gr = null;
			pfc = null;
			ff = null;
			myFont = null;
		}

		public int PointSize 
		{
			get 
			{
				return pointSize;
			}
			set 
			{
				pointSize = value;
			}
		}

		public Clef Clef 
		{
			get 
			{
				return clef;
			}
			set 
			{
				clef = value;
			}
		}

		public int TimeSignatureNumerator 
		{
			get 
			{
				return timeSigNumerator;
			}
			set 
			{
				timeSigNumerator = value;
			}
		}

		public int TimeSignatureDenominator 
		{
			get 
			{
				return timeSigDenominator;
			}
			set 
			{
				timeSigDenominator = value;
			}
		}

		private void DrawClef(ref float x) 
		{
			
			float y = 0;

			// Draw the clef.
			y = GetStaffLineY(clef.StaffLine) - ascent;

			// Draw.
			gr.DrawString(""+clef.ClefChar, myFont, Brushes.Black, x, y);

			// Increment x.
			x += pointSize*1.3f;		//TODO: Compute clef width, plus add space.
		}

		private void DrawTimeSignature(ref float x) 
		{
			// Draw special cases.
			if (TimeSignatureNumerator == 4 && TimeSignatureDenominator == 4)
			{
				gr.DrawString("c", myFont, Brushes.Black, x, GetStaffLineY(3) - ascent);
			} 
			else if (TimeSignatureNumerator == 2 && TimeSignatureDenominator == 2) 
			{		
				gr.DrawString("C", myFont, Brushes.Black, x, GetStaffLineY(3)- ascent);
			} 
			else 
			{
				// Draw the normal case of 2 numbers.
				gr.DrawString(GetTimeNumberString(TimeSignatureNumerator), myFont, Brushes.Black, x, GetStaffLineY(2) - ascent);
				gr.DrawString(GetTimeNumberString(TimeSignatureDenominator), myFont, Brushes.Black, x, GetStaffLineY(4) - ascent);
			}

			// Increment x.
			x += pointSize*1.5f;		//TODO: Compute time sig width and add space.
		}

		private void DrawNote(Note n, ref float x) {
			bool noteOnLine;
			int position;

            // TESTING: If it's a blank note (MIDI -1) move to the right by a default amount.
            if (n.Midi < 0)
            {
                x += pointSize * 1.2f;
                return;
            }

			Pitch p = n.GetPitch(key);
			position = GetVerticalLocation(p, clef, out noteOnLine);

			// Compute vertical position, based on note and clef.
			float y, yTxt;
			if (noteOnLine)
				y = GetStaffLineY(position);
			else
				y = GetStaffSpaceY(position);
            // Compute version to use with font rendering.
            yTxt = y - ascent;

			// Draw accidental, if necessary.
			if (p.Accidental != Accidental.Natural) { // TODO: make this smarter, based on key and measure context.
				char c = ' ';

				switch (p.Accidental) {
					case Accidental.Natural:
						c = Natural;
						break;
					case Accidental.Flat:
						c = Flat;
						break;
					case Accidental.Sharp:
						c = Sharp;
						break;
					case Accidental.DoubleFlat:
						c = DoubleFlat;
						break;
					case Accidental.DoubleSharp:
						c = DoubleSharp;
						break;
				}
				
				gr.DrawString("" + c, myFont, Brushes.Black, x, yTxt);
				x += pointSize * 0.5f;
			}

			// Draw note.
			gr.DrawString("" + QuarterHead, myFont, Brushes.Black, x, yTxt);   //HalfHead
			
			//MessageBox.Show("drawing " + QuarterHead + " at " + x.ToString() + ", " + y.ToString());
 
			// Draw stem.
			// Pick x coord and up/down direction.
            bool up = (position > 3 || (!noteOnLine && position == 3));
            float stemX;
            float yStemEnd;
            if (up) {
                stemX = noteLeftOffset + x + noteWidth;
                // Check for below staff -- if below, draw up to middle line. Otherwise, draw one octave length.
                if (position > 6)
                    yStemEnd = GetStaffLineY(3);
                else
                    yStemEnd = y - octaveHeight;
            } else {
                stemX = noteLeftOffset + x;
                // Check for above staff - if above, draw down to middle line.
                if (position < 0)
                    yStemEnd = GetStaffLineY(3);
                else
                    yStemEnd = y + octaveHeight;
            }
            gr.DrawLine(Pens.Black, stemX, y, stemX, yStemEnd);


			// Draw ledger lines, if necessary.
			if (position <= 0) {
                // Above staff.
                for (int ledgerPos = position; ledgerPos <= 0; ledgerPos++) {
                    if (noteOnLine || ledgerPos < 0) {   // Only draw for pos=0 case if it's on the line
                        float yLedger;
                        if (noteOnLine)
                            yLedger = GetStaffLineY(ledgerPos);
                        else
                            yLedger = GetStaffLineY(ledgerPos+1);
                        gr.DrawLine(Pens.Black, LEDGER_X_OFFSET + x - (LEDGER_WIDTH / 2), yLedger,
                                                LEDGER_X_OFFSET + x + (LEDGER_WIDTH / 2), yLedger);
                    }
                }
            } else if (position >= 5) {
                // Below staff.
                for (int ledgerPos = position; ledgerPos >= 5; ledgerPos--) {
                    if (noteOnLine || ledgerPos >= 6) {   // Only draw for pos=5 case if it's on the line (space 5 is ok w/o line)
                        float yLedger = GetStaffLineY(ledgerPos);
                        gr.DrawLine(Pens.Black, LEDGER_X_OFFSET + x - (LEDGER_WIDTH / 2), yLedger,
                                                LEDGER_X_OFFSET + x + (LEDGER_WIDTH / 2), yLedger);
                    }
                }
            }

			// Increment x.
			x += pointSize * 1.2f;		//TODO: Compute note width and add space.
		}

		private string GetTimeNumberString(int n) 
		{
			
			string s;
			
			if (n < 1)
				throw new ArgumentOutOfRangeException("n", "GetTimeNumberString: n must be > 0");
			// TODO: Handle # digits in n; this only works for n from 1-9.
			if (n > 9)
				throw new ArgumentOutOfRangeException("n", "GetTimeNumberString: n must be < 10");

			s = ((char)((int)'0' + n)).ToString();

			return s;

		}


		/// <summary>
		/// Gets the y-coordinate of the given staff line.
		/// </summary>
		/// <param name="line">Line 1 is the top line, line 2 is 2nd from the top, etc.</param>
		/// <returns></returns>
		private float GetStaffLineY(int line) 
		{
			return topStaffLine + staffLineSpace * (line - 1);
		}
		/// <summary>
		/// Gets the y-coordinate of the center of the given staff space.
		/// </summary>
		/// <param name="line">Space 1 is the top space, space 2 is 2nd from the top, etc.</param>
		/// <returns></returns>
		private float GetStaffSpaceY(int space) 
		{
			return topStaffLine + staffLineSpace * ((float)space - 0.5f);
		}

		/// <summary>
		/// Return line # of note (or space # for space). 0 is upper ledger line if on line,
		/// or note sitting on top of staff if on space.
		/// </summary>
		/// <param name="n"></param>
		/// <param name="clef"></param>
		/// <param name="noteOnLine"></param>
		/// <returns></returns>
		private int GetVerticalLocation(Pitch p, Clef clef, out bool noteOnLine) {
			noteOnLine = (0 == (clef.NumberCenter - p.Number) % 2);
            if (!noteOnLine && clef.NumberCenter < p.Number)   // handle special case for notes on space above the clef center// TODO: only works if clefs are on lines?
                return clef.StaffLine + (clef.NumberCenter - p.Number) / 2 - 1;
            else
                return clef.StaffLine + (clef.NumberCenter - p.Number) / 2;
		}
	}
}
