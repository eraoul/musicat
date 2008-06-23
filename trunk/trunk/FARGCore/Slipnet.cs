using System;
using System.Collections.Generic;
using System.Text;

namespace FARGCore {
	public class Slipnet : IEnumerable<ConceptNode> {
		private List<ConceptNode> nodes;

		public Slipnet() {
            Reset();
		}

		public void AddNode(ConceptNode node) {
			nodes.Add(node);
		}

		public void RemoveNode(ConceptNode node) {
			nodes.Remove(node);
		}

        public void Reset() {
            nodes = new List<ConceptNode>(100);
        }

		#region IEnumerable<ConceptNode> Members

		public IEnumerator<ConceptNode> GetEnumerator() {
			return nodes.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			throw new Exception("The method or operation is not implemented.");
		}

		#endregion
	}
}
