using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Models;
using Common.Models.DTO;
using Common.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [Route("customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private IRepository<Customer> _repository;
        private IMapper _mapper;

        public CustomersController(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{customerId:guid}", Name = "CustomerById")]
        public async Task<IActionResult> GetById(Guid customerId)
        {
            var result = await _repository.GetByIdAsync(customerId);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerCreationDto customerCreationDto)
        {
            var customer = _mapper.Map<Customer>(customerCreationDto);
            await _repository.CreateAsync(customer);
            
            return CreatedAtRoute("CustomerById", new { customerId = customer.Id },
                            customer.Id);

            
        }
    }
}