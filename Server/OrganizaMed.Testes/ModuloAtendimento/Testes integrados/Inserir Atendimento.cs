using OrganizaMed.Dominio.ModuloAtendimento;
using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Compartilhado;
using OrganizaMed.Infra.ModuloAtendimento;

namespace OrganizaMed.Testes.ModuloAtendimento.Testes_integrados;


[TestClass]
[TestCategory("Inserir Atendimento")]
public class Inserir_Atendimento
{
    private OrganizaMedDbContext _dbContext;
    private RepositorioAtendimentoOrm _repositorioAtendimento;

    [TestInitialize]
    public void Inicializar()
    {
        _dbContext = new OrganizaMedDbContext();
        _dbContext.RemoveRange(_dbContext.Atendimento);
        _dbContext.SaveChanges();
        _repositorioAtendimento = new RepositorioAtendimentoOrm(_dbContext);
    }

    [TestMethod]
    public void Deve_Inserir_Atendimento()
    {
        //Arrange
        Medico novoMedico =  new Medico
        {
            Nome = "leonardo",
            Telefone = "123456789",
            Cpf = "12345678900",
            Crm = "12345rs",
            DataNascimento = new DateTime(2018, 9, 9),
        };

        Atendimento novoAtendimento = new Atendimento
        {
            Tipo = "Cirurgia",
            HoraInicio = TimeSpan.Parse("14:00:00"),
            HoraFim = TimeSpan.Parse("16:00:00"),
            Medico = novoMedico,
            MedicoId = novoMedico.Id,
        };
        
        //Act
        _repositorioAtendimento.Inserir(novoAtendimento);
        
        //Arrange
        var atentimentoInserido = _repositorioAtendimento.SelecionarPorId(novoAtendimento.Id);
        
        Assert.AreEqual(novoAtendimento.Tipo, atentimentoInserido.Tipo);
    }
}