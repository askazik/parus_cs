using System;
using System.Windows.Forms;

namespace parus
{
    public class ErrorMessage
    {
        public ErrorMessage(string caption, string message)
        {
            // Displays the MessageBox.
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
