using System;
using System.Collections.Generic;
using System.Text;

namespace FARGCore {
	public class ConceptNode {
		/// <summary>
		/// A list of links of which this node is a member.
		/// </summary>
		private List<ConceptLink> links;
		/// <summary>
		/// The name of the concept node.
		/// </summary>
		private string name;
		/// <summary>
		/// Current activation of this node.
		/// </summary>
		private float activation;
		private int conceptualDepth;

		public ConceptNode() {
			throw new System.NotImplementedException();
		}

		public ConceptNode(string name, int conceptualDepth, float activation) {
			this.name = name;
			this.conceptualDepth = conceptualDepth;
			this.activation = activation;

			links = new List<ConceptLink>();
		}

		public void AddLink(ConceptLink link) {
			links.Add(link);
		}

		public override string ToString() {
			return name + "(" + conceptualDepth + ") - " + activation.ToString("#.###");
		}

		/// <summary>
		/// Sends activation to all linked neighbors. Must implement in such a way that cycles don't cause infinite loops!
		/// </summary>
		public void SpreadActivation(float amount) {
			throw new System.NotImplementedException();
		}

		public void IncreaseActivation(float amount) {
			activation += amount;
			throw new System.NotImplementedException();
		}
	}
}
