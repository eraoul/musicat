using System;
using System.Collections;

namespace MusicPrimitives
{

	/// <summary>
	/// Represents an ordered collection of ScaleDegrees within one octave as defined in the SeekWell project.  
	/// TODO: Replace with generics version of ArrayList in C# 2.0.
	/// </summary>
	public class Alphabet : IEnumerable	
	{
		private ArrayList scaleDegrees;
		
		public Alphabet()
		{
			scaleDegrees = new ArrayList();
		}

		/// <summary>
		/// Returns the number of items in the alphabet.
		/// </summary>
		public int Count
		{
			get
			{
				return scaleDegrees.Count;
			}
		}

		public ScaleDegree this[int index]
		{
			get
			{
				if (index < 0 || index >= Count)
					throw new IndexOutOfRangeException("Alphabet: index " + index + " is out-of-range.");
				
				return (ScaleDegree)scaleDegrees[index];	
			}
		}
		
		/// <summary>
		/// Add a new ScaleDegree to the alphabet. ScaleDegrees must be added in the correct order; the order of Add calls determines alphabet adjacency.
		/// </summary>
		/// <param name="sd"></param>
		public void Add(ScaleDegree sd)
		{
			scaleDegrees.Add(sd);
		}
		#region IEnumerable Members

		public IEnumerator GetEnumerator()
		{
			return scaleDegrees.GetEnumerator();
		}

		#endregion
	}
}
