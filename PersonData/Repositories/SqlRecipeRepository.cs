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
    public class SqlRecipeRepository 
    {
        public SqlRecipeRepository()
        {

        }
        string connectionString = @"Data Source=(localdb)\LocalDBApp1;Initial Catalog=RecipeRepository;Integrated Security=True";

        public Recipe CreateUpdateRecipe(int foodTypeId, int courseTypeId, string name, string description, double servingSize, int prepTime, int cookTime)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The parameter cannot be null or empty. ", nameof(name));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("The parameter cannot be null or empty. ", nameof(description));

            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipe.CreateUpdateRecipe", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var p = command.Parameters.Add("FoodTypeId", SqlDbType.Int);
                        p.Value = foodTypeId;
                        p = command.Parameters.Add("CourseTypeId", SqlDbType.Int);
                        p.Value = courseTypeId;
                        p = command.Parameters.Add("Name", SqlDbType.NVarChar);
                        p.Value = name;
                        p = command.Parameters.Add("Description", SqlDbType.NVarChar);
                        p.Value = description;
                        p = command.Parameters.Add("ServingSize", SqlDbType.Float);
                        p.Value = servingSize;
                        p = command.Parameters.Add("PrepTime", SqlDbType.Int);
                        p.Value = prepTime;
                        p = command.Parameters.Add("CookTime", SqlDbType.Int);
                        p.Value = cookTime;

                        p = command.Parameters.Add("RecipeId", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        

                        transaction.Complete();
                        

                        return new Recipe((int)command.Parameters["RecipeId"].Value, foodTypeId, courseTypeId, name, description, servingSize, prepTime, cookTime,
                            (DateTime)command.Parameters["CreatedOn"].Value,(DateTime)command.Parameters["UpdatedOn"].Value);
                    }
                }
            }

        }

        public DataTable GetRecipeList()
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Library.FetchAllBooks", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();


                        SqlDataReader reader = command.ExecuteReader();

                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            reader.Close();
                            return dt;
                        
                    }
                }
            }
        }

        public void DeletRecipe(int recipeId)
        {
            throw new NotImplementedException();
        }

        public Recipe FetchRecipe(int recipeId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Recipe> RetreiveRecipes()
        {
            throw new NotImplementedException();
        }
    }
}
