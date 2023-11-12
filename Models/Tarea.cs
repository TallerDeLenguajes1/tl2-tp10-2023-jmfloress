namespace tl2_tp10_2023_jmfloress.Models;
public enum EstadoTarea{
    Ideas,
    ToDo,
    Doing,
    Review,
    Done
}
public class Tarea
{
    private int id;
    private int idTablero;
    private string nombre;
    private EstadoTarea estado;
    private string descripcion;
    private string color;
    private int? idUsuarioAsignado;

    public int Id { get => id; set => id = value; }
    public int IdTablero { get => idTablero; set => idTablero = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public EstadoTarea Estado { get => estado; set => estado = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public string Color { get => color; set => color = value; }
    public int? IdUsuarioAsignado { get => idUsuarioAsignado; set => idUsuarioAsignado = value; }
}