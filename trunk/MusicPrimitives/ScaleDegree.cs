// Static Model

using System;


namespace MusicPrimitives 
{

	/// <summary>
	/// Represents one of the degrees of a scale.  For example, in G major, the 5th scale degree is D.  Note that the scale degree 
	/// number must be between 1 and 7.  Also, scale degrees may include an alteration, so that in C minor, the 3rd, lowered scale
	/// degree is Eb.  Note that even though the lowered third is indicated in the key signature, the scale
	/// degree object must still include the lowered 3rd, etc.
	/// </summary>
	public class ScaleDegree
	{
		/// <summary>
		/// A number of 1 represents the tonic of the key.  5 represents the 5th, etc.  The number is restricted to the range 1 - 7.
		/// </summary>
		private int number;

		private Alteration alteration;

		/// <summary>
		/// Initializes the ScaleDegree to the tonic.
		/// </summary>
		public ScaleDegree()
		{
			number = 1;
			alteration = Alteration.None;
		}

		/// <summary>
		/// Initializes the new scaledegree to the given # and alteration.
		/// </summary>
		/// <param name="number">Must be between 1=tonic and 7=subtonic.</param>
		/// <param name="alteration">The pitch modification to apply to the scale degree.</param>
		public ScaleDegree(int number, Alteration alteration) {
			Number = number;
			Alteration = alteration;
		}

		public int Number
		{
			get
			{
				return number;
			}
			set
			{
				if (value < 1 || value > 7){
					throw new ArgumentOutOfRangeException("Number", value, "Number must be between 1 and 7.");
				}
				number = value;
			}
		}

		public Alteration Alteration
		{
			get
			{
				return alteration;
			}
			set
			{
				if (!Enum.IsDefined(typeof(Alteration), value)){
					throw new ArgumentOutOfRangeException("Alteration", value, "The given alteration was not recognized.");
				}
				alteration = value;
			}
		}
	}// END CLASS DEFINITION ScaleDegree
}