using Customer.Domain.Interfaces;
using Customer.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IFetchCustomers repo;

    public CustomerController(IFetchCustomers repo)
    {
        this.repo = repo;
    }

    [HttpGet]
    [Route("/")]
    public async Task<IEnumerable<CustomerModel>> List()
    {
        return await repo.FetchAllAsync();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<CustomerModel>> Get(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            return BadRequest("Guid was incorrect format");

        var result = await repo.FetchAsync(guid);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

}

