using ExcelToImageApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExcelToImageApp.Controls
{
    public partial class CCAControl : UserControl
    {
        private List<CCAModel> _ccas = new List<CCAModel>();

        public event EventHandler GenerateRequested;

        public CCAControl()
        {
            InitializeComponent();
        }

        public void LoadData(List<CCAModel> ccas, string baseFolder)
        {
            _ccas = ccas ?? new List<CCAModel>();
            
            clbCCAs.Items.Clear();
            foreach (var cca in _ccas)
            {
                clbCCAs.Items.Add(cca, true);
            }

            if (string.IsNullOrEmpty(txtOutputFolder.Text) && !string.IsNullOrEmpty(baseFolder))
            {
                txtOutputFolder.Text = Path.Combine(baseFolder, "CCA");
            }

            UpdateSummary();
        }

        public List<CCAModel> GetSelectedCCAs()
        {
            return clbCCAs.CheckedItems.Cast<CCAModel>().ToList();
        }

        public string OutputFolder => txtOutputFolder.Text;
        public int TotalCount => clbCCAs.Items.Count;
        public int SelectedCount => clbCCAs.CheckedItems.Count;

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
            for (int i = 0; i < clbCCAs.Items.Count; i++)
            {
                clbCCAs.SetItemChecked(i, state);
            }
            UpdateSummary();
        }

        private void ClbCCAs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() => UpdateSummary()));
        }

        private void UpdateSummary()
        {
            lblSummary.Text = $"Total: {TotalCount}, Selected: {SelectedCount}";
        }
    }
}
