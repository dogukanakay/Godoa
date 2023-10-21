using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfEmployeeDal : EfEntityRepositoryBase<Employee, GodoaContext>, IEmployeeDal
    {
        private IQueryable<EmployeeDetailDto> GetEmployeeDetailQuery(GodoaContext context)
        {
            return from g in context.Employees
                   join or in context.Users on g.UserId equals or.UserId

                   select new EmployeeDetailDto
                   {
                       EmployeeId = g.EmployeeId,
                       UserName=or.UserName,
                       NationalityIdentity=g.NationalityIdentity,
                       Address=g.Adress,
                       Status=g.Status,
                       HireDate=g.HireDate
                      
                   };
        }
        public List<EmployeeDetailDto> GetEmployeeDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetEmployeeDetailQuery(context).ToList();
                return result.ToList();

            }
        }
    }
}
