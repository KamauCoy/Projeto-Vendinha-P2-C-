-- Database: Vendinha

CREATE DATABASE "Vendinha"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;



CREATE TABLE clientes (
    id SERIAL PRIMARY KEY,
    nome_completo VARCHAR(200) NOT NULL,
    cpf VARCHAR(14) NOT NULL,
    data_nascimento TIMESTAMP NOT NULL,
    email VARCHAR(150) NOT NULL
);

CREATE TABLE dividas (
    id SERIAL PRIMARY KEY,
    valor DECIMAL(18,2) NOT NULL,
    paga BOOLEAN NOT NULL DEFAULT FALSE,
    data_criacao TIMESTAMP NOT NULL,
    data_pagamento TIMESTAMP,
    cliente_id INT NOT NULL REFERENCES clientes(id) 
);