using System.Drawing;
using System.Windows.Forms;

namespace Onero.Extensions
{
    public static class CheckedListExtensions
    {
        const int CHECKBOX_WIDTH = 16;

        public static bool MouseHitsItemText(this CheckedListBox sender)
        {
            bool hit = false;
            Point loc = sender.PointToClient(Cursor.Position);
            for (int i = 0; i < sender.Items.Count; i++)
            {
                Rectangle rec = sender.GetItemRectangle(i);
                rec.X = CHECKBOX_WIDTH;
                rec.Width -= CHECKBOX_WIDTH;

                if (rec.Contains(loc))
                {
                    hit = true;
                    break;
                }
            }
            return hit;
        }

        #region Event handlers that support 'ticking' only checkbox itslef, without label

        public static bool AuthorizeCheck { get; set; }

        public static void ItemChecked(object sender, ItemCheckEventArgs e)
        {
            if (!AuthorizeCheck)
                e.NewValue = e.CurrentValue;
        }

        public static void MouseDownClick(object sender, MouseEventArgs e)
        {
            var clb = sender as CheckedListBox;
            Point loc = clb.PointToClient(Cursor.Position);
            for (int i = 0; i < clb.Items.Count; i++)
            {
                Rectangle rec = clb.GetItemRectangle(i);
                rec.Width = 16;

                if (rec.Contains(loc))
                {
                    AuthorizeCheck = true;
                    bool newValue = !clb.GetItemChecked(i);
                    clb.SetItemChecked(i, newValue);
                    AuthorizeCheck = false;

                    return;
                }
            }
        }

        #endregion
    }
}