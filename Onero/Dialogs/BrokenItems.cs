using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Onero.Collections;
using Onero.Extensions;
using Onero.Loader.Broken;
using Onero.Loader.Interfaces;

namespace Onero.Dialogs
{
    public partial class BrokenItems : Form
    {
        private Dictionary<Type, IEnumerable<Broken>> items;
        private Dictionary<Type, CheckedListBox> checkListBoxes;
        private Dictionary<Type, Button> addNewButtons;

        private void Form_Load(object sender, EventArgs e)
        {
            ReadControls();

            ReadCollections();

            EnsureVisibility();

            DrawChecklists();

            saveButton.Enabled = false;
        }

        #region Private items collections and getter / setter

        private void ReadControls()
        {
            checkListBoxes = new Dictionary<Type, CheckedListBox>
            {
                {typeof (BrokenLink), linksCheckList},
                {typeof (BrokenImage), imagesCheckList},
                {typeof (BrokenScript), scriptsCheckList},
                {typeof (BrokenStyle), stylesCheckList}
            };

            foreach (var checkedListBoxPair in checkListBoxes)
            {
                // CheckedListBox support
                checkedListBoxPair.Value.MouseDown += CheckedListExtensions.MouseDownClick;
                checkedListBoxPair.Value.ItemCheck += CheckedListExtensions.ItemChecked;
            }

            addNewButtons = new Dictionary<Type, Button>
            {
                {typeof (BrokenLink), addNewLinkItem},
                {typeof (BrokenImage), addNewImageItem},
                {typeof (BrokenScript), addNewScriptItem},
                {typeof (BrokenStyle), addNewStyleItem}
            };
        }

