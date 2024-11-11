using backend_final_proj.Input;
using backend_final_proj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace backend_final_proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Fat Controller
    //Better practice would be to have a service and controller will just forward request to service
    public class EF_AllTasksController : ControllerBase
    {
        //Injecting Database Context into Controller
        private readonly TaskmanagementDbContext _context;
        //Contructor
        public EF_AllTasksController(TaskmanagementDbContext context)
        {
            _context = context;
        }


        //Inject End


        [HttpGet("get_tasks")]
        public async Task <ActionResult<List<AllTask>>> GetAllTasks()
        {


            List<AllTask> blogs = await _context.AllTasks
    .FromSql($"SELECT * FROM dbo.all_tasks")
    .ToListAsync();

            //return Ok(tasks);
            return blogs;

        }
        public class TaskUser
        {
            public string? task_user { get; set; }
            
        }

        [HttpGet("get_distinct_users")]
        public async Task<ActionResult<List<TaskUser?>>> GetAllDistinctUsers()
        {

            List<string?> result = await _context.AllTasks.Select(m => m.TaskUser).Distinct().ToListAsync();
            List<TaskUser> user_list =new List<TaskUser>();
            foreach (string res in result)
            {
                TaskUser temp_obj = new TaskUser { task_user = res };
                user_list.Add(temp_obj);

            }
            

            //return Ok(tasks);
            return user_list;

        }


        [HttpPost("add_tasks")]
        public async Task<ActionResult<List<AllTask>>> AddTasks([FromForm] AllTask get_input)
        //public async Task<String> AddTasks([FromForm] AllTask get_input)
        {
            //string query = "select * from dbo.all_tasks";
            _context.AllTasks.Add(get_input);
            await _context.SaveChangesAsync();
            return Ok(await GetAllTasks());



        }

        [HttpPost("delete_tasks")]
        //public JsonResult delete_tasks([FromForm] DELETE_Input_Format delete_input)
        public async Task<ActionResult<List<AllTask>>> DeleteTasks([FromForm] DELETE_Input_Format delete_input)
        {

            _context.AllTasks.Where(c=>c.Manager == delete_input.Manager
                        && c.ManagerEmail == delete_input.Manager_email
                        && c.TaskUser == delete_input.Task_user
                        && c.TaskTitle == delete_input.Task_title
                        && c.TaskDescription == delete_input.Task_description).ExecuteDelete();
            await _context.SaveChangesAsync();
            return Ok(await GetAllTasks());

        }


    }
}
