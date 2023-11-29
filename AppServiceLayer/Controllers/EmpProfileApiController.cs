using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AppServiceLayer.Models;
using BussinessLogicLayer;
using DataAccessLayer;

namespace AppServiceLayer.Controllers
{
    public class EmpProfileApiController : ApiController
    {
        EmpProfileOperations profileOperations = new EmpProfileOperations();
        public void Post(EmpProfileModel empModel)
        {
            EmpProfile emp = new EmpProfile();
            emp.EmpCode = empModel.EmpCode;
            emp.EmpName = empModel.EmpName;
            emp.DateOfBirth = empModel.DateOfBirth;
            emp.Email = empModel.Email;
            emp.DeptCode = empModel.DeptCode;
            profileOperations.insertEmpProfile(emp);

        }

        public List<EmpProfileModel> GetAll()
        {
            List<EmpProfile> list = profileOperations.ListOfEmployee();
            List<EmpProfileModel> empList = new List<EmpProfileModel>();
            foreach (EmpProfile empModel in list)
            {
                EmpProfileModel emp = new EmpProfileModel();
                emp.EmpCode = empModel.EmpCode;
                emp.EmpName = empModel.EmpName;
                emp.DateOfBirth = empModel.DateOfBirth;
                emp.Email = empModel.Email;
                emp.DeptCode = empModel.DeptCode;
                empList.Add(emp);
            }
            return empList;
        }
        public  EmpProfileModel GetById(int empCode)
        {
            EmpProfile empModel = profileOperations.GetEmployeeById(empCode);

            
                EmpProfileModel emp = new EmpProfileModel();
                emp.EmpCode = empModel.EmpCode;
                emp.EmpName = empModel.EmpName;
                emp.DateOfBirth = empModel.DateOfBirth;
                emp.Email = empModel.Email;
                emp.DeptCode = empModel.DeptCode;

                return emp;
           
        }
        public void Put(int empCode, EmpProfileModel empModel)
        {
            EmpProfile emp = profileOperations.GetEmployeeById(empCode);

            
                // Update the employee profile with the new data.
                emp.EmpName = empModel.EmpName;
                emp.DateOfBirth = empModel.DateOfBirth;
                emp.Email = empModel.Email;
                emp.DeptCode = empModel.DeptCode;

                // Save the updated employee profile.
                profileOperations.updateEmpProfile(emp);
            
           
        }
        public void Delete(int empCode)
        {
            EmpProfile emp = profileOperations.GetEmployeeById(empCode);

            
                profileOperations.deleteEmpProfile(empCode);
            
        }


    }
}
