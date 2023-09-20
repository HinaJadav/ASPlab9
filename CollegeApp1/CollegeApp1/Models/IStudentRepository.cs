namespace CollegeApp1.Models
{
    public interface IStudentRepository
    {

        Student GetStudent(int Id);
        IEnumerable<Student> GetAllStudents();
        Student Add(Student Student);
        Student Update(Student StudentChanges);
        Student Delete(int Id);
    }
}
