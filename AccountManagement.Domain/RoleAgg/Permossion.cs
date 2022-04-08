namespace AccountManagement.Domain.RoleAgg
{
    public class Permossion
    {


        public long Id { get; set; }
        public int Code { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
        
        public Permossion(int code)
        {
            Code = code;
        }
    }
}
