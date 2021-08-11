using Microsoft.AspNetCore.Mvc;
using Backoffice.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Backoffice.Data;
using Microsoft.AspNetCore.Authorization;
using System;

[Route("categories")]
public class CategoryController : ControllerBase
{
    // https://localhost:5001/categories

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Category>>> Get()
    {
        return new List<Category>();
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Category>> GetById()
    {
        return new Category();
    }

    [HttpPost]
    [Route("")]
    // [Authorize(Roles = "employee")]
    [AllowAnonymous]
    public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody] Category model)
    {
        // Verifica se os dados são válidos
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            context.Categories.Add(model);
            await context.SaveChangesAsync();
            return model;
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Não foi possível criar a categoria" });

        }
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Category>>> Put(int id, [FromBody] Category model)
    {
        // Verifica se o ID informado é o mesmo do modelo
        if (id != model.Id)
            return NotFound(new { message = "Categoria não encontrada" });

        // Verifica se os dados são válidos
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return NotFound();

    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<List<Category>>> Delete()
    {
        return Ok();
    }

}