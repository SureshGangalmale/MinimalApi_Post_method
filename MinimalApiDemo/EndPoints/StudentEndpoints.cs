using MinimalApiDemo.Models;
using MinimalApiDemo.Repositories;

namespace MinimalApiDemo.EndPoints
{
    public static class StudentEndpoints
    {
        public static void MapStudentEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/student", (Student student, StudentRepository repo) =>
            {
                repo.Insert(student);
                return Results.Ok("Student Added successfully");
            });
        }
    }
}
