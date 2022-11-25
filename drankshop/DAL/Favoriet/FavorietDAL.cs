using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Favoriet
{
    public class FavorietDAL : DBcommand, IFavorietContainer
    {
        public List<FavorietDTO> FavorietenLijst(int accountID)
        {
            try
            {
                List<FavorietDTO> favoriets = new List<FavorietDTO>();

                string queryString = "SELECT * FROM Favoriet WHERE AccountID = @AI;";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("@AI", accountID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FavorietDTO favoriet = new FavorietDTO();
                        favoriet.DrankID = (int)rdr["DrankID"];
                        favoriet.AccountID = (int)rdr["AccountID"];
                        favoriets.Add(favoriet);
                    }
                }
                return favoriets;
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

        public bool FavorietToevoegen(FavorietDTO favorietDTO)
        {
            try
            {
                string querystring1 = "SELECT 1 FROM Favoriet WHERE AccountID = @aid " +                           
                                      "AND DrankID = @Id;";

                string queryString = "INSERT INTO Favoriet (AccountID, DrankID) VALUES (@AI, @DI);";

                using (SqlConnection connectie = OpenSqlConnection())
                {
                    SqlCommand test = CreateCommand(querystring1, connectie);
                    test.Parameters.AddWithValue("@aid", favorietDTO.AccountID);
                    test.Parameters.AddWithValue("@Id", favorietDTO.DrankID);
                    while (test.ExecuteReader().Read())
                    {
                        return false;
                    }
                }
                using(SqlConnection connectie = OpenSqlConnection())
                {
                        SqlCommand cmd = CreateCommand(queryString, connectie);

                    cmd.Parameters.AddWithValue("@AI", favorietDTO.AccountID);
                    cmd.Parameters.AddWithValue("@DI", favorietDTO.DrankID);
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

        public bool VerwijderFavoriet(int id)
        {
            try
            {
                string queryString = "DELETE FROM Favoriet WHERE AccountID = @i;";
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
    }
}
