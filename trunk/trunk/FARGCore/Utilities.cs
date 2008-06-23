using System;
using System.Collections.Generic;
using System.Text;

namespace FARGCore {
	public static class Utilities {

        public static string newline = System.Environment.NewLine;
        public static Random rand = new Random();

		public static OptionsForm.OptionsFormData LoadSettings() {
			OptionsForm.OptionsFormData data;
			
			data.parallelCodelets = Settings.Default.OptionCoreParllelCodelets;

			return data;
		}

		public static void SaveSettings(OptionsForm.OptionsFormData data) {
			Settings.Default.OptionCoreParllelCodelets = data.parallelCodelets;

			Settings.Default.Save();
		}
	}
}
