using System.Windows.Forms;

namespace Onero.Dialogs
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void OkClick(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
