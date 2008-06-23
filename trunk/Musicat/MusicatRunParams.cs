using System;
using System.Collections.Generic;
using System.Text;
using FARGCore;

namespace Musicat {
	/// <summary>
	/// Represents a set of parameters used to initialize a given run of Musicat.
	/// These parameters can be saved/loaded from disk.
	/// </summary>
	[Serializable]
	public class MusicatRunParams : FARGModelRunParams {
		/// <summary>
		/// Options from the Musicat options form.
		/// </summary>
		public MusicatOptionsForm.OptionsFormData optionsMusicat;

		public MusicatRunParams(string melody, FARGCore.OptionsForm.OptionsFormData optionsCore,
								MusicatOptionsForm.OptionsFormData optionsMusicat)
			: base(melody, optionsCore) {

			this.optionsMusicat = optionsMusicat;
		}
	}
}
