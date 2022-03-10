using MovieRestApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace MovieRestApp.Repository
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly Configration.ConfigrationSettings m_configrationSettings;
        private  SqlConnection sqlConnection;
        private const string m_insertDirector = "Insert into DirectorInfo (Name,BirthDate) Values(@Name,@BirthDate)";
        private const string m_FindByAgeGreater = "select * from DirectorInfo where year(BirthDate)<@year";
        private const string m_FindByAgeLess = "select * from DirectorInfo where year(BirthDate)>@year";
         private const string m_FindById = " select* from DirectorInfo where(Id) =@id";
        // 1989   <1992 
        public DirectorRepository(Configration.ConfigrationSettings configrationSettings)
        {
            m_configrationSettings = configrationSettings;

            sqlConnection = new(m_configrationSettings.connectionString);

        }
        public DirectorInfo GetDirectorSql(SqlDataReader read)
        {

            var reader = new DirectorInfo { Id = (int)read[0], Name = (string)read[1], BirthDate = (DateTime)read[2] };
            return reader;
        }
        public IEnumerable<DirectorInfo> FindDirectorByAgeGreater(int t)
        {
           
            try {
                var list = new List<DirectorInfo>();
            var command = new SqlCommand(m_FindByAgeGreater,sqlConnection);
                int b = 2022 - t;
                command.Parameters.AddWithValue("@year",b);
              
                sqlConnection.Open();
              
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(GetDirectorSql(reader));
                }
                return list;
            }
            finally {

                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();
            
            }
        }
        public IEnumerable<DirectorInfo> FindDirectorByAgeLess(int t)
        {
            try
            {
                var list = new List<DirectorInfo>();
                var command = new SqlCommand(m_FindByAgeLess, sqlConnection);
                int b = 2022 - t;
                command.Parameters.AddWithValue("@year", b);

                sqlConnection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(GetDirectorSql(reader));
                }
                return list;
            }
            finally
            {

                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();

            }
        }
        public DirectorInfo Save(DirectorInfo entity)
        {
            try { 
            var command = new SqlCommand(m_insertDirector, sqlConnection);
            command.Parameters.AddWithValue("@Name", entity.Name);
            command.Parameters.AddWithValue("@BirthDate", entity.BirthDate);
            sqlConnection.Open();
            command.ExecuteNonQuery();
            }  finally{
                if ( sqlConnection.State == System.Data.ConnectionState.Open)
                         sqlConnection.Close();
            
            }
            return entity;
        }
        public long Count(int count)
        {
            throw new NotImplementedException();
        }

        public void Delete(DirectorInfo entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(IEnumerable<DirectorInfo> entities)
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

        public IEnumerable<DirectorInfo> FindAll()
        {
            throw new NotImplementedException();
        }

        public DirectorInfo FindById(int id)
        {
           var directorInfo = new DirectorInfo();
            try
            {
                var command = new SqlCommand(m_FindById,sqlConnection);
                command.Parameters.AddWithValue("@id",id);
                sqlConnection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
              

                        directorInfo = GetDirectorSql(reader);
                    }
                return directorInfo;
            }
            
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                    sqlConnection.Close();
            }
        }

      

        public IEnumerable<DirectorInfo> SaveAll(IEnumerable<DirectorInfo> entities)
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
        public Task<DirectorInfo> SaveAsync(DirectorInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task<long> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(DirectorInfo entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync(IEnumerable<DirectorInfo> entities)
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

        public Task<DirectorInfo> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExitsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DirectorInfo>> SaveAllAsync(IEnumerable<DirectorInfo> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DirectorInfo>> FindAllAsync()
        {
            throw new NotImplementedException();
        }
=======
       
>>>>>>> 342fc99c2b3b3985dc14eba9438059f60282ec86
    }
}
