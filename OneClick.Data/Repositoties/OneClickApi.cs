using Newtonsoft.Json;
using OneClick.Data.Data;
using OneClick.Domain.Domain.DomainModels;
using OneClick.Domain.Enums.Project;
using OneClick.Services.Contracts;
using OneClick.UseCases.Intefaces.OneClickProjects;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;


namespace OneClick.Data.Repositoties
{
    public class OneClickApi : IOneClickApi<Response<object>>
    {
        public async Task<Response<object>> ChangeState(string serverIp, string projectName, ProjectState newState)
        {
            var response = new Response<object> { Success = true };

            var authResponse = await AuthenticateServerAsync(serverIp);
            if (authResponse.Success)
            {
                try
                {
                    HttpResponseMessage res = await authResponse.Data.PostAsJsonAsync("api/Project/ChangeState", new { ProjectName = projectName, ProjectNewState = newState });
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        var responceString = await res.Content.ReadAsStringAsync();
                        var projectResponse = JsonConvert.DeserializeObject<Response<object>>(responceString);
                        if (projectResponse == null || !projectResponse.Success)
                        {
                            response.Success = false;
                            response.Message = "ChangeState Error";
                        }
                    }

                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = ex.Message;
                }
            }

            return response;
        }

        public async Task<Response<object>> GetProjectAsync(string serverIp, string projectName)
        {
            var response = new Response<object> { Success = true };

            var authResponse = await AuthenticateServerAsync(serverIp);
            if (authResponse.Success)
            {
                try
                {
                    HttpResponseMessage res = await authResponse.Data.GetAsync("api/Project/GetById?name=" + projectName);
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        var responceString = await res.Content.ReadAsStringAsync();
                        var projectResponse = JsonConvert.DeserializeObject<Project>(responceString);

                        if (projectResponse != null) { response.Data = projectResponse; }
                    }


                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = ex.Message;
                }
            }


            return response;
        }

        public async Task<Response<object>> GetProjectsAsync(string serverIp)
        {
            var response = new Response<object> { Success = true };

            var authResponse = await AuthenticateServerAsync(serverIp);
            if (authResponse.Success)
            {
                try
                {
                    HttpResponseMessage res = await authResponse.Data.GetAsync("api/Project/Get");
                    if (res.StatusCode == HttpStatusCode.OK)
                    {
                        var responceString = await res.Content.ReadAsStringAsync();
                        var projectResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Project>>(responceString);
                        if (projectResponse != null)
                        {
                            response.Data = projectResponse;
                        }
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = res.StatusCode.ToString();
                    }
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = ex.Message;
                }


            }

            return response;
        }

        //----------------------- private methods ------------------
        private async Task<Response<HttpClient>> AuthenticateServerAsync(string serverIp)
        {
            var response = new Response<HttpClient> { Success = true };



            var client = new HttpClient();
            client.BaseAddress = new Uri("http://" + serverIp + ":" + DataSettings.OneClickApiPort + "/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage httpResponse = await client.PostAsJsonAsync("Login?useCookies=false",
                                           new { Email = DataSettings.OneClickServerLogin, Password = DataSettings.OneClickServerPass });

                var responceString = await httpResponse.Content.ReadAsStringAsync();
                var loginResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponse>(responceString);

                if (httpResponse.StatusCode == HttpStatusCode.OK)
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResponse.AccessToken);
                    response.Data = client;
                }
                else
                {
                    response.Success = false;
                    response.Message = httpResponse.StatusCode.ToString();
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }


            return response;
        }
    }
}
