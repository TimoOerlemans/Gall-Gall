using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Account
{
    public class AccountDAL : DBcommand, IAccountContainer
    {
        public bool BeschikbaarCheck(AccountDTO accountDTO)
        {
            try
            {
                string querystring = "SELECT 1 FROM Account WHERE Gebruikersnaam = @GN;";
                using (SqlConnection connectie = OpenSqlConnection())
                {
                    SqlCommand test = CreateCommand(querystring, connectie);
                    test.Parameters.AddWithValue("@GN", accountDTO.Gebruikersnaam);
                    while (test.ExecuteReader().Read())
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch (SqlException s)
            {
                throw new Exception("SqlException", s);
            }
            catch (NullReferenceException n)
            {
                throw new Exception("NullReferenceException", n);
            }
            catch (Exception e)
            {
                throw new Exception("exception", e);
            }
        }
        public int Inloggen(string gebruikersnaam, string wachtwoord)
        {
            try 
            { 
                string queryString = "SELECT * from Account Where Gebruikersnaam = @gebruikersnaam AND Wachtwoord = @wachtwoord";
                using (SqlConnection connectie = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, connectie);

                    cmd.Parameters.AddWithValue("@gebruikersnaam", gebruikersnaam);
                    cmd.Parameters.AddWithValue("@wachtwoord", wachtwoord);
                    
                    SqlDataReader rdr = cmd.ExecuteReader();
                    bool returnvalue = rdr.HasRows;
                    DataTable dataTable = new DataTable();
                    dataTable.Load(rdr);
                    if (returnvalue)
                    {
                        return Convert.ToInt32(dataTable.Rows[0]["AccountID"]);
                    }
                    return 0;
                }
            }
            catch (SqlException s)
            {
                throw new Exception("SqlException", s);
            }
            catch (NullReferenceException n)
            {
                throw new Exception("NullReferenceException", n);
            }
            catch (Exception e)
            {
                throw new Exception("exception", e);
            }
        }

        public int OphalenPerId(int id)
        {
            try
            {
                string queryString = "SELECT Rollen FROM Account WHERE AccountID = @Id;";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);

                    cmd.Parameters.AddWithValue("@Id",id);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    bool returnable = rdr.HasRows;
                    DataTable dataTable = new DataTable();
                    dataTable.Load(rdr);
                    if (returnable)
                    {
                        return Convert.ToInt32(dataTable.Rows[0]["Rollen"]);
                    }
                    return 0;
                }
            }
            catch (SqlException s)
            {
                throw new Exception("SqlException", s);
            }
            catch (NullReferenceException n)
            {
                throw new Exception("NullReferenceException", n);
            }
            catch (Exception e)
            {
                throw new Exception("exception", e);
            }
        }

        public bool Registreren(AccountDTO accountDTO)
        {
            try
            {
                string queryString = "INSERT INTO Account(Voornaam, Achternaam, Gebruikersnaam, Wachtwoord, Leeftijd, Rollen) VALUES (@Vn, @An, @Gn, @Ww, @Lt, @Rl);";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("@Vn", accountDTO.Voornaam);
                    cmd.Parameters.AddWithValue("@An", accountDTO.Achternaam);
                    cmd.Parameters.AddWithValue("@Gn", accountDTO.Gebruikersnaam);
                    cmd.Parameters.AddWithValue("@Ww", accountDTO.Wachtwoord);
                    cmd.Parameters.AddWithValue("@Lt", accountDTO.Leeftijd);
                    cmd.Parameters.AddWithValue("@Rl", accountDTO.Rol);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException s)
            {
                throw new Exception("SqlException", s);
            }
            catch (NullReferenceException n)
            {
                throw new Exception("NullReferenceException", n);
            }
            catch (Exception e)
            {
                throw new Exception("exception", e);
            }
        }
    }
}
