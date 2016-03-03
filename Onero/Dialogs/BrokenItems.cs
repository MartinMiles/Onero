using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Onero.Collections;
using Onero.Loader;
using Onero.Loader.Broken;

namespace Onero.Dialogs
{
    public partial class BrokenItems : Form
    {
        #region Private items collections and getter / setter

        private IEnumerable<Broken> _links;
        private IEnumerable<Broken> _images;

        private IEnumerable<Broken> Get<T>()
        {
            if (typeof (T) == typeof (BrokenLink))
            {
                return _links;
            }
            if (typeof (T) == typeof (BrokenImage))
            {
                return _images;
            }

            throw new ArgumentOutOfRangeException("Type not supported: " + typeof (T));
        }

        private void Set<T>(IEnumerable<Broken> items)
        {
            if (typeof (T) == typeof (BrokenLink))
            {
                _links = items;
            }
            else if (typeof (T) == typeof (BrokenImage))
            {
                _images = items;
            }
        }

        #endregion

        public string CurrentProfileName { get; internal set; }

        public BrokenItems()
        {
            InitializeComponent();
        }

        #region Button handlers

        private void SaveClick(object sender, EventArgs e)
        {
            if (SaveItems<BrokenLink>(_links, linksCheckList.CheckedItems) && SaveItems<BrokenImage>(_images, imagesCheckList.CheckedItems))
            {
                saveButton.Enabled = false;
                Text = "Rules Editor - Successfully saved";
                cancelButton.Text = "Close";
            }
        }

        private bool SaveItems<T>(IEnumerable<Broken> items, CheckedListBox.CheckedItemCollection checkedNames) where T : Broken
        {
            foreach (T link in items)
            {
                link.Enabled = checkedNames.Contains(link.NameWithPrefix);
            }

            try
            {
                new CollectionOf<T>(CurrentProfileName).Save(items);
                return true;

            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
                return false;
            }
        }


        private void CancelClick(object sender, EventArgs e)
        {
            Close();

           
        }

        #endregion

        private void BrokenItems_Load(object sender, EventArgs e)
        {
            _links = new CollectionOf<BrokenLink>(CurrentProfileName).Read<BrokenLink>();
            _images = new CollectionOf<BrokenImage>(CurrentProfileName).Read<BrokenImage>();

            DrawBrokenItemsList();

            saveButton.Enabled = false;
        }

        private void DrawBrokenItemsList()
        {
            linksCheckList.Items.Clear();
            for (int i = 0; i < _links.Count(); i++)
            {
                var item = _links.ElementAt(i);
                linksCheckList.Items.Add(item.NameWithPrefix, item.Enabled);
            }

            imagesCheckList.Items.Clear();
            for (int i = 0; i < _images.Count(); i++)
            {
                var item = _images.ElementAt(i);
                imagesCheckList.Items.Add(item.NameWithPrefix, item.Enabled);
            }
        }

        private void CheckedListBoxSingleClick(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
        }

        private void LinksCheckListDoubleCLick(object sender, EventArgs e)
        {
            CheckedListBoxDoubleClick<BrokenLink>(GetSelectedItem(sender));
        }

        private void ImagesCheckListDoubleCLick(object sender, EventArgs e)
        {
            CheckedListBoxDoubleClick<BrokenImage>(GetSelectedItem(sender));
        }

        //TODO: Duplicated with the one at RulesList
        private string GetSelectedItem(object sender)
        {
            var clb = sender as CheckedListBox;

            if (clb.SelectedItem == null)
            {
                return string.Empty;
            }

            return clb.SelectedItem as string;
        }

        private void CheckedListBoxDoubleClick<T>(string selectedItemName) where T : Broken, new()
        {
            // TODO: Replace this in favor of locally store collection (_links or _images) and possibly generic. To get rid of if (typeof (T) == typeof (BrokenLink)) below
            var items = Get<T>(); // new CollectionOf<T>(CurrentProfileName).Read<T>();

            Broken rule = items.FirstOrDefault(r => r.NameWithPrefix == selectedItemName);

            if (rule == null)
            {
                return;
            }

            var editorForm = new BrokenItem { StartPosition = FormStartPosition.CenterParent };
            editorForm.Title = $"{rule.Name} ({(rule.Enabled ? "enabled" : "disabled")})";

            editorForm.Rule = rule;

            var dialogResult = editorForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                rule = editorForm.Rule;
            }
            else if (dialogResult == DialogResult.Yes)
            {
                items = items.Where(r => r != rule);
            }
            else
            {
                return;
            }

            // temporal fix
            Set<T>(items);

            DrawBrokenItemsList();

            editorForm.Dispose();

            saveButton.Enabled = true;
        }

        private void AddNewLinkItemClicked(object sender, EventArgs e)
        {
            AddNewClick<BrokenLink>(((Control)sender).Name);
        }

        private void AddNewImageItemClicked(object sender, EventArgs e)
        {
            AddNewClick<BrokenImage>(((Control)sender).Name);
        }

        private void AddNewClick<T>(string name) where T : Broken, new()
        {
            //var rules = name == "linksCheckList" ? _links : _images;

            var editorForm = new BrokenItem
            {
                StartPosition = FormStartPosition.CenterParent,
                
                // TODO: Make widow title change (and for similar forms as well, possibly inherriance)
                //Title = "Please enter a new rule:",
                Rule = (T)Activator.CreateInstance(typeof(T), new[] {"", ""})
            };

            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                if (name == "addNewLinkItem")
                {
                    _links = _links.Concat(new[] { editorForm.Rule });

                }
                else if (name == "addNewImageItem")
                {
                    _images = _images.Concat(new[] { editorForm.Rule });

                }

                DrawBrokenItemsList();

                saveButton.Enabled = true;
            }

            editorForm.Dispose();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
