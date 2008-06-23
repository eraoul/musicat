using System;
using System.Collections.Generic;
using System.Text;

namespace FARGCore {
	/// <summary>
	/// Represents a set of parameters used to initialize a given run of Musicat.
	/// These parameters can be saved/loaded from disk.
	/// </summary>
	[Serializable]
	public class FARGModelRunParams {
		/// <summary>
		/// A generic user input string (for example, a sequence).
		/// </summary>
		public string userInput;

		/// <summary>
		/// Options from the FARG core options form.
		/// </summary>
		public OptionsForm.OptionsFormData optionsCore;

		public FARGModelRunParams(string userInput, OptionsForm.OptionsFormData optionsCore) {
			this.userInput = userInput;
			this.optionsCore = optionsCore;
		}

		// Note:Particular FARG models should derive from this class 
		// to implement their own extra options.
	}
}
