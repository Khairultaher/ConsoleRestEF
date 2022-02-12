using BusyAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Text;

namespace BusyAPI
{
    class Program
    {
        private static AppDbContext _dbContext;
        static async Task Main(string[] args)
        {
            #region DI & Configs
            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(AppConstants.ConnectionString));

            #endregion

            var serviceProvider = services.BuildServiceProvider();
            _dbContext = serviceProvider.GetService<AppDbContext>();

            // load account
            //Account acc = await LoadAccount();

            // load user
            //List<User> users = await LoadUsers();

            // load hours
            //List<HourEntry> hours = await LoadHourEntrys();

            // load projects
            List<Project> hours = await LoadProjects();

            // load tags
            List<Tag> tags = await LoadTags();

            Console.ReadLine();
        }

        private static async Task<Account> LoadAccount()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-API-Key", "cd0c40ce5765bf2103d7537fb75eeef34fd40e6a6e0320dff7a6763c3e43a226");
                //var response = await httpClient.GetStringAsync(new Uri("https://api.demo.busy.no/hourEntries"));
                var response = await httpClient.GetStringAsync(new Uri("https://api.demo.busy.no/accounts/me"));

                Account acc = JsonConvert.DeserializeObject<Account>(response);

                if (acc is not null) {
                   await _dbContext.Accounts.AddAsync(acc);
                   await _dbContext.SaveChangesAsync();
                }
                return acc;
            }
        }
        private static async Task<List<User>> LoadUsers()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add(AppConstants.X_API_KEY, AppConstants.X_API_VALUE);
                var response = await httpClient.GetStringAsync(new Uri($"{AppConstants.ApiBaseUrl}/users"));
                GenericResponse<User> heList = JsonConvert.DeserializeObject<GenericResponse<User>>(response);

                if (heList is not null)
                {
                    await _dbContext.Users.AddRangeAsync(heList.Data);
                    await _dbContext.SaveChangesAsync();
                }
                return heList.Data;
            }
        }

        private static async Task<List<HourEntry>> LoadHourEntrys()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add(AppConstants.X_API_KEY, AppConstants.X_API_VALUE);
                var response = await httpClient.GetStringAsync(new Uri($"{AppConstants.ApiBaseUrl}/hourEntries"));
                GenericResponse<HourEntry> heList = JsonConvert.DeserializeObject<GenericResponse<HourEntry>>(response);


                if (heList is not null)
                {
                    await _dbContext.HourEntrys.AddRangeAsync(heList.Data);
                    await _dbContext.SaveChangesAsync();
                }

                return heList.Data;
            }
        }

        private static async Task<List<Project>> LoadProjects()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add(AppConstants.X_API_KEY, AppConstants.X_API_VALUE);
                var response = await httpClient.GetStringAsync(new Uri($"{AppConstants.ApiBaseUrl}/projects"));
                GenericResponse<Project> heList = JsonConvert.DeserializeObject<GenericResponse<Project>>(response);


                if (heList is not null)
                {
                    await _dbContext.Projects.AddRangeAsync(heList.Data);
                    await _dbContext.SaveChangesAsync();
                }

                return heList.Data;
            }
        }

        private static async Task<List<Tag>> LoadTags()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add(AppConstants.X_API_KEY, AppConstants.X_API_VALUE);
                var response = await httpClient.GetStringAsync(new Uri($"{AppConstants.ApiBaseUrl}/tags"));
                GenericResponse<Tag> heList = JsonConvert.DeserializeObject<GenericResponse<Tag>>(response);


                if (heList is not null)
                {
                    await _dbContext.Tags.AddRangeAsync(heList.Data);
                    await _dbContext.SaveChangesAsync();
                }
                return heList.Data;
            }
        }
    }

    public class GenericResponse<T> where T : class
    {
        public List<T> Data { get; set; }
    }
}
