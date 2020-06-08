using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CourseLibrary.API.Controllers
{
    // Could have use : Controller, but since this is an API, dont need to support View

    [ApiController]
    [Route("api/authors")]
    // or [Route("api/controller")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibrayRepository;
        
        public AuthorsController(ICourseLibraryRepository courseLibrayRepository)
        {
            _courseLibrayRepository = courseLibrayRepository ??
                throw new ArgumentNullException(nameof(courseLibrayRepository));
        }

        [HttpGet()]
        public IActionResult GetAuthors()
        {
            var authorsFromRepo = _courseLibrayRepository.GetAuthors();

            return new JsonResult(authorsFromRepo);
        }
    }
}