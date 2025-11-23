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
        private List<ClassModel> _rawClasses;
        private List<GroupModel> _rawGroups;
        private List<CCAModel> _rawCCAs;
        private List<StaffModel> _rawStaff;
        private List<StudentModel> _rawStudents;

        public MainForm()
        {
            InitializeComponent();
            _excelService = new ExcelService();
            _loadedClasses = new List<ClassModel>();
            _loadedGroups = new List<GroupModel>();
            _loadedCCAs = new List<CCAModel>();
            _loadedStaff = new List<StaffModel>();
            _loadedStudents = new List<StudentModel>();
            _rawClasses = new List<ClassModel>();
            _rawGroups = new List<GroupModel>();
            _rawCCAs = new List<CCAModel>();
            _rawStaff = new List<StaffModel>();
            _rawStudents = new List<StudentModel>();

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

                _rawClasses = _excelService.LoadClassData(txtFilePath.Text);
                _rawGroups = _excelService.LoadGroupData(txtFilePath.Text);
                _rawCCAs = _excelService.LoadCCAData(txtFilePath.Text);
                _rawStaff = _excelService.LoadStaffData(txtFilePath.Text);
                _rawStudents = _excelService.LoadStudentData(txtFilePath.Text);

                RebuildLoadedFromRaw();
                
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
                SetStatus("Load completed.");

                // Enable generate buttons after successful load
                btnGenerateAll.Enabled = true;
                btnGenerateClass.Enabled = true;
                btnGenerateGroup.Enabled = true;
                btnGenerateCCA.Enabled = true;
            }
            catch (Exception ex)
            {
                Log($"Error: {ex.Message}");
                MessageBox.Show($"Error loading data: {ex.Message}");
                SetStatus("Error during load.");
        }
        }

        private void RebuildLoadedFromRaw()
        {
            bool toUpper = chkUppercase.Checked;
            string Up(string s) => toUpper ? (s ?? string.Empty).ToUpperInvariant() : (s ?? string.Empty);

            _loadedClasses = _rawClasses.Select(c => new ClassModel { ClassName = Up(c.ClassName) }).ToList();
            _loadedGroups = _rawGroups.Select(g => new GroupModel { GroupName = Up(g.GroupName) }).ToList();
            _loadedCCAs = _rawCCAs.Select(a => new CCAModel { CCAName = Up(a.CCAName) }).ToList();
            _loadedStaff = _rawStaff.Select(s => new StaffModel { StaffName = Up(s.StaffName), Position = Up(s.Position) }).ToList();
            _loadedStudents = _rawStudents.Select(st => new StudentModel { StudentName = Up(st.StudentName), IndexNo = Up(st.IndexNo), ClassName = Up(st.ClassName) }).ToList();
        }

        private void ChkUppercase_CheckedChanged(object? sender, EventArgs e)
        {
            try
            {
                // Preserve checked indices
                var classChecked = clbClasses.CheckedIndices.Cast<int>().ToList();
                var groupChecked = clbGroups.CheckedIndices.Cast<int>().ToList();
                var ccaChecked = clbCCAs.CheckedIndices.Cast<int>().ToList();

                RebuildLoadedFromRaw();

                // Rebind Class
                clbClasses.Items.Clear();
                foreach (var cls in _loadedClasses) clbClasses.Items.Add(cls, false);
                foreach (var i in classChecked) if (i >= 0 && i < clbClasses.Items.Count) clbClasses.SetItemChecked(i, true);
                UpdateClassSummary();

                // Rebind Group
                clbGroups.Items.Clear();
                foreach (var grp in _loadedGroups) clbGroups.Items.Add(grp, false);
                foreach (var i in groupChecked) if (i >= 0 && i < clbGroups.Items.Count) clbGroups.SetItemChecked(i, true);
                UpdateGroupSummary();

                // Rebind CCA
                clbCCAs.Items.Clear();
                foreach (var cca in _loadedCCAs) clbCCAs.Items.Add(cca, false);
                foreach (var i in ccaChecked) if (i >= 0 && i < clbCCAs.Items.Count) clbCCAs.SetItemChecked(i, true);
                UpdateCCASummary();

                // Rebind Staff and Student (defaults to all selected)
                _staffControl.LoadData(_loadedStaff, txtBaseFolder.Text);
                _studentControl.LoadData(_loadedStudents, txtBaseFolder.Text);

                UpdateStaffSummary();
                UpdateStudentSummary();
            }
            catch (Exception ex)
            {
                Log($"Uppercase toggle error: {ex.Message}");
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

        private bool _forceCopyToAllDuringAll = false;

        private void BtnGenerateAll_Click(object sender, EventArgs e)
        {
            Log("Starting Generate All...");
            SetStatus("Generating all images...");
            _forceCopyToAllDuringAll = true;

            string classDir = txtOutputFolderClass.Text;
            string groupDir = txtOutputFolderGroup.Text;
            string staffDir = _staffControl?.OutputFolder ?? string.Empty;
            string studentDir = _studentControl?.OutputFolder ?? string.Empty;
            string ccaDir = txtOutputFolderCCA.Text;

            BtnGenerateClass_Click(sender, e);
            BtnGenerateGroup_Click(sender, e);
            StaffControl_GenerateRequested(sender, e);
            StudentControl_GenerateRequested(sender, e);
            BtnGenerateCCA_Click(sender, e);

            int c = Directory.Exists(classDir) ? Directory.EnumerateFiles(classDir).Count() : 0;
            int g = Directory.Exists(groupDir) ? Directory.EnumerateFiles(groupDir).Count() : 0;
            int s = (!string.IsNullOrWhiteSpace(staffDir) && Directory.Exists(staffDir)) ? Directory.EnumerateFiles(staffDir).Count() : 0;
            int st = (!string.IsNullOrWhiteSpace(studentDir) && Directory.Exists(studentDir)) ? Directory.EnumerateFiles(studentDir).Count() : 0;
            int cc = Directory.Exists(ccaDir) ? Directory.EnumerateFiles(ccaDir).Count() : 0;
            int total = c + g + s + st + cc;
            Log($"Generate All completed. Class: {c}, Group: {g}, Staff: {s}, Student: {st}, CCA: {cc}. Total: {total}.");
            SetStatus("Generate All completed.");

            _forceCopyToAllDuringAll = false;
        }

        private void BtnGenerateClass_Click(object sender, EventArgs e)
        {
            try
            {
                Log("Starting Class image generation...");
                SetStatus("Generating Class images...");
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

                var pattern = cmbClassFilenamePattern?.SelectedItem as string ?? "{CLASS}{SEPA}{SEQNO}.{EXT}";
                var sepa = cmbSeparator?.SelectedItem as string ?? "_";
                var shortSchool = (txtSchoolShortName?.Text ?? "").Trim();
                var school = (txtSchoolName?.Text ?? "").Trim();
                int padWidth = pattern.Contains("{SEQNO3}") ? 3 : pattern.Contains("{SEQNO2}") ? 2 : 0;
                int total = 0;

                foreach (var cls in clbClasses.CheckedItems.Cast<ClassModel>())
                {
                    var classToken = cls.ClassName?.Trim() ?? string.Empty; // e.g., "1-Gryffindor"
                    foreach (var rf in refFiles)
                    {
                        var seqOut = padWidth > 0 ? rf.Seq.PadLeft(padWidth, '0') : rf.Seq;
                        string fileName = pattern
                            .Replace("{CLASS}", classToken)
                            .Replace("{CLASSNO}", classToken)
                            .Replace("{SEQNO3}", seqOut)
                            .Replace("{SEQNO2}", seqOut)
                            .Replace("{SEQNO}", seqOut)
                            .Replace("{SEPA}", sepa)
                            .Replace("{SHORTSCHOOL}", shortSchool)
                            .Replace("{SCHOOL}", school)
                            .Replace("{EXT}", rf.Ext);

                        var destPath = Path.Combine(txtOutputFolderClass.Text, fileName);
                        SaveImageWithTimestamp(rf.Path, destPath);
                        total++;
                    }
                }

                Log($"Generated {total} class images into '{txtOutputFolderClass.Text}'.");
                CopyToAll(txtOutputFolderClass.Text);
                SetStatus("Class generation completed.");
            }
            catch (Exception ex)
            {
                Log($"Error generating class images: {ex.Message}");
                MessageBox.Show($"Error generating class images: {ex.Message}");
                SetStatus("Class generation error.");
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
            try
            {
                Log("Starting Group image generation...");
                SetStatus("Generating Group images...");
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

                if (string.IsNullOrWhiteSpace(txtOutputFolderGroup.Text))
                {
                    MessageBox.Show("Please specify an output folder for Group.");
                    return;
                }
                Directory.CreateDirectory(txtOutputFolderGroup.Text);

                // Clean output folder
                foreach (var existing in Directory.EnumerateFiles(txtOutputFolderGroup.Text))
                {
                    try { File.Delete(existing); } catch { }
                }

                // Reference images for group (files starting with GROUP-<number>)
                var refFiles = Directory.EnumerateFiles(referenceDir, "GROUP-*.*", SearchOption.TopDirectoryOnly)
                    .Select(p => new { Path = p, Name = Path.GetFileName(p) })
                    .Where(f => f.Name.StartsWith("GROUP-", StringComparison.OrdinalIgnoreCase))
                    .Select(f =>
                    {
                        var nameWithoutExt = Path.GetFileNameWithoutExtension(f.Name);
                        var rest = nameWithoutExt.Substring("GROUP-".Length);
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
                    MessageBox.Show($"No reference images found starting with 'GROUP-' in {referenceDir}.");
                    return;
                }

                if (clbGroups.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select at least one group to generate.");
                    return;
                }

                var pattern = cmbGroupFilenamePattern?.SelectedItem as string ?? "{GROUP}{SEPA}{SEQNO}.{EXT}";
                var sepa = cmbSeparator?.SelectedItem as string ?? "_";
                int padWidth = pattern.Contains("{SEQNO3}") ? 3 : 0;
                int total = 0;

                foreach (var grp in clbGroups.CheckedItems.Cast<GroupModel>())
                {
                    var groupToken = grp.GroupName?.Trim() ?? string.Empty;
                    foreach (var rf in refFiles)
                    {
                        var seqOut = padWidth > 0 ? rf.Seq.PadLeft(padWidth, '0') : rf.Seq;
                        string fileName = pattern
                            .Replace("{GROUP}", groupToken)
                            .Replace("{SEQNO3}", seqOut)
                            .Replace("{SEQNO}", seqOut)
                            .Replace("{SEPA}", sepa)
                            .Replace("{EXT}", rf.Ext);

                        var destPath = Path.Combine(txtOutputFolderGroup.Text, fileName);
                        SaveImageWithTimestamp(rf.Path, destPath);
                        total++;
                    }
                }

                Log($"Generated {total} group images into '{txtOutputFolderGroup.Text}'.");
                CopyToAll(txtOutputFolderGroup.Text);
                SetStatus("Group generation completed.");
            }
            catch (Exception ex)
            {
                Log($"Error generating group images: {ex.Message}");
                MessageBox.Show($"Error generating group images: {ex.Message}");
                SetStatus("Group generation error.");
            }
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

        private void StaffControl_GenerateRequested(object? sender, EventArgs e)
        {
            try
            {
                Log("Starting Staff image generation...");
                SetStatus("Generating Staff images...");
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

                var selected = _staffControl.GetSelectedStaff();
                if (selected.Count == 0)
                {
                    MessageBox.Show("Please select at least one staff.");
                    return;
                }

                var output = _staffControl.OutputFolder;
                if (string.IsNullOrWhiteSpace(output))
                {
                    MessageBox.Show("Please specify an output folder for Staff.");
                    return;
                }
                Directory.CreateDirectory(output);

                // Clean output folder
                foreach (var existing in Directory.EnumerateFiles(output))
                {
                    try { File.Delete(existing); } catch { }
                }

                // Reference images for staff (files starting with STAFF-<number>)
                var refFiles = Directory.EnumerateFiles(referenceDir, "STAFF-*.*", SearchOption.TopDirectoryOnly)
                    .Select(p => new { Path = p, Name = Path.GetFileName(p) })
                    .Where(f => f.Name.StartsWith("STAFF-", StringComparison.OrdinalIgnoreCase))
                    .Select(f =>
                    {
                        var nameWithoutExt = Path.GetFileNameWithoutExtension(f.Name);
                        var rest = nameWithoutExt.Substring("STAFF-".Length);
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
                    MessageBox.Show($"No reference images found starting with 'STAFF-' in {referenceDir}.");
                    return;
                }

                var sepa = cmbSeparator?.SelectedItem as string ?? "_";
                var pattern = _staffControl.SelectedPattern;
                int padWidth = pattern.Contains("{SEQNO3}") ? 3 : 0;
                int total = 0;

                foreach (var st in selected)
                {
                    var nameToken = st.StaffName?.Trim() ?? string.Empty;
                    var posToken = st.Position?.Trim() ?? string.Empty;
                    foreach (var rf in refFiles)
                    {
                        var seqOut = padWidth > 0 ? rf.Seq.PadLeft(padWidth, '0') : rf.Seq;
                        var fileName = pattern
                            .Replace("{STAFF}", nameToken)
                            .Replace("{POSITION}", posToken)
                            .Replace("{SEQNO3}", seqOut)
                            .Replace("{SEQNO}", seqOut)
                            .Replace("{SEPA}", sepa)
                            .Replace("{EXT}", rf.Ext);

                        var destPath = Path.Combine(output, fileName);
                        SaveImageWithTimestamp(rf.Path, destPath);
                        total++;
                    }
                }

                Log($"Generated {total} staff images into '{output}'.");
                CopyToAll(output);
                SetStatus("Staff generation completed.");
            }
            catch (Exception ex)
            {
                Log($"Error generating staff images: {ex.Message}");
                MessageBox.Show($"Error generating staff images: {ex.Message}");
                SetStatus("Staff generation error.");
            }
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

        private void StudentControl_GenerateRequested(object? sender, EventArgs e)
        {
            try
            {
                Log("Starting Student image generation...");
                SetStatus("Generating Student images...");
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

                var selected = _studentControl.GetSelectedStudents();
                if (selected.Count == 0)
                {
                    MessageBox.Show("Please select at least one student.");
                    return;
                }

                var output = _studentControl.OutputFolder;
                if (string.IsNullOrWhiteSpace(output))
                {
                    MessageBox.Show("Please specify an output folder for Student.");
                    return;
                }
                Directory.CreateDirectory(output);

                // Clean output folder
                foreach (var existing in Directory.EnumerateFiles(output))
                {
                    try { File.Delete(existing); } catch { }
                }

                // Reference images for student (files starting with STUDENT-<number>)
                var refFiles = Directory.EnumerateFiles(referenceDir, "STUDENT-*.*", SearchOption.TopDirectoryOnly)
                    .Select(p => new { Path = p, Name = Path.GetFileName(p) })
                    .Where(f => f.Name.StartsWith("STUDENT-", StringComparison.OrdinalIgnoreCase))
                    .Select(f =>
                    {
                        var nameWithoutExt = Path.GetFileNameWithoutExtension(f.Name);
                        var rest = nameWithoutExt.Substring("STUDENT-".Length);
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
                    MessageBox.Show($"No reference images found starting with 'STUDENT-' in {referenceDir}.");
                    return;
                }

                var sepa = cmbSeparator?.SelectedItem as string ?? "_";
                var pattern = _studentControl.SelectedPattern;
                int padWidth = pattern.Contains("{SEQNO3}") || pattern.Contains("{SEQNO03}") ? 3 : 0;
                int total = 0;

                foreach (var st in selected)
                {
                    var classToken = st.ClassName?.Trim() ?? string.Empty;
                    var indexToken = st.IndexNo?.Trim() ?? string.Empty;
                    var nameToken = st.StudentName?.Trim() ?? string.Empty;
                    foreach (var rf in refFiles)
                    {
                        var seqOut = padWidth > 0 ? rf.Seq.PadLeft(padWidth, '0') : rf.Seq;
                        var fileName = pattern
                            .Replace("{CLASS}", classToken)
                            .Replace("{INDEXNO}", indexToken)
                            .Replace("{STUDENT}", nameToken)
                            .Replace("{SEQNO03}", seqOut)
                            .Replace("{SEQNO3}", seqOut)
                            .Replace("{SEQNO}", seqOut)
                            .Replace("{SEPA}", sepa)
                            .Replace("{EXT}", rf.Ext);

                        var destPath = Path.Combine(output, fileName);
                        SaveImageWithTimestamp(rf.Path, destPath);
                        total++;
                    }
                }

                Log($"Generated {total} student images into '{output}'.");
                CopyToAll(output);
                SetStatus("Student generation completed.");
            }
            catch (Exception ex)
            {
                Log($"Error generating student images: {ex.Message}");
                MessageBox.Show($"Error generating student images: {ex.Message}");
                SetStatus("Student generation error.");
            }
        }

        private void BtnGenerateCCA_Click(object sender, EventArgs e)
        {
            try
            {
                Log("Starting CCA image generation...");
                SetStatus("Generating CCA images...");
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

                if (string.IsNullOrWhiteSpace(txtOutputFolderCCA.Text))
                {
                    MessageBox.Show("Please specify an output folder for CCA.");
                    return;
                }
                Directory.CreateDirectory(txtOutputFolderCCA.Text);

                // Clean output folder
                foreach (var existing in Directory.EnumerateFiles(txtOutputFolderCCA.Text))
                {
                    try { File.Delete(existing); } catch { }
                }

                // Reference images for CCA (files starting with CCA-<number>)
                var refFiles = Directory.EnumerateFiles(referenceDir, "CCA-*.*", SearchOption.TopDirectoryOnly)
                    .Select(p => new { Path = p, Name = Path.GetFileName(p) })
                    .Where(f => f.Name.StartsWith("CCA-", StringComparison.OrdinalIgnoreCase))
                    .Select(f =>
                    {
                        var nameWithoutExt = Path.GetFileNameWithoutExtension(f.Name);
                        var rest = nameWithoutExt.Substring("CCA-".Length);
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
                    MessageBox.Show($"No reference images found starting with 'CCA-' in {referenceDir}.");
                    return;
                }

                if (clbCCAs.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select at least one CCA to generate.");
                    return;
                }

                var pattern = cmbCCAFilenamePattern?.SelectedItem as string ?? "{CCA}{SEPA}{SEQNO}.{EXT}";
                var sepa = cmbSeparator?.SelectedItem as string ?? "_";
                int padWidth = pattern.Contains("{SEQNO3}") ? 3 : 0;
                int total = 0;

                foreach (var cca in clbCCAs.CheckedItems.Cast<CCAModel>())
                {
                    var ccaToken = cca.CCAName?.Trim() ?? string.Empty;
                    foreach (var rf in refFiles)
                    {
                        var seqOut = padWidth > 0 ? rf.Seq.PadLeft(padWidth, '0') : rf.Seq;
                        string fileName = pattern
                            .Replace("{CCA}", ccaToken)
                            .Replace("{SEQNO3}", seqOut)
                            .Replace("{SEQNO}", seqOut)
                            .Replace("{SEPA}", sepa)
                            .Replace("{EXT}", rf.Ext);

                        var destPath = Path.Combine(txtOutputFolderCCA.Text, fileName);
                        SaveImageWithTimestamp(rf.Path, destPath);
                        total++;
                    }
                }

                Log($"Generated {total} CCA images into '{txtOutputFolderCCA.Text}'.");
                CopyToAll(txtOutputFolderCCA.Text);
                SetStatus("CCA generation completed.");
            }
            catch (Exception ex)
            {
                Log($"Error generating CCA images: {ex.Message}");
                MessageBox.Show($"Error generating CCA images: {ex.Message}");
                SetStatus("CCA generation error.");
            }
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBaseFolder.Text))
                {
                    MessageBox.Show("Please set a Base Folder on the Main tab.");
                    return;
                }
                var confirm = MessageBox.Show(
                    "This will permanently delete the 'All', 'CCA', 'Class', 'Group', 'Staff', and 'Student' folders under the Base Folder. Continue?",
                    "Confirm Clean",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (confirm != DialogResult.Yes)
                {
                    Log("Clean cancelled by user.");
                    SetStatus("Clean cancelled.");
                    return;
                }
                SetStatus("Cleaning output folders...");

                var names = new[] { "All", "CCA", "Class", "Group", "Staff", "Student", "Sudent" };
                int removed = 0;
                foreach (var name in names)
                {
                    var dir = Path.Combine(txtBaseFolder.Text, name);
                    if (Directory.Exists(dir))
                    {
                        try
                        {
                            Directory.Delete(dir, true);
                            removed++;
                            Log($"Deleted folder '{dir}'.");
                        }
                        catch (Exception ex)
                        {
                            Log($"Could not delete '{dir}': {ex.Message}");
                        }
                    }
                }
                Log($"Clean completed. Deleted {removed} folder(s).");
                SetStatus("Clean completed.");
            }
            catch (Exception ex)
            {
                Log($"Clean error: {ex.Message}");
                SetStatus("Clean error.");
            }
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
            rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            rtbLog.ScrollToCaret();
            rtbLog.Refresh();
        }

        private void SetStatus(string text)
        {
            try
            {
                if (statusLabel == null) return;
                statusLabel.Text = text;
                statusLabel.Owner?.Refresh();
                Application.DoEvents();
            }
            catch
            {
                // ignore UI refresh errors
            }
        }

        private void CopyToAll(string sourceDirectory)
        {
            try
            {
                if (!(_forceCopyToAllDuringAll || (chkCopyToAll?.Checked ?? false))) return;
                if (string.IsNullOrWhiteSpace(txtBaseFolder.Text)) return;

                string allDir = Path.Combine(txtBaseFolder.Text, "All");
                Directory.CreateDirectory(allDir);

                int copied = 0;
                foreach (var file in Directory.EnumerateFiles(sourceDirectory))
                {
                    var name = Path.GetFileName(file);
                    var dest = Path.Combine(allDir, name);
                    File.Copy(file, dest, overwrite: true);
                    copied++;
                }
                if (copied > 0)
                {
                    Log($"Copied {copied} file(s) to '{allDir}'.");
                }
            }
            catch (Exception ex)
            {
                Log($"CopyToAll error: {ex.Message}");
            }
        }
    }
}
