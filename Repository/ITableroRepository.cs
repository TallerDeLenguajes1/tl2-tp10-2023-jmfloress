using tl2_tp10_2023_jmfloress.Models;

public interface ITableroRepository
{
    public void Add(Tablero tablero);
    public void Update(int id, Tablero tablero);
    public Tablero GetById(int id);
    public List<Tablero> GetAll();
    public List<Tablero> GetByUsuario(int idUsuario);
    public void Delete(int id);
}