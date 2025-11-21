using MinimalApiDemo.Data;
using MinimalApiDemo.Models;

namespace MinimalApiDemo.Repositories
{
    public class StudentRepository
    {
        private readonly MySqlDbContext _dbContext;

        public StudentRepository(MySqlDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Insert(Student student)
        {
            using var conn = _dbContext.GetConnection();
            using var cmd = _dbContext.CreateCommand("InsertStudent", conn);
            cmd.Parameters.AddWithValue("p_name", student.Name);
            cmd.Parameters.AddWithValue("p_age", student.Age);
            cmd.ExecuteNonQuery();
        }
    }
}
