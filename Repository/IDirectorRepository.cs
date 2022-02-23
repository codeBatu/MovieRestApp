using MovieRestApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.ExceptionLibrary.Repository;
namespace MovieRestApp.Repository
{
  public  interface IDirectorRepository: ICrudRepository<DirectorInfo,int>
    {
        IEnumerable<DirectorInfo> FindDirectorByAgeGreater(int t);
     IEnumerable<DirectorInfo> FindDirectorByAgeLess(int t);
    }
}
