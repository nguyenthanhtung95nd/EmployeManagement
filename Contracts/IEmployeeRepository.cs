using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges = false);
        Employee GetEmployee(Guid companyId, Guid id, bool trackChanges = false);
    }
}