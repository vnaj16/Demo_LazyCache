using GenFu;
using LazyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LazyCache_ConsoleApp
{
    public class StudentRepository
    {
        List<Student> listToReturn = new();
        public StudentRepository()
        {
            //https://github.com/MisterJames/GenFu
            listToReturn = A.ListOf<Student>(500);
        }

        public List<Student> GetAll()
        {
            // Create our cache service using the defaults (Dependency injection ready).
         // By default it uses a single shared cache under the hood so cache is shared out of the box (but you can configure this)
         //https://github.com/alastairtree/LazyCache 
            IAppCache cache = new CachingService();

            // Declare (but don't execute) a func/delegate whose result we want to cache
            Func<List<Student>> complexObjectFactory = () => GetAllWithoutCaching();

            // Get our ComplexObjects from the cache, or build them in the factory func 
            // and cache the results for next time under the given key
            return cache.GetOrAdd("Students", complexObjectFactory);
        }
        public List<Student> GetAllWithoutCaching()
        {
            Thread.Sleep(5000);
            return listToReturn;
        }
    }
}
