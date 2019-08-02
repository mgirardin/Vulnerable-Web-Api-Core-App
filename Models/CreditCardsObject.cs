namespace APITest.Models
{
    public class CreditCardObject
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string CreditCardNumber {get; set;}
        public string SecurityNumber { get; set; } //MD5 Insecure
    }
}