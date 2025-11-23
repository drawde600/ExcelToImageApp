using ExcelToImageApp.Models;
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

        public MainForm()
        {
            InitializeComponent();
            _excelService = new ExcelService();
            _loadedClasses = new List<ClassModel>();
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
                
                // Populate Class Tab
                clbClasses.Items.Clear();
                foreach (var cls in _loadedClasses)
                {
                    clbClasses.Items.Add(cls, true); // Default checked
                }

                // Hook up event for counting
                clbClasses.ItemCheck += ClbClasses_ItemCheck;

                // Set default output folder for Class if not set
                if (string.IsNullOrWhiteSpace(txtOutputFolderClass.Text) && !string.IsNullOrWhiteSpace(txtBaseFolder.Text))
                {
                    txtOutputFolderClass.Text = Path.Combine(txtBaseFolder.Text, "Class");
                }

                UpdateClassSummary();

                Log($"Loaded {_loadedClasses.Count} classes.");
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
            // The check state is not yet updated when this event fires, so we defer the update
            this.BeginInvoke(new Action(() => UpdateClassSummary()));
        }

        private void UpdateClassSummary()
        {
            int total = clbClasses.Items.Count;
            int selected = clbClasses.CheckedItems.Count;
            string summary = $"Class: {total} items ({selected} selected)";
            
            lblClassSummary.Text = summary;
            lblMainClassSummary.Text = summary;
        }

        private void BtnGenerateClass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet supported");
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

        private void SetAllChecked(CheckedListBox clb, bool state)
        {
            for (int i = 0; i < clb.Items.Count; i++)
            {
                clb.SetItemChecked(i, state);
            }
        }

        private void Log(string message)
        {
            rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}\n");
            rtbLog.ScrollToCaret();
        }
    }
}
