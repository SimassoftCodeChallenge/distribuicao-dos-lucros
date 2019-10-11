using System.Collections.Generic;
using System.Linq;
using Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;

namespace Simasoft.Challenge.Lucro.Dominio.Modelo.DistribuicaoLucros
{
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

        public DistribuicaoLucro(List<Funcionario> funcionarios, float valorDisponibilizado, float salarioMinimoNacional)
        {
            _participantes = new List<Participacao>();            
            funcionarios.ForEach(x => {
                _participantes.Add(new Participacao(x,salarioMinimoNacional));
            });  

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
            float sb = participante.SalarioBruto;
            int pta = participante.Pesos.RetornaPesoTempoAdmissao();
            int pfs = participante.Pesos.RetornaPesoFaixaSalarial();
            int paa = participante.Pesos.RetornaPesoAreaDeAtuacao();

            float _valorParticipacao = (((sb * pta) + (sb * paa)) / (pfs)) * 12;
            return _valorParticipacao;
        }

        private void CalcularParticipacaoDosFuncionarios()
        {
            foreach (var _funcionario in _participantes)
            {
                float _valorDeParticipacao = CalculaParticipacaoDoFuncionario(_funcionario, _salarioMinimoNacional);
                _funcionario.ValorDeParticipacaoAReceber(_valorDeParticipacao);
            }
        }

        public IReadOnlyCollection<Participacao> Participantes => _participantes.ToArray();

        private int InformaTotalDeFuncionarios() => _participantes.ToArray().Length;
        private float InformaTotalDistribuido() => _participantes.ToArray().Sum(x => x.ValorDeParticipacaoRecebido());
        private float InformaSaldoTotalDisponibilizado() => _valorDisponibilizado - InformaTotalDistribuido();
    }
}
