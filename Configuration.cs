namespace MoSocioAPI.DAC.Migrations
{
    using MoSocioAPI.DAC.Security;
    using MoSocioAPI.Model;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MoSocioAPI.DAC.MoSocioAPIDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoSocioAPI.DAC.MoSocioAPIDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            #region Meios de Pagamento

            context.MeiosPagamentos.AddOrUpdate(meioPagamento => meioPagamento.Sigla,
                new MeioPagamento { Sigla = "CC", Descricao = "Cartão de Crédito" },
                new MeioPagamento { Sigla = "CD", Descricao = "Cartão de Débito" },
                new MeioPagamento { Sigla = "CH", Descricao = "Cheque Bancário" },
                new MeioPagamento { Sigla = "CI", Descricao = "Crédito Documentário Internacional" },
                new MeioPagamento { Sigla = "CO", Descricao = "Cheque ou Cartão Oferta" },
                new MeioPagamento { Sigla = "CS", Descricao = "Compensação de Saldos de Conta Corrente" },
                new MeioPagamento { Sigla = "DE", Descricao = "Dinheiro Electrónico" },
                new MeioPagamento { Sigla = "MB", Descricao = "Referências de Pagamento para Multicaixa" },
                new MeioPagamento { Sigla = "NU", Descricao = "Numerário" },
                new MeioPagamento { Sigla = "OU", Descricao = "Outros Meios Aqui não Assinalados" },
                new MeioPagamento { Sigla = "PR", Descricao = "Permuta de Bens" },
                new MeioPagamento { Sigla = "TB", Descricao = "Transferência Bancária ou Débito Direto Autorizado" });
            #endregion

            #region Tipos de Documento

            context.DocTypes.AddOrUpdate(doc => doc.DocTypeId,
                new DocType { DocTypeId = 1, Sigla = "FT", Descricao = "Factura" },
                new DocType { DocTypeId = 2, Sigla = "FR", Descricao = "Factura/recibo" },
                new DocType { DocTypeId = 3, Sigla = "PP", Descricao = "Pró-forma" },
                new DocType { DocTypeId = 4, Sigla = "NC", Descricao = "Nota de Crédito" },
                new DocType { DocTypeId = 5, Sigla = "OR", Descricao = "Orçamento" },
                new DocType { DocTypeId = 6, Sigla = "GR", Descricao = "Guia de Remessa" },
                new DocType { DocTypeId = 7, Sigla = "GT", Descricao = "Guia de Transporte" },
                new DocType { DocTypeId = 8, Sigla = "RG", Descricao = "Recibo" });
            #endregion



            #region Tipos de Itens

            context.ItemsTypes.AddOrUpdate(it => it.ItemTypeId,
                new ItemType { ItemTypeId = 1, Description = "Produto" },
                new ItemType { ItemTypeId = 2, Description = "Serviço" });
            #endregion

            #region Planos

            context.Planos.AddOrUpdate(pl => pl.PlanoId,
                new Plano { PlanoId = 1, CreatedDate = DateTime.Now, NomePlano = "Experience", PrecoAnual = 0, PrecoMensal = 0, QtdDocumentos = 6, QtdUsers = 1, UpdatedDate = DateTime.Now },
                new Plano { PlanoId = 2, CreatedDate = DateTime.Now, NomePlano = "Base", PrecoAnual = 50000.00M, PrecoMensal = 5000.00M, QtdDocumentos = 99, QtdUsers = 2, UpdatedDate = DateTime.Now },
                new Plano { PlanoId = 3, CreatedDate = DateTime.Now, NomePlano = "Premium", PrecoAnual = 150000.00M, PrecoMensal = 15000.00M, QtdDocumentos = 99, QtdUsers = 99, UpdatedDate = DateTime.Now });
            #endregion

            #region Paises

            context.Paises.AddOrUpdate(p => p.CodigoISO,
            new Pais { CodigoISO = "AF", Descricao = "Afeganistão" },
             new Pais { CodigoISO = "ZA", Descricao = "África do Sul" },
             new Pais { CodigoISO = "AL", Descricao = "Albânia" },
             new Pais { CodigoISO = "DE", Descricao = "Alemanha" },
             new Pais { CodigoISO = "AD", Descricao = "Andorra" },
             new Pais { CodigoISO = "AO", Descricao = "Angola" },
             new Pais { CodigoISO = "AG", Descricao = "Antiga e Barbuda" },
             new Pais { CodigoISO = "SA", Descricao = "Arábia Saudita" },
             new Pais { CodigoISO = "DZ", Descricao = "Argélia" },
             new Pais { CodigoISO = "AR", Descricao = "Argentina" },
             new Pais { CodigoISO = "AM", Descricao = "Arménia" },
             new Pais { CodigoISO = "AU", Descricao = "Austrália" },
             new Pais { CodigoISO = "AT", Descricao = "Áustria" },
             new Pais { CodigoISO = "AZ", Descricao = "Azerbaijão" },
             new Pais { CodigoISO = "BS", Descricao = "Bahamas" },
             new Pais { CodigoISO = "BD", Descricao = "Bangladexe" },
             new Pais { CodigoISO = "BB", Descricao = "Barbados" },
             new Pais { CodigoISO = "BH", Descricao = "Bahrein" },
             new Pais { CodigoISO = "BE", Descricao = "Bélgica" },
             new Pais { CodigoISO = "BZ", Descricao = "Belize" },
             new Pais { CodigoISO = "BJ", Descricao = "Benim" },
             new Pais { CodigoISO = "BY", Descricao = "Bielorrússia" },
             new Pais { CodigoISO = "BO", Descricao = "Bolívia" },
             new Pais { CodigoISO = "BA", Descricao = "Bósnia e Herzegovina" },
             new Pais { CodigoISO = "BW", Descricao = "Botsuana" },
             new Pais { CodigoISO = "BR", Descricao = "Brasil" },
             new Pais { CodigoISO = "BN", Descricao = "Brunei" },
             new Pais { CodigoISO = "BG", Descricao = "Bulgária" },
             new Pais { CodigoISO = "BF", Descricao = "Burquina Faso" },
             new Pais { CodigoISO = "BI", Descricao = "Burúndi" },
             new Pais { CodigoISO = "BT", Descricao = "Butão" },
             new Pais { CodigoISO = "CV", Descricao = "Cabo Verde" },
             new Pais { CodigoISO = "CM", Descricao = "Camarões" },
             new Pais { CodigoISO = "KH", Descricao = "Camboja" },
             new Pais { CodigoISO = "CA", Descricao = "Canadá" },
             new Pais { CodigoISO = "QA", Descricao = "Catar" },
             new Pais { CodigoISO = "KZ", Descricao = "Cazaquistão" },
             new Pais { CodigoISO = "TD", Descricao = "Chade" },
             new Pais { CodigoISO = "CL", Descricao = "Chile" },
             new Pais { CodigoISO = "CN", Descricao = "China" },
             new Pais { CodigoISO = "CY", Descricao = "Chipre" },
             new Pais { CodigoISO = "CO", Descricao = "Colômbia" },
             new Pais { CodigoISO = "KM", Descricao = "Comores" },
             new Pais { CodigoISO = "CG", Descricao = "Congo-Brazzaville" },
             new Pais { CodigoISO = "KP", Descricao = "Coreia do Norte" },
             new Pais { CodigoISO = "KR", Descricao = "Coreia do Sul" },
             new Pais { CodigoISO = "XK", Descricao = "Cosovo" },
             new Pais { CodigoISO = "CI", Descricao = "Costa do Marfim" },
             new Pais { CodigoISO = "CR", Descricao = "Costa Rica" },
             new Pais { CodigoISO = "HR", Descricao = "Croácia" },
             new Pais { CodigoISO = "KW", Descricao = "Cuaite" },
             new Pais { CodigoISO = "CU", Descricao = "Cuba" },
             new Pais { CodigoISO = "DK", Descricao = "Dinamarca" },
             new Pais { CodigoISO = "DM", Descricao = "Dominica" },
             new Pais { CodigoISO = "EG", Descricao = "Egito" },
             new Pais { CodigoISO = "AE", Descricao = "Emirados Árabes Unidos" },
             new Pais { CodigoISO = "EC", Descricao = "Equador" },
             new Pais { CodigoISO = "ER", Descricao = "Eritreia" },
             new Pais { CodigoISO = "SK", Descricao = "Eslováquia" },
             new Pais { CodigoISO = "SI", Descricao = "Eslovénia" },
             new Pais { CodigoISO = "ES", Descricao = "Espanha" },
             new Pais { CodigoISO = "PS", Descricao = "Estado da Palestina" },
             new Pais { CodigoISO = "US", Descricao = "Estados Unidos" },
             new Pais { CodigoISO = "EE", Descricao = "Estónia" },
             new Pais { CodigoISO = "ET", Descricao = "Etiópia" },
             new Pais { CodigoISO = "FJ", Descricao = "Fiji" },
             new Pais { CodigoISO = "PH", Descricao = "Filipinas" },
             new Pais { CodigoISO = "FI", Descricao = "Finlândia" },
             new Pais { CodigoISO = "FR", Descricao = "França" },
             new Pais { CodigoISO = "GA", Descricao = "Gabão" },
             new Pais { CodigoISO = "GM", Descricao = "Gâmbia" },
             new Pais { CodigoISO = "GH", Descricao = "Gana" },
             new Pais { CodigoISO = "GE", Descricao = "Geórgia" },
             new Pais { CodigoISO = "GD", Descricao = "Granada" },
             new Pais { CodigoISO = "GR", Descricao = "Grécia" },
             new Pais { CodigoISO = "GT", Descricao = "Guatemala" },
             new Pais { CodigoISO = "GY", Descricao = "Guiana" },
             new Pais { CodigoISO = "GN", Descricao = "Guiné" },
             new Pais { CodigoISO = "GQ", Descricao = "Guiné Equatorial" },
             new Pais { CodigoISO = "GW", Descricao = "Guiné-Bissau" },
             new Pais { CodigoISO = "HT", Descricao = "Haiti" },
             new Pais { CodigoISO = "HN", Descricao = "Honduras" },
             new Pais { CodigoISO = "HU", Descricao = "Hungria" },
             new Pais { CodigoISO = "YE", Descricao = "Lémen" },
             new Pais { CodigoISO = "MH", Descricao = "Ilhas Marechal" },
             new Pais { CodigoISO = "IN", Descricao = "Índia" },
             new Pais { CodigoISO = "ID", Descricao = "Indonésia" },
             new Pais { CodigoISO = "IR", Descricao = "Irão" },
             new Pais { CodigoISO = "IQ", Descricao = "Iraque" },
             new Pais { CodigoISO = "IE", Descricao = "Irlanda" },
             new Pais { CodigoISO = "IS", Descricao = "Islândia" },
             new Pais { CodigoISO = "IL", Descricao = "Israel" },
             new Pais { CodigoISO = "IT", Descricao = "Itália" },
             new Pais { CodigoISO = "JM", Descricao = "Jamaica" },
             new Pais { CodigoISO = "JP", Descricao = "Japão" },
             new Pais { CodigoISO = "DJ", Descricao = "Jibuti" },
             new Pais { CodigoISO = "JO", Descricao = "Jordânia" },
             new Pais { CodigoISO = "LA", Descricao = "Laus" },
             new Pais { CodigoISO = "LS", Descricao = "Lesoto" },
             new Pais { CodigoISO = "LV", Descricao = "Letónia" },
             new Pais { CodigoISO = "LB", Descricao = "Líbano" },
             new Pais { CodigoISO = "LR", Descricao = "Libéria" },
             new Pais { CodigoISO = "LY", Descricao = "Líbia" },
             new Pais { CodigoISO = "LI", Descricao = "Liechtenstein" },
             new Pais { CodigoISO = "LT", Descricao = "Lituânia" },
             new Pais { CodigoISO = "LU", Descricao = "Luxemburgo" },
             new Pais { CodigoISO = "MK", Descricao = "Macedónia" },
             new Pais { CodigoISO = "MG", Descricao = "Madagáscar" },
             new Pais { CodigoISO = "MY", Descricao = "Malásia" },
             new Pais { CodigoISO = "MW", Descricao = "Maláui" },
             new Pais { CodigoISO = "MV", Descricao = "Maldivas" },
             new Pais { CodigoISO = "ML", Descricao = "Mali" },
             new Pais { CodigoISO = "MT", Descricao = "Malta" },
             new Pais { CodigoISO = "MA", Descricao = "Marrocos" },
             new Pais { CodigoISO = "MU", Descricao = "Maurícia" },
             new Pais { CodigoISO = "MR", Descricao = "Mauritânia" },
             new Pais { CodigoISO = "MX", Descricao = "México" },
             new Pais { CodigoISO = "MM", Descricao = "Mianmar" },
             new Pais { CodigoISO = "FM", Descricao = "Micronésia" },
             new Pais { CodigoISO = "MZ", Descricao = "Moçambique" },
             new Pais { CodigoISO = "MD", Descricao = "Moldávia" },
             new Pais { CodigoISO = "MC", Descricao = "Mónaco" },
             new Pais { CodigoISO = "MN", Descricao = "Mongólia" },
             new Pais { CodigoISO = "ME", Descricao = "Montenegro" },
             new Pais { CodigoISO = "NA", Descricao = "Namíbia" },
             new Pais { CodigoISO = "NR", Descricao = "Nauru" },
             new Pais { CodigoISO = "NP", Descricao = "Nepal" },
             new Pais { CodigoISO = "NI", Descricao = "Nicarágua" },
             new Pais { CodigoISO = "NE", Descricao = "Níger" },
             new Pais { CodigoISO = "NG", Descricao = "Nigéria" },
             new Pais { CodigoISO = "NO", Descricao = "Noruega" },
             new Pais { CodigoISO = "NZ", Descricao = "Nova Zelândia" },
             new Pais { CodigoISO = "OM", Descricao = "Omã" },
             new Pais { CodigoISO = "NL", Descricao = "Países Baixos" },
             new Pais { CodigoISO = "PW", Descricao = "Palau" },
             new Pais { CodigoISO = "PA", Descricao = "Panamá" },
             new Pais { CodigoISO = "PG", Descricao = "Papua Nova Guiné" },
             new Pais { CodigoISO = "PK", Descricao = "Paquistão" },
             new Pais { CodigoISO = "PY", Descricao = "Paraguai" },
             new Pais { CodigoISO = "PE", Descricao = "Peru" },
             new Pais { CodigoISO = "PL", Descricao = "Polónia" },
             new Pais { CodigoISO = "PT", Descricao = "Portugal" },
             new Pais { CodigoISO = "KE", Descricao = "Quénia" },
             new Pais { CodigoISO = "KG", Descricao = "Quirguistão" },
             new Pais { CodigoISO = "KI", Descricao = "Quiribáti" },
             new Pais { CodigoISO = "GB", Descricao = "Reino Unido" },
             new Pais { CodigoISO = "CF", Descricao = "República Centro-Africana" },
             new Pais { CodigoISO = "CZ", Descricao = "República Checa" },
             new Pais { CodigoISO = "CD", Descricao = "República Democrática do Congo" },
             new Pais { CodigoISO = "DO", Descricao = "República Dominicana" },
             new Pais { CodigoISO = "RO", Descricao = "Roménia" },
             new Pais { CodigoISO = "RW", Descricao = "Ruanda" },
             new Pais { CodigoISO = "RU", Descricao = "Rússia" },
             new Pais { CodigoISO = "SB", Descricao = "Salomão" },
             new Pais { CodigoISO = "SV", Descricao = "Salvador" },
             new Pais { CodigoISO = "WS", Descricao = "Samoa" },
             new Pais { CodigoISO = "LC", Descricao = "Santa Lúcia" },
             new Pais { CodigoISO = "KN", Descricao = "São Cristóvão e Neves" },
             new Pais { CodigoISO = "SM", Descricao = "São Marinho" },
             new Pais { CodigoISO = "ST", Descricao = "São Tomé e Príncipe" },
             new Pais { CodigoISO = "VC", Descricao = "São Vicente e Granadinas" },
             new Pais { CodigoISO = "SC", Descricao = "Seicheles" },
             new Pais { CodigoISO = "SN", Descricao = "Senegal" },
             new Pais { CodigoISO = "SL", Descricao = "Serra Leoa" },
             new Pais { CodigoISO = "RS", Descricao = "Sérvia" },
             new Pais { CodigoISO = "SG", Descricao = "Singapura" },
             new Pais { CodigoISO = "SY", Descricao = "Síria" },
             new Pais { CodigoISO = "SO", Descricao = "Somália" },
             new Pais { CodigoISO = "LK", Descricao = "SriLanca" },
             new Pais { CodigoISO = "SZ", Descricao = "Suazilândia" },
             new Pais { CodigoISO = "SD", Descricao = "Sudão" },
             new Pais { CodigoISO = "SS", Descricao = "Sudão do Sul" },
             new Pais { CodigoISO = "SE", Descricao = "Suécia" },
             new Pais { CodigoISO = "CH", Descricao = "Suíça" },
             new Pais { CodigoISO = "SR", Descricao = "Suriname" },
             new Pais { CodigoISO = "TH", Descricao = "Tailândia" },
             new Pais { CodigoISO = "TW", Descricao = "Taiuã" },
             new Pais { CodigoISO = "TJ", Descricao = "Tajiquistão" },
             new Pais { CodigoISO = "TZ", Descricao = "Tanzânia" },
             new Pais { CodigoISO = "TL", Descricao = "Timor-Leste" },
             new Pais { CodigoISO = "TG", Descricao = "Togo" },
             new Pais { CodigoISO = "TO", Descricao = "Tonga" },
             new Pais { CodigoISO = "TT", Descricao = "Trindade e Tobago" },
             new Pais { CodigoISO = "TN", Descricao = "Tunísia" },
             new Pais { CodigoISO = "TM", Descricao = "Turcomenistão" },
             new Pais { CodigoISO = "TR", Descricao = "Turquia" },
             new Pais { CodigoISO = "TV", Descricao = "Tuvalu" },
             new Pais { CodigoISO = "UA", Descricao = "Ucrânia" },
             new Pais { CodigoISO = "UG", Descricao = "Uganda" },
             new Pais { CodigoISO = "UY", Descricao = "Uruguai" },
             new Pais { CodigoISO = "UZ", Descricao = "Uzbequistão" },
             new Pais { CodigoISO = "VU", Descricao = "Vanuatu" },
             new Pais { CodigoISO = "VA", Descricao = "Vaticano" },
             new Pais { CodigoISO = "VE", Descricao = "Venezuela" },
             new Pais { CodigoISO = "VN", Descricao = "Vietname" },
             new Pais { CodigoISO = "ZM", Descricao = "Zâmbia" },
             new Pais { CodigoISO = "ZW", Descricao = "Zimbábue" });
            #endregion


            #region Moedas

            context.Moedas.AddOrUpdate(m => m.Sigla,
             new Moeda { Sigla = "AED", Descricao = "United Arab Emirates (AED)" },
             new Moeda { Sigla = "AFN", Descricao = "Afghan afghani (AFN)" },
             new Moeda { Sigla = "ALL", Descricao = "Albanian lek (ALL)" },
             new Moeda { Sigla = "AMD", Descricao = "Armenian dram (AMD)" },
             new Moeda { Sigla = "AOA", Descricao = "Angolan kwanza (AOA)" },
             new Moeda { Sigla = "ARS", Descricao = "Argentine peso (ARS)" },
             new Moeda { Sigla = "AUD", Descricao = "Australian dollar (AUD)" },
             new Moeda { Sigla = "AWG", Descricao = "Aruban florin (AWG)" },
             new Moeda { Sigla = "AZN", Descricao = "Azerbaijani manat (AZN)" },
             new Moeda { Sigla = "BBD", Descricao = "Barbadian dollar (BBD)" },
             new Moeda { Sigla = "BDT", Descricao = "Bangladeshi taka (BDT)" },
             new Moeda { Sigla = "BGN", Descricao = "Bulgarian lev (BGN)" },
             new Moeda { Sigla = "BHD", Descricao = "Bahraini dinar (BHD)" },
             new Moeda { Sigla = "BIF", Descricao = "Burundian franc (BIF)" },
             new Moeda { Sigla = "BMD", Descricao = "Bermudian dollar (BMD)" },
             new Moeda { Sigla = "BND", Descricao = "Brunei dollar (BND)" },
             new Moeda { Sigla = "BRL", Descricao = "Brazilian real (BRL)" },
             new Moeda { Sigla = "BTN", Descricao = "Bhutanese ngultrum (BTN)" },
             new Moeda { Sigla = "BWP", Descricao = "Botswana pula (BWP)" },
             new Moeda { Sigla = "BYR", Descricao = "Belarusian ruble (BYR)" },
             new Moeda { Sigla = "BZD", Descricao = "Belize dollar (BZD)" },
             new Moeda { Sigla = "CAD", Descricao = "Canadian dollar (CAD)" },
             new Moeda { Sigla = "CHF", Descricao = "Swiss franc (CHF)" },
             new Moeda { Sigla = "CLP", Descricao = "Chilean peso (CLP)" },
             new Moeda { Sigla = "CNY", Descricao = "Chinese yuan (CNY)" },
             new Moeda { Sigla = "COP", Descricao = "Colombian peso (COP)" },
             new Moeda { Sigla = "CRC", Descricao = "Costa Rican colon (CRC)" },
             new Moeda { Sigla = "CUC", Descricao = "Cuban convertible pe (CUC)" },
             new Moeda { Sigla = "CVE", Descricao = "Cape Verdean escudo (CVE)" },
             new Moeda { Sigla = "CZK", Descricao = "Czech koruna (CZK)" },
             new Moeda { Sigla = "DJF", Descricao = "Djiboutian franc (DJF)" },
             new Moeda { Sigla = "DKK", Descricao = "Danish krone (DKK)" },
             new Moeda { Sigla = "DOP", Descricao = "Dominican peso (DOP)" },
             new Moeda { Sigla = "DZD", Descricao = "Algerian dinar (DZD)" },
             new Moeda { Sigla = "EGP", Descricao = "Egyptian pound (EGP)" },
             new Moeda { Sigla = "ERN", Descricao = "Eritrean nakfa (ERN)" },
             new Moeda { Sigla = "ETB", Descricao = "Ethiopian birr (ETB)" },
             new Moeda { Sigla = "EUR", Descricao = "Euro (EUR)" },
             new Moeda { Sigla = "FJD", Descricao = "Fijian dollar (FJD)" },
             new Moeda { Sigla = "GBP", Descricao = "British pound (GBP)" },
             new Moeda { Sigla = "GEL", Descricao = "Georgian lari (GEL)" },
             new Moeda { Sigla = "GHS", Descricao = "Ghana cedi (GHS)" },
             new Moeda { Sigla = "GIP", Descricao = "Gibraltar pound (GIP)" },
             new Moeda { Sigla = "GNF", Descricao = "Guinean franc (GNF)" },
             new Moeda { Sigla = "GTQ", Descricao = "Guatemalan quetzal (GTQ)" },
             new Moeda { Sigla = "GYD", Descricao = "Guyanese dollar (GYD)" },
             new Moeda { Sigla = "HKD", Descricao = "Hong Kong dollar (HKD)" },
             new Moeda { Sigla = "HNL", Descricao = "Honduran lempira (HNL)" },
             new Moeda { Sigla = "HRK", Descricao = "Croatian kuna (HRK)" },
             new Moeda { Sigla = "HTG", Descricao = "Haitian gourde (HTG)" },
             new Moeda { Sigla = "HUF", Descricao = "Hungarian forint (HUF)" },
             new Moeda { Sigla = "IDR", Descricao = "Indonesian rupiah (IDR)" },
             new Moeda { Sigla = "ILS", Descricao = "Israeli new shekel (ILS)" },
             new Moeda { Sigla = "INR", Descricao = "Indian rupee (INR)" },
             new Moeda { Sigla = "IQD", Descricao = "Iraqi dinar (IQD)" },
             new Moeda { Sigla = "ISK", Descricao = "Icelandic krona (ISK)" },
             new Moeda { Sigla = "JMD", Descricao = "Jamaican dollar (JMD)" },
             new Moeda { Sigla = "JOD", Descricao = "Jordanian dinar (JOD)" },
             new Moeda { Sigla = "JPY", Descricao = "Japanese yen (JPY)" },
             new Moeda { Sigla = "KES", Descricao = "Kenyan shilling (KES)" },
             new Moeda { Sigla = "KGS", Descricao = "Kyrgyzstani som (KGS)" },
             new Moeda { Sigla = "KHR", Descricao = "Cambodian riel (KHR)" },
             new Moeda { Sigla = "KMF", Descricao = "Comorian franc (KMF)" },
             new Moeda { Sigla = "KWD", Descricao = "Kuwaiti dinar (KWD)" },
             new Moeda { Sigla = "KYD", Descricao = "Cayman Islands dolla (KYD)" },
             new Moeda { Sigla = "KZT", Descricao = "Kazakhstani tenge (KZT)" },
             new Moeda { Sigla = "LAK", Descricao = "Lao kip (LAK)" },
             new Moeda { Sigla = "LBP", Descricao = "Lebanese pound (LBP)" },
             new Moeda { Sigla = "LKR", Descricao = "Sri Lankan rupee (LKR)" },
             new Moeda { Sigla = "LRD", Descricao = "Liberian dollar (LRD)" },
             new Moeda { Sigla = "LSL", Descricao = "Lesotho loti (LSL)" },
             new Moeda { Sigla = "MAD", Descricao = "Moroccan dirham (MAD)" },
             new Moeda { Sigla = "MDL", Descricao = "Moldovan leu (MDL)" },
             new Moeda { Sigla = "MGA", Descricao = "Malagasy ariary (MGA)" },
             new Moeda { Sigla = "MMK", Descricao = "Burmese kyat (MMK)" },
             new Moeda { Sigla = "MNT", Descricao = "Mongolian togrog (MNT)" },
             new Moeda { Sigla = "MRO", Descricao = "Mauritanian ouguiya (MRO)" },
             new Moeda { Sigla = "MUR", Descricao = "Mauritian rupee (MUR)" },
             new Moeda { Sigla = "MVR", Descricao = "Maldivian rufiyaa (MVR)" },
             new Moeda { Sigla = "MWK", Descricao = "Malawian kwacha (MWK)" },
             new Moeda { Sigla = "MXN", Descricao = "Mexican peso (MXN)" },
             new Moeda { Sigla = "MYR", Descricao = "Malaysian ringgit (MYR)" },
             new Moeda { Sigla = "MZN", Descricao = "Mozambican metical (MZN)" },
             new Moeda { Sigla = "NAD", Descricao = "Namibian dollar (NAD)" },
             new Moeda { Sigla = "NGN", Descricao = "Nigerian naira (NGN)" },
             new Moeda { Sigla = "NIO", Descricao = "Nicaraguan cordoba (NIO)" },
             new Moeda { Sigla = "NOK", Descricao = "Norwegian krone (NOK)" },
             new Moeda { Sigla = "NPR", Descricao = "Nepalese rupee (NPR)" },
             new Moeda { Sigla = "NZD", Descricao = "New Zealand dollar (NZD)" },
             new Moeda { Sigla = "OMR", Descricao = "Omani rial (OMR)" },
             new Moeda { Sigla = "PAB", Descricao = "Panamanian balboa (PAB)" },
             new Moeda { Sigla = "PEN", Descricao = "Peruvian nuevo sol (PEN)" },
             new Moeda { Sigla = "PGK", Descricao = "Papua New Guinean ki (PGK)" },
             new Moeda { Sigla = "PHP", Descricao = "Philippine peso (PHP)" },
             new Moeda { Sigla = "PKR", Descricao = "Pakistani rupee (PKR)" },
             new Moeda { Sigla = "PLN", Descricao = "Polish Zloty (PLN)" },
             new Moeda { Sigla = "PYG", Descricao = "Paraguayan guarani (PYG)" },
             new Moeda { Sigla = "QAR", Descricao = "Qatari riyal (QAR)" },
             new Moeda { Sigla = "RON", Descricao = "Romanian leu (RON)" },
             new Moeda { Sigla = "RSD", Descricao = "Serbian dinar (RSD)" },
             new Moeda { Sigla = "RUB", Descricao = "Russian ruble (RUB)" },
             new Moeda { Sigla = "RWF", Descricao = "Rwandan franc (RWF)" },
             new Moeda { Sigla = "SAR", Descricao = "Saudi riyal (SAR)" },
             new Moeda { Sigla = "SBD", Descricao = "Solomon Islands doll (SBD)" },
             new Moeda { Sigla = "SCR", Descricao = "Seychellois rupee (SCR)" },
             new Moeda { Sigla = "SDG", Descricao = "Sudanese pound (SDG)" },
             new Moeda { Sigla = "SEK", Descricao = "Swedish krona (SEK)" },
             new Moeda { Sigla = "SLL", Descricao = "Sierra Leonean leone (SLL)" },
             new Moeda { Sigla = "SOS", Descricao = "Somali shilling (SOS)" },
             new Moeda { Sigla = "SRD", Descricao = "Surinamese dollar (SRD)" },
             new Moeda { Sigla = "SZL", Descricao = "Swazi lilangeni (SZL)" },
             new Moeda { Sigla = "THB", Descricao = "Thai baht (THB)" },
             new Moeda { Sigla = "TJS", Descricao = "Tajikistani somoni (TJS)" },
             new Moeda { Sigla = "TMT", Descricao = "Turkmenistan manat (TMT)" },
             new Moeda { Sigla = "TND", Descricao = "Tunisian dinar (TND)" },
             new Moeda { Sigla = "TOP", Descricao = "Tongan pa?anga (TOP)" },
             new Moeda { Sigla = "TRY", Descricao = "Turkish lira (TRY)" },
             new Moeda { Sigla = "TTD", Descricao = "Trinidad and Tobago  (TTD)" },
             new Moeda { Sigla = "TWD", Descricao = "New Taiwan dollar (TWD)" },
             new Moeda { Sigla = "UAH", Descricao = "Ukrainian hryvnia (UAH)" },
             new Moeda { Sigla = "UGX", Descricao = "Ugandan shilling (UGX)" },
             new Moeda { Sigla = "USD", Descricao = "United States dollar (USD)" },
             new Moeda { Sigla = "UYU", Descricao = "Uruguayan peso (UYU)" },
             new Moeda { Sigla = "UZS", Descricao = "Uzbekistani som (UZS)" },
             new Moeda { Sigla = "VND", Descricao = "Vietnamese (VND)" },
             new Moeda { Sigla = "VUV", Descricao = "Vanuatu vatu (VUV)" },
             new Moeda { Sigla = "WST", Descricao = "Samoan Tala (WST)" },
             new Moeda { Sigla = "XAF", Descricao = "Central African CFA  (XAF)" },
             new Moeda { Sigla = "XCD", Descricao = "East Caribbean dolla (XCD)" },
             new Moeda { Sigla = "XOF", Descricao = "West African CFA fra (XOF)" },
             new Moeda { Sigla = "XPF", Descricao = "CFP franc (XPF)" },
             new Moeda { Sigla = "YER", Descricao = "Yemeni rial (YER)" },
             new Moeda { Sigla = "ZAR", Descricao = "South African rand (ZAR)" },
             new Moeda { Sigla = "ZMW", Descricao = "Zambian kwacha (ZMW)" });
            #endregion


            #region Idiomas

            context.Idiomas.AddOrUpdate(idioma => idioma.IdiomaId,
                new Idioma { IdiomaId = 1, Descricao = "Chinês" },
                new Idioma { IdiomaId = 2, Descricao = "Espanhol" },
                new Idioma { IdiomaId = 3, Descricao = "Inglês" },
                new Idioma { IdiomaId = 4, Descricao = "Hindi" },
                new Idioma { IdiomaId = 5, Descricao = "Árabe" },
                new Idioma { IdiomaId = 6, Descricao = "Português" },
                new Idioma { IdiomaId = 7, Descricao = "Bengali" },
                new Idioma { IdiomaId = 8, Descricao = "Russo" },
                new Idioma { IdiomaId = 9, Descricao = "Japonês" },
                new Idioma { IdiomaId = 10, Descricao = "Punjabi/Lahnda" },
                new Idioma { IdiomaId = 11, Descricao = "Italiano" },
                new Idioma { IdiomaId = 12, Descricao = "Alemão" },
                new Idioma { IdiomaId = 13, Descricao = "Sueco" },
                new Idioma { IdiomaId = 14, Descricao = "Turco" },
                new Idioma { IdiomaId = 15, Descricao = "Holandês" },
                new Idioma { IdiomaId = 16, Descricao = "Dinamarquês" },
                new Idioma { IdiomaId = 17, Descricao = "Italiano" },
                new Idioma { IdiomaId = 18, Descricao = "Francês" });
            #endregion

            #region Motivos de Isenção Impostos

            context.MotivosIsencaoImposto.AddOrUpdate(motivo => motivo.MotivoIsencaoImpostoSigla,
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M00", MotivoIsencaoImpostoDescricao = "IVA – Regime Simplificado" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M02", MotivoIsencaoImpostoDescricao = "Transmissão de bens e serviço não sujeita" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M04", MotivoIsencaoImpostoDescricao = "IVA – Regime de Exclusão" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M10", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea a) do nº1 do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M11", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea b) do nº1 do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M12", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea c) do nº1 do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M13", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea d) do nº1 do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M14", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea e) do nº1 do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M15", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea f) do nº1 do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M16", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea g) do nº1 do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M17", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea h) do nº1 do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M18", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea i) do nº1 artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M19", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea j) do nº1 do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M20", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea k) do nº1 do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M21", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea l) do nº1 do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M22", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea m) do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M23", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea n) do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M24", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea 0) do artigo 12.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M80", MotivoIsencaoImpostoDescricao = "Isento nos termos da alinea a) do nº1 do artigo 14.º" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M81", MotivoIsencaoImpostoDescricao = "Isento nos termos da alinea b) do nº1 do artigo 14.º" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M82", MotivoIsencaoImpostoDescricao = "Isento nos termos da alinea c) do nº1 do artigo 14.º" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M83", MotivoIsencaoImpostoDescricao = "Isento nos termos da alinea d) do nº1 do artigo 14.º" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M84", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea e) do nº1 do artigo 14.º" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M85", MotivoIsencaoImpostoDescricao = "Isento nos termos da alinea a) do nº2 do artigo 14." },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M86", MotivoIsencaoImpostoDescricao = "Isento nos termos da alinea b) do nº2 do artigo 14.º" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M30", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea a) do artigo 15.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M31", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea b) do artigo 15.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M32", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea c) do artigo 15.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M33", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea d) do artigo 15.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M34", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea e) do artigo 15.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M35", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea f) do artigo 15.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M36", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea g) do artigo 15.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M37", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea h) do artigo 15.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M38", MotivoIsencaoImpostoDescricao = "Isento nos termos da alínea i) do artigo 15.º do CIVA" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M90", MotivoIsencaoImpostoDescricao = "Isento nos termos da alinea a) do nº1 do artigo 16.º" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M91", MotivoIsencaoImpostoDescricao = "Isento nos termos da alinea b) do nº1 do artigo 16.º" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M92", MotivoIsencaoImpostoDescricao = "Isento nos termos da alinea c) do nº1 do artigo 16.º" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M93", MotivoIsencaoImpostoDescricao = "Isento nos termos da alinea d) do nº1 do artigo 16.º" },
                new MotivoIsencaoImposto { MotivoIsencaoImpostoSigla = "M94", MotivoIsencaoImpostoDescricao = "Isento nos termos da alinea e) do nº1 do artigo 16.º" });
            #endregion


            #region  Criação dos Perfis

            var roleManager = new ApplicationRoleManager(context);
            var userManager = new ApplicationUserManager(context);

            const string adminRoleName = "Administrador";
            const string normalRoleName = "Normal";
            const string administracaoRoleName = "Administracao";

            // Role Administrador
            var roleAdministrador = roleManager.FindByName(adminRoleName);
            if (roleAdministrador == null)
            {
                roleAdministrador = new IdentityRole(adminRoleName);
                roleManager.Create(roleAdministrador);
            }

            // Role Norma User
            var roleNormal = roleManager.FindByName(normalRoleName);
            if (roleNormal == null)
            {
                roleNormal = new IdentityRole(normalRoleName);
                roleManager.Create(roleNormal);
            }

            // Role Administracao
            var roleAdministracao = roleManager.FindByName(administracaoRoleName);
            if (roleAdministracao == null)
            {
                roleAdministracao = new IdentityRole(administracaoRoleName);
                roleManager.Create(roleAdministracao);
            }

            // Criar User da Administraçao
            #region  Criar User da Administraçao
            var user = userManager.FindByName("admin");

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "invoicingadministracao@outlook.com"
                };
                var result = userManager.Create(user, "admin123");
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(roleAdministracao.Name))
            {
                var result = userManager.AddToRole(user.Id, roleAdministracao.Name);
            }

            #endregion

            #endregion
        }
    }
}
