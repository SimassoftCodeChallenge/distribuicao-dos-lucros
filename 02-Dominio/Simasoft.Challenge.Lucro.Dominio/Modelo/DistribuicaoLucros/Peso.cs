using System;
using System.Collections.Generic;
using System.Text;

namespace Simasoft.Challenge.Lucro.Dominio.Modelo.DistribuicaoLucros
{
    public sealed class Peso
    {
        private int _areaAtuacao;
        private int _faixaSalarial;
        private int _tempoAdmissao;

        private readonly bool _ehEstagiario;

        public int PesoPorTempoDeAdmissao { get => RetornaPesoTempoAdmissao(); }
        public int PesoPorFaixaSalarial { get => RetornaPesoFaixaSalarial(); }
        public int PesoPorAreaDeAtuacao { get => RetornaPesoAreaDeAtuacao(); }

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
            if (_ehEstagiario || (_faixaSalarial > 0 && _faixaSalarial <= 3))
                return 1;
            if (_faixaSalarial > 3 && _faixaSalarial <= 5)
                return 2;
            if (_faixaSalarial > 5 && _faixaSalarial <= 8)
                return 3;
            if (_faixaSalarial > 8)
                return 5;
            return 0;
        }

        public int RetornaPesoTempoAdmissao()
        {
            if (_tempoAdmissao <= 1)
                return 1;
            if (_tempoAdmissao > 1 && _tempoAdmissao <= 3)
                return 2;
            if (_tempoAdmissao > 3 && _tempoAdmissao <= 8)
                return 3;
            if (_tempoAdmissao > 8)
                return 5;

            return 0;
        }

        public int RetornaPesoAreaDeAtuacao()
        {
            return _areaAtuacao;
        }
    }
}
