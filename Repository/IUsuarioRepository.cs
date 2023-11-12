using tl2_tp10_2023_jmfloress.Models;

public interface IUsuarioRepository
{
    public void Add(Usuario usuario);
    public void Update(int id, Usuario usuario);
    public List<Usuario> GetAll();
    public Usuario GetById(int id);
    public void Delete(int id);
}