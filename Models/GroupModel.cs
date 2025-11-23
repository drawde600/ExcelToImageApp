namespace ExcelToImageApp.Models
{
    public class GroupModel
    {
        public string GroupName { get; set; } = string.Empty;

        public override string ToString()
        {
            return GroupName;
        }
    }
}
