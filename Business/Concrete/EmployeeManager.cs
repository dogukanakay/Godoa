using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
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
    //[SecuredOperation("admin")]
    public class EmployeeManager:IEmployeeService
    {
        IEmployeeDal _employeeDal;
        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }
        [LogAspect(typeof(FileLogger))]
        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult("Eklendi");
        }
        [LogAspect(typeof(FileLogger))]
        public IResult Delete(Employee employee)
        {
            _employeeDal.Delete(employee);
            return new SuccessResult("Silindi");
        }

        public async Task<IDataResult<Employee>> GetById(int emloyeeId)
        {
            return new SuccessDataResult<Employee>(await _employeeDal.Get(s => s.EmployeeId == emloyeeId));

        }

        public async Task<IDataResult<List<Employee>>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(await _employeeDal.GetAll(), "Verileri Getirildi");
        }
        [LogAspect(typeof(FileLogger))]
        public IResult Update(Employee employee)
        {
            _employeeDal.Update(employee);
            return new SuccessResult("Güncellendi");
        }

        public async Task<IDataResult<List<EmployeeDetailDto>>> GetEmployeeDetails()
        {
            return new SuccessDataResult<List<EmployeeDetailDto>>(await _employeeDal.GetEmployeeDetails(),"Employee detaylı bilgileri getirildi.");
        }
    }
}
