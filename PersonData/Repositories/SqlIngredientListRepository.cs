﻿using RecipeData.Models;
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
        public SqlIngredientListRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        string connectionString;

        public void AddToIngredientList(int RecipeID, int IngredientID, int MeasurementID, double Quantity)
        {

            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.AddToIngredientList", connection))
                    {

                        command.CommandType = CommandType.StoredProcedure;

                        var p = command.Parameters.Add("RecipeID", SqlDbType.Int);
                        p.Value = RecipeID;
                        p = command.Parameters.Add("IngredientID", SqlDbType.Int);
                        p.Value = IngredientID;
                        p = command.Parameters.Add("MeasurementID", SqlDbType.NVarChar);
                        p.Value = MeasurementID;
                        p = command.Parameters.Add("Quantity", SqlDbType.Float);
                        p.Value = Quantity;

                        connection.Open();

                        command.ExecuteNonQuery();



                        transaction.Complete();


                    }
                }
            }

        }
        int IngredientId;
        public int CreateIngredient(string Name, int HaveItem)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.CreateIngredient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        var p = command.Parameters.Add("Name", SqlDbType.NVarChar);
                        p.Value = Name;
                        p = command.Parameters.Add("HaveItem", SqlDbType.Bit);
                        p.Value = HaveItem; 
                        p = command.Parameters.Add("IngredientId", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;

                        connection.Open();

                        command.ExecuteNonQuery();

                        IngredientId = Convert.ToInt32(command.Parameters["IngredientId"].Value);


                        transaction.Complete();

                        return IngredientId;

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
                    using (var command = new SqlCommand("Recipes.DeleteFromIngredientList", connection))
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
                    using (var command = new SqlCommand("Recipes.FetchAllIngredientsInPantry", connection))
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

        public DataTable FetchAllIngredient()
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.FetchAllIngredients", connection))
                    {

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
        public DataTable FetchIngredientList(int recipeId)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.FetchIngredientList", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        var p = command.Parameters.Add("recipeId", SqlDbType.Int);
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

        public void UpdateHaveItem(string Name, bool HaveItem)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.UpdateHaveItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        var p = command.Parameters.Add("Name", SqlDbType.NVarChar);
                        p.Value = Name;
                        p = command.Parameters.Add("HaveItem", SqlDbType.Bit);
                        if (HaveItem)
                        {
                            p.Value = 0;
                        }
                        else
                        {
                            p.Value = 1;
                        }
                        connection.Open();

                        command.ExecuteNonQuery();

                        //FoodTypeID = Convert.ToInt32(command.Parameters["@FoodTypeID"].Value);


                        transaction.Complete();


                    }
                }

            }
        }
        public IList<string> FetchMeasurementList()
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.FetchMeasurementList", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                       
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        var Measurements = new List<string>();
                        foreach(DataRow row in dt.Rows)
                        {
                            Measurements.Add((string)row["Name"]);
                        }
                        reader.Close();

                        return Measurements;


                    }
                }

            }

        }
        int MeasurementId;
        public int FetchMeasurementId(string Name)
        {
            using (var transaction = new TransactionScope())
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand("Recipes.FetchMeasurementId", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        var p = command.Parameters.Add("Name", SqlDbType.NVarChar);
                        p.Value = Name;
                        p = command.Parameters.Add("MeasurementId", SqlDbType.Int);
                        p.Direction = ParameterDirection.Output;
                        command.CommandType = CommandType.StoredProcedure;
                        

                        connection.Open();

                        command.ExecuteNonQuery();

                        MeasurementId = Convert.ToInt32(command.Parameters["MeasurementId"].Value);

                        transaction.Complete();

                        return MeasurementId;


                    }
                }

            }

        }
    }
}
