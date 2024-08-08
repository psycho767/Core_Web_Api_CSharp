using API_WebApp;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//List<StudentModel> student = new List<StudentModel>
//{
//    new StudentModel{id:1,Name:"Hitesh",Age:20,email:"hitesh@gmail.com",address:"noida" }
//}

List<StudentModel> students = new List<StudentModel>
{
     new StudentModel { Id = 1, Name = "Hitesh", Age = 30, Email = "hitesh@gmail.com", Address = "Noida" },
    new StudentModel { Id = 2, Name = "Gaurav", Age = 40, Email = "gaurav@gmail.com", Address = "Gr.Noida" },
     new StudentModel { Id = 3, Name = "Saurabh", Age = 30, Email = "saurabh@gmail.com", Address = "Bulandsher" },
     new StudentModel { Id = 3, Name = "Rahul", Age = 25, Email = "rahul@gmail.com", Address = "Bihar" }
   
};



app.MapGet("/", () => "Hello World!");

app.Run();
