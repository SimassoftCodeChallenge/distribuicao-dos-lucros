using Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simasoft.Challenge.Lucro.Dominio.Modelo.DistribuicaoLucros
{
    public sealed class Participacao
    {
        private readonly float _salarioMinimoRegional;
        private readonly Colaborador _participante;
        private float _valorParticipacao;
        private readonly Peso _peso;

        public Participacao(Colaborador participante, float salarioMinimoRegional)
        {
            _participante = participante;
            _salarioMinimoRegional = salarioMinimoRegional;
            _peso = new Peso(_participante.Area, _participante.SalarioBruto, _participante.DataAdmissao, _salarioMinimoRegional, _participante.EhEstagiario);
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
}
