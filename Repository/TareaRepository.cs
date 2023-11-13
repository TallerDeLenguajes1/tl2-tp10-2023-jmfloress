using System.Data.Entity.Infrastructure;
using System.Data.SQLite;
using Microsoft.AspNetCore.Authentication;
using tl2_tp10_2023_jmfloress.Models;

namespace tl2_tp10_2023_jmfloress.Repository;
public class TareaRepository : ITareaRepository
{
    private string connectionPath = "Data Source=DataBase/kanban.db;Cache=shared";

    public void Add(int idTablero, Tarea tarea)
    {
        string queryString = @"INSERT INTO Tarea (id_tablero, nombre, estado, descripcion, color, id_usuario_asignado)
                                VALUES (@idTablero, @nombre, @estado, @descripcion, @color, @idUsuarioAsignado)";
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
            query.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
            query.Parameters.Add(new SQLiteParameter("@estado", tarea.Estado));
            query.Parameters.Add(new SQLiteParameter("@descripcion", tarea.Descripcion));
            query.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
            query.Parameters.Add(new SQLiteParameter("@idUsuarioAsignado", tarea.IdUsuarioAsignado));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void Update(int id, Tarea tarea)
    {
        string queryString = @"UPDATE Tarea SET id_tablero = @idTablero, nombre = @nombre, estado = @estado, descripcion = @descripcion, color = @color, id_usuario_asignado = @idUsuarioAsignado
                                WHERE id = @id";
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id", id));
            query.Parameters.Add(new SQLiteParameter("@idTablero", tarea.IdTablero));
            query.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
            query.Parameters.Add(new SQLiteParameter("@estado", tarea.Estado));
            query.Parameters.Add(new SQLiteParameter("@descripcion", tarea.Descripcion));
            query.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
            query.Parameters.Add(new SQLiteParameter("@idUsuarioAsignado", tarea.IdUsuarioAsignado));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }

    public Tarea GetById(int id)
    {
        string queryString = @"SELECT * FROM Tarea
                                WHERE id = @id";
        Tarea tarea = new Tarea();
        using (SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id", id));
            connection.Open();
            using(SQLiteDataReader reader = query.ExecuteReader())
            {
                while(reader.Read())
                {
                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.Nombre = reader["nombre"].ToString();
                    tarea.Estado = (EstadoTarea)Convert.ToInt32(reader["estado"]);
                    tarea.Descripcion = reader["descripcion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.IdUsuarioAsignado = reader["id_usuario_asignado"] == DBNull.Value ? null : Convert.ToInt32(reader["id_usuario_asignado"]);

                }
            }
            connection.Close();
        }
        return tarea;
    }

    public List<Tarea> GetByUsuario(int idUsuario)
    {
        String queryString = @"SELECT * FROM Tarea
                                WHERE id_usuario_asignado = @idUsuario";
        List<Tarea> tareas = new List<Tarea>();
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
            connection.Open();
            using(SQLiteDataReader reader = query.ExecuteReader())
            {
                while(reader.Read())
                {
                    var tarea = new Tarea();
                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.Nombre = reader["nombre"].ToString();
                    tarea.Estado = (EstadoTarea) Convert.ToInt32(reader["estado"]);
                    tarea.Descripcion = reader["descripcion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.IdUsuarioAsignado = reader["id_usuario_asignado"] == DBNull.Value ? null : Convert.ToInt32(reader["id_usuario_asignado"]);
                    tareas.Add(tarea);
                }
            }
            connection.Close();
        }
        return tareas;
    }

    public List<Tarea> GetByTablero(int idTablero)
    {
        String queryString = @"SELECT * FROM Tarea
                                WHERE id_tablero = @idTablero";
        List<Tarea> tareas = new List<Tarea>();
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
            connection.Open();
            using(SQLiteDataReader reader = query.ExecuteReader())
            {
                while(reader.Read())
                {
                    var tarea = new Tarea();
                    tarea.Id = Convert.ToInt32(reader["id"]);
                    tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                    tarea.Nombre = reader["nombre"].ToString();
                    tarea.Estado = (EstadoTarea) Convert.ToInt32(reader["estado"]);
                    tarea.Descripcion = reader["descripcion"].ToString();
                    tarea.Color = reader["color"].ToString();
                    tarea.IdUsuarioAsignado = reader["id_usuario_asignado"] == DBNull.Value ? null : Convert.ToInt32(reader["id_usuario_asignado"]);
                    tareas.Add(tarea);
                }
            }
            connection.Close();
        }
        return tareas;
    }

    public void Delete(int id)
    {
        string queryString = @"DELETE FROM Tarea WHERE id = @id";
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@id", id));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }

    public void AsignarTarea(int idUsuario, int idTarea)
    {
        string queryString = @"UPDATE Tarea SET id_usuario_asignado = @idUsuario
                                WHERE id = @idTarea";
        using(SQLiteConnection connection = new SQLiteConnection(connectionPath))
        {
            SQLiteCommand query = new SQLiteCommand(queryString, connection);
            query.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
            query.Parameters.Add(new SQLiteParameter("@idUsuario", idUsuario));
            connection.Open();
            query.ExecuteNonQuery();
            connection.Close();
        }
    }
}