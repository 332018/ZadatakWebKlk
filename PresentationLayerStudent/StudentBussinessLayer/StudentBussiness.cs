using StudentDataLayer;
using StudentDataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentBussinessLayer
{
    
    public class StudentBussiness
    {
        private readonly StudentRepository studentRepository;

        public StudentBussiness()
        {
            this.studentRepository = new StudentRepository();
        }

        public List<Student> GetAllStudents()
        {
            return this.studentRepository.GetAllStudents();
        }

        public bool InsertStudent(Student s)
        {
            if(this.studentRepository.InsertStudent(s) > 0)
            {
                return true;
            }
            return false;
        }

        public List<Student> GetStudents(decimal pr)
        {
            return this.studentRepository.GetAllStudents().Where(s => s.Ocena > pr).ToList();
        }
    }
}
