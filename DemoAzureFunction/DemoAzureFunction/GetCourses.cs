using DemoAzureFunction.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DemoAzureFunction
{
    public static class GetCourses
    {
        [FunctionName("GetCourses")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            List<Course> courses = new List<Course>();

            //string _connection_string = "Server=tcp:alexeiserver.database.windows.net,1433;Initial Catalog=appdb;Persist Security Info=False;User ID=alexeiadmin;Password=Password.1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string _connection_string = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_sqlConnectionString");
            string query = "SELECT CourseID,CourseName,rating from Course";
            SqlConnection _connection = new SqlConnection(_connection_string);
            _connection.Open();

            SqlCommand _sqlcommand = new SqlCommand(query, _connection);
            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course _course = new Course()
                    {
                        CourseID = _reader.GetInt32(0),
                        CourseName = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)
                    };

                    courses.Add(_course);
                }
            }
            _connection.Close();
            return new OkObjectResult(JsonConvert.SerializeObject(courses));
        }
    }
}
