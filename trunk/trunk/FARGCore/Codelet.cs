using System;
using System.Collections.Generic;
using System.Text;

namespace FARGCore {
	public abstract class Codelet {

        protected Coderack coderack;
        protected Workspace workspace;
        protected Slipnet slipnet;
        
        protected int urgency;

        protected string name;

		public string Name {
			get { return name; }
		}

		public int Urgency {
			get { return urgency; }
			set { urgency = value; }
		}
        protected Codelet parent;

        /// <summary>
        /// The parent codelet that added this one to the coderack (if any).
        /// </summary>
        public Codelet Parent {
            get { return parent; }
        }

		public Codelet(string name, int urgency, Codelet parent, Coderack coderack, Workspace workspace, Slipnet slipnet) {
			this.name = name;
			this.urgency = urgency;
            this.parent = parent;
            this.coderack = coderack;
            this.workspace = workspace;
            this.slipnet = slipnet;
		}
		
		abstract public void Run();

		public override string ToString() {
			return name + ": urgency=" + urgency;
		}
	}
}
