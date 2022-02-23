using MovieRestApp.Configration;
using MovieRestApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace MovieRestApp.Repository
{
    public class MovieRepository : IMoviceRepository
    {
        private readonly ConfigrationSettings m_connectionString;
        private readonly SqlConnection m_sqlConnection ;
        private const  string m_sqlInsertMovie ="Insert into MovieInfos (Name,Rating,Imdb,Cost) Values (@Name,@Rating,@Imdb,@Cost) ";
        private const string m_movieFindYearAndMonth = "Select * from  MovieInfos where year(SceneDateTime)=@SceneDateTime and month(SceneDateTime)=@month";
        private const string m_movieFindYear = "Select * from  MovieInfos where year(SceneDateTime)=@year";
        private const string m_findByDirectorId = "select t.Name ,t.SceneDateTime,t.Rating,t.Imdb,t.Cost from MovieInfos t inner join MoviesToDirector m on t.Id=m.DirectorId where m.DirectorId=@DirectorId";
        public MovieRepository(ConfigrationSettings configrationSettings)
        {
          
               m_connectionString = configrationSettings;
            m_sqlConnection = new SqlConnection(m_connectionString.connectionString);
        }
       
        public MovieInfo GetMovieSql(SqlDataReader  reader) {

            var read = new MovieInfo {Id=(int)reader[0],Name=(string)reader[1],SceneDateTime=(DateTime)reader[2],Rating =(decimal)reader[3],Imdb =(decimal)reader[4],Cost=(decimal)reader[5] };
            return read;
        }
        public MovieInfo GetMovieByDirectorSql(SqlDataReader reader)
        {

            var read = new MovieInfo {  Name = (string)reader[0], SceneDateTime = (DateTime)reader[1], Rating = (decimal)reader[2], Imdb = (decimal)reader[3], Cost = (decimal)reader[4] };
            return read;
        }
        public MovieInfo FindByDirectorId(int id)
        {
            try {
                MovieInfo movieInfo = new MovieInfo();
                var command = new SqlCommand(m_findByDirectorId,m_sqlConnection);
                command.Parameters.AddWithValue("@DirectorId",id);
                m_sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    movieInfo = GetMovieByDirectorSql(reader);
                }
                return movieInfo;
            } finally {
                if (m_sqlConnection.State == System.Data.ConnectionState.Open)

                {
                    m_sqlConnection.Close();
                }
            }
            throw new NotImplementedException();
        }
        public IEnumerable<MovieInfo> FindMovieYear(int year)
        {
            try
            {

                var command = new SqlCommand(m_movieFindYear, m_sqlConnection);
                var list = new List<MovieInfo>();
                command.Parameters.AddWithValue("@year", year);
        
                m_sqlConnection.Open();
                var reader = command.ExecuteReader();


                while (reader.Read())
                {
                    list.Add(GetMovieSql(reader));
                }

                return list;

            }
            finally
            {

                if (m_sqlConnection.State == System.Data.ConnectionState.Open)
                    m_sqlConnection.Close();
            }
            throw new NotImplementedException();
        }
        public IEnumerable<MovieInfo> FindMovieYearAndMont(int year, int month)
        {
            
            try {
               
                var command = new SqlCommand(m_movieFindYearAndMonth, m_sqlConnection);
                var list = new List<MovieInfo>();
                command.Parameters.AddWithValue("@SceneDateTime", year);
                command.Parameters.AddWithValue("@SceneDateTime", month);
                m_sqlConnection.Open();
                var reader = command.ExecuteReader();
               

                while (reader.Read())
                {
                    list.Add(GetMovieSql(reader));
                }

                return list;
            
            } finally 
            {

                if (m_sqlConnection.State == System.Data.ConnectionState.Open)
                    m_sqlConnection.Close();
            }
         
        }
        public MovieInfo Save(MovieInfo entity)
        {
            try {
            var command = new SqlCommand(m_sqlInsertMovie,m_sqlConnection);
            command.Parameters.AddWithValue("@Name",entity.Name);
            command.Parameters.AddWithValue("@Rating", entity.Rating);
            command.Parameters.AddWithValue("@Imdb", entity.Imdb);
            command.Parameters.AddWithValue("@Cost", entity.Cost);
            m_sqlConnection.Open();
                command.ExecuteNonQuery();
               
            }
            finally {
                if (m_sqlConnection.State == System.Data.ConnectionState.Open)
                    m_sqlConnection.Close();
            
            }
            return entity;
        }
        public long Count(int count)
        {
            throw new NotImplementedException();
        }

        public void Delete(MovieInfo entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(IEnumerable<MovieInfo> entities)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllById(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExitsById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieInfo> FindAll()
        {
            throw new NotImplementedException();
        }

        public MovieInfo FindById(int id)
        {
            throw new NotImplementedException();
        }

       

        public IEnumerable<MovieInfo> SaveAll(IEnumerable<MovieInfo> entities)
        {
            throw new NotImplementedException();
        }

        public Task<MovieInfo> SaveAsync(MovieInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(MovieInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync(IEnumerable<MovieInfo> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllByIdAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieInfo> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExitsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieInfo>> SaveAllAsync(IEnumerable<MovieInfo> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieInfo>> FindAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
