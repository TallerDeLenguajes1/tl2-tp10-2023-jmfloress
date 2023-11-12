using tl2_tp10_2023_jmfloress.Models;
using System.Data.SQLite;

namespace tl2_tp09_2023_jmfloress.Repository;
public class TableroRepository : ITableroRepository
{
    private string connectionPath = "Data Source=DataBase/kanban.db;Cache=Shared";

    public void Add(Tablero tablero)
    {
        string queryString = @"INSERT INTO Tablero (id_usuario_propietario, nombre, descripcion)
                                VALUES (@idUsuario, @nombre, @descripcion)";
        using (SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@idUsuario", tablero.IdUsuarioPropietario));
            query.Parameters.Add(new SQLiteParameter("@nombre", tablero.Nombre));
            query.Parameters.Add(new SQLiteParameter("@descripcion", tablero.Descripcion));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void Update(int id, Tablero tablero)
    {
        string queryString = @"UPDATE Tablero SET id_usuario_propietario = @idUsuario, nombre = @nombre, descripcion = @descripcion
                               WHERE id = @id";
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id", id));
            query.Parameters.Add(new SQLiteParameter("@idUsuario", tablero.IdUsuarioPropietario));
            query.Parameters.Add(new SQLiteParameter("@nombre", tablero.Nombre));
            query.Parameters.Add(new SQLiteParameter("@descripcion", tablero.Descripcion));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Clone();
        }
    }

    public Tablero GetById(int id)
    {
        string queryString = @"SELECT * FROM Tablero 
                               WHERE id = @id";
        Tablero tablero = new Tablero();
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id", id));
            connection.Open();
            using(SQLiteDataReader reader = query.ExecuteReader())
            {
                while(reader.Read())
                {
                    tablero.Id = Convert.ToInt32(reader["id"]);
                    tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    tablero.Nombre = reader["nombre"].ToString();
                    tablero.Descripcion = reader["descripcion"].ToString();
                }
            }
            connection.Close();
        }
        return tablero;
    }

    public List<Tablero> GetAll()
    {
        string queryString = @"SELECT * FROM Tablero";
        List<Tablero> tableros = new List<Tablero>();
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            connection.Open();
            using(SQLiteDataReader reader = query.ExecuteReader())
            {
                while(reader.Read())
                {
                    var tablero = new Tablero();
                    tablero.Id = Convert.ToInt32(reader["id"]);
                    tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    tablero.Nombre = reader["nombre"].ToString();
                    tablero.Descripcion = reader["descripcion"].ToString();
                    tableros.Add(tablero);
                }
            }
            connection.Close();
        }
        return tableros;
    }

    public List<Tablero> GetByUsuario(int idUsuario)
    {
        string queryString = @"SELECT * FROM Tablero
                               WHERE id_usuario_propietario = @idUsuario";
        List<Tablero> tableros = new List<Tablero>();
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
            connection.Open();
            using(SQLiteDataReader reader = query.ExecuteReader())
            {
                while(reader.Read())
                {
                    var tablero = new Tablero();
                    tablero.Id = Convert.ToInt32(reader["id"]);
                    tablero.IdUsuarioPropietario = Convert.ToInt32(reader["id_usuario_propietario"]);
                    tablero.Nombre = reader["nombre"].ToString();
                    tablero.Descripcion = reader["descripcion"].ToString();
                    tableros.Add(tablero);
                }
            }
            connection.Close();
        }
        return tableros;
    }

    public void Delete(int id)
    {
        string queryString = @"DELETE FROM Tablero WHERE id = @id";
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id", id));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }
}