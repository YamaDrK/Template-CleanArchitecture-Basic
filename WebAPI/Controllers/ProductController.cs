using Application.DTOs.Products;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Abstractions;

namespace WebAPI.Controllers
{
    public class ProductController(IProductService _productService) : CrudController<UpsertProductDTO, UpsertProductDTO>
    {
        public override async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }

        public override async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }

        public override async Task<IActionResult> Create([FromBody] UpsertProductDTO createDTO)
        {
            return Ok(await _productService.CreateAsync(createDTO));
        }

        public override async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _productService.DeleteAsync(id);
            return Ok("Delete successfully");
        }

        public override async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpsertProductDTO updateDTO)
        {
            return Ok(await _productService.UpdateAsync(id, updateDTO));
        }
    }
}
