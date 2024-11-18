using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Dominio.ModuloMedico;

public class Medico : Entidade
{

    public string Nome { get; set; }
    
    public DateTime DataNascimento { get; set; }
    
    public string Telefone { get; set; }
    
    public string Cpf { get; set; }
    
    public string Crm { get; set; }

    public Medico()
    {
        
    }
    
    public Medico(string nome, DateTime dataNascimento, string telefone, string cpf, string crm)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
        Telefone = telefone;
        Cpf = cpf;
        Crm = crm;
    }
    
    
}
