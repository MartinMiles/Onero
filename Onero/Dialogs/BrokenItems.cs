using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Onero.Collections;
using Onero.Loader.Broken;
using Onero.Loader.Interfaces;

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

        private void ReadCollections()
        {
            _links = new CollectionOf<BrokenLink>(CurrentProfile.Name).Read<BrokenLink>();
            _images = new CollectionOf<BrokenImage>(CurrentProfile.Name).Read<BrokenImage>();            
        }

        #endregion

        public IProfile CurrentProfile { get; internal set; }

        public BrokenItems()
        {
            InitializeComponent();
        }

        #region Button handlers

        private void SaveClick(object sender, EventArgs e)
        {
            if (this.IsValid())
            {
                CurrentProfile.FindAllBrokenLinks = testAllLinks.Checked;
                CurrentProfile.FindAllBrokenImages = testAllImages.Checked;

                if (SaveItems<BrokenLink>(_links, linksCheckList.CheckedItems) && SaveItems<BrokenImage>(_images, imagesCheckList.CheckedItems))
                {
                    saveButton.Enabled = false;
                    DialogResult = DialogResult.OK;
                }
            }
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private bool SaveItems<T>(IEnumerable<Broken> items, CheckedListBox.CheckedItemCollection checkedNames) where T : Broken
        {
            foreach (T link in items)
            {
                link.Enabled = checkedNames.Contains(link.NameWithPrefix);
            }

            try
            {
                new CollectionOf<T>(CurrentProfile.Name).Save(items);
                return true;

            }
            catch (Exception excp)
            {
                MessageBox.Show(excp.Message);
                return false;
            }
        }

        #endregion

        private void BrokenItems_Load(object sender, EventArgs e)
        {
            ReadCollections();

            EnsureVisibility();

            DrawChecklists();

            saveButton.Enabled = false;
        }

        private void DrawChecklists()
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
            var items = Get<T>(); 

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

            DrawChecklists();

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
            var editorForm = new BrokenItem
            {
                StartPosition = FormStartPosition.CenterParent,
                
                // TODO: Make widow title change (and for similar forms as well, possibly inherriance)
                Title = "Please enter a new broken links pattern",
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

                DrawChecklists();
                saveButton.Enabled = true;
            }

            editorForm.Dispose();
        }

        private void TestAllLinksCheckChanged(object sender, EventArgs e)
        {
            linksCheckList.Visible = !(sender as CheckBox).Checked;
            addNewLinkItem.Visible = !(sender as CheckBox).Checked;

            if (e != null)
            {
                saveButton.Enabled = true;
            }
        }

        private void TestAllImagesCheckChanged(object sender, EventArgs e)
        {
            imagesCheckList.Visible = !(sender as CheckBox).Checked;
            addNewImageItem.Visible = !(sender as CheckBox).Checked;

            if (e != null)
            {
                saveButton.Enabled = true;
            }
        }

        private void EnsureVisibility()
        {
            testAllLinks.Checked = /* !_links.Any() || */ CurrentProfile.FindAllBrokenLinks;
            testAllImages.Checked = /* !_images.Any() || */ CurrentProfile.FindAllBrokenImages;

            TestAllLinksCheckChanged(testAllLinks, null);
            TestAllImagesCheckChanged(testAllImages, null);
        }

        //private void linksCheckList_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    var checkedListBox = sender as CheckedListBox;
        //    List<string> checkedItems = new List<string>();
        //    foreach (var item in checkedListBox.CheckedItems)
        //        checkedItems.Add(item.ToString());

        //    if (e.NewValue == CheckState.Checked)
        //    {
        //        checkedItems.Add(checkedListBox.Items[e.Index].ToString());
        //    }
        //    else if (e.NewValue == CheckState.Unchecked)
        //    {
        //        checkedItems.RemoveAt(e.Index);
        //    }

        //    if (!checkedItems.Any())
        //    {
        //        testAllLinks.Checked = true;
        //    }
        //}
    }
}