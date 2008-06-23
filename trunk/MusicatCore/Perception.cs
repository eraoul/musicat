using System;
using System.Collections.Generic;
using System.Text;

namespace MusicatCore {
	public abstract class Perception {
		private String name;
		private int strength;

		public Perception(string name, int strength) {
			this.name = name;
			this.strength = strength;
		}

		/// <summary>
		/// Outputs the perception.
		/// </summary>
		public override string ToString() {
			throw new System.NotImplementedException();
		}
	}
}
