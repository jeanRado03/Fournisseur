using Fournisseur.Model;
using Npgsql;
using System.Reflection;

namespace Fournisseur.DataAccess
{
    public class ObjectDAO
    {
        private ConnectionManager _connectionManager;

        public ObjectDAO()
        {
            _connectionManager = new ConnectionManager("fournisseur");
        }

        public void insertObject(Object obj)
        {
            string className = obj.GetType().Name;
            using (var conn = _connectionManager.OpenConnection())
            {
                var properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

                var cmd = new NpgsqlCommand($"INSERT INTO {className} ({string.Join(", ", properties.Select(p => p.Name))}) VALUES ({string.Join(", ", properties.Select(p => $"@{p.Name}"))})", conn);

                foreach (var property in properties)
                {
                    cmd.Parameters.AddWithValue($"@{property.Name}", property.GetValue(obj));
                }
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }

        public Magasin[] magasins()
        {
            string query = $"SELECT * FROM magasin";
            using (NpgsqlConnection conn = _connectionManager.OpenConnection())
            {
                var cmd = new NpgsqlCommand(query, conn);

                using (var read = cmd.ExecuteReader())
                {
                    List<Magasin> objects = new List<Magasin>();
                    while (read.Read())
                    {
                        Magasin magasin = new Magasin()
                        {
                            idMagasin = read.GetString(0),
                            nom = read.GetString(1),
                            adresse = read.GetString(2),
                            capacite_stockage = read.GetDouble(3)
                        };
                        objects.Add(magasin);
                    }
                    return objects.ToArray();
                }
            }
        }

        public Object[] getObjects(Object obj)
        {
            string className = obj.GetType().Name;

            string query = $"SELECT * FROM {className}";
            var cmd = new NpgsqlCommand(query, _connectionManager.OpenConnection());

            using (var read = cmd.ExecuteReader())
            {
                List<Object> listObject = new List<Object>();
                while (read.Read())
                {
                    Object objet = Activator.CreateInstance(obj.GetType());
                    PropertyInfo[] properties = obj.GetType().GetProperties();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        string propertyName = properties[i].Name;
                        Type propertyType = properties[i].PropertyType;
                        object value = read.GetValue(i);
                        if (value != DBNull.Value)
                        {
                            properties[i].SetValue(objet, Convert.ChangeType(value, propertyType));
                        }
                    }
                    listObject.Add(objet);
                }
                _connectionManager.CloseConnection();
                return listObject.ToArray();
            }
        }

        public Object[] getObjectsByID(Object obj, string id)
        {
            string className = obj.GetType().Name;
            PropertyInfo[] props = obj.GetType().GetProperties();
            string references = props[0].Name;

            string query = $"SELECT * FROM {className} WHERE {references} = '{id}'";
            var cmd = new NpgsqlCommand(query, _connectionManager.OpenConnection());

            using (var read = cmd.ExecuteReader())
            {
                List<Object> listObject = new List<Object>();
                while (read.Read())
                {
                    Object objet = Activator.CreateInstance(obj.GetType());
                    PropertyInfo[] properties = obj.GetType().GetProperties();
                    for (int i = 0; i < properties.Length; i++)
                    {
                        string propertyName = properties[i].Name;
                        Type propertyType = properties[i].PropertyType;
                        object value = read.GetValue(i);
                        if (value != DBNull.Value)
                        {
                            properties[i].SetValue(objet, Convert.ChangeType(value, propertyType));
                        }
                    }
                    listObject.Add(objet);
                }
                _connectionManager.CloseConnection();
                return listObject.ToArray();
            }
        }
    }
}
