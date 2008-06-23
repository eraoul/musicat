using System;
using System.Collections.Generic;
using System.Text;
using FARGCore;

namespace MusicatCore {
	[Codelet("Grouping", CodeletAttribute.CodeletWorkType.Create, 20)]
	public class GroupingCodelet : Codelet {

        /// <summary>
        /// The notes to try to group. If null, we'll pick randomly from the workspace.
        /// </summary>
        private Note[] notes;

        
        public GroupingCodelet(int urgency, Codelet parent, Coderack coderack, Workspace workspace, Slipnet slipnet)
            : base("Grouping", urgency, parent, coderack, workspace, slipnet) {
		
		}

        /// <summary>
        /// Use this constructer to tell the codelet which notes to try to group. Otherwise, it picks some randomly.
        /// </summary>
        /// <param name="urgency"></param>
        /// <param name="parent"></param>
        /// <param name="coderack"></param>
        /// <param name="workspace"></param>
        /// <param name="slipnet"></param>
        /// <param name="notes"></param>
        public GroupingCodelet(int urgency, Codelet parent, Coderack coderack, Workspace workspace, Slipnet slipnet, Note[] notes)
            : base("Grouping", urgency, parent, coderack, workspace, slipnet) {

            this.notes = notes;         
        }

		public override void Run() {
            HierarchyLayer layer;
            MusicatWorkspace mw = (MusicatWorkspace)workspace;

            // If notes are undefined, pick some randomly.
            if (notes == null) {
                List<Note> notesList = new List<Note>();

                layer = mw.PickRandomLayerWeighted();

                Note n = layer.PickRandomNote();
                notesList.Add(n);
                do {
                    // Pick another note to the right. (not really necessary, but it prevents duplication)
                    Note next = layer.PickRandomNoteAfter(n);
                    // Make sure we got another note.
                    if (next == null)
                        break;
                    notesList.Add(next);
                    n = next;
                } while (Utilities.rand.NextDouble() < 0.2);    // 20% chance of adding another note.

                // Make sure we have at least 2 notes in the group.
                if (notesList.Count < 2)
                    return;
                notes = notesList.ToArray();
            } else {
                // Make sure the given notes exist in the workspace.
                foreach (Note n in notes)
                    if (!n.Layer.Notes.Contains(n))
                        return;
            }

            layer = notes[0].Layer;

            // Try to group them. Depends on existing bond strength, etc.
            
            // Compute total strength of groups currently involved. We'd have to break them to form a new group.
            int totalStrength = 0;
            foreach (NoteGroup group in layer.Groups)
                foreach (Note n in notes)
                    if (group.Contains(n))
                        totalStrength += group.Strength;

            // Compute group strength per note.
            double strPerNote = totalStrength / notes.Length;

            // TODO: Also should include linear relationship info, or other relationships, if discovered by another codelet.

            int r = Utilities.rand.Next(100);

            // Arbitrary probability of breaking groups... maybe need to normalize parameters more formally.
            if (r > strPerNote) {
                // Make it harder to create long groups. Probabilty depends on # notes...
                double rand = Utilities.rand.NextDouble();
                if (rand < 1.0 / notes.Length) {
                    layer.CreateGroup(totalStrength, new List<Note>(notes));    // artibraitly pick the new group strength.. TODO: fix.

                    // Add codelets to promote group members to the next layer.
                    if (layer.LayerAbove != null) {
                        PromotionCodelet gc = new PromotionCodelet(50, this, coderack, workspace, slipnet, notes[0]);
                        coderack.AddCodelet(gc);
                    }
                }
            }
		}
	}
}