        private void ReadCollections()
        {
            items = new Dictionary<Type, IEnumerable<Broken>>
            {
                {typeof (BrokenLink), new CollectionOf<BrokenLink>(CurrentProfile.Name).Read<BrokenLink>()},
                {typeof (BrokenImage), new CollectionOf<BrokenImage>(CurrentProfile.Name).Read<BrokenImage>()},
                {typeof (BrokenScript), new CollectionOf<BrokenScript>(CurrentProfile.Name).Read<BrokenScript>()},
                {typeof (BrokenStyle), new CollectionOf<BrokenStyle>(CurrentProfile.Name).Read<BrokenStyle>()}
            };
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
                CurrentProfile.FindAllBrokenScripts = testAllScripts.Checked;
                CurrentProfile.FindAllBrokenStyles = testAllStyles.Checked;

                bool result = SaveItems<BrokenLink>() && SaveItems<BrokenImage>() && SaveItems<BrokenScript>() && SaveItems<BrokenStyle>();

                if (result)
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

        private bool SaveItems<T>() where T : Broken
        {
            var items = this.items[typeof(T)];
            var checkedNames = checkListBoxes[typeof(T)].CheckedItems;

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


        private void DrawChecklists()
        {
            DrawChecklists<BrokenLink>();
            DrawChecklists<BrokenImage>();
            DrawChecklists<BrokenScript>();
            DrawChecklists<BrokenStyle>();
        }

        private void DrawChecklists<T>()
        {
            checkListBoxes[typeof(T)].Items.Clear();

            for (int i = 0; i < items[typeof(T)].Count(); i++)
            {
                var item = items[typeof(T)].ElementAt(i);
                checkListBoxes[typeof(T)].Items.Add(item.NameWithPrefix, item.Enabled);
            }
        }

        private void CheckedListBoxSingleClick(object sender, EventArgs e)
        {
            saveButton.Enabled = true;
        }

        #region Double click handlers

        private void LinksCheckListDoubleCLick(object sender, EventArgs e)
        {
            CheckedListBoxDoubleClick<BrokenLink>(sender as CheckedListBox);
        }

        private void ImagesCheckListDoubleCLick(object sender, EventArgs e)
        {
            CheckedListBoxDoubleClick<BrokenImage>(sender as CheckedListBox);
        }

        private void ScriptsCheckListDoubleCLick(object sender, EventArgs e)
        {
            CheckedListBoxDoubleClick<BrokenScript>(sender as CheckedListBox);
        }

        private void StylesCheckListDoubleCLick(object sender, EventArgs e)
        {
            CheckedListBoxDoubleClick<BrokenStyle>(sender as CheckedListBox);
        }

        private void CheckedListBoxDoubleClick<T>(CheckedListBox sender) where T : Broken, new()
        {
            if (!sender.MouseHitsItemText())
            {
                return;
            }

            var selectedItemName = sender.GetSelectedString();

            var items = this.items[typeof (T)];

            Broken rule = items.FirstOrDefault(r => r.NameWithPrefix == selectedItemName);

            if (rule == null)
            {
                return;
            }

            var editorForm = new BrokenItemEditor
            {
                StartPosition = FormStartPosition.CenterParent,
                Title = $"{rule.Name} ({(rule.Enabled ? "enabled" : "disabled")})",
                Rule = rule
            };

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

            this.items[typeof (T)] = items;

            DrawChecklists<T>();
            editorForm.Dispose();
            saveButton.Enabled = true;
        }

        #endregion

        #region Add new button handler

        private void AddNewLinkItemClicked(object sender, EventArgs e)
        {
            AddNewClick<BrokenLink>();
        }

        private void AddNewImageItemClicked(object sender, EventArgs e)
        {
            AddNewClick<BrokenImage>();
        }

        private void AddNewScriptItemClicked(object sender, EventArgs e)
        {
            AddNewClick<BrokenScript>();
        }

        private void AddNewStyleItemClicked(object sender, EventArgs e)
        {
            AddNewClick<BrokenStyle>();
        }

        private void AddNewClick<T>() where T : Broken, new()
        {
            var editorForm = new BrokenItemEditor
            {
                StartPosition = FormStartPosition.CenterParent,
                Title = "Please enter a new broken links pattern",
                Rule = (T) Activator.CreateInstance(typeof (T), new[] {"", ""})
            };

            if (editorForm.ShowDialog() == DialogResult.OK)
            {
                items[typeof(T)] = items[typeof(T)].Concat(new[] { editorForm.Rule });

                DrawChecklists<T>();
                saveButton.Enabled = true;
            }

            editorForm.Dispose();
        }

        #endregion

        #region 'Test all' checkbox change handlers

        private void TestAllLinksCheckChanged(object sender, EventArgs e)
        {
            TestAllLinksCheckChanged<BrokenLink>(sender, e);
        }

        private void TestAllImagesCheckChanged(object sender, EventArgs e)
        {
            TestAllLinksCheckChanged<BrokenImage>(sender, e);
        }

        private void TestAllScriptsCheckChanged(object sender, EventArgs e)
        {
            TestAllLinksCheckChanged<BrokenScript>(sender, e);
        }

        private void TestAllStylesCheckChanged(object sender, EventArgs e)
        {
            TestAllLinksCheckChanged<BrokenStyle>(sender, e);
        }

        private void TestAllLinksCheckChanged<T>(object sender, EventArgs e) where T : Broken
        {
            checkListBoxes[typeof(T)].Visible = !(sender as CheckBox).Checked;
            addNewButtons[typeof(T)].Visible = !(sender as CheckBox).Checked;

            if (e != null)
            {
                saveButton.Enabled = true;
            }
        }

        #endregion

        private void EnsureVisibility()
        {
            testAllLinks.Checked = /* !_links.Any() || */ CurrentProfile.FindAllBrokenLinks;
            testAllImages.Checked = /* !_images.Any() || */ CurrentProfile.FindAllBrokenImages;
            testAllScripts.Checked = /* !_images.Any() || */ CurrentProfile.FindAllBrokenScripts;
            testAllStyles.Checked = /* !_images.Any() || */ CurrentProfile.FindAllBrokenStyles;

            TestAllLinksCheckChanged(testAllLinks, null);
            TestAllImagesCheckChanged(testAllImages, null);
            TestAllScriptsCheckChanged(testAllScripts, null);
            TestAllStylesCheckChanged(testAllStyles, null);
        }

        // checkbox 'proper' handler
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