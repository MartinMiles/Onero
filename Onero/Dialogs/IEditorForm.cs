using System.Windows.Forms;
using Onero.Loader;

namespace Onero.Dialogs
{
    public interface IEditorForm
    {
        Rule Entity { get; set; }
        string Title { get; set; }
        DialogResult ShowDialog();
        void Dispose();
    }
}
