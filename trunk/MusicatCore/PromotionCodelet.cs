using System;
using System.Collections.Generic;
using System.Text;
using FARGCore;

namespace MusicatCore {
    [Codelet("Hierarchy", CodeletAttribute.CodeletWorkType.Create, 10)]
    public class PromotionCodelet : Codelet {

        /// <summary>
        /// The note to try to promote. If null, we'll pick randomly from the workspace.
        /// </summary>
        private Note note;


        public PromotionCodelet(int urgency, Codelet parent, Coderack coderack, Workspace workspace, Slipnet slipnet)
            : base("Hierarchy", urgency, parent, coderack, workspace, slipnet) {

        }

        /// <summary>
        /// Use this constructer to tell the codelet which note to try to promote. 
        /// Otherwise, it picks one randomly from an existing group.
        /// </summary>
        /// <param name="urgency"></param>
        /// <param name="parent"></param>
        /// <param name="coderack"></param>
        /// <param name="workspace"></param>
        /// <param name="slipnet"></param>
        /// <param name="notes"></param>
        public PromotionCodelet(int urgency, Codelet parent, Coderack coderack, Workspace workspace, Slipnet slipnet, Note note)
            : base("Hierarchy", urgency, parent, coderack, workspace, slipnet) {

            this.note = note;
        }

        public override void Run() {
            HierarchyLayer layer;
            MusicatWorkspace mw = (MusicatWorkspace)workspace;

            // If note is undefined, pick one randomly from a group.
            if (note == null) {
                layer = mw.PickRandomLayerWeighted();

                // Layer must have a layer above.
                if (layer.LayerAbove == null)
                    return;
                
                // Pick a group from the layer.
                NoteGroup ng = layer.PickRandomGroup();

                // Make sure there was a group.
                if (ng == null)
                    return;

                // Pick a random note form the group.
                note = ng.PickRandomNote();

            } else {
                // Make sure the given note exists in the workspace.
                if (!note.Layer.Notes.Contains(note))
                    return;
            }

            layer = note.Layer;

            // Try to promote. It may be hard if we have to break into a group above,
            // or if this note is not the start or end of a group.
            int r = Utilities.rand.Next(100);


            /*
            // Compute total strength of groups currently involved. We'd have to break them to form a new group.
            int totalStrength = 0;
            foreach (NoteGroup group in layer.Groups)
                foreach (Note n in notes)
                    if (group.Contains(n))
                        totalStrength += group.Strength;

            // Compute group strength per note.
            double strPerNote = totalStrength / notes.Length;

            // TODO: Also should include linear relationship info, or other relationships, if discovered by another codelet.

          

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
             * 
             * */
        }
    }
}
