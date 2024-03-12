using System.Data.SqlClient;
using webapp_project.Models;
namespace webapp_project.Services
{
    public class ProductService
    {

        private static string db_source = "webserver143.database.windows.net";
        private static string db_uber = "sqladmin";
        private static string db_password = "260404JHONn!";
        private static string db_database = "websql";

        private SqlConnection GetConnection()
        {
           var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_uber;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);

        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> products = new List<Product>();
            string consulta = "SELECT ProductID,ProductName,Quantity from Products";

            conn.Open();
            SqlCommand cmd = new SqlCommand(consulta, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity=reader.GetInt32(2)
                        
                    };
                    products.Add(product);

                }
            };
            conn.Close();
            return products;
        }
    }
}
