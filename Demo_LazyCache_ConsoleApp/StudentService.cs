using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LazyCache_ConsoleApp
{
    public class StudentService
    {
        private readonly StudentRepository studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public StudentService()
        {
            this.studentRepository = new();
        }
        public List<Student> GetAll()
        {
            return studentRepository.GetAll();
        }
    }
}
