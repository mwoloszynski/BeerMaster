using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerMaster.Controllers
{
    public class DBController
    {
        private static string _dbFileName = "beermaster_db.bin";
        SQLiteConnection _connection;

        public DBController() 
        {
            _connection = null;
        }

        public void InsertIntoTable(string tableName, string[] columns, string[] values)
        {
            OpenConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "INSERT INTO `" + tableName + "`(";
            for (int i = 0; i < columns.Count(); i++)
            {
                if (columns.Count() - i <= 1) cmd.CommandText += columns[i];
                else cmd.CommandText += columns[i] + ", ";
            }
            cmd.CommandText += ") VALUES(";
            for (int i = 0; i < values.Count(); i++)
            {
                if (values.Count() - i <= 1) cmd.CommandText += "'" + values[i] + "'";
                else cmd.CommandText += "'" + values[i] + "'" + ", ";
            }
            cmd.CommandText += ");";
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                ExecuteQuerry(cmd);
            }
            else
            {
                // Obsługa błędów
            }
            CloseConnection();
        }

        public void UpdateTable(string tableName, string[] columns, string[] values, string[] colCond, string[] valCond, string[] eqCond, string[] andor)
        {
            OpenConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "UPDATE `" + tableName + "` SET ";
            for (int i = 0; i < columns.Count(); i++)
            {
                if (columns.Count() - i <= 1)
                    cmd.CommandText += columns[i] + " = '" + values[i] + "' ";
                else
                    cmd.CommandText += columns[i] + " = '" + values[i] + "', ";
            }
            cmd.CommandText += "WHERE ";
            for (int i = 0; i < colCond.Count(); i++)
            {
                if (colCond.Count() - i <= 1)
                    cmd.CommandText += colCond[i] + " " + eqCond[i] + " " + valCond[i] + ";";
                else
                    cmd.CommandText += colCond[i] + " " + eqCond[i] + " " + valCond[i] + " " + andor[i];
            }
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                ExecuteQuerry(cmd);
            }
            else
            {
                // Obsługa błędów
            }
            CloseConnection();
        }

        public void DeleteSingleRow(string name, string column, string value)
        {
            OpenConnection();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "DELETE FROM `" + name + "` WHERE " + column + " = '" + value + "';";
            ExecuteQuerry(cmd);
            CloseConnection();
        }

        public string SelectSingleColumnOneResult(string name, string conditions, string columnResult)
        {
            OpenConnection();
            string result = "";
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "SELECT * FROM `" + name + "` ";
            cmd.CommandText += conditions;
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    result = (string)reader[columnResult].ToString();


            }
            catch (Exception ex)
            {
                // Obsługa błędów
            }
            CloseConnection();
            return result;
        }

        public List<string> SelectSingleColumnMany(string name, string conditions, string columnResult)
        {
            OpenConnection();
            List<string> result = new List<string>();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = _connection;
            cmd.CommandText = "SELECT * FROM `" + name + "` ";
            cmd.CommandText += conditions;
            cmd.CommandType = System.Data.CommandType.Text;

            try
            {
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((string)reader[columnResult].ToString());
                }

            }
            catch (Exception ex)
            {
                // Obsługa błędów
            }
            CloseConnection();
            return result;
        }

        public void CreateTable(string name, string[,] values, int numbOfValues)
        {
            OpenConnection();
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd.Connection = _connection;
                // value 0 - nazwa kolumny
                // value 1 - typ kolumny
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS `" + name + "`(" + values[0, 0] + " " + values[0, 1];
                for (int i = 1; i < numbOfValues; i++)
                {
                    cmd.CommandText += ", " + values[i, 0] + " " + values[i, 1];
                }
                cmd.CommandText += ");";
                ExecuteQuerry(cmd);
            }
            else
            {
                // Obsługa błędów
            }
            CloseConnection();
        }

        public bool LoadDB()
        {
            try
            {
                if (CheckPath(""))
                {
                    if (!CheckFile(GetPath(), _dbFileName))
                        return false;
                    else
                    {
                        _connection = new SQLiteConnection(GetConnectionString(GetPath() + _dbFileName));
                        return true;
                    }
                }
                else
                {
                    // Obsługa błędów
                    return false;
                }
            } catch (Exception ex)
            {
                // Obsługa błędów
                return false;
            }
        }

        public bool CreateDB()
        {
            try
            {
                if (CheckPath(""))
                {
                    if (!CheckFile(GetPath(), _dbFileName))
                    {
                        SQLiteConnection.CreateFile(GetPath() + _dbFileName);
                        if (!CheckFile(GetPath(), _dbFileName))
                        {
                            // Obsługa błędów
                            return false;
                        }
                        else
                        {
                            _connection = new SQLiteConnection(GetConnectionString(GetPath() + _dbFileName));

                            string[,] userInfo = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "Value", "TEXT" } };
                            string[,] additives = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "Type", "TEXT" }, { "Country", "TEXT" }, { "Supplier", "TEXT" }, { "Color", "REAL" }, { "MaxGrist", "REAL" }, { "Sugar", "REAL" }, { "Potential", "REAL" }, { "Yield", "REAL" }, { "Bitterness", "REAL" }, { "Description", "TEXT" }, { "PricePerL_Kg", "REAL" } };
                            string[,] brew = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "Description", "TEXT" }, { "BrewDate", "TEXT" }, { "RecipeId", "REAL" }, { "BottlingDate", "TEXT" }, { "BottlesAmount", "INTEGER" }, { "BottlesVolume", "REAL" }, { "Rating", "REAL" } };
                            string[,] carbonation = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "Type", "TEXT" }, { "Fermentability", "REAL" }, { "ExtractYield", "REAL" }, { "PercentSolid", "REAL" }, { "Description", "TEXT" }, { "PricePerKg", "REAL" } };
                            string[,] equipment = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "Type", "TEXT" }, { "BatchVolume", "REAL" }, { "Efficiency", "REAL" }, { "Description", "TEXT" } };
                            string[,] fermentation = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "TurboFermentationDescription", "TEXT" }, { "TurboFermentationTime", "INTEGER" }, { "MinTurboFermentationTemp", "REAL" }, { "MaxTurboFermentationTemp", "REAL" }, { "SilentFermentationDescription", "TEXT" }, 
                                { "SilentFermentationTime", "INTEGER" }, { "MinSilentFermentationTemp", "REAL" }, { "MaxSilentFermentationTemp", "REAL" }, { "LageringDescription", "TEXT" }, { "LageringTime", "INTEGER" }, { "MinLageringTemp", "REAL" }, { "MaxLageringTemp", "REAL" }, { "AgingDescription", "TEXT" },
                                { "AgingTime", "INTEGER" }, { "MinAgingTemp", "REAL" }, { "MaxAgingTemp", "REAL" }, { "Description", "TEXT" }};
                            string[,] hop = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "Type", "TEXT" }, { "Country", "TEXT" }, { "Alpha", "REAL" }, { "Beta", "REAL" }, { "Description", "TEXT" }, { "PricePerGram", "REAL" } };
                            string[,] malt = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "Type", "TEXT" }, { "Country", "TEXT" }, { "Supplier", "TEXT" }, { "Color", "REAL" }, { "MaxGrist", "REAL" }, { "Extract", "REAL" }, { "Description", "TEXT" }, { "PricePerKg", "REAL" } };
                            string[,] mash = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "Type", "TEXT" }, { "Description", "TEXT" } };
                            string[,] mashSteps = { { "Id", "INTEGER PRIMARY KEY" }, { "MashId", "INTEGER" }, { "Name", "TEXT" }, { "Type", "TEXT" }, { "WaterAdd", "REAL" }, { "WaterMaltRatio", "REAL" }, { "ObtainTemperature", "REAL" }, { "MaintainTemperature", "REAL" }, { "StepTime", "REAL" }, { "Description", "TEXT" } };
                            string[,] miscellaneous = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "Type", "TEXT" }, { "DosageAmount", "REAL" }, { "DosagePerAmount", "REAL" }, { "TimeOfUse", "TEXT" }, { "Description", "TEXT" }, { "PricePerDose", "REAL" } };
                            string[,] recipe = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "BatchSize", "REAL" }, { "BoilSize", "REAL" }, { "StyleId", "INTEGER" }, { "EquipmentId", "INTEGER" }, { "MashId", "INTEGER" }, 
                                { "FermentationId", "INTEGER" }, { "CarbonationId", "INTEGER" }, { "CarbonationAmount", "REAL" }, { "Color", "REAL" }, { "Bitterness", "REAL" }, { "OriginalGravity", "REAL" }, { "FinalGravity", "REAL" }, { "Alcohol", "REAL" }, { "Rating", "REAL" } };
                            string[,] recipeIngredients = { { "Id", "INTEGER PRIMARY KEY" }, { "RecipeId", "INTEGER" }, { "IngredientId", "INTEGER" }, { "IngredientType", "TEXT" }, { "Amount", "REAL" }, { "MashStepId", "INTEGER" }, { "FermentationStepId", "INTEGER" }, { "AddInTime", "REAL" }, { "HoldTime", "REAL" }, { "HoldTimeType", "TEXT" }};
                            string[,] style = { { "Id", "INTEGER PRIMARY KEY" }, { "Code", "TEXT" }, { "Name", "TEXT" }, { "Type", "TEXT" }, { "MinOriginalGravity", "REAL" }, { "MaxOriginalGravity", "REAL" }, { "MinFinalGravity", "REAL" }, 
                                { "MaxFinalGravity", "REAL" }, { "MinAlcohol", "REAL" }, { "MaxAlcohol", "REAL" }, { "MinIBU", "REAL" }, { "MaxIBU", "REAL" }, { "MinColor", "REAL" }, { "MaxColor", "REAL" }, { "MinCarbonation", "REAL" },
                                { "MaxCarbonation", "REAL" }, { "Description", "TEXT" }, { "Features", "TEXT" }, { "Appearance", "TEXT" }, { "Aroma", "TEXT" }, { "Taste", "TEXT" }, { "Ingredients", "TEXT" } };
                            string[,] unitSettings = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "Value", "TEXT" } };
                            string[,] water = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "PH", "REAL" }, { "Calcium", "REAL" }, { "Magnesium", "REAL" }, { "Sodium", "REAL" }, { "Sulfate", "REAL" }, { "Chloride", "REAL" }, { "Bicarbonate", "REAL" }, { "Description", "TEXT" }, { "PricePerLiter", "REAL" } };
                            string[,] yeast = { { "Id", "INTEGER PRIMARY KEY" }, { "Name", "TEXT" }, { "BeerCategory", "TEXT" }, { "Supplier", "TEXT" }, { "Type", "TEXT" }, { "DosageAmountGram", "REAL" }, { "DosagePerAmountLiters", "REAL" }, { "MinTemperature", "REAL" }, { "MaxTemperature", "REAL" }, { "Attenuation", "REAL" }, { "Flocculation", "REAL" }, { "Description", "TEXT" }, { "PricePerPackage", "REAL" } };


                            CreateTable("UserInfo", userInfo, 3);
                            CreateTable("Additives", additives, 13);
                            CreateTable("Brew", brew, 9);
                            CreateTable("Carbonation", carbonation, 8);
                            CreateTable("Equipment", equipment, 6);
                            CreateTable("Fermentation", fermentation, 19);
                            CreateTable("Hop", hop, 8);
                            CreateTable("Malt", malt, 10);
                            CreateTable("Mash", mash, 4);
                            CreateTable("MashSteps", mashSteps, 10);
                            CreateTable("Miscellaneous", miscellaneous, 8);
                            CreateTable("Recipe", recipe, 16);
                            CreateTable("RecipeIngredients", recipeIngredients, 10);
                            CreateTable("Style", style, 22);
                            CreateTable("UnitSettings", unitSettings, 3);
                            CreateTable("Water", water, 11);
                            CreateTable("Yeast", yeast, 13);

                            string[] userFirstNameColumns = { "Name", "Value" };
                            string[] userFirstNameValues = { "FirstName", "New" };

                            string[] userLastNameColumns = { "Name", "Value" };
                            string[] userLastNameValues = { "LastName", "User" };

                            InsertIntoTable("UserInfo", userFirstNameColumns, userFirstNameValues);
                            InsertIntoTable("UserInfo", userLastNameColumns, userLastNameValues);

                            return true;
                        }
                    }
                    else
                    {
                        return false; // Znaleziono istniejący plik z bazą
                    }
                }
                else
                {
                    // Obsługa błędów
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędów
                return false;
            }
        }





        private void OpenConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    _connection.Open();
                }
                catch (Exception ex)
                {
                    // Obsługa błędów
                }
            }
        }

        private void ExecuteQuerry(SQLiteCommand cmd)
        {
            try
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Obsługa błędów
            }
        }

        private void CloseConnection()
        {
            if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    _connection.Close();
                }
                catch (Exception ex)
                {
                    // Obsługa błędów
                }
            }
        }

        private string GetConnectionString(string plik)
        {
            return "Data Source=" + plik + ";"
                + "Version=3;"
                + "PRAGMA count_changes=OFF;"
                + "PRAGMA temp_store=MEMORY;"
                + "PRAGMA encoding=\"UTF-8\";"
                + "PRAGMA locking_mode=EXCLUSIVE;"
                + "UseUTF8Encoding=True;";
        }

        private bool CheckFile(string path, string name)
        {
            path += name;
            if (!File.Exists(path))
                return false;
            else
                return true;
        }

        private bool CheckPath(string name)
        {
            string path = GetPath();
            if (!Directory.Exists(path))
            {
                DirectoryInfo dir = Directory.CreateDirectory(path);
                if (!String.IsNullOrEmpty(name))
                {
                    DirectoryInfo dir2 = Directory.CreateDirectory(path + name + "\\");
                }
                return true;
            }
            else
            {
                if (!Directory.Exists(path + name + "\\"))
                {
                    DirectoryInfo dir = Directory.CreateDirectory(path + name + "\\");
                    return true;
                }
                else
                {
                    return true;
                }
            }
        }

        private string GetPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\BeerMaster\\";
        }
    }
}
