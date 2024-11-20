using OrganizaMed.Dominio.ModuloAtendimento;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Testes.ModuloAtendimento.Testes_Unitarios;


[TestClass]
[TestCategory("Editar Atendimento")]
public class Editar_Atendimento
{
    [TestMethod]
    public void Deve_Editar_Atendimento()
    {
        //Arrange
        Medico novoMedico = new Medico
        {
            Nome = "Nome do novo medico",
            Cpf = "123.456.789-00",
            DataNascimento = DateTime.Now,
            Crm = "12345rs"
        };
        
        Atendimento novoAtendimento = new Atendimento
        {
            Tipo = "Consulta",
            HoraInicio = DateTime.UtcNow,
            HoraFim = DateTime.UtcNow.AddHours(1),
            Medico  = novoMedico,
        };
        
        //Act
        novoAtendimento.Tipo = "Cirurgia";
        novoAtendimento.Medico.Nome = "Fulano";
        
        //Assert
        Assert.AreEqual(novoAtendimento.Tipo, "Cirurgia");
        Assert.AreEqual(novoAtendimento.Medico.Nome, "Fulano");
    }
}