using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.Categorie
{
    public class CategorieDAL : DBcommand, ICategorieContainer
    {
        public bool BeschikbaarCheck(CategorieDTO categorieDTO)
        {
            try
            {
                string querystring = "SELECT 1 FROM Categorie WHERE Naam = @Naam;";
                using (SqlConnection connectie = OpenSqlConnection())
                {
                    SqlCommand test = CreateCommand(querystring, connectie);
                    test.Parameters.AddWithValue("@Naam", categorieDTO.Naam);
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
        public List<CategorieDTO> AlleCategorieën()
        {
            try
            {
                List<CategorieDTO> categories = new List<CategorieDTO>();

                string queryString = "SELECT * FROM Categorie;";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CategorieDTO categorieDTO = new CategorieDTO();
                        categorieDTO.Id = (int)rdr["CategorieID"];
                        categorieDTO.Naam = (string)rdr["Naam"];
                        categories.Add(categorieDTO);
                    }
                }
                return categories;
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

        public bool CategorieAanmaken(CategorieDTO categorieDTO)
        {
            try
            {
                string queryString = "INSERT INTO Categorie (Naam) VALUES (@Na);";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);

                    cmd.Parameters.AddWithValue("@Na", categorieDTO.Naam);
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

        public bool CategorieBewerken(CategorieDTO categorieDTO)
        {
            try
            {
                string queryString = "UPDATE Categorie SET Naam = @Na WHERE CategorieID = @i;";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("@Na", categorieDTO.Naam);
                    cmd.Parameters.AddWithValue("@i", categorieDTO.Id);
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

        public bool CategorieVerwijderen(int id)
        {
            try
            {
                string queryString = "DELETE FROM Categorie WHERE CategorieID = @i;";
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

        public CategorieDTO OphalenPerId(int id)
        {
            try
            {
                string queryString = "SELECT * FROM Categorie WHERE CategorieID = @Id;";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);

                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader rdr = cmd.ExecuteReader();
                    CategorieDTO categorieDTO = new CategorieDTO();
                    while (rdr.Read())
                    {
                        categorieDTO.Id = (int)rdr["CategorieID"];
                        categorieDTO.Naam = (string)rdr["Naam"];
                        return categorieDTO;
                    }
                    return categorieDTO;
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
