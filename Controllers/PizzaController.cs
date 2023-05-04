using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
        => PizzaService.GetAll();

    [HttpGet("{pId}")]
    public ActionResult<Pizza> Get(int pId)
    {
        var pizza = PizzaService.Get(pId);

        if(pizza == null)
            return NotFound();

        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pPizza)
    {
        PizzaService.Add(pPizza);
        return CreatedAtAction(nameof(Get), new { pId = pPizza.Id }, pPizza);
    }

    [HttpPut("{pId}")]
    public IActionResult Update(int pId, Pizza pPizza)
    {
        if(pId != pPizza.Id)
            return BadRequest();
        
        var existingPizza = PizzaService.Get(pId);
        if(existingPizza is null)
            return NotFound();
        
        PizzaService.Update(pPizza);
        return NoContent();
    }

    [HttpDelete("{pId}")]
    public IActionResult Delete(int pId)
    {
        var pizza = PizzaService.Get(pId);

        if(pizza is null)
            return NotFound();

        PizzaService.Delete(pId);
        
        return NoContent();
    }
}