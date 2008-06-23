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

using MusicStaffDrawer;
using MusicPrimitives;

namespace StaffControl
{
	/// <summary>
	/// Summary description for StaffForm2.
	/// </summary>
	public class Staff : System.Windows.Forms.Control
	{
		// User-settable properties.
		private int pointSize;
		private int timeSigNumerator = 4;
		private int timeSigDenominator = 4;
		private StaffDrawer staffDrawer;

        public bool DrawStaffLines
        {
            get { return staffDrawer.DrawStaffLines; }
            set
            {
                staffDrawer.DrawStaffLines = value;
                this.Invalidate();
            }
        }

		public StaffDrawer StaffDrawer {
			get { return staffDrawer; }
		}

		private List<Measure> measures;

		public List<Measure> Measures {
			get { return measures; }
			set { measures = value; }
		}

		public Staff()
		{
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.DoubleBuffer, true);

			//MessageBox.Show(Application.StartupPath + @"\Fonts path required!");
			staffDrawer = new StaffDrawer(Application.StartupPath + @"\Fonts");
            staffDrawer.Clef = staffDrawer.clefTreble;

            //staffDrawer = new StaffDrawer(@"C:\WINDOWS\Fonts");
			
			staffDrawer.PointSize = 36;
		}

		public int PointSize {
			get {
				return staffDrawer.PointSize;
			}
			set {
				staffDrawer.PointSize = value;
				this.Invalidate();
			}
		}

		public Clef Clef {
			get {
				return staffDrawer.Clef;
			}
			set {
				staffDrawer.Clef = value;
				this.Invalidate();
			}
		}

		public int TimeSignatureNumerator {
			get {
				return staffDrawer.TimeSignatureNumerator;
			}
			set {
				staffDrawer.TimeSignatureNumerator = value;
				this.Invalidate();
			}
		}

		public int TimeSignatureDenominator {
			get {
				return staffDrawer.TimeSignatureDenominator;
			}
			set {
				staffDrawer.TimeSignatureDenominator = value;
				this.Invalidate();
			}
		}

		protected override void OnPaint(PaintEventArgs pe) {

			Graphics gr = pe.Graphics;
			gr.Clear(this.BackColor);

			// Invoke the Staff Drawer.
			staffDrawer.Measures = measures;
			staffDrawer.DrawStaff(gr);

			// Draw the clip rectangle.
			gr.PageUnit = GraphicsUnit.Pixel;
			Rectangle border = pe.ClipRectangle;
			border.Width -= 1;
			border.Height -= 1; 
			gr.DrawRectangle(Pens.DarkBlue, border.Left, border.Top, border.Width, border.Height);// border.Width, border.Height);

			// Clean up.
			gr = null;

			// Calling the base class OnPaint
			base.OnPaint(pe);
		}

	}
}
