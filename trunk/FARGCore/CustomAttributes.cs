using System;
using System.Collections.Generic;
using System.Text;

namespace FARGCore {
	public class CodeletAttribute : Attribute {

		public enum CodeletWorkType {
			Create, Destroy, Examine, Halt
		}


		private const int DEFAULT_URGENCY = 10;
		private string _category;
		private CodeletWorkType _workType;
		private int _defaultUrgency;

		public string Category {
			get { return _category; }
		}

		public int DefaultUrgency {
			get { return _defaultUrgency; }
		}


		public CodeletAttribute(string category, CodeletWorkType workType, int defaultUrgency) {
			_category = category;
			_workType = workType;
			_defaultUrgency = defaultUrgency;
		}

		public CodeletAttribute(string category, CodeletWorkType workType) {
			_category = category;
			_workType = workType;
			_defaultUrgency = DEFAULT_URGENCY;
		}
	}
}
