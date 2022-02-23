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
    public class DirectorController : ControllerBase
    {
        private readonly DataServiceLayer m_dataServiceLayer;
        public DirectorController(DataServiceLayer dataServiceLayer)
        {
            m_dataServiceLayer = dataServiceLayer;
           
        }
        [HttpPost("Director/save")]
        public IActionResult SaveDirector(DirectorInfo directorInfo) {

            try
            {
                return directorInfo != null ? new ObjectResult(m_dataServiceLayer.SaveDirector(directorInfo)):null;
            }
            catch (Exception ex)
            {

                throw new DataServiceException("DirectorController. SaveDirector",ex);
            }
        }
        [HttpGet("FindById")]
        public IActionResult FindById(int id)
        {

            try
            {
                return new ObjectResult(m_dataServiceLayer.FindById(id));
            }
            catch (Exception ex)
            {

                throw new DataServiceException("DirectorController. SaveDirector", ex);
            }
        }
        [HttpGet("Director/find/age/greater")]
        public IActionResult FindAgeGreater(int t)
        {

            try
            {
                return new ObjectResult(m_dataServiceLayer.FindDirectorByAgeGreater(t));
            }
            catch (Exception ex)
            {

                throw new DataServiceException("DirectorController. SaveDirector", ex);
            }
        }
        [HttpGet("Director/find/age/less")]
        public IActionResult FindAgeless(int t)
        {

            try
            {
                return new ObjectResult(m_dataServiceLayer.FindDirectorByAgeLess(t));
            }
            catch (Exception ex)
            {

                throw new DataServiceException("DirectorController. SaveDirector", ex);
            }
        }
    }
}
