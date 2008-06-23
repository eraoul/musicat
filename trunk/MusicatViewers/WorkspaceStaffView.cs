using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MusicatCore;
using FARGViewers;
using MusicPrimitives;

namespace MusicatViewers {
	public partial class WorkspaceStaffView : ViewControl {
		private MusicatWorkspace workspace;

        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        delegate void DrawStaffCallback(HierarchyLayer layer);


		public WorkspaceStaffView(MusicatWorkspace workspace ) {
			InitializeComponent();

			this.workspace = workspace;

            // Cheat! For testing, populate motive views.
            Measure m = new Measure();
            List <Measure> measures = new List<Measure>();
            measures.Add(m);
            m.Notes = new MusicPrimitives.NoteStream();
            m.Notes.AddNote(new MusicPrimitives.Note(76, 1));
            m.Notes.AddNote(new MusicPrimitives.Note(74, 2));
            m.Notes.AddNote(new MusicPrimitives.Note(72, 3));
            staff2.Measures = measures;
            staff2.Refresh();

            m = new Measure();
            measures = new List<Measure>();
            measures.Add(m);
            m.Notes = new MusicPrimitives.NoteStream();
            m.Notes.AddNote(new MusicPrimitives.Note(74, 1));
            m.Notes.AddNote(new MusicPrimitives.Note(76, 2));
            m.Notes.AddNote(new MusicPrimitives.Note(77, 3));
            m.Notes.AddNote(new MusicPrimitives.Note(77, 4));
            staff3.Measures = measures;
            staff3.Refresh();

            m = new Measure();
            measures = new List<Measure>();
            measures.Add(m);
            m.Notes = new MusicPrimitives.NoteStream();
            m.Notes.AddNote(new MusicPrimitives.Note(72, 1));
            m.Notes.AddNote(new MusicPrimitives.Note(72, 2));
            staff4.Measures = measures;
            staff4.Refresh();

            m = new Measure();
            measures = new List<Measure>();
            measures.Add(m);
            m.Notes = new MusicPrimitives.NoteStream();
            m.Notes.AddNote(new MusicPrimitives.Note(77, 1));
            m.Notes.AddNote(new MusicPrimitives.Note(72, 2));
            m.Notes.AddNote(new MusicPrimitives.Note(74, 3));
            staff5.Measures = measures;
            staff5.Refresh();
            // End Cheat.

            workspace.Update += new EventHandler<MusicatWorkspaceEventArgs>(workspace_Update);
            UpdateView();
		}

        void workspace_Update(object sender, MusicatWorkspaceEventArgs e) {
            UpdateView();
        }

		// This should be called whenever the workspace is changed.
        public override void UpdateView() {
            // Update the text view.
            SetText(workspace.ToString());

            // Update the staff view.
            DrawStaff(((MusicatWorkspace)workspace).Layers[0]);
		}

        private void WorkspaceStaffView_Resize(object sender, EventArgs e) {
            splitContainer1.Height = this.Height * 2 / 3;

            staff2.Height = splitContainer1.Height / 4;
            staff3.Height = staff2.Height;
            staff4.Height = staff2.Height;
            staff5.Height = staff2.Height;

            staffTop.Height = splitContainer1.Height / 2;
            staff1.Height = staffTop.Height;

            lblLayer2.Top = staffTop.Top + 6;
            labelLayer1.Top = staff1.Top + 6;
            lblMotives.Top = staff2.Top + 6;
            lblMotives.Left = staff2.Left + staff2.Width / 2 - lblMotives.Width / 2;

            txtNotes.Height = this.Height /3;
            txtNotes.Top = this.Height / 3;
        }



        // If the calling thread is different from the thread that
        // created the TextBox control, this method creates a
        // SetTextCallback and calls itself asynchronously using the
        // Invoke method.
        //
        // If the calling thread is the same as the thread that created
        // the TextBox control, the Text property is set directly. 
        private void SetText(string text) {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (txtNotes.InvokeRequired) {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            } else {
                txtNotes.Text = text;
            }
        }

        private void DrawStaff(HierarchyLayer layer) {
            if (staff1.InvokeRequired) {
                DrawStaffCallback d = new DrawStaffCallback(DrawStaff);
                this.Invoke(d, new object[] { layer });
            } else {
                List<Measure> measures = new List<Measure>();
                // Make a single measure to contain the notes, for now.
				Measure m = new Measure();
                measures.Add(m);
                m.Notes = new MusicPrimitives.NoteStream();
				// Add all the notes to the measure.
                foreach (MusicatCore.Note n in layer.Notes)
                    m.Notes.AddNote(n.Midi);
                staff1.Measures = measures;

				// Create groups for display.


                staff1.Refresh();

                // Draw the top staff.
                m = new Measure();
                measures = new List<Measure>(); 
                measures.Add(m);
                m.Notes = new MusicPrimitives.NoteStream();
                // Add all the notes to the measure.
                for (int i = 0; i < layer.Notes.Count; i++)
                {
                    MusicatCore.Note n = layer.Notes[i];
                    if (i % 4 == 0)
                        m.Notes.AddNote(n.Midi);
                    else
                        m.Notes.AddNote(-1);
                }
                staffTop.Measures = measures;
                staffTop.Refresh();
            }
        }

    }
}