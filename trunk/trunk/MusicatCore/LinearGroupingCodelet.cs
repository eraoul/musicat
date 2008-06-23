using System;
using System.Collections.Generic;
using System.Text;

using FARGCore;

namespace MusicatCore {
    [Codelet("LinearGrouping", CodeletAttribute.CodeletWorkType.Create, 30)]
    public class LinearGroupingCodelet : Codelet {

        /// <summary>
        /// The first note to look at. If null, we'll pick randomly from the workspace.
        /// </summary>
        private Note note1;

        /// <summary>
        /// The second note to look at. If null, we'll pick randomly.
        /// </summary>
        private Note note2;

        public LinearGroupingCodelet(int urgency, Codelet parent, Coderack coderack, Workspace workspace, Slipnet slipnet)
            : base("LinearGrouping", urgency, parent, coderack, workspace, slipnet) {

        }

        /// <summary>
        /// Use this constructor to generate a codelet that will look at a specific note or notes.
        /// </summary>
        /// <param name="urgency"></param>
        /// <param name="parent"></param>
        /// <param name="noteA"></param>
        /// <param name="noteB"></param>
        public LinearGroupingCodelet(int urgency, Codelet parent, Coderack coderack, Workspace workspace, Slipnet slipnet, Note note1, Note note2)
            : base("LinearGrouping", urgency, parent, coderack, workspace, slipnet) {

            this.note1 = note1;
            this.note2 = note2;

        }

        public override void Run() {
            // Test for a missing left hand note (note1) or right hand note (note2).
            // If either is missing, fill in randomly from the workspace.
            if (note1 == null) {
                // Randomly pick a layer, weighted by # notes in each layer.
                HierarchyLayer randLayer = ((MusicatWorkspace)workspace).PickRandomLayerWeighted();

                // Randomly pick a note in the layer.
                note1 = randLayer.PickRandomNote();
                
                // Make sure we picked one.
                if (note1 == null)
                    return;

            }
            if (note2 == null) {
                // Randomly pick a note in the same layer as note1, to the right of note1.
                note2 = note1.Layer.PickRandomNoteAfter(note1);
                // If none are to the right, just stop.
                if (note2 == null)
                    return;
            }


            // Test to make sure the notes still exist. If not, just stop.
            if (!note1.Layer.Notes.Contains(note1) || !note2.Layer.Notes.Contains(note2))
                return;

            // Now, look for a linear relationship of at least 3 notes.

            // Find the time-difference between the first 2 notes.
            int diff = note2.StartTime - note1.StartTime;
            // Look for something at about that distance to the right.
            int targetTime = note2.StartTime + diff;

            // Sort the notes in the layer by distance from the target.
            HierarchyLayer layer = note1.Layer;

            List<Note> notesSorted = new List<Note>(layer.Notes.CloneNotes());
            notesSorted.Sort(delegate(Note x, Note y) { 
                return Comparer<int>.Default.Compare(Math.Abs(x.StartTime - targetTime), Math.Abs(y.StartTime - targetTime)); 
            });

            // Choose the first result. 
            // TODO: Do this randomly; choose one further away sometimes?
            Note note3 = notesSorted[0];

            // Let's make sure we didn't just reselect note2 again.
            if (note3 == note2)
                return;

            // Look for a linear relationship, +- a half step.
            if (Math.Abs((note3.Midi - note2.Midi) - (note2.Midi - note1.Midi)) <= 1) {
                // We found a linear relationship. Create a codelet to try to form a group.
                Note[] notes = new Note[3];
                notes[0] = note1;
                notes[1] = note2;
                notes[2] = note3;

                GroupingCodelet gc = new GroupingCodelet(50, this, coderack, workspace, slipnet, notes);
                coderack.AddCodelet(gc);
            }
            
        }

    }
}
