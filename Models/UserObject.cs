namespace APITest.Models
{
    public class UserObject
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Salary {get; set;}
        public string Password {get; set;} //MD5 Insecure
    }
}
