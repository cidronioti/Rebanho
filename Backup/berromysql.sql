-- phpMyAdmin SQL Dump
-- version 4.1.12
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 25-Jan-2018 às 22:31
-- Versão do servidor: 5.5.36
-- PHP Version: 5.4.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `berromysql`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `agrupamento`
--

CREATE TABLE IF NOT EXISTS `agrupamento` (
  `COD_AGRUPAMENTO` int(11) NOT NULL AUTO_INCREMENT,
  `DATA_BAIXA` varchar(10) DEFAULT NULL,
  `GRAU_SANGUE` varchar(10) DEFAULT NULL,
  `GRUPO` varchar(20) DEFAULT NULL,
  `ORIGEM` varchar(20) DEFAULT NULL,
  `DESTINACAO` varchar(20) DEFAULT NULL,
  `PELAGEM` varchar(20) DEFAULT NULL,
  `COD_DESMAMA` int(11) DEFAULT NULL,
  `PAI` varchar(7) DEFAULT NULL,
  `MAE` varchar(7) DEFAULT NULL,
  `REGIME_ALIMETAR` varchar(50) DEFAULT NULL,
  `OBS` varchar(100) DEFAULT NULL,
  `COD_CRIADOR` varchar(3) DEFAULT NULL,
  `COD_ANIMAL` varchar(7) DEFAULT NULL,
  PRIMARY KEY (`COD_AGRUPAMENTO`),
  KEY `FK_AGRUPAME_REFERENCE_CRIADOR` (`COD_CRIADOR`),
  KEY `FK_AGRUPAME_REFERENCE_ANIMAL` (`COD_ANIMAL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `animal`
--

CREATE TABLE IF NOT EXISTS `animal` (
  `COD_ANIMAL` varchar(7) NOT NULL,
  `NOME_ANIMAL` varchar(50) DEFAULT NULL,
  `DATA_NASCIMENTO` varchar(10) DEFAULT NULL,
  `SEXO_ANIMAL` char(1) DEFAULT NULL,
  `CITUACAO` varchar(30) DEFAULT NULL,
  `BRINCO` varchar(7) DEFAULT NULL,
  `COD_RACA` varchar(3) DEFAULT NULL,
  `COD_LOCAL` varchar(3) DEFAULT NULL,
  `CAMINHO_FOTO` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`COD_ANIMAL`),
  KEY `FK_ANIMAL_REFERENCE_LOCAL` (`COD_LOCAL`),
  KEY `FK_ANIMAL_REFERENCE_RACA` (`COD_RACA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `baixa`
--

CREATE TABLE IF NOT EXISTS `baixa` (
  `COD_BAIXA` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `COD_ANIMAL` varchar(7) DEFAULT NULL,
  `COD_CAUSAS_MORTIS` varchar(3) DEFAULT NULL,
  `DATA_BAIXA` varchar(10) DEFAULT NULL,
  `OBS` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`COD_BAIXA`),
  UNIQUE KEY `COD_BAIXA` (`COD_BAIXA`),
  KEY `FK_BAIXA_REFERENCE_ANIMAL` (`COD_ANIMAL`),
  KEY `FK_BAIXA_REFERENCE_CAUSAS_M` (`COD_CAUSAS_MORTIS`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `categoria`
--

CREATE TABLE IF NOT EXISTS `categoria` (
  `cod_categoria` int(11) NOT NULL AUTO_INCREMENT,
  `nome_categoria` varchar(150) NOT NULL,
  `flag` char(1) NOT NULL,
  PRIMARY KEY (`cod_categoria`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Extraindo dados da tabela `categoria`
--

INSERT INTO `categoria` (`cod_categoria`, `nome_categoria`, `flag`) VALUES
(1, 'ANTIBIOTICO', 'M'),
(2, 'LARVICIDA', 'M'),
(3, 'ANTIHELMINTICO', 'M'),
(4, 'ANESTESICO', 'M');

-- --------------------------------------------------------

--
-- Estrutura da tabela `causas_mortis`
--

CREATE TABLE IF NOT EXISTS `causas_mortis` (
  `COD_CAUSAS_MORTIS` varchar(3) NOT NULL,
  `NOME_CAUSA` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`COD_CAUSAS_MORTIS`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `cliente`
--

CREATE TABLE IF NOT EXISTS `cliente` (
  `COD_CLIENTE` int(11) NOT NULL AUTO_INCREMENT,
  `NOME_CLIENTE` varchar(150) DEFAULT NULL,
  `CPF_CLIENTE` varchar(20) DEFAULT NULL,
  `RG_CLIENTE` varchar(20) DEFAULT NULL,
  `FONE_CLIENTE` varchar(20) DEFAULT NULL,
  `PROPRIEDADE_CLIENTE` varchar(150) DEFAULT NULL,
  `COD_ENDERECO` int(11) DEFAULT NULL,
  PRIMARY KEY (`COD_CLIENTE`),
  KEY `FK_CLIENTE_REFERENCE_ENDERECO` (`COD_ENDERECO`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Extraindo dados da tabela `cliente`
--

INSERT INTO `cliente` (`COD_CLIENTE`, `NOME_CLIENTE`, `CPF_CLIENTE`, `RG_CLIENTE`, `FONE_CLIENTE`, `PROPRIEDADE_CLIENTE`, `COD_ENDERECO`) VALUES
(1, 'TEREZA', '33242342344', '234234', '(23) 4234-2343', 'QEWEQE', 9);

-- --------------------------------------------------------

--
-- Estrutura da tabela `coberturas`
--

CREATE TABLE IF NOT EXISTS `coberturas` (
  `COD_COBERTURA` int(11) NOT NULL AUTO_INCREMENT,
  `COD_ANIMAL` varchar(7) DEFAULT NULL,
  `COD_INSEMINADORES` int(11) DEFAULT NULL,
  `DATA_CIO` varchar(10) DEFAULT NULL,
  `HORA_CIO` varchar(5) DEFAULT NULL,
  `TIPO_CORTURA` varchar(30) DEFAULT NULL,
  `MACHO` varchar(7) DEFAULT NULL,
  `PARTIDA` varchar(20) DEFAULT NULL,
  `DOSES` int(11) DEFAULT NULL,
  `OBS` varchar(50) DEFAULT NULL,
  `VALOR_GASTO` double DEFAULT NULL,
  PRIMARY KEY (`COD_COBERTURA`),
  KEY `FK_COBERTUR_REFERENCE_INSEMINA` (`COD_INSEMINADORES`),
  KEY `FK_COBERTUR_REFERENCE_ANIMAL` (`COD_ANIMAL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `coleta_embrioes`
--

CREATE TABLE IF NOT EXISTS `coleta_embrioes` (
  `COD_COLETA_EMBRIOES` int(11) NOT NULL AUTO_INCREMENT,
  `COD_ANIMAL` varchar(7) DEFAULT NULL,
  `DATA_COLETA` varchar(10) DEFAULT NULL,
  `VALOR` double DEFAULT NULL,
  `NUM_EMBRIOES` int(11) DEFAULT NULL,
  `ESTADO_SEMEN` varchar(15) DEFAULT NULL,
  `RESPONSAVEL` varchar(50) DEFAULT NULL,
  `OBS` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`COD_COLETA_EMBRIOES`),
  KEY `FK_COLETA_E_REFERENCE_ANIMAL` (`COD_ANIMAL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `compra`
--

CREATE TABLE IF NOT EXISTS `compra` (
  `COD_COMPRA` int(11) NOT NULL AUTO_INCREMENT,
  `COD_CRIADOR` varchar(3) DEFAULT NULL,
  `COD_RACA` varchar(3) DEFAULT NULL,
  `COD_LOCAL` varchar(3) DEFAULT NULL,
  `DATA_COMPRA` varchar(10) DEFAULT NULL,
  `VALOR_ANIMAL` double DEFAULT NULL,
  `NATA_FISCAL` varchar(20) DEFAULT NULL,
  `GTA` varchar(15) DEFAULT NULL,
  `NUMERO_ANIMAL` varchar(7) DEFAULT NULL,
  `SEXO` char(1) DEFAULT NULL,
  `DATA_NASCIMENTO` varchar(10) DEFAULT NULL,
  `SITUACAO` varchar(50) DEFAULT NULL,
  `NOME_ANIMAL` varchar(50) DEFAULT NULL,
  `GRAU_SANGUE` varchar(20) DEFAULT NULL,
  `PESO` double DEFAULT NULL,
  `DESTINACAO` varchar(50) DEFAULT NULL,
  `GRUPO` varchar(50) DEFAULT NULL,
  `VENDEDOR` varchar(50) DEFAULT NULL,
  `CHIPE` varchar(10) DEFAULT NULL,
  `PELAGEM` varchar(50) DEFAULT NULL,
  `RGN` varchar(15) DEFAULT NULL,
  `RGD` varchar(15) DEFAULT NULL,
  `BRINCO` varchar(7) DEFAULT NULL,
  `OBS` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`COD_COMPRA`),
  KEY `FK_COMPRA_REFERENCE_LOCAL` (`COD_LOCAL`),
  KEY `FK_COMPRA_REFERENCE_RACA` (`COD_RACA`),
  KEY `FK_COMPRA_REFERENCE_CRIADOR` (`COD_CRIADOR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `criador`
--

CREATE TABLE IF NOT EXISTS `criador` (
  `COD_CRIADOR` varchar(3) NOT NULL,
  `NOME_CRIADOR` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`COD_CRIADOR`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `desmama`
--

CREATE TABLE IF NOT EXISTS `desmama` (
  `COD_CRIA_DEFINITIVO` varchar(7) NOT NULL,
  `COD_CRIA` varchar(7) DEFAULT NULL,
  `DATA_DESMAMA` varchar(10) DEFAULT NULL,
  `DESTINACAO` varchar(30) DEFAULT NULL,
  `PESO_DESMAMA` double DEFAULT NULL,
  `COD_LOCAL` varchar(3) DEFAULT NULL,
  `OBS` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`COD_CRIA_DEFINITIVO`),
  KEY `FK_DESMAMA_REFERENCE_PARTO_RE` (`COD_CRIA`),
  KEY `FK_DESMAMA_REFERENCE_LOCAL` (`COD_LOCAL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `diagnostico`
--

CREATE TABLE IF NOT EXISTS `diagnostico` (
  `COD_DIAGNOSTICO` int(11) NOT NULL AUTO_INCREMENT,
  `COD_ANIMAL` varchar(7) DEFAULT NULL,
  `DATA_DIAGNOSTICO` varchar(10) DEFAULT NULL,
  `RESULTADO` varchar(10) DEFAULT NULL,
  `OBS` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`COD_DIAGNOSTICO`),
  KEY `FK_DIAGNOST_REFERENCE_ANIMAL` (`COD_ANIMAL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `endereco`
--

CREATE TABLE IF NOT EXISTS `endereco` (
  `cod_endereco` int(11) NOT NULL AUTO_INCREMENT,
  `cep_endereco` varchar(20) DEFAULT NULL,
  `rua_endereco` varchar(150) DEFAULT NULL,
  `numero_endereco` varchar(6) DEFAULT NULL,
  `bairro_endereco` varchar(150) DEFAULT NULL,
  `cidade_endereco` varchar(150) DEFAULT NULL,
  `obs_endereco` text,
  PRIMARY KEY (`cod_endereco`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=10 ;

--
-- Extraindo dados da tabela `endereco`
--

INSERT INTO `endereco` (`cod_endereco`, `cep_endereco`, `rua_endereco`, `numero_endereco`, `bairro_endereco`, `cidade_endereco`, `obs_endereco`) VALUES
(9, '50865130', 'ANDRÉ VIEIRA DE MELO', '234', 'ESTÂNCIA', 'RECIFE', 'SSDFSDFDSF');

-- --------------------------------------------------------

--
-- Estrutura da tabela `evento_sanitario`
--

CREATE TABLE IF NOT EXISTS `evento_sanitario` (
  `COD_EVENTO_SANITARIO` int(11) NOT NULL AUTO_INCREMENT,
  `COD_ANIMAL` varchar(7) DEFAULT NULL,
  `COD_SANI_ZOO` int(11) DEFAULT NULL,
  `QTD` double DEFAULT NULL,
  `DOSES` varchar(10) DEFAULT NULL,
  `OBS` varchar(100) DEFAULT NULL,
  `SCORE` varchar(10) DEFAULT NULL,
  `NOTA_FISCAL` varchar(30) DEFAULT NULL,
  `LABORATORIO` varchar(50) DEFAULT NULL,
  `VALOR` double DEFAULT NULL,
  `ALERTA` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`COD_EVENTO_SANITARIO`),
  KEY `FK_EVENTO_S_REFERENCE_ANIMAL` (`COD_ANIMAL`),
  KEY `FK_EVENTO_S_REFERENCE_EVENTO_S` (`COD_SANI_ZOO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `evento_sanitario_zootecnico`
--

CREATE TABLE IF NOT EXISTS `evento_sanitario_zootecnico` (
  `COD_SANI_ZOO` int(11) NOT NULL AUTO_INCREMENT,
  `NOME_SANI_ZOO` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`COD_SANI_ZOO`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `funcionarios`
--

CREATE TABLE IF NOT EXISTS `funcionarios` (
  `idfuncionarios` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) DEFAULT NULL,
  `data_admicao` varchar(15) DEFAULT NULL,
  `salario` double DEFAULT NULL,
  `cargo` varchar(50) DEFAULT NULL,
  `fone` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`idfuncionarios`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `inseminadores`
--

CREATE TABLE IF NOT EXISTS `inseminadores` (
  `COD_INSEMINADORES` int(11) NOT NULL AUTO_INCREMENT,
  `REGISTRO` varchar(15) DEFAULT NULL,
  `NOME` varchar(50) DEFAULT NULL,
  `CRMV` varchar(20) DEFAULT NULL,
  `FONE` varchar(15) DEFAULT NULL,
  `EMAIL` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`COD_INSEMINADORES`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `local1`
--

CREATE TABLE IF NOT EXISTS `local1` (
  `COD_LOCAL` varchar(3) NOT NULL,
  `NOME_LOCAL` varchar(50) DEFAULT NULL,
  `AREA_LOCAL` double DEFAULT NULL,
  `GRAMINEA` varchar(30) DEFAULT NULL,
  `DATA_AVALIACAO` varchar(10) DEFAULT NULL,
  `PADRAO_CORTE` varchar(20) DEFAULT NULL,
  `PADRAO_PASTEJO` varchar(20) DEFAULT NULL,
  `SUPORTE` double DEFAULT NULL,
  `PASTEJO` double DEFAULT NULL,
  `PERDA` double DEFAULT NULL,
  `CONSUMO` double DEFAULT NULL,
  `DESCANSO` int(11) DEFAULT NULL,
  `OBS` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`COD_LOCAL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `medicamentos`
--

CREATE TABLE IF NOT EXISTS `medicamentos` (
  `COD_MEDICAMENTO` int(11) NOT NULL AUTO_INCREMENT,
  `COD_BARRAS` varchar(20) DEFAULT NULL,
  `NOME_COMERCIAL` varchar(50) NOT NULL,
  `PRINCIPIO_ATIVO` varchar(50) DEFAULT NULL,
  `INDICACOES` text,
  `PRECO_COMPRA` float DEFAULT NULL,
  `QUANTIDADE_POR_EMBALAGEM` int(11) DEFAULT NULL,
  `QUANTIDADE_DE_EMBALAGEM` int(11) DEFAULT NULL,
  `QUANTIDADE_MIN` int(11) DEFAULT NULL,
  `DATA_VALIDADE` varchar(10) NOT NULL,
  `APRESENTACAO` varchar(100) NOT NULL,
  `LABORATORIO` varchar(150) DEFAULT NULL,
  `MODO_USO` text,
  `OBS` text,
  `COD_CATEGORIA` int(11) NOT NULL,
  `COD_UNIDADE` int(11) NOT NULL,
  `caminho_foto` varchar(200) DEFAULT NULL,
  `foto` longblob,
  PRIMARY KEY (`COD_MEDICAMENTO`),
  KEY `COD_CATEGORIA_FK` (`COD_CATEGORIA`),
  KEY `COD_UNIDADE_FK` (`COD_UNIDADE`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Extraindo dados da tabela `medicamentos`
--

INSERT INTO `medicamentos` (`COD_MEDICAMENTO`, `COD_BARRAS`, `NOME_COMERCIAL`, `PRINCIPIO_ATIVO`, `INDICACOES`, `PRECO_COMPRA`, `QUANTIDADE_POR_EMBALAGEM`, `QUANTIDADE_DE_EMBALAGEM`, `QUANTIDADE_MIN`, `DATA_VALIDADE`, `APRESENTACAO`, `LABORATORIO`, `MODO_USO`, `OBS`, `COD_CATEGORIA`, `COD_UNIDADE`, `caminho_foto`, `foto`) VALUES
(5, '131', 'QEQWE', 'EWQE', 'QWEQWE', 2, 12, 12, 12, '13/11/1213', 'QEWQE', 'QEWWQEWQE', 'WEQEQE', 'QWEQWE', 1, 1, 'C:UsersManoelDocumentsCIDRONIOkensol.jpg', 0x53797374656d2e427974655b5d),
(6, '35435345', 'SEDOMIN', 'ASDSAD', ' EX. INDICADO CONTRA PICADA DE COBRA.', 2, 12, 12, 12, '31/23/1232', 'ASDSD', 'KONIG', 'EX. APLICAR 5 ML A CADA 12 HORAS.', 'SFSFDF', 4, 3, 'C:UsersManoelDocumentsCIDRONIOmed.jpg', 0x53797374656d2e427974655b5d);

-- --------------------------------------------------------

--
-- Estrutura da tabela `parto`
--

CREATE TABLE IF NOT EXISTS `parto` (
  `CO` int(11) NOT NULL AUTO_INCREMENT,
  `COD_ANIMAL` varchar(7) DEFAULT NULL,
  `DATA_PARTO` varchar(10) DEFAULT NULL,
  `NUM_CRIAS` int(11) DEFAULT NULL,
  `NUM_NATIMORTOS` int(11) DEFAULT NULL,
  PRIMARY KEY (`CO`),
  KEY `FK_PARTO_REFERENCE_ANIMAL` (`COD_ANIMAL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `parto_registro_cria`
--

CREATE TABLE IF NOT EXISTS `parto_registro_cria` (
  `COD_CRIA` varchar(7) NOT NULL,
  `NOME_CRIA` varchar(50) DEFAULT NULL,
  `SEXO_CRIA` char(1) DEFAULT NULL,
  `COD_RACA` varchar(3) DEFAULT NULL,
  `PESO` double DEFAULT NULL,
  `OBS` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`COD_CRIA`),
  KEY `FK_PARTO_RE_REFERENCE_RACA` (`COD_RACA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `pesagem`
--

CREATE TABLE IF NOT EXISTS `pesagem` (
  `COD_PESAGEM` int(11) NOT NULL AUTO_INCREMENT,
  `COD_ANIMAL` varchar(7) DEFAULT NULL,
  `DATA_PESAGEM` varchar(10) DEFAULT NULL,
  `PESO_ATUAL` double DEFAULT NULL,
  PRIMARY KEY (`COD_PESAGEM`),
  KEY `FK_PESAGEM_REFERENCE_ANIMAL` (`COD_ANIMAL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `premiacao`
--

CREATE TABLE IF NOT EXISTS `premiacao` (
  `COD_PREMIACAO` int(11) NOT NULL AUTO_INCREMENT,
  `COD_ANIMAL` varchar(7) DEFAULT NULL,
  `DATA_PREMIACAO` varchar(10) DEFAULT NULL,
  `TITULO` varchar(40) DEFAULT NULL,
  `LOCAL12` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`COD_PREMIACAO`),
  KEY `FK_PREMIACA_REFERENCE_ANIMAL` (`COD_ANIMAL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `raca`
--

CREATE TABLE IF NOT EXISTS `raca` (
  `COD_RACA` varchar(3) NOT NULL,
  `NOME_RACA` varchar(50) DEFAULT NULL,
  `PERIODO_GESTACAO` int(11) DEFAULT NULL,
  PRIMARY KEY (`COD_RACA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `raca`
--

INSERT INTO `raca` (`COD_RACA`, `NOME_RACA`, `PERIODO_GESTACAO`) VALUES
('ABC', 'AKSDJSDAK', 123),
('STI', 'SANTA INES', 150);

-- --------------------------------------------------------

--
-- Estrutura da tabela `unidade`
--

CREATE TABLE IF NOT EXISTS `unidade` (
  `cod_unidade` int(11) NOT NULL AUTO_INCREMENT,
  `nome_unidade` varchar(150) NOT NULL,
  `flag` char(1) NOT NULL,
  PRIMARY KEY (`cod_unidade`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Extraindo dados da tabela `unidade`
--

INSERT INTO `unidade` (`cod_unidade`, `nome_unidade`, `flag`) VALUES
(1, 'ML', 'M'),
(2, 'KG', 'M'),
(3, 'L', 'M'),
(4, 'G', 'M');

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuarios`
--

CREATE TABLE IF NOT EXISTS `usuarios` (
  `idusuarios` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) DEFAULT NULL,
  `permissao` varchar(80) DEFAULT NULL,
  `login` varchar(100) DEFAULT NULL,
  `senha` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`idusuarios`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Estrutura da tabela `venda_animal`
--

CREATE TABLE IF NOT EXISTS `venda_animal` (
  `COD_VENDA` int(11) NOT NULL AUTO_INCREMENT,
  `COD_ANIMAL` varchar(7) DEFAULT NULL,
  `DATA_VENDA` varchar(10) DEFAULT NULL,
  `VALOR_KG` double DEFAULT NULL,
  `PESO_ANIMAL` double DEFAULT NULL,
  `VALOR_TOTAL` double DEFAULT NULL,
  `COMPRADOR` varchar(50) DEFAULT NULL,
  `NOTA_FISCAL` varchar(20) DEFAULT NULL,
  `GTA` varchar(10) DEFAULT NULL,
  `OBS` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`COD_VENDA`),
  KEY `FK_VENDA_AN_REFERENCE_ANIMAL` (`COD_ANIMAL`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `agrupamento`
--
ALTER TABLE `agrupamento`
  ADD CONSTRAINT `FK_AGRUPAME_REFERENCE_ANIMAL` FOREIGN KEY (`COD_ANIMAL`) REFERENCES `animal` (`COD_ANIMAL`),
  ADD CONSTRAINT `FK_AGRUPAME_REFERENCE_CRIADOR` FOREIGN KEY (`COD_CRIADOR`) REFERENCES `criador` (`COD_CRIADOR`);

--
-- Limitadores para a tabela `animal`
--
ALTER TABLE `animal`
  ADD CONSTRAINT `FK_ANIMAL_REFERENCE_LOCAL` FOREIGN KEY (`COD_LOCAL`) REFERENCES `local1` (`COD_LOCAL`),
  ADD CONSTRAINT `FK_ANIMAL_REFERENCE_RACA` FOREIGN KEY (`COD_RACA`) REFERENCES `raca` (`COD_RACA`);

--
-- Limitadores para a tabela `baixa`
--
ALTER TABLE `baixa`
  ADD CONSTRAINT `FK_BAIXA_REFERENCE_ANIMAL` FOREIGN KEY (`COD_ANIMAL`) REFERENCES `animal` (`COD_ANIMAL`),
  ADD CONSTRAINT `FK_BAIXA_REFERENCE_CAUSAS_M` FOREIGN KEY (`COD_CAUSAS_MORTIS`) REFERENCES `causas_mortis` (`COD_CAUSAS_MORTIS`);

--
-- Limitadores para a tabela `cliente`
--
ALTER TABLE `cliente`
  ADD CONSTRAINT `FK_CLIENTE_REFERENCE_ENDERECO` FOREIGN KEY (`COD_ENDERECO`) REFERENCES `endereco` (`COD_ENDERECO`);

--
-- Limitadores para a tabela `coberturas`
--
ALTER TABLE `coberturas`
  ADD CONSTRAINT `FK_COBERTUR_REFERENCE_ANIMAL` FOREIGN KEY (`COD_ANIMAL`) REFERENCES `animal` (`COD_ANIMAL`),
  ADD CONSTRAINT `FK_COBERTUR_REFERENCE_INSEMINA` FOREIGN KEY (`COD_INSEMINADORES`) REFERENCES `inseminadores` (`COD_INSEMINADORES`);

--
-- Limitadores para a tabela `coleta_embrioes`
--
ALTER TABLE `coleta_embrioes`
  ADD CONSTRAINT `FK_COLETA_E_REFERENCE_ANIMAL` FOREIGN KEY (`COD_ANIMAL`) REFERENCES `animal` (`COD_ANIMAL`);

--
-- Limitadores para a tabela `compra`
--
ALTER TABLE `compra`
  ADD CONSTRAINT `FK_COMPRA_REFERENCE_CRIADOR` FOREIGN KEY (`COD_CRIADOR`) REFERENCES `criador` (`COD_CRIADOR`),
  ADD CONSTRAINT `FK_COMPRA_REFERENCE_LOCAL` FOREIGN KEY (`COD_LOCAL`) REFERENCES `local1` (`COD_LOCAL`),
  ADD CONSTRAINT `FK_COMPRA_REFERENCE_RACA` FOREIGN KEY (`COD_RACA`) REFERENCES `raca` (`COD_RACA`);

--
-- Limitadores para a tabela `desmama`
--
ALTER TABLE `desmama`
  ADD CONSTRAINT `FK_DESMAMA_REFERENCE_LOCAL` FOREIGN KEY (`COD_LOCAL`) REFERENCES `local1` (`COD_LOCAL`),
  ADD CONSTRAINT `FK_DESMAMA_REFERENCE_PARTO_RE` FOREIGN KEY (`COD_CRIA`) REFERENCES `parto_registro_cria` (`COD_CRIA`);

--
-- Limitadores para a tabela `diagnostico`
--
ALTER TABLE `diagnostico`
  ADD CONSTRAINT `FK_DIAGNOST_REFERENCE_ANIMAL` FOREIGN KEY (`COD_ANIMAL`) REFERENCES `animal` (`COD_ANIMAL`);

--
-- Limitadores para a tabela `evento_sanitario`
--
ALTER TABLE `evento_sanitario`
  ADD CONSTRAINT `FK_EVENTO_S_REFERENCE_ANIMAL` FOREIGN KEY (`COD_ANIMAL`) REFERENCES `animal` (`COD_ANIMAL`),
  ADD CONSTRAINT `FK_EVENTO_S_REFERENCE_EVENTO_S` FOREIGN KEY (`COD_SANI_ZOO`) REFERENCES `evento_sanitario_zootecnico` (`COD_SANI_ZOO`);

--
-- Limitadores para a tabela `medicamentos`
--
ALTER TABLE `medicamentos`
  ADD CONSTRAINT `COD_CATEGORIA_FK` FOREIGN KEY (`COD_CATEGORIA`) REFERENCES `categoria` (`cod_categoria`) ON DELETE NO ACTION,
  ADD CONSTRAINT `COD_UNIDADE_FK` FOREIGN KEY (`COD_UNIDADE`) REFERENCES `unidade` (`cod_unidade`) ON DELETE NO ACTION;

--
-- Limitadores para a tabela `parto`
--
ALTER TABLE `parto`
  ADD CONSTRAINT `FK_PARTO_REFERENCE_ANIMAL` FOREIGN KEY (`COD_ANIMAL`) REFERENCES `animal` (`COD_ANIMAL`);

--
-- Limitadores para a tabela `parto_registro_cria`
--
ALTER TABLE `parto_registro_cria`
  ADD CONSTRAINT `FK_PARTO_RE_REFERENCE_RACA` FOREIGN KEY (`COD_RACA`) REFERENCES `raca` (`COD_RACA`);

--
-- Limitadores para a tabela `pesagem`
--
ALTER TABLE `pesagem`
  ADD CONSTRAINT `FK_PESAGEM_REFERENCE_ANIMAL` FOREIGN KEY (`COD_ANIMAL`) REFERENCES `animal` (`COD_ANIMAL`);

--
-- Limitadores para a tabela `premiacao`
--
ALTER TABLE `premiacao`
  ADD CONSTRAINT `FK_PREMIACA_REFERENCE_ANIMAL` FOREIGN KEY (`COD_ANIMAL`) REFERENCES `animal` (`COD_ANIMAL`);

--
-- Limitadores para a tabela `venda_animal`
--
ALTER TABLE `venda_animal`
  ADD CONSTRAINT `FK_VENDA_AN_REFERENCE_ANIMAL` FOREIGN KEY (`COD_ANIMAL`) REFERENCES `animal` (`COD_ANIMAL`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
