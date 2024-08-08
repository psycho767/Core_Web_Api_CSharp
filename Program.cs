using API_WebApp.Student_Model;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



List<StudentModel> students = new List<StudentModel>
{
     new StudentModel { Id = 1, Name = "Hitesh", Age = 30, Email = "hitesh@gmail.com", Address = "Noida" },
    new StudentModel { Id = 2, Name = "Gaurav", Age = 40, Email = "gaurav@gmail.com", Address = "Gr.Noida" },
     new StudentModel { Id = 3, Name = "Saurabh", Age = 30, Email = "saurabh@gmail.com", Address = "Bulandsher" },
     new StudentModel { Id = 3, Name = "Rahul", Age = 25, Email = "rahul@gmail.com", Address = "Bihar" }
   
};

//Get All Model Data
app.MapGet("/" ,() => students);

//Get Data By Id
app.MapGet("Data/{id}", (int id) => students.FindAll(students => students.Id == id));

//create new data
app.MapPost("Data",(CreateStudent_Model update_Stu) => {
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
app.MapPut("data/{id}",(UpdateStudent_model update,int id) => {
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

app.MapGet("Hello", () => "Hello World!");

app.Run();
