using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLogicLayer
{
    public class EmpProfileOperations
    {
        EmpProfileRepository empProfileRepository = new EmpProfileRepository(new EmsContext());

        public void insertEmpProfile(EmpProfile empProfile)
        {
            empProfileRepository.Insert(empProfile);

        }

        public List<EmpProfile> ListOfEmployee()
        {
            return empProfileRepository.GetAll().ToList();

        }
        public EmpProfile GetEmployeeById(int empCode)
        {
            return empProfileRepository.GetByCode(empCode); // Assuming you have a method named Get in your repository to retrieve an employee by ID.
        }

        public void updateEmpProfile(EmpProfile empProfile)
        {
            empProfileRepository.Update(empProfile); // Assuming you have an Update method in your repository to update an employee profile.
        }
        public void deleteEmpProfile(int empCode)
        {
            empProfileRepository.Delete(empCode); // Assuming you have a Delete method in your repository to delete an employee profile.
        }


    }
}
