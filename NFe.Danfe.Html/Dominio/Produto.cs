// ===================================================================
//  Empresa: DSBR - Empresa de Desenvolvimento de Sistemas
//  Projeto: DSBR - Automação Comercial
//  Autores:  Valnei Filho, Vagner Marcelo
//  E-mail: dsbrbrasil@yahoo.com.br
//  Data Criação: 10/04/2020
//  Todos os direitos reservados
// ===================================================================


namespace NFe.Danfe.Html.Dominio
{
    public class Produto
    {
        #region Propriedades

        /// <summary>
        ///     Código do produto
        /// </summary>
        public string Codigo { get; }

        /// <summary>
        ///     Descrição do produto
        /// </summary>
        public string Descricao { get; }

        /// <summary>
        ///     Informações adicionais do produto
        /// </summary>
        public string InfAdic { get; }

        /// <summary>
        ///     Unidade do produto
        /// </summary>
        public string Unidade { get; }

        /// <summary>
        ///     Quantidade do produto
        /// </summary>
        public decimal Quantidade { get; }

        /// <summary>
        ///     Valor unitário do produto
        /// </summary>
        public decimal ValorUnitario { get; }

        /// <summary>
        ///     Valor IMCS
        /// </summary>
        public decimal VIcms { get; }

        /// <summary>
        ///     Código NNCM
        /// </summary>
        public string Ncm { get; }

        /// <summary>
        ///     Código CFOP
        /// </summary>
        public string Cfop { get; }

        /// <summary>
        ///     Origem Mercadoria
        /// </summary>
        public string Origem { get; }

        /// <summary>
        ///     Base de calculo
        /// </summary>
        public decimal BaseCalculo { get; }

        /// <summary>
        ///     Percentual ICMS
        /// </summary>
        public decimal PIcms { get; }

        /// <summary>
        ///     IPI
        /// </summary>
        public decimal? ValorIpi { get; }

        /// <summary>
        ///      Percentual IPI
        /// </summary>
        public decimal? PIpi { get; }

        /// <summary>
        /// Valor Total
        /// </summary>
        public decimal ValorTotal { get; set; }

        /// <summary>
        ///     Base de cálculo do IPI
        /// </summary>
        public decimal? BaseCalculoIpi { get; }

        /// <summary>
        ///     Classificação tributária do IBS/CBS (cClassTrib - UB14)
        /// </summary>
        public string CClassTrib { get; }

        /// <summary>
        ///     Base de cálculo do IBS/CBS (vBC - UB16)
        /// </summary>
        public decimal? BaseCalculoIbsCbs { get; }

        /// <summary>
        ///     Base de cálculo do Imposto Seletivo (vBCIS - UB05)
        /// </summary>
        public decimal? BaseCalculoIs { get; }

        /// <summary>
        ///     Alíquota do IBS UF. Alíquota efetiva (pAliqEfet) quando houver redução (gRed), senão pIBSUF
        /// </summary>
        public decimal? PIbsUf { get; }

        /// <summary>
        ///     Valor do IBS UF (vIBSUF - UB35)
        /// </summary>
        public decimal? VIbsUf { get; }

        /// <summary>
        ///     Alíquota do IBS Município. Alíquota efetiva (pAliqEfet) quando houver redução (gRed), senão pIBSMun
        /// </summary>
        public decimal? PIbsMun { get; }

        /// <summary>
        ///     Valor do IBS Município (vIBSMun - UB54)
        /// </summary>
        public decimal? VIbsMun { get; }

        /// <summary>
        ///     Alíquota da CBS. Alíquota efetiva (pAliqEfet) quando houver redução (gRed), senão pCBS
        /// </summary>
        public decimal? PCbs { get; }

        /// <summary>
        ///     Valor da CBS (vCBS - UB67)
        /// </summary>
        public decimal? VCbs { get; }

        /// <summary>
        ///     Alíquota do Imposto Seletivo (pIS - UB06)
        /// </summary>
        public decimal? PIs { get; }

        /// <summary>
        ///     Valor do Imposto Seletivo (vIS - UB11)
        /// </summary>
        public decimal? VIs { get; }

        #endregion

        #region Construtor

