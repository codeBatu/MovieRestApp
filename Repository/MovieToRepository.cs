using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MovieRestApp.Entity;

namespace MovieRestApp.Repository
{
    public class MovieToRepository
    {
        private readonly Configration.ConfigrationSettings m_configrationSettings;
        private readonly SqlConnection sqlConnection;
        public MovieToRepository(Configration.ConfigrationSettings configrationSettings)
        {
            m_configrationSettings = configrationSettings;
            sqlConnection = new SqlConnection(m_configrationSettings.connectionString);
        }

        //  public MovieToDirector FindByDirectorId(int id) {

        //        try
        //        {
        //            var command = new SqlCommand();
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }

        //    }
        //}
    }
}
