using System;
using System.Collections.Generic;
using System.Text;
using FARGCore;

namespace MusicatCore {

    public class MusicatWorkspaceEventArgs : EventArgs {
        public MusicatWorkspace workspace;

        public MusicatWorkspaceEventArgs(MusicatWorkspace workspace) {
            this.workspace = workspace;
        }
    }

	public class MusicatWorkspace : Workspace  {

        private const int NUM_LAYERS = 3;

        public event EventHandler<MusicatWorkspaceEventArgs> Update;
        
        private NoteStream rawInput;
        private List<HierarchyLayer> layers;

        public List<HierarchyLayer> Layers {
            get { return layers; }
            set { layers = value; }
        }
        
		public MusicatWorkspace() {
            Reset();
		}

        public override void Reset() {
            // Make the empty raw input.
            rawInput = new NoteStream();

            // Make the initial layers.
            layers = new List<HierarchyLayer>(NUM_LAYERS);
            layers.Add(new HierarchyLayer(1, this));       // start with layer #0 (bottom layer)
            // Add layers, setting up double-links above and below.
            for (int i = 1; i < NUM_LAYERS; i++) {
                HierarchyLayer layer = new HierarchyLayer(i+1, this);
                layer.SetLinkBelow(layers[i - 1]);
                layers[i - 1].SetLinkAbove(layer);
                layers.Add(layer);
            }
            layers[NUM_LAYERS - 2].SetLinkAbove(layers[NUM_LAYERS - 1]);
        }

        /// <summary>
        /// Adds a new note to the raw input of the workspace.
        /// </summary>
        public void AddInputNote(Note note) {
			rawInput.AddNote(note);
            layers[0].AddNote(note);

            // Cheat! Copy notes to layer 2 for testing.
            if (layers[0].Notes.Count % 4 == 1)
                layers[1].AddNote(note);

            UpdateView();
		}

        /// <summary>
        /// Pick a random layer. This is weighted by the # notes in each layer.
        /// </summary>
        /// <returns></returns>
        public HierarchyLayer PickRandomLayerWeighted() {
            int[] cum_weight = new int[layers.Count];

            cum_weight[0] = layers[0].Notes.Count;
            for (int i = 1; i < layers.Count; i++) {
                cum_weight[i] = cum_weight[i - 1] + layers[i].Notes.Count;
            }

            int rand = Utilities.rand.Next(cum_weight[layers.Count-1]);

            for (int i = 0; i < layers.Count; i++)
                if (rand < cum_weight[i])
                    return layers[i];

            throw new Exception("Should have picked a layer already.");
        }


        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            // Display the raw input stream so far.
            //sb.Append("Input stream: ");
            //sb.AppendLine(rawInput.ToString());

            // Display the layers.
            //sb.AppendLine(Utilities.newline + "Layers:");
            sb.AppendLine();

            for (int i = layers.Count-1; i >=0; i--)
                sb.AppendLine(layers[i].ToString());
            
            // Display groups.
            //sb.Append(Utilities.newline + "Groups:");

            return sb.ToString();
        }

        /// <summary>
        /// Raise an event to let viewers update their views.
        /// </summary>
        public void UpdateView() {
            // Verify we have subsubscribed event handlers.
            if (Update != null) {
                MusicatWorkspaceEventArgs ea = new MusicatWorkspaceEventArgs(this);
                Update(this, ea);
            }
        }

	}
}