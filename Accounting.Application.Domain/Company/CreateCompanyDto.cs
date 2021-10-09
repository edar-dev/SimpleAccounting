namespace Accounting.Application.Domain.Company
{
    public class CreateCompanyDto
    {
        public CreateCompanyDto(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}