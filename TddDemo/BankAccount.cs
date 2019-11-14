namespace TddDemo
{
    public class BankAccount
    {
        public BankAccount(int id, string iban)
        {
            Id = id;
            Iban = iban;
        }

        public string Iban { get; private set; }
        public int Id { get; private set; }
    }
}