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
                    using (var command = new SqlCommand("Recipes.CreateUpdateRecipe", connection))
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


                        return new Recipe((int)command.Parameters["RecipeId"].Value, foodTypeId, courseTypeId, name, description, servingSize, prepTime, cookTime);
                    }
                }
            }

        }

        public DataTable GetRecipesXIngredientsAway(int v)
        {
            throw new NotImplementedException();
        }

        public DataTable SearchAllRecipes(string text1, string text2, string text3, string text4, double v1, double v2, string text5, int v3, int v4, DateTime date1, DateTime date2, bool @checked)
        {
            throw new NotImplementedException();
        }

        public DataTable GetRecipeList()
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.FetchAllRecipes", connection))
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

        public DataTable GetStepList(int recipeId)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.FetchSteps", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        var p = command.Parameters.Add("RecipeId", SqlDbType.Int);
                        p.Value = recipeId;

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

        public DataTable GetRecipeHistory()
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.FetchFullHistory", connection))
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

        public Recipe GetRecipeFromName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The parameter cannot be null or empty. ", nameof(name));
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.FetchRecipeByName", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var p = command.Parameters.Add("Name", SqlDbType.NVarChar);
                        p.Value = name;
                       

                       
                        connection.Open();


                        SqlDataReader reader = command.ExecuteReader();

                       


                        return new Recipe((int)command.Parameters["RecipeId"].Value,
                                          (int)command.Parameters["FoodTypeId"].Value,
                                          (int)command.Parameters["CourseTypeId"].Value,
                                          name,
                                          command.Parameters["Description"].Value.ToString(),
                                          (double)command.Parameters["ServingSize"].Value,
                                          (int)command.Parameters["PrepTime"].Value,
                                          (int)command.Parameters["CookTime"].Value);
                    }
                }
            }

        }

        public object GetFreshRecipe()
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.FetchRemindRecipes", connection))
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

        public object GetTopTenMonthly()
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.FetchTopTen", connection))
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

        public void CreateGetStep(int recipeId, int stepNumber, string stepDescription)
        {
            if (string.IsNullOrWhiteSpace(stepDescription))
                throw new ArgumentException("The parameter cannot be null or empty. ", nameof(stepDescription));
            
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.CreateGetStep", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var p = command.Parameters.Add("RecipeId", SqlDbType.Int);
                        p.Value = recipeId;
                        p = command.Parameters.Add("StepNumber", SqlDbType.Int);
                        p.Value = stepNumber;
                        p = command.Parameters.Add("StepDescription", SqlDbType.NVarChar);
                        p.Value = stepDescription;

                        

                        connection.Open();

                        command.ExecuteNonQuery();


                        transaction.Complete();


                    }
                }
            }
        }

        public void DeleteStep(int recipeId, int stepNumber)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.DeleteStep", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var p = command.Parameters.Add("RecipeId", SqlDbType.Int);
                        p.Value = recipeId;
                        p = command.Parameters.Add("StepNumber", SqlDbType.Int);
                        p.Value = stepNumber;
                        



                        connection.Open();

                        command.ExecuteNonQuery();


                        transaction.Complete();


                    }
                }
            }
        }


        public void DeleteRecipe(int recipeId)
        {

            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.DeleteRecipe", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var p = command.Parameters.Add("RecipeId", SqlDbType.Int);
                        p.Value = recipeId;
                        
                        connection.Open();

                        command.ExecuteNonQuery();


                        transaction.Complete();


                    }
                }
            }
        }
        double stars;
        public double GetStars(int recipeId)
        {

            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.FetchStars", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var p = command.Parameters.Add("RecipeId", SqlDbType.Int);
                        p.Value = recipeId;
                        p = command.Parameters.Add("stars", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        stars = Convert.ToDouble(command.Parameters["@stars"].Value);



                        connection.Open();

                        command.ExecuteNonQuery();


                        transaction.Complete();

                        return stars;
                    }
                }
            }
        }
        public void addtoHistoryOfUsedRecipes(int recipeId,double stars)
        {

            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.AddToHistoryOfUsedRecipes", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var p = command.Parameters.Add("RecipeId", SqlDbType.Int);
                        p.Value = recipeId;
                        p = command.Parameters.Add("stars", SqlDbType.Float);
                        p.Value = stars;





                        connection.Open();

                        command.ExecuteNonQuery();


                        transaction.Complete();

                    }
                }
            }
        }
    }
}
