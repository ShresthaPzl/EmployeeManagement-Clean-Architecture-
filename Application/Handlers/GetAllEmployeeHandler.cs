using Application.Queries;
using Core.Entities;
using Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Handlers
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, List<Employee>>
    {
        private readonly IEmployeeRepository _iEmployeeRepository;
        public GetAllEmployeeHandler(IEmployeeRepository iEmployeeRepository)
        {
            _iEmployeeRepository = iEmployeeRepository; 
        }

        public async Task<List<Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            return (List<Employee>)await _iEmployeeRepository.GetAllAsync();
        }
    }
}
