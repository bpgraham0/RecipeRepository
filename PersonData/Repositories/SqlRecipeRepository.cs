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
        public SqlRecipeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        string connectionString;
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

                        
                    }
                    
                }
            }
            return GetRecipeFromName(name);

        }

        public DataTable GetRecipesXIngredientsAway(int x)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.FetchHaveExceptX", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        var p = command.Parameters.Add("x", SqlDbType.Int);
                        p.Value = x;
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

        public DataTable SearchAllRecipes(string Name, string Description, string CourseType, string FoodType, double StarsMin, double StarsMax, string Ingreadent, int PreptimeMax, int cooktimeMax, DateTime DateMin, DateTime DateMax, bool Have, bool DateChanged)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.SearchAllRecipes", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandType = CommandType.StoredProcedure;
                        var p = command.Parameters.Add("Name", SqlDbType.NVarChar);
                        p.Value = Name;
                        p = command.Parameters.Add("Description", SqlDbType.NVarChar);
                        p.Value = Description;
                        p = command.Parameters.Add("CourseType", SqlDbType.NVarChar);
                        p.Value = CourseType;
                        p = command.Parameters.Add("FoodType", SqlDbType.NVarChar);
                        p.Value = FoodType;
                        p = command.Parameters.Add("StarsMin", SqlDbType.Float);
                        p.Value = StarsMin;
                        p = command.Parameters.Add("StarsMax", SqlDbType.Float);
                        p.Value = StarsMax;
                        p = command.Parameters.Add("Ingreadent", SqlDbType.NVarChar);
                        p.Value = Ingreadent;
                        p = command.Parameters.Add("PreptimeMax", SqlDbType.Int);
                        p.Value = PreptimeMax;
                        p = command.Parameters.Add("cooktimeMax", SqlDbType.Int);
                        p.Value = cooktimeMax;
                        //p = command.Parameters.Add("DateMin", SqlDbType.Date);
                        //p.Value = DateMin;
                        //p = command.Parameters.Add("DateMax", SqlDbType.Date);
                        //p.Value = DateMax;
                        //p = command.Parameters.Add("Have", SqlDbType.Bit);
                        //p.Value = Have;
                        //p = command.Parameters.Add("DateChanged", SqlDbType.Bit);
                        //p.Value = DateChanged;

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

                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        reader.Close();

                        DataRow dr = dt.Rows[0];
                        return new Recipe((int)dr["RecipeId"],
                                          (int)dr["FoodTypeId"],
                                          (int)dr["CourseTypeId"],
                                          name,
                                          (string)dr["Description"],
                                          (double)dr["ServingSize"],
                                          (int)dr["PrepTime"],
                                          (int)dr["CookTime"]);



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
                    using (var command = new SqlCommand("Recipes.CreateUpdateSteps", connection))
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
                        p = command.Parameters.Add("stars", SqlDbType.Float);
                        p.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        stars = Convert.ToDouble(command.Parameters["stars"].Value);

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
