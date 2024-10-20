using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using backend_final_proj.Input;

namespace backend_final_proj.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        private IConfiguration _configuration;
        public TodoController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost("delete_tasks")]
        public JsonResult delete_tasks([FromForm] DELETE_Input_Format delete_input)
        {
            //string query = "select * from dbo.all_tasks";

            string query = "delete from dbo.all_tasks" +
                " where manager=@manager " +
                "and manager_email=@manager_email " +
                "and task_user=@task_user " +
                "and task_title=@task_title " +
                "and task_description=@task_description;";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            SqlDataReader myReader;
            using (SqlConnection conn = new SqlConnection(SqlDataSource))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@manager", delete_input.Manager);
                    cmd.Parameters.AddWithValue("@manager_email", delete_input.Manager_email);
                    cmd.Parameters.AddWithValue("@task_user", delete_input.Task_user);
                    cmd.Parameters.AddWithValue("@task_title", delete_input.Task_title);
                    cmd.Parameters.AddWithValue("@task_description", delete_input.Task_description);
                    //Console.WriteLine( cmd.ToString());
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                }

            }
            return new JsonResult("Deleted Successfully!");
        }

        [HttpPost("add_tasks")]
        public JsonResult add_tasks([FromForm] GET_Input_Format get_input)
        {
            //string query = "select * from dbo.all_tasks";

            string query = "insert into dbo.all_tasks (manager,manager_email,task_user,task_title,task_description,time_created,due_date) " +
                "values (@manager," +
                "@manager_email," +
                "@task_user," +
                "@task_title," +
                "@task_description," +
                "@time_created," +
                "@due_date);";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            SqlDataReader myReader;
            using (SqlConnection conn = new SqlConnection(SqlDataSource))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@manager", get_input.Manager);
                    cmd.Parameters.AddWithValue("@manager_email", get_input.Manager_email);
                    cmd.Parameters.AddWithValue("@task_user", get_input.Task_user);
                    cmd.Parameters.AddWithValue("@task_title", get_input.Task_title);
                    cmd.Parameters.AddWithValue("@task_description", get_input.Task_description);
                    cmd.Parameters.AddWithValue("@time_created", get_input.Time_created);
                    cmd.Parameters.AddWithValue("@due_date", get_input.Due_date);

                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                }
                
            }
            return new JsonResult("Added Successfully!");
        }

        [HttpGet("get_tasks")]
        public JsonResult get_tasks()
        {
            string query = "select * from dbo.all_tasks";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            SqlDataReader myReader;
            using (SqlConnection conn = new SqlConnection(SqlDataSource))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                }

            }
            return new JsonResult(table);
        }

        [HttpGet("get_dist_users")]
        public JsonResult get_dist_users()
        {
            string query = "select DISTINCT task_user from dbo.all_tasks";
            DataTable table = new DataTable();
            string SqlDataSource = _configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            SqlDataReader myReader;
            using (SqlConnection conn = new SqlConnection(SqlDataSource))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                }

            }
            return new JsonResult(table);
        }



    }
}
