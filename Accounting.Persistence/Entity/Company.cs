namespace Accounting.Persistence.Entity
{
    public class Company : EntityBase
    {
        public Company(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}