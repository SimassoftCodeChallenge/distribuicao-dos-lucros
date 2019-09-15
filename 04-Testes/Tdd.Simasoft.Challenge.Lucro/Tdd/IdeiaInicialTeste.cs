using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Tdd.Simasoft.Challenge.Lucro.Tdd.Utils;

namespace Tdd.Simasoft.Challenge.Lucro.Tdd
{
    [TestClass]
    public class IdeiaInicialTeste: BaseTeste
    {        

        [TestMethod()]
        public void CriaFuncionarioVitorWilson()
        { 
            Funcionario vitorWilson = new Funcionario(0009968,"Victor Wilson","Diretoria","Diretor Financeiro",12696.20f,new DateTime(2012,01,05));            
            Assert.IsTrue(vitorWilson != null);
        }
        
        [TestMethod()]
        public void ConverteVitorWilsonEmParticipante()
        {
            Funcionario vitorWilson = new Funcionario(0009968, "Victor Wilson", "Diretoria", "Diretor Financeiro", 12696.20f, new DateTime(2012, 01, 05));
            Participacao participante = new Participacao(vitorWilson, salarioMinimoNacional.Value);
            Assert.IsTrue(!string.IsNullOrEmpty(participante.Nome));
        }

        [TestMethod()]
        public void GeraPesosParaVitorWilson()
        {
            Funcionario vitorWilson = new Funcionario(0009968, "Victor Wilson", "Diretoria", "Diretor Financeiro", 12696.20f, new DateTime(2012, 01, 05));
            Participacao participante = new Participacao(vitorWilson, salarioMinimoNacional.Value);
            Peso pesoVitorWilson = new Peso(participante.AreaDeAtuacao, participante.SalarioBruto, participante.DataDeAdmissao, salarioMinimoNacional.Value,participante.Estagiario);
            Assert.IsTrue(pesoVitorWilson.RetornaPesoAreaDeAtuacao() == 1 && pesoVitorWilson.RetornaPesoFaixaSalarial() == 13 && pesoVitorWilson.RetornaPesoTempoAdmissao() == 7);
        }

        [TestMethod()]
        public void DeserializaArquivoDeDadosJsonParaDominioFuncionario()
        {
            string arquivoJson = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", "")}\\baseteste.json";
            string json = File.ReadAllText($"{arquivoJson}");
            List<Funcionario> funcionarios = JsonConvert.DeserializeObject<List<Funcionario>>(json, new FuncionarioConverter());

            Assert.IsTrue(funcionarios.Count > 0);
        }

        [TestMethod()]
        public void ConverteFuncionariosDoJsonEmParticipantes()
        {
            var salarioMinimo = salarioMinimoNacional;
            List<Funcionario> funcionarios = PegaListaDeFuncionariosViaJson();
            List<Participacao> participantes = new List<Participacao>();
            funcionarios.ForEach(x =>
            {
                participantes.Add(new Participacao(x, salarioMinimo.Value));
            });
            Assert.IsTrue(participantes.Count == funcionarios.Count);
        } 
        
        [TestMethod()]
        public void CalculaParticipacaoDosFuncionariosCadastrados()
        {
            List<Participacao> participantes = PegaListaDeFuncionariosConvertidosEmParticipantes();
            var calculoParticipacao = new DistribuicaoLucro(participantes, 1000000, salarioMinimoNacional.Value);
            Assert.IsTrue(true);
        }

        public List<Participacao> PegaListaDeFuncionariosConvertidosEmParticipantes()
        {
            var salarioMinimo = salarioMinimoNacional;
            List<Funcionario> funcionarios = PegaListaDeFuncionariosViaJson();
            List<Participacao> participantes = new List<Participacao>();
            funcionarios.ForEach(x =>
            {
                participantes.Add(new Participacao(x, salarioMinimo.Value));
            });
            return participantes;
        }

