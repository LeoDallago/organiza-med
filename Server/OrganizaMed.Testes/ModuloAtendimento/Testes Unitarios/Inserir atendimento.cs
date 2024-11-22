using OrganizaMed.Dominio.ModuloAtendimento;
using OrganizaMed.Dominio.ModuloMedico;

namespace OrganizaMed.Testes.ModuloAtendimento.Testes_Unitarios;


[TestClass]
[TestCategory("Inserir atendimento")]
public class Inserir_atendimento
{
    [TestMethod]
    public void Deve_Inserir_atendimento()
    {
        //Arrange
       Medico novoMedico = new Medico
        {
            Nome = "Nome do novo medico",
            Cpf = "123.456.789-00",
            DataNascimento = DateTime.Now,
            Crm = "12345rs"
        };

        Atendimento novoAtendimento;
        
        //Act
        novoAtendimento = new Atendimento
        {
            Tipo = "Consulta",
            HoraInicio = TimeSpan.Parse("11:00:00"),
            HoraFim = TimeSpan.Parse("12:00:00"),
            Medico  = novoMedico,
        };
        
        //Assert
        Assert.AreEqual(novoAtendimento.Medico.Nome, novoMedico.Nome);
    }

    [TestMethod]
    public void Deve_inserir_atendimento_com_formato_invalido()
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
            Tipo = "",
            HoraInicio = TimeSpan.Parse("11:00:00"),
            HoraFim = TimeSpan.Parse("12:00:00"),
            Medico  = novoMedico,
        };
        
        //Act
        var validador = new ValidaAtendimento();
        var resultado = validador.Validate(novoAtendimento);
        
        //Assert
        Assert.IsFalse(resultado.IsValid);
    }

    [TestMethod]
    public void Deve_Inserir_atendimento_com_horario_invalido()
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
            Tipo = "",
            HoraInicio = TimeSpan.Parse("11:00:00"),
            HoraFim = TimeSpan.Parse("10:00:00"),
            Medico  = novoMedico,
        };
        
        //Act
        bool validaHora = novoAtendimento.ValidarHorario(novoAtendimento.HoraInicio, novoAtendimento.HoraFim);
        
        //Assert
        Assert.IsFalse(validaHora);
    }
}