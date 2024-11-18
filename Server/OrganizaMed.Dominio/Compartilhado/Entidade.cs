namespace OrganizaMed.Dominio.Compartilhado;

public abstract class Entidade
{
    public Guid Id { get; set; }

    public Entidade()
    {
        Id = Guid.NewGuid();
    }
}