        /// <summary>
        ///     NFe
        /// </summary>
        /// <param name="codigo">Código</param>
        /// <param name="descricao">Descrição</param>
        /// <param name="infAdic">Informações adicionais</param>
        /// <param name="unidade">Unidade de medida</param>
        /// <param name="quantidade">Quantidade</param>
        /// <param name="valorUnitario">Valor unitário</param>
        /// <param name="valorIcms">Valor do ICMS</param>
        /// <param name="ncm">Código NCM</param>
        /// <param name="cfop">Código CFOP</param>
        /// <param name="origem">{0- Nacional | 1 Importado}</param>
        /// <param name="baseCalculo">Base de cálculo</param>
        /// <param name="pIcms">Percentual ICMS</param>
        /// <param name="pIpI">Percentual IPI</param>
        /// <param name="vIpi">Valor percentual do IPI</param>
        /// <param name="valorTotal">Valor Total</param>
        public Produto(string codigo, string descricao, string infAdic, string unidade, decimal quantidade, decimal valorUnitario,
                decimal valorIcms, string ncm, string cfop, string origem, decimal baseCalculo, decimal pIcms, decimal? pIpI,
                decimal? vIpi,decimal valorTotal)
        {
            Codigo = codigo;
            Descricao = descricao;
            InfAdic = infAdic;
            Unidade = unidade;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            VIcms = valorIcms;
            Ncm = ncm;
            Cfop = cfop;
            Origem = origem;
            BaseCalculo = baseCalculo;
            PIcms = pIcms;
            ValorIpi = vIpi;
            PIpi = pIpI;
            ValorTotal = valorTotal;
        }

        /// <summary>
        ///     NFe com os campos da Reforma Tributária (IBS, CBS e IS)
        /// </summary>
        /// <param name="codigo">Código</param>
        /// <param name="descricao">Descrição</param>
        /// <param name="infAdic">Informações adicionais</param>
        /// <param name="unidade">Unidade de medida</param>
        /// <param name="quantidade">Quantidade</param>
        /// <param name="valorUnitario">Valor unitário</param>
        /// <param name="valorIcms">Valor do ICMS</param>
        /// <param name="ncm">Código NCM</param>
        /// <param name="cfop">Código CFOP</param>
        /// <param name="origem">{0- Nacional | 1 Importado}</param>
        /// <param name="baseCalculo">Base de cálculo</param>
        /// <param name="pIcms">Percentual ICMS</param>
        /// <param name="pIpI">Percentual IPI</param>
        /// <param name="vIpi">Valor percentual do IPI</param>
        /// <param name="valorTotal">Valor Total</param>
        /// <param name="baseCalculoIpi">Base de cálculo do IPI</param>
        /// <param name="cClassTrib">Classificação tributária do IBS/CBS</param>
        /// <param name="baseCalculoIbsCbs">Base de cálculo do IBS/CBS</param>
        /// <param name="baseCalculoIs">Base de cálculo do IS</param>
        /// <param name="pIbsUf">Alíquota do IBS UF (efetiva quando houver gRed)</param>
        /// <param name="vIbsUf">Valor do IBS UF</param>
        /// <param name="pIbsMun">Alíquota do IBS Município (efetiva quando houver gRed)</param>
        /// <param name="vIbsMun">Valor do IBS Município</param>
        /// <param name="pCbs">Alíquota da CBS (efetiva quando houver gRed)</param>
        /// <param name="vCbs">Valor da CBS</param>
        /// <param name="pIs">Alíquota do IS</param>
        /// <param name="vIs">Valor do IS</param>
        public Produto(string codigo, string descricao, string infAdic, string unidade, decimal quantidade, decimal valorUnitario,
                decimal valorIcms, string ncm, string cfop, string origem, decimal baseCalculo, decimal pIcms, decimal? pIpI,
                decimal? vIpi, decimal valorTotal, decimal? baseCalculoIpi, string cClassTrib = null,
                decimal? baseCalculoIbsCbs = null, decimal? baseCalculoIs = null, decimal? pIbsUf = null,
                decimal? vIbsUf = null, decimal? pIbsMun = null, decimal? vIbsMun = null, decimal? pCbs = null,
                decimal? vCbs = null, decimal? pIs = null, decimal? vIs = null)
                : this(codigo, descricao, infAdic, unidade, quantidade, valorUnitario, valorIcms, ncm, cfop, origem,
                        baseCalculo, pIcms, pIpI, vIpi, valorTotal)
        {
            BaseCalculoIpi = baseCalculoIpi;
            CClassTrib = cClassTrib;
            BaseCalculoIbsCbs = baseCalculoIbsCbs;
            BaseCalculoIs = baseCalculoIs;
            PIbsUf = pIbsUf;
            VIbsUf = vIbsUf;
            PIbsMun = pIbsMun;
            VIbsMun = vIbsMun;
            PCbs = pCbs;
            VCbs = vCbs;
            PIs = pIs;
            VIs = vIs;
        }

        /// <summary>
        ///     NFCe
        /// </summary>
        /// <param name="codigo">Código</param>
        /// <param name="descricao">Descrição</param>
        /// <param name="unidade">Unidade de medida</param>
        /// <param name="quantidade">Quantidade</param>
        /// <param name="valorUnitario">Valor unitário</param>
        public Produto(string codigo, string descricao, string unidade, decimal quantidade, decimal valorUnitario)
        {
            Codigo = codigo;
            Descricao = descricao;
            Unidade = unidade;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        #endregion
    }
}