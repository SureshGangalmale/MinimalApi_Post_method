using MinimalApiDemo.Data;
using MinimalApiDemo.Models;
using MinimalApiDemo.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("MySqlConn");

var dbContext = new MySqlDbContext(connectionString);
var studentRepo = new StudentRepository(dbContext);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*List<Student> students = new List<Student>();
app.MapGet("/student", () =>
{
    return students;
});

app.MapPost("/student", (Student student) =>
{
    students.Add(student);
    return "Success";
});

app.MapPut("/student/{id}", (int id, Student student) =>
{
    var stud = students.FindIndex(s => s.Id == id);
    if (stud < 0)
    {
        return Results.NotFound();
    }
    students[stud] = student;
    return Results.Ok("Student updated success...");
});

app.MapDelete("/student/{id}",(int id)=>
{
    var stud = students.FirstOrDefault(s => s.Id == id);
    if (stud == null)
    {
        return Results.NotFound();
    }
    students.Remove(stud);
    return Results.Ok("Student deleted success...");
});*/

app.MapPost("/student", (Student student) =>
{
    studentRepo.Insert(student);
    return Results.Ok("Student inserted successfully");
});

app.Run();


