using ExcelToImageApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExcelToImageApp.Controls
{
    public partial class StaffControl : UserControl
    {
        private List<StaffModel> _staff = new List<StaffModel>();

        public event EventHandler GenerateRequested;
        public event EventHandler? SelectionChanged;

        public StaffControl()
        {
            InitializeComponent();
        }

        public void LoadData(List<StaffModel> staff, string baseFolder)
        {
            _staff = staff ?? new List<StaffModel>();
            
            clbStaff.Items.Clear();
            foreach (var staffMember in _staff)
            {
                clbStaff.Items.Add(staffMember, true);
            }

            if (string.IsNullOrEmpty(txtOutputFolder.Text) && !string.IsNullOrEmpty(baseFolder))
            {
                txtOutputFolder.Text = Path.Combine(baseFolder, "Staff");
            }

            UpdateSummary();
        }

        public List<StaffModel> GetSelectedStaff()
        {
            return clbStaff.CheckedItems.Cast<StaffModel>().ToList();
        }

        public string OutputFolder => txtOutputFolder.Text;
        public int TotalCount => clbStaff.Items.Count;
        public int SelectedCount => clbStaff.CheckedItems.Count;

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
            for (int i = 0; i < clbStaff.Items.Count; i++)
            {
                clbStaff.SetItemChecked(i, state);
            }
            UpdateSummary();
        }

        private void ClbStaff_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() => UpdateSummary()));
        }

        private void UpdateSummary()
        {
            lblSummary.Text = $"Total: {TotalCount}, Selected: {SelectedCount}";
            SelectionChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
