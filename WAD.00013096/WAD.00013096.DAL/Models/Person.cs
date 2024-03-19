namespace WAD._00013096.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public ICollection<Estate> Estates { get; set; }
    }
}
