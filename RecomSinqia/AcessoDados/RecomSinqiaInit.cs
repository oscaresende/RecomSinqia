using RecomSinqia.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RecomSinqia.AcessoDados
{
	public class RecomSinqiaInit : CreateDatabaseIfNotExists<RecomSinqiaContexto>
	{
		protected override void Seed(RecomSinqiaContexto contexto)
		{
            List<Gerencia> Gerencias = new List<Gerencia>()
            {
                #region GERENCIA
                new Gerencia() { Nome = "Atendimento"},
                new Gerencia() { Nome = "Desenvolvimento"}
                #endregion
            };

            Gerencias.ForEach(g => contexto.Gerencia.Add(g));

            List<Cliente> Clientes = new List<Cliente>()
            {
                #region CLIENTES
                new Cliente() { Nome = "AERUS"},
                new Cliente() { Nome = "AGROS"},
                new Cliente() { Nome = "ALEPEPREV"},
                new Cliente() { Nome = "BANESES"},
                new Cliente() { Nome = "BASES"},
                new Cliente() { Nome = "BRF"},
                new Cliente() { Nome = "CABEC"},
                new Cliente() { Nome = "CAFBEP"},
                new Cliente() { Nome = "CAGEPREV"},
                new Cliente() { Nome = "CAPAF"},
                new Cliente() { Nome = "CAPOF"},
                new Cliente() { Nome = "CARFEPE"},
                new Cliente() { Nome = "CELPOS"},
                new Cliente() { Nome = "CERES"},
                new Cliente() { Nome = "CIBRIUS"},
                new Cliente() { Nome = "COMPESAPREV"},
                new Cliente() { Nome = "ECOS"},
                new Cliente() { Nome = "ENGENHONOVO"},
                new Cliente() { Nome = "FABASA"},
                new Cliente() { Nome = "FACEAL"},
                new Cliente() { Nome = "FAPECE"},
                new Cliente() { Nome = "FASCEMAR"},
                new Cliente() { Nome = "FIBRA"},
                new Cliente() { Nome = "FUNCASAL"},
                new Cliente() { Nome = "FUNCORSAN"},
                new Cliente() { Nome = "GEIPREV"},
                new Cliente() { Nome = "IDEIA3"},
                new Cliente() { Nome = "ODP"},
                new Cliente() { Nome = "PORTUS"},
                new Cliente() { Nome = "PREVBAHIA"},
                new Cliente() { Nome = "PREVCOM-BrC"},
                new Cliente() { Nome = "PREVCOM-MG"},
                new Cliente() { Nome = "PREVES "},
                new Cliente() { Nome = "SARAHPREV"},
                new Cliente() { Nome = "SERGUS"},
                new Cliente() { Nome = "UASPREV"}
                #endregion
            };

            Clientes.ForEach(g => contexto.Cliente.Add(g));

            List<Sistema> Sistemas = new List<Sistema>()
            {
                #region SISTEMA
                new Sistema() { Nome = "Atenaprev.Net - Ativo Fixo"},
                new Sistema() { Nome = "Atenaprev.Net - Benefício"},
                new Sistema() { Nome = "Atenaprev.Net - Contábil"},
                new Sistema() { Nome = "Atenaprev.Net - Contratos"},
                new Sistema() { Nome = "Atenaprev.Net - Empréstimo"},
                new Sistema() { Nome = "Atenaprev.Net - Financeiro"},
                new Sistema() { Nome = "Atenaprev.Net - Imóveis"},
                new Sistema() { Nome = "Atenaprev.Net - Investimento"},
                new Sistema() { Nome = "Atenaprev.Net - Materiais"},
                new Sistema() { Nome = "Atenaprev.Net - Orçamento"},
                new Sistema() { Nome = "Atenaprev.Net - Portal – Área Externa"},
                new Sistema() { Nome = "Atenaprev.Net - Portal – Área Restrita"},
                new Sistema() { Nome = "Atenaprev.Net - Protocolo"},
                new Sistema() { Nome = "Manifestação de Cliente"},
                new Sistema() { Nome = "Sistema Ativo Fixo"},
                new Sistema() { Nome = "Sistema Cálculo de Cotas"},
                new Sistema() { Nome = "Sistema Contábil"},
                new Sistema() { Nome = "Sistema de Atendimento"},
                new Sistema() { Nome = "Sistema de Benefícios"},
                new Sistema() { Nome = "Sistema de Empréstimo"},
                new Sistema() { Nome = "Sistema de Imóveis"},
                new Sistema() { Nome = "Sistema de Investimento"},
                new Sistema() { Nome = "Sistema de Orçamento"},
                new Sistema() { Nome = "Sistema Financeiro"},
                new Sistema() { Nome = "Sistema Internet"}
                #endregion
            };

            Sistemas.ForEach(g => contexto.Sistema.Add(g));

            List<Modulo> Modulos = new List<Modulo>()
            {
                #region MODULO
                new Modulo() { Nome = "Atendimento - Beneficios"},
                new Modulo() { Nome = "Atendimento - Emprestimos"},
                new Modulo() { Nome = "Ativo Fixo - Acompanhamento"},
                new Modulo() { Nome = "Ativo Fixo - Cadastro"},
                new Modulo() { Nome = "Ativo Fixo - Encerramento de Exercicio"},
                new Modulo() { Nome = "Ativo Fixo - Fechamento"},
                new Modulo() { Nome = "Ativo Fixo - Integração com Contabilidade"},
                new Modulo() { Nome = "Ativo Fixo - Movimentação"},
                new Modulo() { Nome = "Ativo Fixo - Relatórios"},
                new Modulo() { Nome = "Benefício - Acesso"},
                new Modulo() { Nome = "Benefício - Adesão"},
                new Modulo() { Nome = "Benefício - Arrecadação"},
                new Modulo() { Nome = "Benefício - Atuário"},
                new Modulo() { Nome = "Benefício - Cadastro"},
                new Modulo() { Nome = "Beneficio - Cálculo de Cotas"},
                new Modulo() { Nome = "Benefício - Cálculo Estatuto Primitivo"},
                new Modulo() { Nome = "Benefício - Concessão de Benefícios"},
                new Modulo() { Nome = "Beneficio - Contribuições"},
                new Modulo() { Nome = "Benefício - DIRF"},
                new Modulo() { Nome = "Benefício - DPREV"},
                new Modulo() { Nome = "Benefício - e-Financeira"},
                new Modulo() { Nome = "Benefício - Estorno"},
                new Modulo() { Nome = "Beneficio - Etiqueta"},
                new Modulo() { Nome = "Benefício - Extrato do Participante"},
                new Modulo() { Nome = "Benefício - Fechamento Contábil"},
                new Modulo() { Nome = "Benefício - Fechamento da Reserva"},
                new Modulo() { Nome = "Beneficio - Ficha Financeira"},
                new Modulo() { Nome = "Benefício - Folha de Benefícios"},
                new Modulo() { Nome = "Beneficio - Geração de Cobrança em Atraso"},
                new Modulo() { Nome = "Benefício - Geração de Cobrança Mensal"},
                new Modulo() { Nome = "Benefício - Geral"},
                new Modulo() { Nome = "Benefício - IN 1452"},
                new Modulo() { Nome = "Benefício - Institutos BPD"},
                new Modulo() { Nome = "Benefício - Institutos Portabilidade"},
                new Modulo() { Nome = "Benefício - Institutos Resgate"},
                new Modulo() { Nome = "Benefício - Institutos"},
                new Modulo() { Nome = "Benefício - Integração Banco"},
                new Modulo() { Nome = "Benefício - Integração com Contabilidade"},
                new Modulo() { Nome = "Benefício - Integração com Empréstimo"},
                new Modulo() { Nome = "Benefício - Integração com Financeiro"},
                new Modulo() { Nome = "Benefício - Integração com Patrocinadora"},
                new Modulo() { Nome = "Benefício - Integração com PREVIC"},
                new Modulo() { Nome = "Benefício - Integração com Site"},
                new Modulo() { Nome = "Benefício - Integração com Terceiros"},
                new Modulo() { Nome = "Benefício - Manutenção das Contribuições"},
                new Modulo() { Nome = "Benefício - Manutenção INSS"},
                new Modulo() { Nome = "Benefício - Parâmetros"},
                new Modulo() { Nome = "Benefício - Parcela Isenta"},
                new Modulo() { Nome = "Benefício - Portabilidade de Saída"},
                new Modulo() { Nome = "Benefício - PREVIC"},
                new Modulo() { Nome = "Benefício - Reajuste de Benefícios"},
                new Modulo() { Nome = "Benefício - Reativação de Benefício"},
                new Modulo() { Nome = "Benefício - Recadastramento"},
                new Modulo() { Nome = "Benefício - Recalculo de Benefício"},
                new Modulo() { Nome = "Benefício - Relatórios"},
                new Modulo() { Nome = "Benefício - Renovação de Auxílio Doença"},
                new Modulo() { Nome = "Beneficio - Suspensão de Benefício"},
                new Modulo() { Nome = "Benefício - Tabelas"},
                new Modulo() { Nome = "Contábil - Acesso"},
                new Modulo() { Nome = "Contábil - Cadastro"},
                new Modulo() { Nome = "Contábil - Cálculo de Cotas"},
                new Modulo() { Nome = "Contábil - Demonstrações"},
                new Modulo() { Nome = "Contabil - Encerramento de Exercicio"},
                new Modulo() { Nome = "Contábil - Exportação Previc"},
                new Modulo() { Nome = "Contábil - Exportação RF (SPED, EFD, etc)"},
                new Modulo() { Nome = "Contábil - Fechamento"},
                new Modulo() { Nome = "Contábil - Integração"},
                new Modulo() { Nome = "Contábil - Movimentação"},
                new Modulo() { Nome = "Contábil - Parâmetros"},
                new Modulo() { Nome = "Contábil - Relatórios"},
                new Modulo() { Nome = "Contratos - Cadastro"},
                new Modulo() { Nome = "Contratos - Integração"},
                new Modulo() { Nome = "Contratos - Relatórios"},
                new Modulo() { Nome = "Data Limite"},
                new Modulo() { Nome = "Desempenho de Rotina"},
                new Modulo() { Nome = "Empréstimo - Acesso"},
                new Modulo() { Nome = "Empréstimo - Amortização Extra"},
                new Modulo() { Nome = "Empréstimo - Amortização Individual"},
                new Modulo() { Nome = "Empréstimo - Boleto"},
                new Modulo() { Nome = "Empréstimo - Cadastro"},
                new Modulo() { Nome = "Emprestimo - Calculo da TIR"},
                new Modulo() { Nome = "Empréstimo - Concessão"},
                new Modulo() { Nome = "Empréstimo - Exclusão de Movimento"},
                new Modulo() { Nome = "Empréstimo - Fechamento"},
                new Modulo() { Nome = "Empréstimo - Geração da Prestação"},
                new Modulo() { Nome = "Empréstimo - Integração Cobrança Banco"},
                new Modulo() { Nome = "Empréstimo - Integração com Benefício"},
                new Modulo() { Nome = "Empréstimo - Integração com Internet"},
                new Modulo() { Nome = "Empréstimo - Integração com Investimento"},
                new Modulo() { Nome = "Empréstimo - Integração Concessão Banco"},
                new Modulo() { Nome = "Empréstimo - Integração Contábil"},
                new Modulo() { Nome = "Empréstimo - Integração Financeiro"},
                new Modulo() { Nome = "Empréstimo - Integração Patrocinadora"},
                new Modulo() { Nome = "Empréstimo - Integração Seguradora"},
                new Modulo() { Nome = "Empréstimo - Liberar"},
                new Modulo() { Nome = "Empréstimo - Liquidação"},
                new Modulo() { Nome = "Empréstimo - Movimentação"},
                new Modulo() { Nome = "Empréstimo - Parâmetros"},
                new Modulo() { Nome = "Empréstimo - Provisão de Perda"},
                new Modulo() { Nome = "Empréstimo - Relatórios"},
                new Modulo() { Nome = "Empréstimo - Repactuação"},
                new Modulo() { Nome = "Empréstimo - Suspensão do Contrato"},
                new Modulo() { Nome = "Financeiro - Acesso"},
                new Modulo() { Nome = "Financeiro - Adiantamento"},
                new Modulo() { Nome = "Financeiro - Autorização de PP/PR"},
                new Modulo() { Nome = "Financeiro - Banco Conciliado"},
                new Modulo() { Nome = "Financeiro - Banco Disponível"},
                new Modulo() { Nome = "Financeiro - Cadastro"},
                new Modulo() { Nome = "Financeiro - DCTF"},
                new Modulo() { Nome = "Financeiro - DIRF"},
                new Modulo() { Nome = "Financeiro - Exportação"},
                new Modulo() { Nome = "Financeiro - Fechamento"},
                new Modulo() { Nome = "Financeiro - Fluxo de Caixa"},
                new Modulo() { Nome = "Financeiro - Integração"},
                new Modulo() { Nome = "Financeiro - Movimentação Bancária"},
                new Modulo() { Nome = "Financeiro - Parâmetros"},
                new Modulo() { Nome = "Financeiro - Relatórios"},
                new Modulo() { Nome = "Financeiro - Retenções"},
                new Modulo() { Nome = "Financeiro - Valores a Pagar"},
                new Modulo() { Nome = "Financeiro - Valores a Receber"},
                new Modulo() { Nome = "Imóveis - Acesso"},
                new Modulo() { Nome = "Imóveis - Aluguel"},
                new Modulo() { Nome = "Imóveis - Cadastro"},
                new Modulo() { Nome = "Imóveis - Integração Financeiro"},
                new Modulo() { Nome = "Imóveis - Movimento"},
                new Modulo() { Nome = "Imóveis - Parametros"},
                new Modulo() { Nome = "Imóveis - Processamento"},
                new Modulo() { Nome = "Imóveis - Relatórios"},
                new Modulo() { Nome = "Investimento - Ações"},
                new Modulo() { Nome = "Investimentos - Acesso"},
                new Modulo() { Nome = "Investimentos - Cadastro"},
                new Modulo() { Nome = "Investimentos - Cálculo da TIR"},
                new Modulo() { Nome = "Investimentos - Fechamento Renda Fixa "},
                new Modulo() { Nome = "Investimentos - Fechamento Renda Variável"},
                new Modulo() { Nome = "Investimentos - Fundos"},
                new Modulo() { Nome = "Investimentos - Índices"},
                new Modulo() { Nome = "Investimentos - Integração"},
                new Modulo() { Nome = "Investimentos - Parâmetros"},
                new Modulo() { Nome = "Investimentos - Posição contábil"},
                new Modulo() { Nome = "Investimentos - Previsão de Resgate Renda Fixa"},
                new Modulo() { Nome = "Investimentos - Relatório de Renda Fixa"},
                new Modulo() { Nome = "Investimentos - Relatórios Gerenciais"},
                new Modulo() { Nome = "Investimentos - Relatórios Renda Variável "},
                new Modulo() { Nome = "Investimentos - Renda Variável"},
                new Modulo() { Nome = "Investimentos - Resgate"},
                new Modulo() { Nome = "Investimentos - Títulos de Renda Fixa - Relatórios"},
                new Modulo() { Nome = "Materiais - Cadastro"},
                new Modulo() { Nome = "Orçamento - Acesso"},
                new Modulo() { Nome = "Orçamento - Acompanhamento"},
                new Modulo() { Nome = "Orçamento - Analise Comparativa"},
                new Modulo() { Nome = "Orçamento - Associar Contas"},
                new Modulo() { Nome = "Orçamento - Cadastro"},
                new Modulo() { Nome = "Orçamento - Justificativa"},
                new Modulo() { Nome = "Orçamento - Parametros"},
                new Modulo() { Nome = "Orçamento - Plano de Contas"},
                new Modulo() { Nome = "Orçamento - Previsão"},
                new Modulo() { Nome = "Orçamento - Relatórios"},
                new Modulo() { Nome = "Portal - Acesso"},
                new Modulo() { Nome = "Portal - Benefício"},
                new Modulo() { Nome = "Portal - Cadastro"},
                new Modulo() { Nome = "Protocolo - Tramitação"},
                new Modulo() { Nome = "Script"},
                new Modulo() { Nome = "Serviços online"},
                new Modulo() { Nome = "Site"}
                #endregion
            };

            Modulos.ForEach(g => contexto.Modulo.Add(g));

            List<Classificacao> Classificacoes = new List<Classificacao>()
            {
                #region CLASSIFICACAO
                new Classificacao() { Nome = "Suporte", Sigla = "S" },
                new Classificacao() { Nome = "Melhoria", Sigla = "M" },
                new Classificacao() { Nome = "Requisição", Sigla = "R" },
                new Classificacao() { Nome = "Legislação", Sigla = "L" }
                #endregion

            };

            Classificacoes.ForEach(g => contexto.Classificacao.Add(g));

            List<TipoFalha> TiposFalhas = new List<TipoFalha>()
			{
                #region TIPOFALHA
                new TipoFalha() { Nome = "Falha de Sistema"},
				new TipoFalha() { Nome = "Falha de Operação"},
				new TipoFalha() { Nome = "Melhorias"},
				new TipoFalha() { Nome = "Procedimento"},
				new TipoFalha() { Nome = "Falta de Informação na Base"}
                #endregion

            };

			TiposFalhas.ForEach(g => contexto.TipoFalha.Add(g));

			List<Prioridade> Prioridades = new List<Prioridade>()
			{
                #region PRIORIDADE
                new Prioridade() { Nome = "Baixa"},
				new Prioridade() { Nome = "Média"},
				new Prioridade() { Nome = "Alta"},
				new Prioridade() { Nome = "Crítica"}
                #endregion
            };

			Prioridades.ForEach(g => contexto.Prioridade.Add(g));

            List<Dificuldade> Dificuldades = new List<Dificuldade>()
            {
                #region DIFICULDADE
                new Dificuldade() { Nome = "Fácil"},
                new Dificuldade() { Nome = "Médio"},
                new Dificuldade() { Nome = "Difícil 1"},
                new Dificuldade() { Nome = "Difícil 2"},
                new Dificuldade() { Nome = "Difícil 3"}
                #endregion
            };

            Dificuldades.ForEach(g => contexto.Dificuldade.Add(g));

            List<Colaborador> Colaboradores = new List<Colaborador>()
			{
                #region COLABORADOR
                new Colaborador() { Nome = "Leonardo Veiga"},
                new Colaborador() { Nome = "Jonatas Eduardo"},
                new Colaborador() { Nome = "Luis Oscar"},
                new Colaborador() { Nome = "Jessele Bonfim"},
                new Colaborador() { Nome = "Kênia Guimarães"},
                new Colaborador() { Nome = "Rafael Miranda"},
                new Colaborador() { Nome = "Tiago Reis"},
                new Colaborador() { Nome = "Anthonio Matheus"},
                new Colaborador() { Nome = "Matheus Machado"},
                new Colaborador() { Nome = "Jessica Neves"},
                new Colaborador() { Nome = "Glauber Santos"},
                new Colaborador() { Nome = "Tiago Dória"},
                new Colaborador() { Nome = "Marcelo Henrique"},
                new Colaborador() { Nome = "Mauricio Menezes"},
                new Colaborador() { Nome = "Ronaldo Chaves"}
                #endregion
            };

			Colaboradores.ForEach(g => contexto.Colaborador.Add(g));

			contexto.SaveChanges();
		}

	}
}