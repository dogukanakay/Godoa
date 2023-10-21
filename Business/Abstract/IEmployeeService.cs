using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
      
            IResult Add(Employee employee);
            IResult Delete(Employee employee);
            IResult Update(Employee employee);

            IDataResult<List<Employee>> GetAll();
            IDataResult<Employee> GetById(int emloyeeId);
            IDataResult<List<EmployeeDetailDto>> GetEmployeeDetails();
       
    }
}
