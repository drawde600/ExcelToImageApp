namespace ExcelToImageApp.Models
{
    public class StaffModel
    {
        public string StaffName { get; set; } = string.Empty;

        public override string ToString()
        {
            return StaffName;
        }
    }
}
