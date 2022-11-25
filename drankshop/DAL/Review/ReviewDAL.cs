using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.Review
{
    public class ReviewDAL : DBcommand, IReviewContainer
    {
        public List<ReviewDTO> ReviewPerAccount(int accountID)
        {
            try
            {
                List<ReviewDTO> reviews = new List<ReviewDTO>();

                string queryString = "SELECT * FROM Review WHERE AccountID = @AI;";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("@AI", accountID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ReviewDTO review = new ReviewDTO();
                        review.Id = (int)rdr["ReviewID"];
                        review.Beschrijving = (string)rdr["Beschrijving"];
                        review.Cijfer = (int)rdr["Cijfer"];
                        review.AccountID = (int)rdr["AccountID"];
                        reviews.Add(review);
                    }
                }
                return reviews;
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

        public List<ReviewDTO> ReviewPerDrank(int drankID)
        {
            try
            {
                List<ReviewDTO> reviews = new List<ReviewDTO>();

                string queryString = "SELECT * FROM Review WHERE DrankID = @DI;";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);
                    cmd.Parameters.AddWithValue("@DI", drankID);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ReviewDTO review = new ReviewDTO();
                        review.Id = (int)rdr["ReviewID"];
                        review.Beschrijving = (string)rdr["Beschrijving"];
                        review.Cijfer = (int)rdr["Cijfer"];
                        review.AccountID = (int)rdr["DrankID"];
                        reviews.Add(review);
                    }
                }
                return reviews;
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

        public bool SchrijfReview(ReviewDTO reviewDTO)
        {
            try
            {
                string queryString = "INSERT INTO Review (AccountID, DrankID, Beschrijving, Cijfer) VALUES (@AI, @DI, @BS, @CF);";
                using (SqlConnection conn = OpenSqlConnection())
                {
                    SqlCommand cmd = CreateCommand(queryString, conn);

                    cmd.Parameters.AddWithValue("@AI", reviewDTO.AccountID);
                    cmd.Parameters.AddWithValue("@DI", reviewDTO.DrankID);
                    cmd.Parameters.AddWithValue("@BS", reviewDTO.Beschrijving);
                    cmd.Parameters.AddWithValue("@CF", reviewDTO.Cijfer);
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

        public bool VerwijderReview(int id)
        {
            try
            {
                string queryString = "DELETE FROM Review WHERE ReviewID = @i;";
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
