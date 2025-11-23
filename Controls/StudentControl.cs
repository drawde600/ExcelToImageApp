using ExcelToImageApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ExcelToImageApp.Controls
{
    public partial class StudentControl : UserControl
    {
        private List<StudentModel> _students = new List<StudentModel>();

        public event EventHandler GenerateRequested;

        public StudentControl()
        {
            InitializeComponent();
        }

        public void LoadData(List<StudentModel> students, string baseFolder)
        {
            _students = students ?? new List<StudentModel>();
            
            clbStudents.Items.Clear();
            foreach (var student in _students)
            {
                clbStudents.Items.Add(student, true);
            }

            if (string.IsNullOrEmpty(txtOutputFolder.Text) && !string.IsNullOrEmpty(baseFolder))
            {
                txtOutputFolder.Text = Path.Combine(baseFolder, "Student");
            }

            UpdateSummary();
        }

        public List<StudentModel> GetSelectedStudents()
        {
            return clbStudents.CheckedItems.Cast<StudentModel>().ToList();
        }

        public string OutputFolder => txtOutputFolder.Text;
        public int TotalCount => clbStudents.Items.Count;
        public int SelectedCount => clbStudents.CheckedItems.Count;

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
            for (int i = 0; i < clbStudents.Items.Count; i++)
            {
                clbStudents.SetItemChecked(i, state);
            }
            UpdateSummary();
        }

        private void ClbStudents_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() => UpdateSummary()));
        }

        private void UpdateSummary()
        {
            lblSummary.Text = $"Total: {TotalCount}, Selected: {SelectedCount}";
        }
    }
}
