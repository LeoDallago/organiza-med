using OrganizaMed.Dominio.ModuloMedico;
using OrganizaMed.Infra.Compartilhado;
using OrganizaMed.Infra.ModuloMedico;

namespace OrganizaMed.Testes.ModuloMedico.Testes_Integrados;

[TestClass]
[TestCategory("Excluir Medico")]
public class Excluir_Medico
{
    private OrganizaMedDbContext _dbContext;
    private RepositorioMedicoOrm _repositorioMedicoOrm;
    
    
    [TestInitialize]
    public void Inicializar()
    {
        _dbContext = new OrganizaMedDbContext();
        _dbContext.RemoveRange(_dbContext.Medico);
        _dbContext.SaveChanges();
        _repositorioMedicoOrm = new RepositorioMedicoOrm(_dbContext);
    }

    [TestMethod]
    public void Deve_Excluir_Medico()
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
        
        _repositorioMedicoOrm.Inserir(novoMedico);
        var medicoInserido = _repositorioMedicoOrm.SelecionarPorId(novoMedico.Id);
        
        //Act
        _repositorioMedicoOrm.Excluir(medicoInserido);
        
        //Assert
        var medicoExcluido = _repositorioMedicoOrm.SelecionarPorId(medicoInserido.Id);
        Assert.IsNull(medicoExcluido);
    }
}