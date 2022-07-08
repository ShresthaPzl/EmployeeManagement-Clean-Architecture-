using Application.Commands;
using Application.Mappers;
using Application.Responses;
using Core.Entities;
using Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
    {
        private readonly IEmployeeRepository _iEmployeeRepository;
        public CreateEmployeeHandler(IEmployeeRepository iEmployeeRepository)
        {
            _iEmployeeRepository = iEmployeeRepository;
        }

        public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employeeEntity = EmployeeMapper.Mapper.Map<Employee>(request);
            if(employeeEntity is null)
            {
                throw new ApplicationException("Issues with mapper!");
            }
            var newEmployee = await _iEmployeeRepository.AddAsync(employeeEntity);
            var employeeResponse = EmployeeMapper.Mapper.Map<EmployeeResponse>(newEmployee);
            return employeeResponse;
        }
    }
}
