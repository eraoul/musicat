using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace MusicatCore
{
    [TestFixture]
    public class NoteStreamTest
    {
        [Test]
        public void TestAddNote()
        {
            NoteStream ns = new NoteStream();
            ns.AddNote(45);
			ns.AddNote(60);


            Assert.AreEqual("A2 C4 ", ns.ToString());
        }
    }
}
