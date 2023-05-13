using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DemoAzureFunction.Models;
using System.Data.SqlClient;
using System.Data;

namespace DemoAzureFunction
{
    public static class AddCourse
    {
        [FunctionName("AddCourse")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string httpBody = await new StreamReader(req.Body).ReadToEndAsync();
            Course course = JsonConvert.DeserializeObject<Course>(httpBody);

            string _connection_string = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_sqlConnectionString");
            string query = "INSERT INTO Course(CourseID,CourseName,rating) VALUES(@param1,@param2,@param3)";
            SqlConnection _connection = new SqlConnection(_connection_string);
            _connection.Open();

            // Here we create a parameterized query to insert the data into the database
            using (SqlCommand _command = new SqlCommand(query, _connection))
            {
                _command.Parameters.Add("@param1", SqlDbType.Int).Value = course.CourseID;
                _command.Parameters.Add("@param2", SqlDbType.VarChar, 1000).Value = course.CourseName;
                _command.Parameters.Add("@param3", SqlDbType.Decimal).Value = course.Rating;
                _command.CommandType = CommandType.Text;
                _command.ExecuteNonQuery();

            }

            return new OkObjectResult("Course added");
        }
    }
}
