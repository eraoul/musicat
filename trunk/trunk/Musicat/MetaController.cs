using System;
using System.Collections.Generic;
using System.Text;

namespace TwoNoteModel {
	public class MetaController {
		private Slipnet slipnet;
		private Coderack coderack;
		private Workspace workspace;
		
        /// <summary>
		/// The notes to feed into the workspace as time progresses.
		/// </summary>
		private NoteStream inputMelody;

		
		public MetaController() {
			slipnet = new Slipnet();
			coderack = new Coderack();
			workspace = new Workspace();
			
			//throw new System.NotImplementedException();
		}

		/// <summary>
		/// Runs the model.
		/// </summary>
		public void Run() {
			//throw new System.NotImplementedException();
		}
	}
}
