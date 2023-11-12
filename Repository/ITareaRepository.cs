using tl2_tp10_2023_jmfloress.Models;

public interface ITareaRepository
{
    public void Add(int idTablero, Tarea tarea);
    public void Update(int id, Tarea tarea);
    public Tarea GetById(int id);
    public List<Tarea> GetByUsuario(int idUsuario);
    public List<Tarea> GetByTablero(int idTablero);
    public void Delete(int id);
    public void AsignarTarea(int idUsuario, int idTarea);
}