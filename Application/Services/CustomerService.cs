using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found");
            }
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> GetCustomerByEmailAsync(string email)
        {
            var customer = await _customerRepository.GetByEmailAsync(email);
            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found");
            }
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> AddCustomerAsync(CustomerDto customerDto)
        {
            var customerEntity = _mapper.Map<Customer>(customerDto);
            customerEntity.CustomerId = Guid.NewGuid();
            var customer = await _customerRepository.AddAsync(customerEntity);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> UpdateCustomerAsync(CustomerDto customerDto)
        {
            var customerEntity = await _customerRepository.GetByIdAsync(customerDto.CustomerId);
            if (customerEntity == null)
            {
                throw new KeyNotFoundException("Customer not found");
            }

            _mapper.Map(customerDto, customerEntity);
            await _customerRepository.UpdateAsync(customerEntity);
            return _mapper.Map<CustomerDto>(customerEntity);
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer == null)
            {
                throw new KeyNotFoundException("Customer not found");
            }

            await _customerRepository.DeleteAsync(id);
        }
    }
}
