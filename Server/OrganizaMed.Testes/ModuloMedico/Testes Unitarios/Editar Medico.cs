using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Testes.ModuloMedico.Testes_Unitarios;

[TestClass]
[TestCategory("Editar Medico")]
public class Editar_Medico
{
    [TestMethod]
    public void Editar_Nome_Medico()
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
        novoMedico.Nome  = "Leonardo Editado";
        
        //Assert
        Assert.AreEqual(novoMedico.Nome, "Leonardo Editado");
    }
}