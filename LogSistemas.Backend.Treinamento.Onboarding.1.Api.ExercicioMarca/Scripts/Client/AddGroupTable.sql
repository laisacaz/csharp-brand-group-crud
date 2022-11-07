CREATE TABLE pro_grupo (
	cod int NOT NULL  GENERATED  BY DEFAULT AS IDENTITY,
	descricao varchar (30) NOT NULL,
	ativo bool NOT NULL,
	subgrupo bool NULL,
	data_inicial timestamp NULL,
	CONSTRAINT pro_grupo_pk PRIMARY KEY (cod)); 
