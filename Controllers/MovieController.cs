using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRestApp.DataService;
using MovieRestApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util.ExceptionLibrary.Service;

namespace MovieRestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly DataServiceLayer m_dataServiceLayer;
        public MovieController(DataServiceLayer dataServiceLayer)
        {
            m_dataServiceLayer = dataServiceLayer;
        }
        [HttpPost("Movie/save")]
        public IActionResult Save(MovieInfo movieInfo) {

            try
            {
                return new OkObjectResult(m_dataServiceLayer.SaveMovie(movieInfo));
            }
            catch (Exception)
            {

                throw;
            }
        
        }
        [HttpGet("Movie/find/yearmonth")]
        public IActionResult FindMovieYear(int y,int m)
        {

            try
            {
                return  new ObjectResult(m_dataServiceLayer.FindMovieYearAndMont(y,m));
            }
            catch (Exception exp)
            {
               

                throw new  DataServiceException("MovieController.FindMovieYear",exp);
            }

        }
        [HttpGet("Movie/find/director")]
        public IActionResult FindByDirectorId(int id)
        {
            try
            {
                return new ObjectResult(m_dataServiceLayer.FindByDirectorId(id));
            }
            catch (Exception exp)
            {


                throw new DataServiceException("MovieController.FindMovieYear", exp);
            }



        }
        [HttpGet("Movie/find/year")]
        public IActionResult FindMovieYear(int y)
        {

            try
            {
                return new ObjectResult(m_dataServiceLayer.FindMovieYear(y));
            }
            catch (Exception exp)
            {


                throw new DataServiceException("MovieController.FindMovieYear", exp);
            }

        }
    }
   
}

