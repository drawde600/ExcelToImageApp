namespace ExcelToImageApp.Models
{
    public class StudentModel
    {
        public string StudentName { get; set; } = string.Empty;
        public string IndexNo { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;

        public override string ToString()
        {
            // Display as: Name — Index — Class (omit empties)
            var parts = new System.Collections.Generic.List<string>();
            if (!string.IsNullOrWhiteSpace(StudentName)) parts.Add(StudentName);
            if (!string.IsNullOrWhiteSpace(IndexNo)) parts.Add(IndexNo);
            if (!string.IsNullOrWhiteSpace(ClassName)) parts.Add(ClassName);
            return string.Join(" — ", parts);
        }
    }
}
