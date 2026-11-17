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
    public class Imposto
    {
        #region Propriedades

        public decimal vBCIMS { get; }

        public decimal vICMS { get; }

        public decimal? vBCICMSST { get; }

        public decimal? vICMSST { get; }

        public decimal vProd { get; }

        public decimal vFrete { get; }

        public decimal vSeg { get; }

        public decimal vDesc { get; }

        public decimal vOutro { get; }

        public decimal vIpi { get; }

        public decimal vNF { get; }

        public decimal vTotTrib { get; }

        public decimal vPis { get; }

        public decimal vCofins { get; }

        public decimal? vICMSUFRemet { get; }

        public decimal? vICMSUFDest { get; }

        public decimal? vFCP { get; }

        public decimal? vFCPST { get; }

        public decimal? vFCPUFDest { get; }

        public decimal? qBCMono { get; }

        public decimal? vICMSMono { get; }

        public decimal? qBCMonoReten { get; }

        public decimal? vICMSMonoReten { get; }

        public decimal? vCBS { get; }

        public decimal? vIBSUF { get; }

        public decimal? vIBSMun { get; }

        public decimal? vIS { get; }

        public decimal? vIBSMono { get; }

        public decimal? vCBSMono { get; }

        public decimal? vIBSMonoReten { get; }

        public decimal? vCBSMonoReten { get; }

        /// <summary>
        ///     True quando o XML possui o grupo de totais do IBS/CBS (IBSCBSTot) ou do Imposto Seletivo (ISTot)
        /// </summary>
        public bool PossuiTotaisIbsCbsIs { get; }

        #endregion


        public Imposto(decimal vBcims, decimal vIcms, decimal? vBcicmsst, decimal? vIcmsst, 
                decimal vProd, decimal vFrete, decimal vSeg, decimal vDesc, decimal vOutro, decimal vIpi,
                decimal vNf,decimal vTotTrib,decimal vPis,decimal vCofins,decimal? vICMSUFRemet, decimal? vICMSUFDest)
        {
            vBCIMS = vBcims;
            vICMS = vIcms;
            vBCICMSST = vBcicmsst;
            vICMSST = vIcmsst;
            this.vProd = vProd;
            this.vFrete = vFrete;
            this.vSeg = vSeg;
            this.vDesc = vDesc;
            this.vOutro = vOutro;
            this.vIpi = vIpi;
            vNF = vNf;
            this.vTotTrib = vTotTrib;
            this.vPis = vPis;
            this.vCofins = vCofins;
            this.vICMSUFRemet = vICMSUFRemet;
            this.vICMSUFDest = vICMSUFDest;

        }

        /// <summary>
        ///     Totais com os campos da Reforma Tributária (IBS, CBS e IS) e os demais campos facultativos da NT 2026.010
        /// </summary>
        public Imposto(decimal vBcims, decimal vIcms, decimal? vBcicmsst, decimal? vIcmsst,
                decimal vProd, decimal vFrete, decimal vSeg, decimal vDesc, decimal vOutro, decimal vIpi,
                decimal vNf, decimal vTotTrib, decimal vPis, decimal vCofins, decimal? vICMSUFRemet, decimal? vICMSUFDest,
                decimal? vFCP, decimal? vFCPST, decimal? vFCPUFDest, decimal? qBCMono, decimal? vICMSMono,
                decimal? qBCMonoReten, decimal? vICMSMonoReten, decimal? vCBS, decimal? vIBSUF, decimal? vIBSMun,
                decimal? vIS, decimal? vIBSMono, decimal? vCBSMono, decimal? vIBSMonoReten, decimal? vCBSMonoReten,
                bool possuiTotaisIbsCbsIs)
                : this(vBcims, vIcms, vBcicmsst, vIcmsst, vProd, vFrete, vSeg, vDesc, vOutro, vIpi, vNf, vTotTrib, vPis,
                        vCofins, vICMSUFRemet, vICMSUFDest)
        {
            this.vFCP = vFCP;
            this.vFCPST = vFCPST;
            this.vFCPUFDest = vFCPUFDest;
            this.qBCMono = qBCMono;
            this.vICMSMono = vICMSMono;
            this.qBCMonoReten = qBCMonoReten;
            this.vICMSMonoReten = vICMSMonoReten;
            this.vCBS = vCBS;
            this.vIBSUF = vIBSUF;
            this.vIBSMun = vIBSMun;
            this.vIS = vIS;
            this.vIBSMono = vIBSMono;
            this.vCBSMono = vCBSMono;
            this.vIBSMonoReten = vIBSMonoReten;
            this.vCBSMonoReten = vCBSMonoReten;
            PossuiTotaisIbsCbsIs = possuiTotaisIbsCbsIs;
        }
    }
}