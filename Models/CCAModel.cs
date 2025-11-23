namespace ExcelToImageApp.Models
{
    public class CCAModel
    {
        public string CCAName { get; set; } = string.Empty;

        public override string ToString()
        {
            return CCAName;
        }
    }
}
