using MinimalApiDemo.Data;
using MinimalApiDemo.Models;

namespace MinimalApiDemo
{
    public static class EndPoints 
    {
        public static void MapStudentEndpoints(this WebApplication app)
        {
            app.MapPost("/students", async (Student student, MySqlDbContext dbContext) =>
            {
                dbContext.students.Add(student);
                await dbContext.SaveChangesAsync();
                return Results.Created($"/students/{student.Id}", student);
            });
        }
    }
}
