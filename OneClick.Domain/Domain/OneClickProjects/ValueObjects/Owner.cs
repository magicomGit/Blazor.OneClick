using CSharpFunctionalExtensions;
using OneClick.Domain.Domain.DomainModels;

namespace OneClick.Domain.Domain.OneClickProjects.ValueObjects
{
    public class Owner : ValueObject
    {
        public Guid OwnerId { get;  }
        public string? OwnerName { get;  }


        private Owner(Guid OwnerId, string OwnerName)
        {
            this.OwnerId = OwnerId;
            this.OwnerName = OwnerName;
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
