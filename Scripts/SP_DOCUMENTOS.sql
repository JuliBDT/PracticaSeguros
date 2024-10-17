--Creación de los SP de DOCUMENTOS
CREATE OR REPLACE PROCEDURE documentos_insert (
    d_doctype           NUMBER,
    d_documento         VARCHAR2,
    d_cliente           VARCHAR2,
    d_ccd               NUMBER,
    d_fechaexpiracion   DATE
)
IS
BEGIN
    INSERT INTO DOCUMENTOS (DOCTYPE, DOCUMENTO, CLIENTE, CUIL_CUIT_DNI, FECHAEXPIRACION)
    VALUES (d_doctype, d_documento, d_cliente, d_ccd, d_fechaexpiracion);

END documentos_insert;

----------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE documentos_delete (
    d_doctype   INTEGER,
    d_documento VARCHAR2,
    d_cliente   VARCHAR2,
    d_ccd       NUMBER
)
IS
BEGIN
    DELETE FROM DOCUMENTOS
    WHERE   DOCTYPE = d_doctype
        AND DOCUMENTO = d_documento
        AND CLIENTE = d_cliente
        AND CUIL_CUIT_DNI = d_ccd;

END documentos_delete;

-----------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE documentos_update (
    d_doctype           INTEGER,
    d_documento         VARCHAR2,
    d_cliente           VARCHAR2,
    d_ccd               NUMBER,
    d_fechaexpiracion   DATE
)
IS
BEGIN
    UPDATE DOCUMENTOS
    SET FECHAEXPIRACION = d_fechaexpiracion
    WHERE   DOCTYPE = d_doctype
        AND DOCUMENTO = d_documento
        AND CLIENTE = d_cliente
        AND CUIL_CUIT_DNI = d_ccd;

END documentos_update;
