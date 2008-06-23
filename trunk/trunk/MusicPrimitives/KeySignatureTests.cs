using System;
using NUnit.Framework;

namespace MusicPrimitives.Tests
{
	/// <summary>
	/// Summary description for KeySignatureTests.
	/// </summary>
	[TestFixture]
	public class KeySignatureTests
	{
		public KeySignatureTests()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		[Test]
		public void Success() 
		{
		}

		[Test]
		public void CMajor() 
		{
			KeySignature ks = new KeySignature(new Key(0, KeyMode.Major));
			Assert.AreEqual(0, ks.Count);
		}

		[Test]
		public void GMajor() 
		{
			KeySignature ks = new KeySignature(new Key(1, KeyMode.Major));
			Assert.AreEqual(1, ks.Count);
			
			Assert.AreEqual("F#", ks[0].ToString());
		}

		[Test]
		public void FMajor() 
		{
			KeySignature ks = new KeySignature(new Key(-1, KeyMode.Major));
			Assert.AreEqual(1, ks.Count);

			Assert.AreEqual("Bb", ks[0].ToString());
		}

		[Test]
		public void DMinor() 
		{
			KeySignature ks = new KeySignature(new Key(2, KeyMode.Minor));
			Assert.AreEqual(1, ks.Count);

			Assert.AreEqual("Bb", ks[0].ToString());
		}		
		
		[Test]
		public void DMajor() 
		{
			KeySignature ks = new KeySignature(new Key(2, KeyMode.Major));
			Assert.AreEqual(2, ks.Count);

			Assert.AreEqual("F#", ks[0].ToString());
			Assert.AreEqual("C#", ks[1].ToString());
		}

		[Test]
		public void BMajor() 
		{
			KeySignature ks = new KeySignature(new Key(5, KeyMode.Major));
			Assert.AreEqual(5, ks.Count);

			Assert.AreEqual("F#", ks[0].ToString());
			Assert.AreEqual("C#", ks[1].ToString());
			Assert.AreEqual("G#", ks[2].ToString());
			Assert.AreEqual("D#", ks[3].ToString());
			Assert.AreEqual("A#", ks[4].ToString());
		}

		[Test]
		public void CbMajor() 
		{
			KeySignature ks = new KeySignature(new Key(-7, KeyMode.Major));
			Assert.AreEqual(7, ks.Count);

			Assert.AreEqual("Bb", ks[0].ToString());
			Assert.AreEqual("Eb", ks[1].ToString());
			Assert.AreEqual("Ab", ks[2].ToString());
			Assert.AreEqual("Db", ks[3].ToString());
			Assert.AreEqual("Gb", ks[4].ToString());
			Assert.AreEqual("Cb", ks[5].ToString());
			Assert.AreEqual("Fb", ks[6].ToString());
		}

		[Test]
		public void CbMinor() 
		{
			KeySignature ks = new KeySignature(new Key(-7, KeyMode.Minor));
			Assert.AreEqual(10, ks.Count);
			Assert.AreEqual("Bb", ks[0].ToString());
			Assert.AreEqual("Eb", ks[1].ToString());
			Assert.AreEqual("Ab", ks[2].ToString());
			Assert.AreEqual("Db", ks[3].ToString());
			Assert.AreEqual("Gb", ks[4].ToString());
			Assert.AreEqual("Cb", ks[5].ToString());
			Assert.AreEqual("Fb", ks[6].ToString());
			Assert.AreEqual("Bbb", ks[7].ToString());
			Assert.AreEqual("Ebb", ks[8].ToString());
			Assert.AreEqual("Abb", ks[9].ToString());
		}

		[Test]
		public void ToStringC() 
		{
			KeySignature ks = new KeySignature(new Key(0, KeyMode.Major));
			Assert.AreEqual("", ks.ToString());
		}

		[Test]
		public void ToStringB() 
		{
			KeySignature ks = new KeySignature(new Key(5, KeyMode.Major));
			Assert.AreEqual("F# C# G# D# A#", ks.ToString());
		}

		[Test]
		public void ToStringCSharp() 
		{
			KeySignature ks = new KeySignature(new Key(7, KeyMode.Major));
			Assert.AreEqual("F# C# G# D# A# E# B#", ks.ToString());
		}

		[Test]
		public void ToStringDFlat() 
		{
			KeySignature ks = new KeySignature(new Key(-5, KeyMode.Major));
			Assert.AreEqual("Bb Eb Ab Db Gb", ks.ToString());
		}

		[Test]
		public void ToStringGFlat() 
		{
			KeySignature ks = new KeySignature(new Key(-6, KeyMode.Major));
			Assert.AreEqual("Bb Eb Ab Db Gb Cb", ks.ToString());
		}
	}
}
