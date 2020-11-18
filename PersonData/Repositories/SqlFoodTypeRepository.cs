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
    public class SqlFoodTypeRepository 
    {
        public SqlFoodTypeRepository()
        {

        }
        string connectionString = @"Data Source=(localdb)\LocalDBApp1;Initial Catalog=RecipeRepository;Integrated Security=True";
        int FoodTypeID;
        public int CreateUpdateFoodType(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The parameter cannot be null or empty. ", nameof(name));
            
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("FoodType.CreateUpdateFoodType", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var p = command.Parameters.Add("Name", SqlDbType.NVarChar);
                        p.Value = name;
                        p = command.Parameters.Add("FoodTypeId", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        FoodTypeID = Convert.ToInt32(command.Parameters["@FoodTypeID"].Value);
                        

                        transaction.Complete();


                        return FoodTypeID;
                            }
                }
            }

        }


        string Name;
        public string FetchFoodType(int RecipieID)
        {
                
                using (var transaction = new TransactionScope())
                {
                    using (var connection = new SqlConnection(connectionString))
                    {
                        using (var command = new SqlCommand("FoodType.CreateUpdateFoodType", connection))
                        {

                            command.CommandType = CommandType.StoredProcedure;

                            var p = command.Parameters.Add("RecipieID", SqlDbType.NVarChar);
                            p.Value = RecipieID;
                            p = command.Parameters.Add("Name", SqlDbType.Int);
                            p.Direction = ParameterDirection.Output;

                            connection.Open();

                            command.ExecuteNonQuery();

                            Name = Convert.ToString(command.Parameters["@Name"].Value);


                            transaction.Complete();


                            return Name;
                        }
                    }
                }
            //return Name;
        }

        


    }
}
