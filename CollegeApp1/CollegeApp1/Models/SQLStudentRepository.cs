namespace CollegeApp1.Models
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly AppDbContext context;

        public SQLStudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        Student IStudentRepository.Add(Student student)
        {
            context.Students.Add(student);  
            context.SaveChanges();
            return student;
        }

        Student IStudentRepository.Delete(int Id)
        {
            Student student = context.Students.Find(Id);
            if(student != null)
            {
                context.Students.Remove(student);
                context.SaveChanges();
            }
            return student;

        }

        IEnumerable<Student> IStudentRepository.GetAllStudents()
        {
            return context.Students;
        }

        Student IStudentRepository.GetStudent(int Id)
        {
            return context.Students.FirstOrDefault(m => m.Id == Id);
        }

        Student IStudentRepository.Update(Student StudentChanges)
        { 
            var student = context.Students.Attach(StudentChanges); //*
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return StudentChanges;
        }

    }
}
