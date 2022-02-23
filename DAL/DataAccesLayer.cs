using MovieRestApp.Entity;
using MovieRestApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.ExceptionLibrary.Repository;

namespace MovieRestApp.DAL
{
    public class DataAccesLayer
    {
        private readonly IDirectorRepository m_directorRepository;
        private readonly IMoviceRepository m_movieRepository;
        public DataAccesLayer(IMoviceRepository moviceRepository, IDirectorRepository directorRepository)
        {
            m_movieRepository = moviceRepository;
            m_directorRepository = directorRepository;
        }
        public IEnumerable<DirectorInfo> FindDirectorByAgeGreater(int t)
        {
            try
            {
                return m_directorRepository.FindDirectorByAgeGreater(t);
            }
            catch (Exception exp)
            {

                throw new RepositoryException("DataAccesLayer. FindDirectorByAgeGreater", exp); ;
            }

        }
        public IEnumerable<DirectorInfo> FindDirectorByAgeLess(int t)
        {
            try
            {
                return m_directorRepository.FindDirectorByAgeLess(t);
            }
            catch (Exception exp)
            {

                throw new RepositoryException("DataAccesLayer. FindDirectorByAgeLess", exp); ;
            }

        }
        public MovieInfo FindByDirectorId(int id)
        {
            try
            {
                return m_movieRepository.FindByDirectorId(id);
            }
            catch (Exception exp)
            {

                throw new RepositoryException("DataAccesLayer. FindByDirectorId", exp); ;
            }


        }

            public IEnumerable<MovieInfo> FindMovieYear(int year)
        {
            try
            {
                return m_movieRepository.FindMovieYear(year);
            }
            catch (Exception exp)
            {

                throw new RepositoryException("DataAccesLayer. FindMovieYear", exp); ;
            }
        }
        public IEnumerable<MovieInfo> FindMovieYearAndMont(int year,int month)
        {

            try
            {
                return m_movieRepository.FindMovieYearAndMont( year, month);
            }
            catch (Exception exp)
            {

                throw new RepositoryException("DataAccesLayer. FindMovieYear",exp); ;
            }
        }
        public DirectorInfo SaveDirector(DirectorInfo directorInfo) {
            try
            {
                return m_directorRepository.Save (directorInfo);
            }
            catch (Exception exp)
            {

                throw new RepositoryException("DataAccesLayer.SaveDirector",exp) ;
            }
        
        }
        public DirectorInfo FindByİd(int id)
        {
            try
            {
                return m_directorRepository.FindById(id);
            }
            catch (Exception exp)
            {

                throw new RepositoryException("DataAccesLayer.FindByİd", exp);
            }

        }
        public MovieInfo Save(MovieInfo movieInfo) {
            try
            {
                return m_movieRepository.Save(movieInfo);

            }
            catch (Exception exp)
            {

                throw new RepositoryException("DataAccesLayer.Save",exp); ;
            }
        
        } 
    }
}
