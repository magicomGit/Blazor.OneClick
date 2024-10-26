using CSharpFunctionalExtensions;

namespace OneClick.Domain.Domain.OneClickProjects.ValueObjects
{
    public class Language : ValueObject
    {
        public string Code { get; }
        public string Name { get; }


        private Language(string Code, string Name)
        {
            this.Code = Code;
            this.Name = Name;
        }
        private Language() { }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }

        public static Result<Language, string> Create(string Code, string Name)
        {
            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Name))
            {
                return "Значения не заданы";
            }

            return new Language(Code, Name);
        }
    }
}
