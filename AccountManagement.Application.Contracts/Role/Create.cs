namespace AccountManagement.Application.Contracts.Role
{
    public class Create
    {
        public string Name { get; set; }
        public List<int> Permissions { get; set; }
    }


}
