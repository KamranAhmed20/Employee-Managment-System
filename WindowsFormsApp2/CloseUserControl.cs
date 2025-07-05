using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class CloseUserControl : UserControl
    {
        // Define the event
        public event EventHandler OkayButtonClicked;

        public CloseUserControl()
        {
            InitializeComponent();
        }

        private void OkayBtnClicked(object sender, EventArgs e)
        {
            // Raise the event
            OkayButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
