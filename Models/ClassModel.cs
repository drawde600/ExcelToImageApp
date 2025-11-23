namespace ExcelToImageApp.Models
{
    public class ClassModel
    {
        public string ClassName { get; set; } = string.Empty;

        public override string ToString()
        {
            return ClassName;
        }
    }
}
