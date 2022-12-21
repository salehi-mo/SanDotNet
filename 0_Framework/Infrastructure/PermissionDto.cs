namespace _0_Framework.Infrastructure
{
    public class PermissionDto
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string PersianName { get; set; }

        public PermissionDto(int code, string name,string persianName)
        {
            Code = code;
            Name = name;
            PersianName = persianName;
        }
    }
}