--Creación de los SP de CLIENTES
CREATE OR REPLACE PROCEDURE clientes_insert (
    c_cliente           VARCHAR2,
    c_nom_completo      VARCHAR2,
    c_fecha_nacimiento  DATE,
    c_nulldate          DATE,
    c_estado_civil      INT
)
IS
BEGIN
    INSERT INTO CLIENTES (CLIENTE, NOM_COMPLETO, FECHA_NACIMIENTO, NULLDATE, ESTADO_CIVIL)
    VALUES (c_cliente, c_nom_completo, c_fecha_nacimiento, c_nulldate, c_estado_civil);

END clientes_insert;

----------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE clientes_delete (
    c_cliente VARCHAR2
)
IS
BEGIN
    DELETE FROM CLIENTES
    WHERE   CLIENTE = c_cliente;

END clientes_delete;

-----------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE clientes_update (
    c_cliente           VARCHAR2,
    c_nom_completo      VARCHAR2,
    c_fecha_nacimiento  DATE,
    c_nulldate          DATE,
    c_estado_civil      INT
)
IS
BEGIN
    UPDATE CLIENTES
    SET NOM_COMPLETO = c_nom_completo,
        FECHA_NACIMIENTO = c_fecha_nacimiento,
        NULLDATE = c_nulldate,
        ESTADO_CIVIL = c_estado_civil
        
        
    WHERE   CLIENTE = c_cliente;

END clientes_update;
