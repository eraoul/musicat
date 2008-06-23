using System;
using System.Collections.Generic;
using System.Text;
using FARGCore;

namespace Musicat {
    [CodeletAttribute("Grouping", CodeletAttribute.CodeletWorkType.Create, 10)]
	public class IntervalScoutCodelet : Codelet {
        public IntervalScoutCodelet(int urgency, Codelet parent, Coderack coderack, Workspace workspace, Slipnet slipnet)
            : base("Interval Scout", urgency, parent, coderack, workspace, slipnet) {
			//throw new System.NotImplementedException();
		}
	
		public override void Run() {
			//throw new Exception("The method or operation is not implemented.");
		}
	}
}
