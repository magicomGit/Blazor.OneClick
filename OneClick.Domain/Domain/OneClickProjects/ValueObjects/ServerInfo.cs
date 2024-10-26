using CSharpFunctionalExtensions;
using OneClick.Domain.Domain.DomainModels;

namespace OneClick.Domain.Domain.OneClickProjects.ValueObjects
{
    public class ServerInfo : ValueObject
    {
        public string ServerIP { get; }
        public string ServerName { get;  }
        public int ServerId { get;}


        private ServerInfo(string ServerIP, string ServerName, int ServerId)
        {
            this.ServerIP = ServerIP;
            this.ServerName = ServerName;
            this.ServerId = ServerId;
        }
        private ServerInfo() { }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }



        public static Response<ServerInfo> Create(string ServerIP, string ServerName, int ServerId)
        {
            var response = new Response<ServerInfo> { Success = true };

            if (string.IsNullOrEmpty(ServerIP) || string.IsNullOrEmpty(ServerName) || ServerId < 1)
            {
                response.Success = false;
                response.Message = "Не заполнены все поля!";
            }
            else
            {
                response.Data = new ServerInfo(ServerIP,  ServerName,  ServerId);
            }

            return response;
        }


    }
   
}
