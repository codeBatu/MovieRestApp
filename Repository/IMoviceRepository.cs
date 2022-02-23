using MovieRestApp.Entity;
using System.Collections.Generic;
using Util.ExceptionLibrary.Repository;

namespace MovieRestApp.Repository
{
    public interface IMoviceRepository:ICrudRepository<MovieInfo,int>
    {
        IEnumerable<MovieInfo> FindMovieYearAndMont(int year,int month);
        IEnumerable<MovieInfo> FindMovieYear(int year);
        MovieInfo FindByDirectorId(int id);
    }
}
