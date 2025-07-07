using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using OnlinePharmacy.Application.Common.DTOs;
using OnlinePharmacy.Domain.Entities;
using OnlinePharmacy.Domain.Interfaces;

namespace OnlinePharmacy.WebAPI.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericService<Category, CreateCategoryDTO, CategoryDTO, Guid> _categoryService;

        public CategoryController(IGenericService<Category, CreateCategoryDTO, CategoryDTO, Guid> categoryService)
        {
            _categoryService = categoryService;
        }

        // list all categories for home page
        [HttpGet("Home")]
        public async Task<IActionResult> GetCategoriesHome(int pageNumber = 1, int pageSize = 10, string orderBy = "Order", string orderDirection = "asc", Guid? parentId = null, string? searchableLetters = null)
        {
            Expression<Func<Category, bool>> filter = c =>
            (searchableLetters == null || c.Name_En.Contains(searchableLetters)
            || c.Name_Ar.Contains(searchableLetters))
            && (parentId == null || c.ParentId == parentId);

            var result = await _categoryService.GetByFilterAsync(filter, pageNumber, pageSize, orderBy, orderDirection, default);

            if (result.IsSuccess) 
                return Ok(result.Value);
            return BadRequest(result.Errors);
        }


        //CDUR operations for categories
    }
}
