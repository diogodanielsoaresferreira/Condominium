use p1g1;

-- Indexes for all tables

-- Prédio
-- ID unique clustered with fill factor 100 (Default)

-- Fração
-- ID unique clustered with fill factor 100 (Default)
-- ID_Predio with fill factor 80
CREATE INDEX ixID_Predio ON CONDOMINIUM.FRACAO(ID_Predio) WITH (FILLFACTOR=80);

-- Condómino
-- CC unique clustered with fill factor 75 (Alterar fill factor em index Default)
-- NIF unique with fill factor 75 (Alterar fill factor em index Default)

-- Aviso
-- ID unique clustered with fill factor 100 (Default)
-- ID_Predio with fill factor 80
CREATE INDEX ixID_Predio ON CONDOMINIUM.AVISO(ID_Predio) WITH (FILLFACTOR=80);
-- ID_Predio and date with fill factor 80
CREATE INDEX ixID_Predio_Date ON CONDOMINIUM.AVISO(ID_Predio, Data) WITH (FILLFACTOR=80);

-- Nota
-- ID unique clustered with fill factor 100 (Default)
-- ID_Predio with fill factor 80
CREATE INDEX ixID_Predio ON CONDOMINIUM.NOTA(ID_Predio) WITH (FILLFACTOR=80);
-- ID_Predio and date with fill factor 80
CREATE INDEX ixID_Predio_Date ON CONDOMINIUM.NOTA(ID_Predio, Data) WITH (FILLFACTOR=80);

-- Reunião
-- ID unique clustered with fill factor 100 (Default)
-- ID_Predio with fill factor 80
CREATE INDEX ixID_Predio ON CONDOMINIUM.REUNIAO(ID_Predio) WITH (FILLFACTOR=80);
-- ID_Predio and date with fill factor 80
CREATE INDEX ixID_Predio_Date ON CONDOMINIUM.REUNIAO(ID_Predio, Data) WITH (FILLFACTOR=80);


-- Manutenção
-- ID unique clustered with fill factor 100 (Default)
-- ID_Predio with fill factor 80
CREATE INDEX ixID_Predio ON CONDOMINIUM.MANUTENCAO(ID_Predio) WITH (FILLFACTOR=80);
-- ID_Predio and date with fill factor 80
CREATE INDEX ixID_Predio_Date ON CONDOMINIUM.MANUTENCAO(ID_Predio, Data) WITH (FILLFACTOR=80);
-- Outros Pagamentos with fill factor 80
CREATE INDEX ixOutrosPagamentos ON CONDOMINIUM.MANUTENCAO(ID_Outros_Pagamentos) WITH (FILLFACTOR=80);

-- Outros Pagamentos
-- ID unique clustered with fill factor 100 (Default)
-- NIF with fill factor 80
CREATE INDEX ixNIF ON CONDOMINIUM.Outros_Pagamentos(suj_fiscal_nif) WITH (FILLFACTOR=80);
-- ID_Predio and date with fill factor 80
CREATE INDEX ixID_Predio_Date ON CONDOMINIUM.Outros_Pagamentos(ID_Predio, Data) WITH (FILLFACTOR=80);
-- ID_Predio and Date witb Balanco Covered with fill factor 80
CREATE INDEX ixID_Predio_DateWithBalanco ON CONDOMINIUM.Outros_Pagamentos(ID_Predio, Data) INCLUDE (balanco) WITH (FILLFACTOR=80);

-- Pagamento Quota
-- ID unique clustered with fill factor 100 (Default)
-- ID_Fracao with fill factor 80
CREATE INDEX ixID_Fracao ON CONDOMINIUM.PAGAMENTO_QUOTA(ID_Fracao) WITH (FILLFACTOR=80);
-- Mês with fill factor 80
CREATE INDEX ixID_Mes ON CONDOMINIUM.PAGAMENTO_QUOTA(mes) WITH (FILLFACTOR=80);
-- ID_Predio and date with fill factor 80
CREATE INDEX ixID_Date_Fracao ON CONDOMINIUM.PAGAMENTO_QUOTA(Data, ID_Fracao) WITH (FILLFACTOR=80);
-- ID_Predio and Date witb Balanco Covered with fill factor 80
CREATE INDEX ixID_Date_FracaoWithBalanco ON CONDOMINIUM.PAGAMENTO_QUOTA(Data, ID_Fracao) INCLUDE (balanco) WITH (FILLFACTOR=80);

-- Sujeito Fiscal
-- NIF unique clustered with fill factor 75 (Change fill factor in default)

-- Compra
-- ID unique clustered with fill factor 100 (Default)
-- CC_Condomino with fill factor 80
CREATE INDEX ixID_Condomino ON CONDOMINIUM.Compra(CC_Condomino) WITH (FILLFACTOR=80);
-- ID_Fracao with fill factor 80
CREATE INDEX ixID_Fracao ON CONDOMINIUM.Compra(ID_Fracao) WITH (FILLFACTOR=80);

-- Foto-Fraçao
-- Drop existing index
-- ID_Fracao with fill factor 70
CREATE CLUSTERED INDEX ix_Fracao ON CONDOMINIUM.FOTO_FRACAO(ID_Fracao) WITH (FILLFACTOR=70);

-- Fotos_Predio
-- Drop existing index
-- ID_Predio with fill factor 70
CREATE CLUSTERED INDEX ix_Predio ON CONDOMINIUM.FOTOS_PREDIO(ID) WITH (FILLFACTOR=70);

-- Condomino participa reunião
-- Drop existing index
-- ID_Reuniao with fill factor 70
CREATE CLUSTERED INDEX ix_Reuniao ON CONDOMINIUM.CONDOMINO_PARTICIPA_REUNIAO(ID_Reuniao) WITH (FILLFACTOR=70);

-- Condómino recebe aviso
-- Drop existing index
-- ID_Aviso with fill factor 70
CREATE CLUSTERED INDEX ix_Reuniao ON CONDOMINIUM.CONDOMINO_RECEBE_AVISO(ID_Aviso) WITH (FILLFACTOR=70);

-- Orcamento
-- ID unique clustered with fill factor 100 (Default)
-- Dates and ID_Predio index with fill factor 80
CREATE INDEX ix_Dates_Predio ON CONDOMINIUM.Orcamento(Data_Inicial, Data_Final, ID_Predio) WITH (FILLFACTOR=80);


-- Item
-- Drop default index
-- Orcamento_ID clustered index with fill_factor 80
CREATE CLUSTERED INDEX ix_orcamento ON CONDOMINIUM.Item(Orcamento_ID) WITH (FILLFACTOR=80);
