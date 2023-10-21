using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmployeeManager:IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult("Eklendi");
        }

        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult("Silindi");
        }

        public IDataResult<Employee> GetById(int emloyeeId)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(s => s.EmployeeId == emloyeeId));

        }

        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(_employeeDal.GetAll(), "Verileri Getirildi");
        }

        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult("Güncellendi");
        }

        public IDataResult<List<EmployeeDetailDto>> GetEmployeeDetails()
        {
            return new SuccessDataResult<List<EmployeeDetailDto>>(_employeeDal.GetEmployeeDetails(),"Employee detaylı bilgileri getirildi.");
        }
    }
}
