using Application.Dtos;
using Application.Dtos.UserDto;
using Application.IServices.AdminServices.UserService.Commands;
using ConsoleApp1.Models;
using Domin.IRepositories.IseparationRepository.SqlServer;

namespace Application.Services.AdminServices.UserServices.AllUserService
{
    public class AddUserIdToCustomerForRegisterService : IAddUserIdToCustomerForRegisterService
    {
        private readonly ICustomerRepository _customerRepository;

        public AddUserIdToCustomerForRegisterService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GeneralDto> Execute(CustomerDto customerDto)
        {
            if (customerDto.Id == null || customerDto.Id == 0)
            {
                return new GeneralDto
                {
                    message = "کاربر هنگام ثبت نام با خطا مواجه شده است"
                };
            }

            var customer = new Customer
            {
                Id = customerDto.Id
            };
         await   _customerRepository.AddAsync(customer);
            return new GeneralDto
            {
                message = $"برای کاربر{customerDto.Id} پنل مشتری ایجاد شد"
            };
        }

    }
}
