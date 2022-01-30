// See https://aka.ms/new-console-template for more information
using Demo_LazyCache_ConsoleApp;
using LazyCache;

#region Without Caching
Console.WriteLine("############## WITHOUT CACHING##########");
Console.WriteLine("Start: " + DateTime.Now);
var repo = new StudentRepository();

var listOfStudents = repo.GetAllWithoutCaching();

Console.WriteLine("Finish: " + DateTime.Now);
Console.WriteLine("Numero de estudiantes: " + listOfStudents.Count);
Console.ReadKey();
Console.WriteLine("#########################################");
#endregion

#region With Caching
Console.WriteLine("############## WITH CACHING##########");
var service = new StudentService();

// Get our ComplexObjects from the cache, or build them in the factory func 
// and cache the results for next time under the given key
Console.WriteLine("SE AGREGA A LA CACHE");
Console.WriteLine("Start: " + DateTime.Now);
var cachedResults = service.GetAll();
Console.WriteLine("Finish: " + DateTime.Now);
Console.WriteLine("Numero de estudiantes: " + cachedResults.Count);
Console.WriteLine("");
Console.WriteLine("Nombre del primero: " + cachedResults[0].FirstName);
cachedResults[0].FirstName = "DEBERIA REFLEJARSE EN TODAS LAS LISTAS";
Console.WriteLine("");
Console.WriteLine("SE OBTIENE DE LA CACHE 1ra vez");
var service2 = new StudentService();
Console.WriteLine("Start: " + DateTime.Now);
var cachedResults2 = service2.GetAll();
Console.WriteLine("Finish: " + DateTime.Now);
Console.WriteLine("Numero de estudiantes: " + cachedResults2.Count);
Console.WriteLine("");
Console.WriteLine("Nombre del primero: " + cachedResults2[0].FirstName);


Console.WriteLine("");
Console.WriteLine("SE OBTIENE DE LA CACHE 2da vez");
var service3 = new StudentService();
Console.WriteLine("Start: " + DateTime.Now);
var cachedResults3 = service3.GetAll();
Console.WriteLine("Finish: " + DateTime.Now);
Console.WriteLine("Numero de estudiantes: " + cachedResults3.Count);
Console.WriteLine("");
Console.WriteLine("Nombre del primero: " + cachedResults3[0].FirstName);
Console.WriteLine("#########################################");
#endregion