        public List<Funcionario> PegaListaDeFuncionariosViaJson()
        {
            string arquivoJson = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", "")}\\baseteste.json";
            string json = File.ReadAllText($"{arquivoJson}");
            return JsonConvert.DeserializeObject<List<Funcionario>>(json, new FuncionarioConverter());
        }           
    }

    public class FuncionarioConverter : CustomCreationConverter<Funcionario>
    {
        public override Funcionario Create(Type objectType)
        {
            return new Funcionario();
        }
    }

    public sealed class Funcionario
    {
        [JsonProperty("matricula")]
        public long? Matricula { get; private set; }

        [JsonProperty("nome")]
        public string Nome { get; private set; }

        [JsonProperty("area")]
        public string Area { get; private set; }

        [JsonProperty("cargo")]
        public string Cargo { get; private set; }

        [JsonProperty("salario_bruto")]
        public float SalarioBruto { get; private set; }

        [JsonProperty("data_de_admissao")]
        public DateTime DataAdmissao { get; private set; }

        public bool EhEstagiario { get => ValidaCargoDeEstagiario(Cargo);}

        public Funcionario() { }
        
        public Funcionario(long? _matricula,string _nome,string _area, string _cargo, float _salarioBruto, DateTime _dataAdmissao)
        {
            Matricula = _matricula;
            Nome = _nome;
            Area = _area;
            Cargo = _cargo;
            SalarioBruto = _salarioBruto;
            DataAdmissao = _dataAdmissao;            
        }

        private bool ValidaCargoDeEstagiario(string cargo)
        {
            return cargo.ToLower() == "estagiário" || cargo.ToLower() == "estagiario" ? true : false;
        }
    }      

    public sealed class Peso
    {        
        private int _areaAtuacao;
        private int _faixaSalarial;
        private int _tempoAdmissao;        

        private readonly bool _ehEstagiario;

        public int PesoPorTempoDeAdmissao { get => RetornaPesoTempoAdmissao(); }
        public int PesoPorFaixaSalarial { get => RetornaPesoFaixaSalarial();}
        public int PesoPorAreaDeAtuacao { get => RetornaPesoAreaDeAtuacao();}

        public Peso(string areaAtuacao, float salarioBruto, DateTime dataAdmissao, float salarioMinimoNacional, bool estagiario)
        {            
            _areaAtuacao = CalculaPesoPorAreaDeAtuacao(areaAtuacao);
            _faixaSalarial = CalculaPesoPorFaixaSalarial(salarioBruto, salarioMinimoNacional);
            _tempoAdmissao = CalculaPesoPorTempoDeAdmissao(dataAdmissao);
            _ehEstagiario = estagiario;
        }



        private int CalculaPesoPorTempoDeAdmissao(DateTime dataAdmissao)
        {
            return DateTime.Now.Year - dataAdmissao.Year;
        }

        private int CalculaPesoPorFaixaSalarial(float salarioBruto, float salarioMinimoNacional)
        {
            return (int)Math.Round(salarioBruto / salarioMinimoNacional);
        }

