using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
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
            return from e in context.Employees
                   join u in context.Users on e.UserId equals u.UserId
                   join a in context.UserAddresses on u.UserId equals a.UserId

                   select new EmployeeDetailDto
                   {
                       EmployeeId = e.EmployeeId,
                       UserName=u.UserName,
                       NationalityIdentity=e.NationalityIdentity,
                       Address=a.AddressLine +" "+ a.City +" "+a.Country,
                       Status=e.Status,
                       HireDate=e.HireDate
                      
                   };
        }
        public async Task<List<EmployeeDetailDto>> GetEmployeeDetails()
        {
            using (GodoaContext context = new GodoaContext())
            {
                var result = GetEmployeeDetailQuery(context);
                return await result.ToListAsync();

            }
        }
    }
}
