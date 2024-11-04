using CSharpFunctionalExtensions;
using OneClick.Domain.Domain.DomainModels;

namespace OneClick.Domain.Domain.OneClickProjects.ValueObjects
{
    public class Owner : ValueObject
    {
        public Guid Id { get;  }
        public string? Name { get;  }


        private Owner(Guid OwnerId, string OwnerName)
        {
            this.Id = OwnerId;
            this.Name = OwnerName;
        }
        private Owner() { }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }



        public static Response<Owner> Create(Guid OwnerId, string OwnerName)
        {
            var response = new Response<Owner> { Success = true };

            if (string.IsNullOrEmpty(OwnerName))
            {
                response.Success = false;
            }
            else
            {
                response.Data = new Owner(OwnerId, OwnerName);
            }

            return response;
        }


    }
   
}
