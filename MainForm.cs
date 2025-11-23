using ExcelToImageApp.Models;
using ExcelToImageApp.Controls;
using ExcelToImageApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ExcelToImageApp
{
    public partial class MainForm : Form
    {
        private readonly ExcelService _excelService;
        private List<ClassModel> _loadedClasses;
        private List<GroupModel> _loadedGroups;
        private List<CCAModel> _loadedCCAs;
        private List<StaffModel> _loadedStaff;

        public MainForm()
        {
            InitializeComponent();
            _excelService = new ExcelService();
            _loadedClasses = new List<ClassModel>();
            _loadedGroups = new List<GroupModel>();
            _loadedCCAs = new List<CCAModel>();
            _loadedStaff = new List<StaffModel>();

            // Staff UI is configured via the Designer.
        }

        private void BtnBrowseFile_Click(object sender, EventArgs e)
        {
            BrowseFile();
        }

        private void TxtFilePath_DoubleClick(object sender, EventArgs e)
        {
            BrowseFile();
        }

        private void BtnBrowseBase_Click(object sender, EventArgs e)
        {
            BrowseFolder(txtBaseFolder);
        }

        private void BtnBrowseOutputClass_Click(object sender, EventArgs e)
        {
            BrowseFolder(txtOutputFolderClass);
        }

        private void BrowseFile()
        {
            using (var ofd = new OpenFileDialog { Filter = "Excel Files|*.xlsx;*.xls" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtFilePath.Text = ofd.FileName;
                    if (string.IsNullOrWhiteSpace(txtBaseFolder.Text))
                    {
                        txtBaseFolder.Text = Path.GetDirectoryName(ofd.FileName);
                    }
                }
            }
        }

        private void BrowseFolder(TextBox target)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    target.Text = fbd.SelectedPath;
                }
            }
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                Log("Loading data...");
                if (string.IsNullOrWhiteSpace(txtFilePath.Text))
                {
                    MessageBox.Show("Please select an Excel file first.");
                    return;
                }

                _loadedClasses = _excelService.LoadClassData(txtFilePath.Text);
                _loadedGroups = _excelService.LoadGroupData(txtFilePath.Text);
                _loadedCCAs = _excelService.LoadCCAData(txtFilePath.Text);
                _loadedStaff = _excelService.LoadStaffData(txtFilePath.Text);
                
                // Populate Class Tab
                clbClasses.Items.Clear();
                foreach (var cls in _loadedClasses)
                {
                    clbClasses.Items.Add(cls, true); // Default checked
                }

                // Populate Group Tab
                clbGroups.Items.Clear();
                foreach (var grp in _loadedGroups)
                {
                    clbGroups.Items.Add(grp, true);
                }

                // Populate CCA Tab
                clbCCAs.Items.Clear();
                foreach (var cca in _loadedCCAs)
                {
                    clbCCAs.Items.Add(cca, true);
                }

                // Populate Staff Tab via StaffControl
                _staffControl.LoadData(_loadedStaff, txtBaseFolder.Text);

                // Hook up events
                clbClasses.ItemCheck += ClbClasses_ItemCheck;
                clbGroups.ItemCheck += ClbGroups_ItemCheck;
                clbCCAs.ItemCheck += ClbCCAs_ItemCheck;

                // Set default output folders
                if (!string.IsNullOrWhiteSpace(txtBaseFolder.Text))
                {
                    if (string.IsNullOrWhiteSpace(txtOutputFolderClass.Text))
                        txtOutputFolderClass.Text = Path.Combine(txtBaseFolder.Text, "Class");
                    
                    if (string.IsNullOrWhiteSpace(txtOutputFolderGroup.Text))
                        txtOutputFolderGroup.Text = Path.Combine(txtBaseFolder.Text, "Group");

                    if (string.IsNullOrWhiteSpace(txtOutputFolderCCA.Text))
                        txtOutputFolderCCA.Text = Path.Combine(txtBaseFolder.Text, "CCA");
                    // StaffControl sets its own default when loading data
                }

                UpdateClassSummary();
                UpdateGroupSummary();
                UpdateCCASummary();
                UpdateStaffSummary();

                Log($"Loaded {_loadedClasses.Count} classes, {_loadedGroups.Count} groups, {_loadedCCAs.Count} CCAs, {_loadedStaff.Count} staff.");
                MessageBox.Show("Data loaded successfully!");
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private void ClbClasses_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() => UpdateClassSummary()));
        }

        private void ClbGroups_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() => UpdateGroupSummary()));
        }

        private void UpdateClassSummary()
        {
            int total = clbClasses.Items.Count;
            int selected = clbClasses.CheckedItems.Count;
            string summary = $"Class: {total} items ({selected} selected)";
            
            lblClassSummary.Text = summary;
            lblMainClassSummary.Text = summary;
        }

        private void UpdateGroupSummary()
        {
            int total = clbGroups.Items.Count;
            int selected = clbGroups.CheckedItems.Count;
            string summary = $"Group: {total} items ({selected} selected)";

            lblGroupSummary.Text = summary;
            lblMainGroupSummary.Text = summary;
        }

        private void BtnGenerateAll_Click(object sender, EventArgs e)
        {
            BtnGenerateClass_Click(sender, e);
            BtnGenerateGroup_Click(sender, e);
        }

        private void BtnGenerateClass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Class generation not yet supported");
        }

        private void BtnGenerateGroup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Group generation not yet supported");
        }

        private void ChkSelectAllClass_Click(object sender, EventArgs e)
        {
            SetAllChecked(clbClasses, true);
            UpdateClassSummary();
        }

        private void ChkDeselectAllClass_Click(object sender, EventArgs e)
        {
            SetAllChecked(clbClasses, false);
            UpdateClassSummary();
        }

        private void ChkSelectAllGroup_Click(object sender, EventArgs e)
        {
            SetAllChecked(clbGroups, true);
            UpdateGroupSummary();
        }

        private void ChkDeselectAllGroup_Click(object sender, EventArgs e)
        {
            SetAllChecked(clbGroups, false);
            UpdateGroupSummary();
        }

        private void BtnBrowseOutputGroup_Click(object sender, EventArgs e)
        {
            BrowseFolder(txtOutputFolderGroup);
        }

        private void SetAllChecked(CheckedListBox clb, bool state)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, state);
            }
        }

        private void ClbCCAs_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() => UpdateCCASummary()));
        }

        private void UpdateCCASummary()
        {
            int total = clbCCAs.Items.Count;
            int selected = clbCCAs.CheckedItems.Count;
            string summary = $"CCA: {total} items ({selected} selected)";

            lblCCASummary.Text = summary;
            lblMainCCASummary.Text = summary;
        }

        private void UpdateStaffSummary()
        {
            int total = _staffControl?.TotalCount ?? 0;
            int selected = _staffControl?.SelectedCount ?? 0;
            string summary = $"Staff: {total} items ({selected} selected)";
            if (lblMainStaffSummary != null)
            {
                lblMainStaffSummary.Text = summary;
            }
        }

        private void StaffControl_SelectionChanged(object? sender, EventArgs e)
        {
            UpdateStaffSummary();
        }

        private void BtnGenerateCCA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CCA generation not yet supported");
        }

        private void ChkSelectAllCCA_Click(object sender, EventArgs e)
        {
            SetAllChecked(clbCCAs, true);
            UpdateCCASummary();
        }

        private void ChkDeselectAllCCA_Click(object sender, EventArgs e)
        {
            SetAllChecked(clbCCAs, false);
            UpdateCCASummary();
        }

        private void BtnBrowseOutputCCA_Click(object sender, EventArgs e)
        {
            BrowseFolder(txtOutputFolderCCA);
        }

        private void Log(string message)
        {
            rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
            rtbLog.ScrollToCaret();
        }
    }
}
