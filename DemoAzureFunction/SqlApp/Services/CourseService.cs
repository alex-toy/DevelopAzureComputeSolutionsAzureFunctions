using SqlApp.Models;
using System.Text.Json;

namespace SqlApp.Services
{
    public class CourseService
    {
        public async Task<IEnumerable<Course>> GetCourses()
        {
            string functionurl = "https://alexeifa.azurewebsites.net/api/GetCourses?code=TpqHA58l-4RUWEY2ZlYCJT5SmajsT0xRXvzSHVq_e7GrAzFuhqgwow==";
            using (HttpClient _client = new HttpClient())
            {
                HttpResponseMessage _response = await _client.GetAsync(functionurl);
                string _content = await _response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<Course>>(_content);
            }
        }
    }
}
