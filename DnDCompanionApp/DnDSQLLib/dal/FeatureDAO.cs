using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal
{
    public class FeatureDAO
    {
        SqlConnection conn;

        public FeatureDAO()
        {
            try
            {
                conn = ConnectionFactory.GetConnection();
                conn.Open();
                conn.Close();   // Just double checking to make sure that yes, we can indeed access the server
            }
            catch (SqlException)
            {
                // Figure out how to let the user know that things just aint happening
            }
        }

        public List<Feature> GetClassFeatures(int classId)
        {
            List<Feature> features = new List<Feature>();

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select f.Id, f.Name, f.Description from features f join classFeatures cf on cf.FeatureId = f.Id where cf.ClassId = @cId");
                cmd.Parameters.AddWithValue("@cId", classId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Feature feature = new Feature(Convert.ToString(reader["Name"]), Convert.ToString(reader["Description"]));
                    feature.FeatureID = Convert.ToInt32(reader["Id"]);
                    features.Add(feature);
                }
                reader.Close();

                return features;
            }
            catch (SqlException)
            {
                // **ERROR PLACE HOLDER**
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public Feature GetFeature(int featureId)
        {
            Feature feature = null;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select f.Id, f.Name, f.Description from features f" +
                    $"where f.Id = @fId");
                cmd.Parameters.AddWithValue("@fId", featureId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    feature = new Feature(Convert.ToString(reader["Name"]), Convert.ToString(reader["Description"]));
                    feature.FeatureID = Convert.ToInt32(reader["Id"]);
                }
                reader.Close();

                return feature;
            }
            catch (SqlException)
            {
                // **ERROR PLACE HOLDER**
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
