using API_WebApp.Student_Model;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var group = app.MapGroup("Data");

List<StudentModel> students = new List<StudentModel>
{
     new StudentModel { Id = 1, Name = "Hitesh", Age = 30, Email = "hitesh@gmail.com", Address = "Noida" },
    new StudentModel { Id = 2, Name = "Gaurav", Age = 40, Email = "gaurav@gmail.com", Address = "Gr.Noida" },
     new StudentModel { Id = 3, Name = "Saurabh", Age = 30, Email = "saurabh@gmail.com", Address = "Bulandsher" },
     new StudentModel { Id = 3, Name = "Rahul", Age = 25, Email = "rahul@gmail.com", Address = "Bihar" }
   
};

//Get All Model Data
group.MapGet("/" ,() => students);

//Get Data By Id
group.MapGet("/{id}", (int id) => students.FindAll(students => students.Id == id));

//create new data
group.MapPost("/",(CreateStudent_Model update_Stu) => {
    StudentModel stud = new StudentModel
    { 
        Id = students.Count+1,
        Name = update_Stu.Name,
        Age = update_Stu.Age,
        Email = update_Stu.Email,
        Address = update_Stu.Address
    };
    students.Add(stud);

});

//update data in model
group.MapPut("/{id}",(UpdateStudent_model update,int id) => {
    var index = students.FindIndex(students => students.Id == id);
    students[index] = new StudentModel
    {
        Id = id,
        Name = update.Name,
        Age = update.Age,
        Email = update.Email,
        Address = update.Address
    };
});

//delete data from model
group.MapDelete("/{id}",(int id) =>
{
    students.RemoveAll(students => students.Id == id);
});

app.MapGet("Hello", () => "Hello World!");

app.Run();
