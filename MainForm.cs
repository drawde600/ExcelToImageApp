using ExcelToImageApp.Models;
using ExcelToImageApp.Controls;
using ExcelToImageApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
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
        private List<StudentModel> _loadedStudents;

        public MainForm()
        {
            InitializeComponent();
            _excelService = new ExcelService();
            _loadedClasses = new List<ClassModel>();
            _loadedGroups = new List<GroupModel>();
            _loadedCCAs = new List<CCAModel>();
            _loadedStaff = new List<StaffModel>();
            _loadedStudents = new List<StudentModel>();

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
                _loadedStudents = _excelService.LoadStudentData(txtFilePath.Text);
                
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
                // Populate Student Tab via StudentControl
                _studentControl.LoadData(_loadedStudents, txtBaseFolder.Text);

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
                UpdateStudentSummary();

                Log($"Loaded {_loadedClasses.Count} classes, {_loadedGroups.Count} groups, {_loadedCCAs.Count} CCAs, {_loadedStaff.Count} staff, {_loadedStudents.Count} students.");
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
            try
            {
                // Validate inputs
                if (string.IsNullOrWhiteSpace(txtBaseFolder.Text))
                {
                    MessageBox.Show("Please set a Base Folder on the Main tab.");
                    return;
                }

                var referenceSub = string.IsNullOrWhiteSpace(txtReferenceSubfolder.Text)
                    ? "ReferenceImage"
                    : txtReferenceSubfolder.Text.Trim();
                var referenceDir = Path.Combine(txtBaseFolder.Text, referenceSub);
                if (!Directory.Exists(referenceDir))
                {
                    MessageBox.Show($"Reference folder not found: {referenceDir}");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtOutputFolderClass.Text))
                {
                    MessageBox.Show("Please specify an output folder for Class.");
                    return;
                }
                Directory.CreateDirectory(txtOutputFolderClass.Text);

                // Clean output folder before generating
                int cleared = 0;
                foreach (var existing in Directory.EnumerateFiles(txtOutputFolderClass.Text))
                {
                    try { File.Delete(existing); cleared++; }
                    catch (Exception ex) { Log($"Could not delete '{existing}': {ex.Message}"); }
                }
                if (cleared > 0) Log($"Cleared {cleared} files from '{txtOutputFolderClass.Text}'.");

                // Collect reference images that start with CLASS-
                var refFiles = Directory.EnumerateFiles(referenceDir, "CLASS-*.*", SearchOption.TopDirectoryOnly)
                    .Select(p => new { Path = p, Name = Path.GetFileName(p) })
                    .Where(f => f.Name.StartsWith("CLASS-", StringComparison.OrdinalIgnoreCase))
                    .Select(f =>
                    {
                        var nameWithoutExt = Path.GetFileNameWithoutExtension(f.Name);
                        var rest = nameWithoutExt.Substring("CLASS-".Length);
                        // Extract leading digits as SEQNO; preserve original digit string
                        var digits = new string(rest.TakeWhile(char.IsDigit).ToArray());
                        return new
                        {
                            f.Path,
                            Seq = digits,
                            Ext = Path.GetExtension(f.Name).TrimStart('.')
                        };
                    })
                    .Where(x => !string.IsNullOrEmpty(x.Seq))
                    .OrderBy(x => int.TryParse(x.Seq, out var n) ? n : int.MaxValue)
                    .ToList();

                if (refFiles.Count == 0)
                {
                    MessageBox.Show($"No reference images found starting with 'CLASS-' in {referenceDir}.");
                    return;
                }

                if (clbClasses.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select at least one class to generate.");
                    return;
                }

                var pattern = cmbClassFilenamePattern?.SelectedItem as string ?? "{CLASSNO}{SEPA}{SEQNO}.{EXT}";
                var sepa = cmbSeparator?.SelectedItem as string ?? "_";
                int padWidth = pattern.Contains("{SEQNO3}") ? 3 : pattern.Contains("{SEQNO2}") ? 2 : 0;
                int total = 0;

                foreach (var cls in clbClasses.CheckedItems.Cast<ClassModel>())
                {
                    var classToken = cls.ClassName?.Trim() ?? string.Empty; // e.g., "1-Gryffindor"
                    foreach (var rf in refFiles)
                    {
                        var seqOut = padWidth > 0 ? rf.Seq.PadLeft(padWidth, '0') : rf.Seq;
                        string fileName = pattern
                            .Replace("{CLASSNO}", classToken)
                            .Replace("{SEQNO3}", seqOut)
                            .Replace("{SEQNO2}", seqOut)
                            .Replace("{SEQNO}", seqOut)
                            .Replace("{SEPA}", sepa)
                            .Replace("{EXT}", rf.Ext);

                        var destPath = Path.Combine(txtOutputFolderClass.Text, fileName);
                        SaveImageWithTimestamp(rf.Path, destPath);
                        total++;
                    }
                }

                Log($"Generated {total} class images into '{txtOutputFolderClass.Text}'.");
                MessageBox.Show($"Generated {total} class images.");
            }
            catch (Exception ex)
            {
                Log($"Error generating class images: {ex.Message}");
                MessageBox.Show($"Error generating class images: {ex.Message}");
            }
        }

        private void SaveImageWithTimestamp(string sourcePath, string destinationPath)
        {
            using (var bmp = new Bitmap(sourcePath))
            using (var g = Graphics.FromImage(bmp))
            using (var font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                string stamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                var location = new PointF(4f, 4f);

                using (var shadowBrush = new SolidBrush(Color.FromArgb(160, 0, 0, 0)))
                using (var textBrush = new SolidBrush(Color.FromArgb(210, 255, 255, 255)))
                {
                    // Tiny shadow for readability
                    g.DrawString(stamp, font, shadowBrush, new PointF(location.X + 1, location.Y + 1));
                    g.DrawString(stamp, font, textBrush, location);
                }

                var ext = Path.GetExtension(destinationPath)?.TrimStart('.').ToLowerInvariant();
                switch (ext)
                {
                    case "jpg":
                    case "jpeg":
                        bmp.Save(destinationPath, ImageFormat.Jpeg);
                        break;
                    case "png":
                        bmp.Save(destinationPath, ImageFormat.Png);
                        break;
                    case "bmp":
                        bmp.Save(destinationPath, ImageFormat.Bmp);
                        break;
                    case "gif":
                        bmp.Save(destinationPath, ImageFormat.Gif);
                        break;
                    case "tif":
                    case "tiff":
                        bmp.Save(destinationPath, ImageFormat.Tiff);
                        break;
                    default:
                        // Fallback to source's raw format
                        bmp.Save(destinationPath, bmp.RawFormat);
                        break;
                }
            }
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

        private void StudentControl_SelectionChanged(object? sender, EventArgs e)
        {
            UpdateStudentSummary();
        }

        private void UpdateStudentSummary()
        {
            int total = _studentControl?.TotalCount ?? 0;
            int selected = _studentControl?.SelectedCount ?? 0;
            string summary = $"Student: {total} items ({selected} selected)";
            if (lblMainStudentSummary != null)
            {
                lblMainStudentSummary.Text = summary;
            }
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
