using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using FARGCore;

namespace FARGViewers {
	public partial class CoderackView : ViewControl {

		private Coderack coderack;

        // This delegate enables asynchronous calls for the list view control.
        delegate void AddListItemCallback(string text);
        delegate void ClearListCallback();

		public CoderackView(Coderack coderack) {
			InitializeComponent();

			this.coderack = coderack;

            coderack.Update += new EventHandler<CoderackEventArgs>(coderack_Update);
            UpdateView();
		}

        void coderack_Update(object sender, CoderackEventArgs e) {
            UpdateView();
        }


		// This should be called whenever the coderack is changed.
        public override void UpdateView() {
            ClearList();
            for (int i = 0; i < coderack.Count; i++) {
                Codelet c = coderack[i];
                AddListItem(c.ToString());
            }
		}


        private void ClearList() {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (lvMain.InvokeRequired) {
                ClearListCallback d = new ClearListCallback(ClearList);
                this.Invoke(d, new object[] {});
            } else {
                lvMain.Clear();
            }
        }

        private void AddListItem(string text) {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (lvMain.InvokeRequired) {
                AddListItemCallback d = new AddListItemCallback(AddListItem);
                this.Invoke(d, new object[] { text });
            } else {
                lvMain.Items.Add(text);
            }
        }
	}
}
