using System.Collections.Generic;
using DFe.Classes.Entidades;
using DFe.Classes.Flags;
using DFe.Utils;
using NFe.Classes.Informacoes.Identificacao.Tipos;
using NFe.Classes.Informacoes.Pagamento;
using NFe.Classes.Servicos.Evento;
using NFe.Classes.Servicos.Tipos;
using NFe.Utils.Enderecos;
using Xunit;

namespace NFe.Utils.Testes
{
    public class VinculacaoPagamentoNt2026006Testes
    {
        [Fact(DisplayName = "gPgtoVinc -> serializa nPag/idTransacao como atributos e os demais campos como elementos")]
        public void DeveSerializarGrupoGPgtoVinc()
        {
            var grupo = new gPgtoVinc
            {
                gPgto = new List<gPgto>
                {
                    new gPgto { nPag = "1", idTransacao = "TX-001", tpMeioPgto = "17", CNPJReceb = "12345678000195", CNPJBasePSP = "12345678" },
                    new gPgto { nPag = "2", idTransacao = "TX-002", tpMeioPgto = "15", CNPJReceb = "12345678000195", CNPJBasePSP = "87654321" }
                }
            };

            var xml = FuncoesXml.ClasseParaXmlString(grupo);

            Assert.Contains("<gPgto nPag=\"1\" idTransacao=\"TX-001\">", xml);
            Assert.Contains("<gPgto nPag=\"2\" idTransacao=\"TX-002\">", xml);
            Assert.Contains("<tpMeioPgto>17</tpMeioPgto>", xml);
            Assert.Contains("<CNPJReceb>12345678000195</CNPJReceb>", xml);
            Assert.Contains("<CNPJBasePSP>87654321</CNPJBasePSP>", xml);
        }

        [Fact(DisplayName = "gPgtoVinc -> round-trip preserva os dados")]
        public void DeveDesserializarGrupoGPgtoVinc()
        {
            var original = new gPgtoVinc
            {
                gPgto = new List<gPgto>
                {
                    new gPgto { nPag = "1", idTransacao = "TX-001", tpMeioPgto = "17", CNPJReceb = "12345678000195", CNPJBasePSP = "12345678" }
                }
            };

            var lido = FuncoesXml.XmlStringParaClasse<gPgtoVinc>(FuncoesXml.ClasseParaXmlString(original));

            var item = Assert.Single(lido.gPgto);
            Assert.Equal("1", item.nPag);
            Assert.Equal("TX-001", item.idTransacao);
            Assert.Equal("17", item.tpMeioPgto);
            Assert.Equal("12345678000195", item.CNPJReceb);
            Assert.Equal("12345678", item.CNPJBasePSP);
        }

        [Fact(DisplayName = "Evento 110300 -> detEvento serializa nProt antes de gPgto, com idTransacao como atributo")]
        public void DeveSerializarDetEventoVinculacaoPagamento()
        {
            var det = new detEvento
            {
                versao = "1.00",
                descEvento = NFeTipoEvento.TeNfeVinculacaoPagamento.Descricao(),
                cOrgaoAutor = Estado.SP,
                tpAutor = TipoAutor.taEmpresaEmitente,
                verAplic = "1.0",
                nProt = "135260000000001",
                gPgto = new gPgtoEvento { idTransacao = "TX-001", tpMeioPgto = "17", CNPJReceb = "12345678000195", CNPJBasePSP = "12345678" }
            };

            var xml = FuncoesXml.ClasseParaXmlString(det);

            Assert.Contains("<descEvento>Vinculação Pagamento</descEvento>", xml);
            Assert.Contains("<gPgto idTransacao=\"TX-001\">", xml);
            Assert.Contains("<tpMeioPgto>17</tpMeioPgto>", xml);
            Assert.True(xml.IndexOf("<nProt>") < xml.IndexOf("<gPgto "), "nProt deve vir antes de gPgto (sequência do XSD e110300)");
        }

        [Fact(DisplayName = "Evento 110300 -> código e descrição")]
        public void DeveTipoEventoTerCodigoEDescricaoCorretos()
        {
            Assert.Equal(110300, (int)NFeTipoEvento.TeNfeVinculacaoPagamento);
            Assert.Equal("Vinculação Pagamento", NFeTipoEvento.TeNfeVinculacaoPagamento.Descricao());
        }

        [Theory(DisplayName = "Evento 110300 -> endereço SVRS")]
        [InlineData(TipoAmbiente.Producao, "https://nfe.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
        [InlineData(TipoAmbiente.Homologacao, "https://nfe-homologacao.svrs.rs.gov.br/ws/recepcaoevento/recepcaoevento4.asmx")]
        public void DeveEventoVinculacaoPagamentoUsarSvrs(TipoAmbiente ambiente, string urlEsperada)
        {
            var url = Enderecador.ObterUrlServico(ServicoNFe.RecepcaoEventoVinculacaoTransacaoDePagamento, VersaoServico.Versao100,
                Estado.SP, ambiente, ModeloDocumento.NFe, TipoEmissao.teNormal);
            Assert.Equal(urlEsperada, url);
        }

        [Fact(DisplayName = "ServicoNFe -> valores numéricos existentes não mudam (novo serviço no fim do enum)")]
        public void DeveNovoServicoFicarNoFimDoEnum()
        {
            Assert.True((int)ServicoNFe.RecepcaoEventoVinculacaoTransacaoDePagamento > (int)ServicoNFe.RecepcaoEventoAtualizacaoDataPrevisaoDeEntrega);
        }

        [Fact(DisplayName = "Evento 110300 -> detEvento serializado valida contra e110300_v1.00.xsd oficial")]
        public void DeveDetEventoValidarContraXsdOficial()
        {
            var det = new detEvento
            {
                versao = "1.00",
                descEvento = NFeTipoEvento.TeNfeVinculacaoPagamento.Descricao(),
                cOrgaoAutor = Estado.SP,
                tpAutor = TipoAutor.taEmpresaEmitente,
                verAplic = "1.0",
                nProt = "135260000000001",
                gPgto = new gPgtoEvento { idTransacao = "TX-001", tpMeioPgto = "17", CNPJReceb = "12345678000195", CNPJBasePSP = "12345678" }
            };

            var dir = new System.IO.DirectoryInfo(System.AppContext.BaseDirectory);
            while (dir != null && !System.IO.Directory.Exists(System.IO.Path.Combine(dir.FullName, "NFe.AppTeste", "Schemas"))) dir = dir.Parent;
            Assert.NotNull(dir);
            var xsd = System.IO.Path.Combine(dir.FullName, "NFe.AppTeste", "Schemas", "e110300_v1.00.xsd");

            var schemas = new System.Xml.Schema.XmlSchemaSet { XmlResolver = new System.Xml.XmlUrlResolver() };
            schemas.Add("http://www.portalfiscal.inf.br/nfe", xsd);

            var erros = new List<string>();
            var settings = new System.Xml.XmlReaderSettings { ValidationType = System.Xml.ValidationType.Schema, Schemas = schemas };
            settings.ValidationEventHandler += (s, e) => erros.Add(e.Message);
            using (var reader = System.Xml.XmlReader.Create(new System.IO.StringReader(FuncoesXml.ClasseParaXmlString(det)), settings))
                while (reader.Read()) { }

            Assert.True(erros.Count == 0, string.Join(" | ", erros));
        }
    }
}
