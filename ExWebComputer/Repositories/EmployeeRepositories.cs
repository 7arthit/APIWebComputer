﻿using ExWebComputer.Data;
using ExWebComputer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace ExWebComputer.Repositories
{
    public class EmployeeRepositories : IEmployeeRepositories
    {
        private readonly AppDbcontext _context;

        public EmployeeRepositories(AppDbcontext context)
        {
            _context = context;
        }

        //---------- ค้นหา พนักงาน ----------//

        public IEnumerable<Employee> GetAll(string? search, int? page, int? per_page)
        {
            int pageNumber = page ?? 1;
            int limit = per_page ?? 10;
            return _context.Employees
                .Where(p => search == null || p.Name.Contains(search))
                .Skip((pageNumber - 1) * limit).Take(limit);
        }

        //---------- ค้นหา พนักงาน ด้วย id ----------//

        public Employee? GetById(int id)
        {
            return _context.Employees.FirstOrDefault(p => p.Id == id);
        }

        //---------- เพิ่ม พนักงาน ----------//

        public Employee Create(Employee employee)
        {
            EntityEntry<Employee> result = _context.Employees.Add(employee);
            _context.SaveChanges();
            return result.Entity;
        }

        //---------- แก้ไข พนักงาน ----------//

        public Employee? Update(Employee employee)
        {
            Employee? result = _context.Employees.FirstOrDefault(p => p.Id == employee.Id);
            if (result != null)
            {
                result.Id = employee.Id;
                result.Name = employee.Name;
                result.UserName = employee.UserName;
                result.Password = employee.Password;
                result.Image = employee.Image;
                result.Role = employee.Role;
                _context.SaveChanges();
            }
            return result;
        }

        //---------- ลบ พนักงาน ----------//

        public Employee? Delete(int id)
        {
            Employee? result = _context.Employees.FirstOrDefault(p => p.Id == id);
            if (result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
            return result;
        }
    }
}
