using ExcelToImageApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExcelToImageApp.Controls
{
    public partial class GroupControl : UserControl
    {
        private List<GroupModel> _groups = new List<GroupModel>();

        public event EventHandler GenerateRequested;

        public GroupControl()
        {
            InitializeComponent();
        }

        public void LoadData(List<GroupModel> groups, string baseFolder)
        {
            _groups = groups ?? new List<GroupModel>();
            
            clbGroups.Items.Clear();
            foreach (var group in _groups)
            {
                clbGroups.Items.Add(group, true); // Default checked
            }

            // Set default output folder
            if (string.IsNullOrEmpty(txtOutputFolder.Text) && !string.IsNullOrEmpty(baseFolder))
            {
                txtOutputFolder.Text = Path.Combine(baseFolder, "Group");
            }

            UpdateSummary();
        }

        public List<GroupModel> GetSelectedGroups()
        {
            return clbGroups.CheckedItems.Cast<GroupModel>().ToList();
        }

        public string OutputFolder => txtOutputFolder.Text;

        public int TotalCount => clbGroups.Items.Count;
        public int SelectedCount => clbGroups.CheckedItems.Count;

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            GenerateRequested?.Invoke(this, e);
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtOutputFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void ChkSelectAll_Click(object sender, EventArgs e)
        {
            SetAllChecked(true);
        }

        private void ChkDeselectAll_Click(object sender, EventArgs e)
        {
            SetAllChecked(false);
        }

        private void SetAllChecked(bool state)
        {
            for (int i = 0; i < clbGroups.Items.Count; i++)
            {
                clbGroups.SetItemChecked(i, state);
            }
            UpdateSummary();
        }

        private void ClbGroups_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() => UpdateSummary()));
        }

        private void UpdateSummary()
        {
            lblSummary.Text = $"Total: {TotalCount}, Selected: {SelectedCount}";
        }
    }
}
