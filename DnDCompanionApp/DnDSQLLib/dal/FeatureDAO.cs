using CharacterCreationLib;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSQLLib.dal {
    /// <summary>
    /// Interface between the feature table in the database and the feature logic class
    /// </summary>
    public class FeatureDAO {

        /// <summary>
        /// Database connection
        /// </summary>
        SqlConnection conn;

        /// <summary>
        /// Constructor
        /// </summary>
        public FeatureDAO() {
            conn = ConnectionFactory.GetConnection();
        }

        /// <summary>
        /// Retrieves all features for a specific class
        /// </summary>
        /// <param name="classId">The class whose features must be retrieved</param>
        /// <returns>Collection of features if a class</returns>
        public List<Feature> GetClassFeatures(int classId) {
            List<Feature> features = new List<Feature>();

            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select f.Id, f.Name, f.Description from features f join classFeatures cf on cf.FeatureId = f.Id where cf.ClassId = @cId");
                cmd.Parameters.AddWithValue("@cId", classId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Feature feature = new Feature(Convert.ToString(reader["Name"]), Convert.ToString(reader["Description"]));
                    feature.FeatureID = Convert.ToInt32(reader["Id"]);
                    features.Add(feature);
                }
                reader.Close();

                return features;
            }
        }

        /// <summary>
        /// Retrieves a single feature from the database
        /// </summary>
        /// <param name="featureId">The database ID for the feature to retrieve</param>
        /// <returns>Feature object</returns>
        public Feature GetFeature(int featureId) {
            Feature feature = null;

            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"" +
                    $"select f.Id, f.Name, f.Description from features f" +
                    $"where f.Id = @fId");
                cmd.Parameters.AddWithValue("@fId", featureId);
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    feature = new Feature(Convert.ToString(reader["Name"]), Convert.ToString(reader["Description"]));
                    feature.FeatureID = Convert.ToInt32(reader["Id"]);
                }
                reader.Close();

                return feature;
            }
        }

        /// <summary>
        /// Retrieves all features in the database
        /// </summary>
        /// <returns>Collection of all features</returns>
        public List<Feature> GetAllFeatures() {
            List<Feature> features = new List<Feature>();

            using (conn = ConnectionFactory.GetConnection()) {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT Id, Name, Description from features");
                cmd.Connection = conn;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    Feature feat = new Feature(Convert.ToString(reader["Name"]), Convert.ToString(reader["Description"]));
                    feat.FeatureID = Convert.ToInt32(reader["Id"]);
                    features.Add(feat);
                }
            }
            features.Sort();
            return features;
        }
    }
}
