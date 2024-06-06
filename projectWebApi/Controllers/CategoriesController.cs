using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;
using AutoMapper;
using DTOs;

namespace projectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private ICategoryService _categoryService;
        private IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<CategoryDto>>> Get()
        {
            List<Category> categories = await _categoryService.GetAllCategories();
            if(categories == null)
            {
                return NotFound();
            }
            List<CategoryDto> categoriesDto = _mapper.Map<List<Category>, List<CategoryDto>>(categories);
            return Ok(categoriesDto);
        }



        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}


        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
