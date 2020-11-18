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
    public class SqlIngredientListRepository 
    {
        public SqlIngredientListRepository()
        {

        }
        string connectionString = @"Data Source=(localdb)\LocalDBApp1;Initial Catalog=RecipeRepository;Integrated Security=True";

        public void AddToIngredientList(int RecipeID, int IngredientID, int MeasurementID, int Quanity)
        {
           
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipe.AddToIngredientList", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var p = command.Parameters.Add("RecipeID", SqlDbType.Int);
                        p.Value = RecipeID;
                        p = command.Parameters.Add("IngredientID", SqlDbType.Int);
                        p.Value = IngredientID;
                        p = command.Parameters.Add("MeasurementID", SqlDbType.NVarChar);
                        p.Value = MeasurementID;
                        p = command.Parameters.Add("Quanity", SqlDbType.Float);
                        p.Value = Quanity;
                       
                        connection.Open();

                        command.ExecuteNonQuery();

                        

                        transaction.Complete();
                        

                         }
                }
            }

        }

        public void CreateIngredient(string Name, int HaveItem)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipies.CreateIngredient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        var p = command.Parameters.Add("Name", SqlDbType.NVarChar);
                        p.Value = Name;
                        p = command.Parameters.Add("HaveItem", SqlDbType.Bit);
                        p.Value = HaveItem;
                        connection.Open();

                        command.ExecuteNonQuery();

                        //FoodTypeID = Convert.ToInt32(command.Parameters["@FoodTypeID"].Value);


                        transaction.Complete();



                        //SqlDataReader reader = command.ExecuteReader();

                        //    DataTable dt = new DataTable();
                        //    dt.Load(reader);
                        //    reader.Close();


                    }
                }
            }
        }

        public void DeleteFromIngredientList(int recipeId, int IngredientID)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipies.DeleteFromIngredientList", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        var p = command.Parameters.Add("recipeId", SqlDbType.Int);
                        p.Value = recipeId;
                        p = command.Parameters.Add("IngredientID", SqlDbType.Int);
                        p.Value = IngredientID;
                        connection.Open();

                        command.ExecuteNonQuery();

                        //FoodTypeID = Convert.ToInt32(command.Parameters["@FoodTypeID"].Value);


                        transaction.Complete();


                    }
                }
            }
        }

        public DataTable FetchAllIngredientsInPantry()
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipies.DeleteFromIngredientList", connection))
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

        public IReadOnlyList<Recipe> FetchAllIngredient()
        {
            throw new NotImplementedException();
        }
        public Recipe FetchIngredientList(int recipeId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Recipe> UpdateHaveItem(int, bool)
        {
            throw new NotImplementedException();
        }
        public IReadOnlyList<Recipe> FetchMeasurementList()
        {
            throw new NotImplementedException();
        }
    }
}
