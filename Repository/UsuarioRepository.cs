using System.Data.SQLite;
using tl2_tp10_2023_jmfloress.Models;

namespace tl2_tp09_2023_jmfloress.Repository;
public class UsuarioRepository : IUsuarioRepository
{
    private string connectionPath = "Data Source=DataBase/kanban.db;Cache=Shared";
    public void Add(Usuario usuario)
    {
        string queryString = @"INSERT INTO Usuario (nombre_de_usuario)
                                VALUES (@nombreDeUsuario)";
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@nombreDeUsuario", usuario.NombreDeUsuario));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void Update(int id, Usuario usuario)
    {
        string queryString = @"UPDATE Usuario SET nombre_de_usuario = @nombreDeUsuario
                                WHERE id = @id";
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id", id));
            query.Parameters.Add(new SQLiteParameter("@nombreDeUsuario", usuario.NombreDeUsuario));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }

    public List<Usuario> GetAll()
    {
        string queryString = @"SELECT * FROM Usuario";
        List<Usuario> usuarios = new List<Usuario>();
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            connection.Open();
            using(SQLiteDataReader reader = query.ExecuteReader())
            {
                while(reader.Read())
                {
                    var usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                    usuarios.Add(usuario);
                }
            }
            connection.Close();
        }
        return usuarios;
    }

    public Usuario GetById(int id)
    {
        string queryString = @"SELECT * FROM Usuario
                                WHERE id = @id";
        Usuario usuario = new Usuario();
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id", id));
            connection.Open();
            using(SQLiteDataReader reader = query.ExecuteReader())
            {
                while(reader.Read())
                {
                    usuario.Id = Convert.ToInt32(reader["id"]);
                    usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                }
            }
            connection.Close();
        }

        return usuario;
    }

    public void Delete(int id)
    {
        string queryString = @"DELETE FROM Usuario WHERE id = @id";
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