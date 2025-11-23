using ExcelToImageApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExcelToImageApp.Controls
{
    public partial class ClassControl : UserControl
    {
        private List<ClassModel> _classes = new List<ClassModel>();

        public event EventHandler GenerateRequested;

        public ClassControl()
        {
            InitializeComponent();
        }

        public void LoadData(List<ClassModel> classes, string baseFolder)
        {
            _classes = classes ?? new List<ClassModel>();
            
            clbClasses.Items.Clear();
            foreach (var classItem in _classes)
            {
                clbClasses.Items.Add(classItem, true); // Default checked
            }

            // Set default output folder
            if (string.IsNullOrEmpty(txtOutputFolder.Text) && !string.IsNullOrEmpty(baseFolder))
            {
                txtOutputFolder.Text = Path.Combine(baseFolder, "Class");
            }

            UpdateSummary();
        }

        public List<ClassModel> GetSelectedClasses()
        {
            return clbClasses.CheckedItems.Cast<ClassModel>().ToList();
        }

        public string OutputFolder => txtOutputFolder.Text;

        public int TotalCount => clbClasses.Items.Count;
        public int SelectedCount => clbClasses.CheckedItems.Count;

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
            for (int i = 0; i < clbClasses.Items.Count; i++)
            {
                clbClasses.SetItemChecked(i, state);
            }
            UpdateSummary();
        }

        private void ClbClasses_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() => UpdateSummary()));
        }

        private void UpdateSummary()
        {
            lblSummary.Text = $"Total: {TotalCount}, Selected: {SelectedCount}";
        }
    }
}
