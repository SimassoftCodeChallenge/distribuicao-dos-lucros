using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tdd.Simasoft.Challenge.Lucro.Tdd
{
    [TestClass]
    public class IdeiaInicialTeste: BaseTeste
    {
        [TestMethod()]
        public void CriaFuncionario(){
            Funcionario vitorWilson = Funcionario.of(0009968,"Victor Wilson","Diretoria","Diretor Financeiro",12696.20f,new DateTime(2012,01,05));
            Assert.IsTrue(vitorWilson != null);
        }
    }
    
    public sealed class Funcionario
    {
        public long? Matricula { get; private set; }
        public string Nome { get; private set; }
        public string Area { get; private set; }
        public string Cargo { get; private set; }
        public float SalarioBruto { get; private set; }
        public DateTime DataAdmissao { get; private set; }

        public static Funcionario of(long? _matricula,string _nome,string _area, string _cargo, float _salarioBruto, DateTime _dataAdmissao){
            return new Funcionario(_matricula, _nome, _area, _cargo, _salarioBruto, _dataAdmissao);
        }
        private Funcionario(long? _matricula,string _nome,string _area, string _cargo, float _salarioBruto, DateTime _dataAdmissao){
            Matricula = _matricula;
            Nome = _nome;
            Area = _area;
            Cargo = _cargo;
            SalarioBruto = _salarioBruto;
            DataAdmissao = _dataAdmissao;    
        }  
    }      
    public sealed class Peso
    {
        public int AreaAtuacao { get; private set; }
        public int FaixaSalarial { get; private set; }
        public int TempoAdmissao {get; private set;}

        private Peso(){

        }

        public static int CalculaAreaDeAtuacao(string area){
            switch(area.ToLower()){
                case "diretoria":
                    return 1;                
                case "contabilidade":
                case "financeiro":
                case "tecnologia":
                    return 2;                
                case "serviços gerais":
                    return 3;                
                case "relacionamento com o cliente":
                    return 5;                
            }
            return 0;
        }

        public static int CalculaFaixaSalarial(float faixaSalarial, bool ehEstagiario)
        {
            if(ehEstagiario || (faixaSalarial > 0 && faixaSalarial <= 3))
                return 1;
            if(faixaSalarial > 3 && faixaSalarial < 5)
                return 2;
            if(faixaSalarial > 5 && faixaSalarial < 8)
                return 3;
            if(faixaSalarial > 8)
                return 5;

            return 0;            
        }

        public static int CalculaTempoAdmissao(int tempoDeCasa)
        {
            if(tempoDeCasa <= 1)
                return 1;
            if(tempoDeCasa > 1 && tempoDeCasa < 3)
                return 2;
            if(tempoDeCasa > 3 && tempoDeCasa < 8)
                return 3;
            if(tempoDeCasa > 8)
                return 5;
            
            return 0;
        }
    }
    public sealed class Participacao
    {        
        private Participacao() {}
        public static Participacao of(Funcionario participante) => new Participacao(participante);
        private Participacao(Funcionario participante)
        {
            Participante = participante;
        }
        public static Funcionario Participante { get; private set; }
        public static float ValorParticipacao { get; private set; }
        public static float CalculaParticipacao(Funcionario participante)
        {
            float sb = participante.SalarioBruto;
            int pta = Peso.CalculaTempoAdmissao(CalculaTempoAdmissao());
            int paa = 0;
            int pfs = 0;

            ValorParticipacao = (((sb * pta) + (sb * paa)) / (pfs)) * 12;

            return ValorParticipacao;
        }
        
        public static int CalculaTempoAdmissao() => Participante.DataAdmissao.Year - Participante.DataAdmissao.Year;
        public static int CalculaFaixaSalarial() => Participante.SalarioBruto / float.Parse();
        public static float CalcularParticipacao(Participante participante)
        {

        }
    }
    public class DistribuicaoLucro
    {
        public static DistribuicaoLucro of(IEnumerable<Participacao> participantes){
            return new DistribuicaoLucro(participantes);
        }
        private DistribuicaoLucro(IEnumerable<Participacao> participantes)
        {
            Participantes = participantes;
        }        
        public IReadOnlyCollection<Participacao> Participantes { get; private set; }        

        public static float TotalDisponibilizado {get; private set;}
        public float ValorDisponibilizdo { get; private set; }
        public static void RecebeValorASerDisponibilizado(float valorDisponibilizado)
        {
            ValorDisponibilizado = valorDisponibilizado;
        }

        public static float TotalDisponibilizado() => ValorDisponibilizdo;
        public static float TotalDeFuncionarios() => 0.00;
        public static float TotalDistribuido() => 0.00;        
    }
    }
}