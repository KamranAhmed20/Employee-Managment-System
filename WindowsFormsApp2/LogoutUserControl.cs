using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class LogoutUserControl : UserControl
    {
        public event EventHandler LogoutConfirmed;
        public event EventHandler LogoutCancelled;

        public LogoutUserControl()
        {
            InitializeComponent();

        }

        private void OptionYes(object sender, EventArgs e)
        {
            LogoutConfirmed?.Invoke(this, EventArgs.Empty);
        }

        private void OptionNo(object sender, EventArgs e)
        {
            LogoutCancelled?.Invoke(this, EventArgs.Empty);
        }
    }
}