        private int CalculaPesoPorAreaDeAtuacao(string areaAtuacao)
        {
            switch (areaAtuacao.ToLower())
            {
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
               
        public int RetornaPesoFaixaSalarial()
        {
            if(_ehEstagiario || (_faixaSalarial > 0 && _faixaSalarial <= 3))
                return 1;
            if(_faixaSalarial > 3 && _faixaSalarial <= 5)
                return 2;
            if(_faixaSalarial > 5 && _faixaSalarial <= 8)
                return 3;
            if(_faixaSalarial > 8)
                return 5;            
            return 0;            
        }

        public int RetornaPesoTempoAdmissao()
        {
            if(_tempoAdmissao <= 1)
                return 1;
            if(_tempoAdmissao > 1 && _tempoAdmissao <= 3)
                return 2;
            if(_tempoAdmissao > 3 && _tempoAdmissao <= 8)
                return 3;
            if(_tempoAdmissao > 8)
                return 5;
            
            return 0;
        }

        public int RetornaPesoAreaDeAtuacao()
        {
            return _areaAtuacao;
        }
    }

    public sealed class Participacao
    {
        private readonly float _salarioMinimoRegional;
        private readonly Funcionario _participante;
        private float _valorParticipacao;
        private readonly Peso _peso;

        public Participacao(Funcionario participante, float salarioMinimoRegional)
        {
            _participante = participante;
            _salarioMinimoRegional = salarioMinimoRegional;
            _peso = new Peso(_participante.Area,_participante.SalarioBruto, _participante.DataAdmissao, _salarioMinimoRegional, _participante.EhEstagiario);
        }                       

        public string AreaDeAtuacao
        {
            get => _participante.Area;
            
        }

        public float SalarioBruto
        {
            get => _participante.SalarioBruto;            
        }

        public bool Estagiario
        {
            get => _participante.EhEstagiario;
        }

        public long? Matricula
        {
            get => _participante.Matricula;
        }

        public string Nome
        {
            get => _participante.Nome;
        }

        public DateTime DataDeAdmissao
        {
            get => _participante.DataAdmissao;
        }

        public void ValorDeParticipacaoAReceber(float valorParticipacao)
        {
            _valorParticipacao = valorParticipacao;
        }

        public float ValorDeParticipacaoRecebido()
        {
            return _valorParticipacao;
        }      
        
        public Peso Pesos
        {
            get => _peso;
        }
    }

    public sealed class DistribuicaoLucro
    {
        private readonly List<Participacao> _participantes;
        private readonly float _valorDisponibilizado;
        private readonly float _salarioMinimoNacional;
        
        public DistribuicaoLucro(List<Participacao> participantes, float valorDisponibilizado, float salarioMinimoNacional)
        {
            _participantes = new List<Participacao>();
            if (participantes != null && participantes.Count > 0)
            {
                _participantes.AddRange(participantes);
            }
            _salarioMinimoNacional = salarioMinimoNacional;
            _valorDisponibilizado = valorDisponibilizado;

            CalcularParticipacaoDosFuncionarios();            
        }

        public int TotalDeFuncionarios
        {
            get => InformaTotalDeFuncionarios();
        }

        public float TotalDistribuido
        {
            get => InformaTotalDistribuido();
        }

        public float SaldoTotalDisponibilizado
        {
            get => InformaSaldoTotalDisponibilizado();
        }

        public float TotalDisponibilizado
        {
            get => _valorDisponibilizado;
        }

        private float CalculaParticipacaoDoFuncionario(Participacao participante, float salarioMinimoNacional)
        {
            //Peso peso = new Peso(participante.AreaDeAtuacao, participante.SalarioBruto, participante.DataDeAdmissao,salarioMinimoNacional,participante.Estagiario);

            float sb = participante.SalarioBruto;
            int pta = participante.Pesos.RetornaPesoTempoAdmissao();
            int pfs = participante.Pesos.RetornaPesoFaixaSalarial();
            int paa = participante.Pesos.RetornaPesoAreaDeAtuacao();

            float _valorParticipacao = (((sb * pta) + (sb * paa)) / (pfs)) * 12;
            return _valorParticipacao;
        }

        private void CalcularParticipacaoDosFuncionarios()
        {
            foreach(var _funcionario in _participantes)
            {
                float _valorDeParticipacao = CalculaParticipacaoDoFuncionario(_funcionario,_salarioMinimoNacional);
                _funcionario.ValorDeParticipacaoAReceber(_valorDeParticipacao);
            }
        }

        public IReadOnlyCollection<Participacao> Participantes => _participantes.ToArray();
        
        private int InformaTotalDeFuncionarios() => _participantes.ToArray().Length;
        private float InformaTotalDistribuido() => _participantes.ToArray().Sum(x => x.ValorDeParticipacaoRecebido());        
        private float InformaSaldoTotalDisponibilizado() => _valorDisponibilizado - InformaTotalDistribuido();
               
    }
}