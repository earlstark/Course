using Course.Dtos;
using Course.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/<CoursesController>
        [Authorize(Policy = "AdminOnlyPolicy")]
        [HttpGet]
        public async Task<IEnumerable<CourseDto>> GetAsync()
        {
            return await _courseService.GetAllAsync();
        }

        // GET api/<CoursesController>/5
        [Authorize(Policy = "AdminOnlyPolicy")]
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetAsync(int id)
        {
            var course = await _courseService.GetByIdAsync(id);

            return course == null ? NotFound() : course;
        }

        // POST api/<CoursesController>
        [Authorize(Policy = "AdminOnlyPolicy")]
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CourseDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _courseService.CreateAsync(data);

            return NoContent();
        }

        // PUT api/<CoursesController>/5
        [Authorize(Policy = "AdminOnlyPolicy")]
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] CourseDto data)
        {
            var course = await _courseService.UpdateAsync(id, data);

            return course == null ? NotFound() : NoContent();
        }

        // DELETE api/<CoursesController>/5
        [Authorize(Policy = "AdminOnlyPolicy")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var response = await _courseService.DeleteAsync(id);

            return response ? NoContent() : NotFound();
        }

    }
}
