namespace ExcelToImageApp.Models
{
    public class StudentModel
    {
        public string StudentName { get; set; } = string.Empty;

        public override string ToString()
        {
            return StudentName;
        }
    }
}
