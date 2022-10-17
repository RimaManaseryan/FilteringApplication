using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;
using System.Data.Entity;

namespace FilteringApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        List<User> group = new List<User>()
        {
            new User("Aram", "Gevorgyan", 18, Courses.Css),
            new User("Sveta", "Martirosyan", 21, Courses.JavaScript),
            new User("Gexam", "Vardanyan", 19, Courses.FSharp),
            new User("Vardan", "Gexamyan", 25, Courses.CSharp)
        };
        
        [HttpPost("Filter")]
        public async Task<IActionResult> FilterUsers([FromBody] User testi)
        {
            List<User> FilteredUsers = group;
            if (!String.IsNullOrEmpty(testi.Name))
                FilteredUsers = FilteredUsers.Where(u => u.Name == testi.Name.ToLower()).ToList();
            if (!String.IsNullOrEmpty(testi.LastName))
                FilteredUsers = FilteredUsers.Where(u => u.LastName == testi.LastName.ToLower()).ToList();
            if (testi.Age.HasValue)
                FilteredUsers = FilteredUsers.Where(u => u.Age == testi.Age).ToList();
            if (testi.Course.HasValue)
                FilteredUsers = FilteredUsers.Where(u => u.Course == testi.Course).ToList();
           
            var response = await FilteredUsers.AsQueryable().ToListAsync();
            return Ok(response);
        }
    }
}
