using RecipeData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data;
using System.Data.SqlClient;

namespace RecipeData.Repositories
{
    public class SqlCourseTypeRepository 
    {
        public SqlCourseTypeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        string connectionString;
        int CourseTypeID;
        public int CreateUpdateCourseType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The parameter cannot be null or empty. ", nameof(name));
            
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.CreateUpdateCourseType", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var p = command.Parameters.Add("Name", SqlDbType.NVarChar);
                        p.Value = name;
                        p = command.Parameters.Add("CourseTypeId", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        CourseTypeID = Convert.ToInt32(command.Parameters["CourseTypeID"].Value);
                        

                        transaction.Complete();


                        return CourseTypeID;
                            }
                }
            }

        }


        string Name;
        public string FetchCourseType(int RecipeID)
        {
                
                using (var transaction = new TransactionScope())
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        using (var command = new SqlCommand("Recipes.FetchCourseType", connection))
                        {

                            command.CommandType = CommandType.StoredProcedure;

                            var p = command.Parameters.Add("RecipeId", SqlDbType.Int);
                            p.Value = RecipeID;
                            p = command.Parameters.Add("Name", SqlDbType.NVarChar,64);
                            p.Direction = ParameterDirection.Output;

                            connection.Open();

                            command.ExecuteNonQuery();

                            Name = Convert.ToString(command.Parameters["Name"].Value);


                            transaction.Complete();


                            return Name;
                        }
                    }
                }
            //return Name;
        }

        


    }
}
