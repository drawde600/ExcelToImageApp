namespace ExcelToImageApp.Models
{
    public class StaffModel
    {
        public string StaffName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(Position))
            {
                return $"{StaffName} — {Position}";
            }
            return StaffName;
        }
    }
}
