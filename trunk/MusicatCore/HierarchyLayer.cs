using System;
using System.Collections.Generic;
using System.Text;
using FARGCore;

namespace MusicatCore {
	public class HierarchyLayer {
        private int layerNum;
        private MusicatWorkspace workspace;

        private HierarchyLayer layerAbove;

        public HierarchyLayer LayerAbove {
            get { return layerAbove; }
            set { layerAbove = value; }
        }
        private HierarchyLayer layerBelow;

        public HierarchyLayer LayerBelow {
            get { return layerBelow; }
            set { layerBelow = value; }
        }

		private NoteStream notes;
		
        /// <summary>
		/// List of note groups in this layer. Not ordered.
		/// </summary>
        private List<NoteGroup> groups;

        public List<NoteGroup> Groups {
            get { return groups; }
            set { groups = value; }
        }

		public NoteStream Notes {
			get { return notes; }
			set { notes = value; }
		}

        public HierarchyLayer(int layerNum, MusicatWorkspace workspace) {
            this.layerNum = layerNum;
            this.workspace = workspace;

            notes = new NoteStream();
            groups = new List<NoteGroup>();
        }
        
        public void SetLinkAbove(HierarchyLayer layer) {
            layerAbove = layer;
        }

        public void SetLinkBelow(HierarchyLayer layer) {
            layerBelow = layer;
        }

        /// <summary>
        /// Adds a note to the end of the notestream in the layer and sets the layer reference for the note.
        /// </summary>
        /// <param name="note"></param>
        public void AddNote(Note note) {
            notes.AddNote(note);
            note.Layer = this;

            workspace.UpdateView();
        }

        /// <summary>
        /// Return a random note in this layer.
        /// TODO: Maybe this should be weighted towards recent notes, based on hardening.
        /// </summary>
        /// <returns></returns>
        public Note PickRandomNote() {
            return notes[Utilities.rand.Next(notes.Count)];
        }

        /// <summary>
        /// Returns a random note from the layer, to the right of the given note.
        /// // TODO: weight this somehow, by proximity?
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public Note PickRandomNoteAfter(Note n) {
            // Find the index of the given note in the layer.
            int index = n.GetIndexInLayer();

            // Make sure we're not at the rightmost edge already.
            if (index == notes.Count - 1)
                return null;

            return notes[Utilities.rand.Next(index+1, notes.Count)];
        }

        public NoteGroup PickRandomGroup() {
            if (groups.Count > 0)
                return groups[Utilities.rand.Next(groups.Count)];
            return null;
        }

        /// <summary>
        /// Create a new group of the given strength containing the given notes in this layer.
        /// </summary>
        /// <param name="group"></param>
        /// <param name="strength"></param>
        public void CreateGroup(int strength, List<Note> group) {
            // Destroy any groups that overlap with the new group...
            List<NoteGroup> destroy = new List<NoteGroup>();
            foreach (NoteGroup ng in groups) {
                foreach (Note n in group) {
                    if (ng.Contains(n)) {
                        destroy.Add(ng);
                        break;
                    }
                }    
            }
            foreach (NoteGroup ng in destroy) {
                groups.Remove(ng);
            }


            // Add the new group.
            groups.Add(new NoteGroup(strength, group));

            workspace.UpdateView();
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            sb.Append("Layer #" + layerNum + ": ");

            foreach (Note n in notes) {
                sb.Append(n.ToString() + "\t");
            }

            sb.AppendLine(Utilities.newline + "Groups: ");
            /*foreach (NoteGroup ng in groups) {
                sb.Append(ng.ToString() + "\t");
            }*/
            // Testing: fake the groups.
            if (layerNum == 2)
                sb.Append("(E5 D5 C5)");
            else if (layerNum == 1) 
                sb.Append("(G5 A5)\t(F5 F5)\t(E5 E5)");


            return sb.ToString();
        }

	}
}
