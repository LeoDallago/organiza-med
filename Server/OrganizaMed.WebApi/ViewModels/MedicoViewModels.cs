namespace OrganizaMed.WebApi.ViewModels;

public class ListarMedicoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Crm { get; set; }
}

public class VisualizarMedicoViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
    public string Crm { get; set; }
}

public class InserirMedicoViewModel
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Telefone { get; set; }
    public string Cpf { get; set; }
    public string Crm { get; set; }
}

public class EditarMedicoViewModel : InserirMedicoViewModel {}