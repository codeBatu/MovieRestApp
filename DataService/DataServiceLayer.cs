using MovieRestApp.DAL;
using MovieRestApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.ExceptionLibrary.Service;

namespace MovieRestApp.DataService
{
    public class DataServiceLayer
    {
        private readonly DataAccesLayer m_dataAccesLayer;
      
        public DataServiceLayer(DataAccesLayer dataAccesLayer)
        {
            m_dataAccesLayer = dataAccesLayer;
        }
        public IEnumerable<MovieInfo> FindMovieYearAndMont(int year,int month)
        {

            try
            {
                return m_dataAccesLayer.FindMovieYearAndMont(year,month);
            }
            catch (Exception exp)
            {

                throw new DataServiceException("DataServiceLayer. FindMovieYear", exp); ;
            }
        }
        public IEnumerable<MovieInfo> FindMovieYear(int year)
        {
            try
            {
                return m_dataAccesLayer.FindMovieYear(year);
            }
            catch (Exception exp)
            {

                throw new DataServiceException("DataServiceLayer. FindMovieYear", exp); ;
            }
        }

        public IEnumerable<DirectorInfo> FindDirectorByAgeGreater(int t)
        {

            try
            {
                return m_dataAccesLayer.FindDirectorByAgeGreater(t);
            }
            catch (Exception exp)
            {

                throw new DataServiceException("DataServiceLayer. indDirectorByAgeGreater", exp); ;
            }
        }
        public IEnumerable<DirectorInfo> FindDirectorByAgeLess(int t)
        {

            try
            {
                return m_dataAccesLayer.FindDirectorByAgeLess(t);
            }
            catch (Exception exp)
            {

                throw new DataServiceException("DataServiceLayer. indDirectorByAgeLess", exp); ;
            }
        }
        public DirectorInfo SaveDirector(DirectorInfo directorInfo)
        {

            try
            {
                return m_dataAccesLayer.SaveDirector(directorInfo);
            }
            catch (Exception ex)
            {

                throw new DataServiceException("DataServiceLayer.SaveDirector",ex);
            }

        }

        public MovieInfo FindByDirectorId(int id)
        {
             try
            {
                return m_dataAccesLayer.FindByDirectorId(id);
            }
            catch (Exception ex)
            {

                throw new DataServiceException("DataServiceLayer.FindByDirectorId", ex);
            }


        }


        public DirectorInfo FindById(int id)
        {

            try
            {
                return m_dataAccesLayer.FindByİd(id);
            }
            catch (Exception ex)
            {

                throw new DataServiceException("DataServiceLayer.FindById", ex);
            }

        }
        public MovieInfo SaveMovie(MovieInfo movieInfo)
        {
            try
            {
                return m_dataAccesLayer.Save(movieInfo);
            }
            catch (Exception ex)
            {

                throw new DataServiceException("DataServiceLayer.SaveMovie", ex);
            }


        }
    }
}
