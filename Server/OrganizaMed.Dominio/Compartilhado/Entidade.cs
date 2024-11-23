using OrganizaMed.Dominio.ModuloAutenticacao;

namespace OrganizaMed.Dominio.Compartilhado;

public abstract class Entidade
{
    public Guid Id { get; set; }

    public Entidade()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid UsuarioId { get; set; }
    
    public Usuario? Usuario { get; set; }
}