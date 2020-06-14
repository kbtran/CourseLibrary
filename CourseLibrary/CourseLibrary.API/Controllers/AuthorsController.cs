using AutoMapper;
using CourseLibrary.API.Helpers;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CourseLibrary.API.Controllers
{
    // Could have use : Controller, but since this is an API, dont need to support View

    [ApiController]
    [Route("api/authors")]
    // or [Route("api/controller")]
    public class AuthorsController : ControllerBase
    {
        private readonly ICourseLibraryRepository _courseLibraryRepository;
        private readonly IMapper _mapper;

        public AuthorsController(ICourseLibraryRepository courseLibraryRepository,
            IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository ??
                throw new ArgumentNullException(nameof(courseLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        //[HttpGet()]
        //[HttpHead]
        //public ActionResult<IEnumerable<AuthorDto>> GetAuthors()
        //{
        //    //var authors = new List<AuthorDto>();

        //    //foreach(var author in authorsFromRepo)
        //    //{
        //    //    authors.Add(new AuthorDto()
        //    //    {
        //    //        Id = author.Id,
        //    //        Name = $"{author.FirstName}  {author.LastName}",
        //    //        MainCategory = author.MainCategory,
        //    //        Age = author.DateOfBirth.GetCurrentAge()
        //    //    });
        //    //}

        //    //return new JsonResult(authorsFromRepo);
        //    //return Ok(authors);

        //    var authorsFromRepo = _courseLibraryRepository.GetAuthors();
        //    return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        //}

        [HttpGet()]
        public ActionResult<IEnumerable<AuthorDto>> GetAuthors(
           [FromQuery] string mainCategory)
        {
            var authorsFromRepo = _courseLibraryRepository.GetAuthors(mainCategory);
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo));
        }

        [HttpGet("{authorId}")]
        public IActionResult GetAuthor(Guid authorId)
        {
            var authorFromRepo = _courseLibraryRepository.GetAuthor(authorId);

            if (authorFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AuthorDto>(authorFromRepo));
        }
    }
}