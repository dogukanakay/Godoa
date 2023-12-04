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

            Task<IDataResult<List<Employee>>> GetAll();
            Task<IDataResult<Employee>> GetById(int emloyeeId);
            Task<IDataResult<List<EmployeeDetailDto>>> GetEmployeeDetails();
       
    }
}
