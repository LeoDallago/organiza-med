using FluentValidation;
using FluentValidation.TestHelper;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Testes.ModuloMedico.Testes_Unitarios;


[TestClass]
[TestCategory("Inserir Medico")]
public class Inserir_Medico
{
    [TestMethod]
    public void Deve_Inserir_Medico()
    {
        //Arrange
        Medico novoMedico;
        
        //Act
        novoMedico = new Medico
        {
            Nome = "Nome do novo medico",
            Cpf = "123.456.789-00",
            DataNascimento = DateTime.Now,
            Crm = "12345rs"
        };
        
        //Assert
        Assert.AreEqual(novoMedico.Nome, "Nome do novo medico");
    }

    [TestMethod]
    public void Deve_Inserir_Medico_Nome_Invalido()
    {
        //Arrange
        Medico novoMedico =  new Medico
        {
            Nome = "l",
            Telefone = "123456789",
            Cpf = "12345678900",
            Crm = "12345rs"
        };
        
        //Act
        var validador = new ValidaMedico();
        var resultado =  validador.TestValidate(novoMedico);
        
        //Assert
       Assert.IsFalse(resultado.IsValid);
    }
    
    [TestMethod]
    public void Deve_Inserir_Medico_Nome_Valido()
    {
        //Arrange
        Medico novoMedico =  new Medico
        {
            Nome = "leonardo",
            Telefone = "123456789",
            Cpf = "12345678900",
            Crm = "12345rs"
        };
        
        //Act
        var validador = new ValidaMedico();
        var resultado =  validador.TestValidate(novoMedico);
        
        //Assert
        Assert.IsTrue(resultado.IsValid);
    }
    
}