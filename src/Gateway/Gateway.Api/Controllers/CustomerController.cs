using Customer.ApiClient.Api;
using Customer.ApiClient.Model;
using Customer.Messages;
using Microsoft.AspNetCore.Mvc;
using Rebus.Bus;

namespace Gateway.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    public readonly ILogger<CustomerController> _logger;
    private readonly IBus _bus;
    public readonly CustomerApi _apiClient;
    public CustomerController(ILogger<CustomerController> logger, IBus bus, CustomerApi api)
    {
        _logger = logger;
        _bus = bus;
        _apiClient = api;
    }

    [HttpGet(Name = "ListAllCustomers")]
    public async Task<List<CustomerModel>> ListAll()
    {
        return await _apiClient.ListAllCustomersAsync();
    }
    [HttpGet("{id}", Name = "GetCustomerById")]
    public async Task<ActionResult<CustomerModel>> Get(string id)
    {
        return await _apiClient.GetCustomerByIdAsync(id);
    }

    [HttpPost(Name = "CreateNewCustomer")]
    public async Task<ActionResult<Guid>> CreateNew([FromBody]string name)
    {
        if (string.IsNullOrEmpty(name))
            return BadRequest("Name cannot be null or empty");

        var id = Guid.NewGuid();
        var cmd = new CreateNewCustomerCommand(name, id);
        await _bus.Send(cmd);
        return Accepted(id);
    }
}

