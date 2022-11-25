using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.Drank
{
    public class DrankDAL : DBcommand, IDrankContainer
    {
        public List<DrankDTO> AlleDranken()
        {
            try
            {
                List<DrankDTO> dranken = new List<DrankDTO>();

                string queryString = "SELECT * FROM Drank;";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        DrankDTO drankDTO = new DrankDTO();
                        drankDTO.Id = (int)rdr["DrankID"];
                        drankDTO.Naam = (string)rdr["Naam"];
                        drankDTO.Prijs = (Decimal)rdr["Prijs"];
                        dranken.Add(drankDTO);
                    }
                }
                return dranken;
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

        public List<DrankDTO> DrankPerCategorie(int categorieId)
        {
            try
            {
                List<DrankDTO> dranken = new List<DrankDTO>();

                string queryString = "SELECT * FROM Drank WHERE CategorieID = @i;";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("@i", categorieId);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        DrankDTO drank = new DrankDTO();
                        drank.Id = (int)rdr["DrankID"];
                        drank.Naam = (string)rdr["Naam"];
                        drank.Prijs = (Decimal)rdr["Prijs"];
                        dranken.Add(drank);
                    }
                }
                return dranken;
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

        public bool DrankAanmaken(DrankDTO drankDTO)
        {
            try
            {
                string queryString = "INSERT INTO Drank (Naam, Prijs, CategorieID) VALUES (@Na, @Pr, @CId);";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);

                    cmd.Parameters.AddWithValue("@Na", drankDTO.Naam);
                    cmd.Parameters.AddWithValue("@Pr", drankDTO.Prijs);
                    cmd.Parameters.AddWithValue("@CId", drankDTO.CategorieId);
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

        public bool DrankBewerken(DrankDTO drankDTO)
        {
            try
            {
                string queryString = "UPDATE Drank SET Naam = @Na, Prijs = @Pr WHERE DrankID = @i;";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("@Na", drankDTO.Naam);
                    cmd.Parameters.AddWithValue("@Pr", drankDTO.Prijs);
                    cmd.Parameters.AddWithValue("@i", drankDTO.Id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (SqlException s)
            {
                return false;
            }
            catch (NullReferenceException n)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public DrankDTO DrankPerId(int id)
        {
            try
            {
                string queryString = "SELECT * FROM Drank WHERE DrankID = @Id;";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    DrankDTO drankDTO = new DrankDTO();
                    while (rdr.Read())
                    {
                        drankDTO.Id = (int)rdr["DrankID"];
                        drankDTO.Naam = (string)rdr["Naam"];
                        drankDTO.Prijs = (decimal)rdr["Prijs"];
                        return drankDTO;
                    }
                    return drankDTO;
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

        public bool DrankVerwijderen(int id)
        {
            try
            {
                string queryString = "DELETE FROM Drank WHERE DrankID = @i;";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("@i", id);
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

        public bool BeschikbaarCheck(DrankDTO drankDTO)
        {
            try
            {
                string querystring = "SELECT 1 FROM Drank WHERE Naam = @Naam " +
                                     "AND DrankID != @Id;";
                using (SqlConnection connectie = OpenSqlConnection())
                {
                    SqlCommand test = CreateCommand(querystring, connectie);
                    test.Parameters.AddWithValue("@Naam", drankDTO.Naam);
                    test.Parameters.AddWithValue("@Id", drankDTO.Id);
                    while (test.ExecuteReader().Read())
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
