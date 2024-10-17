--Creación de los SP de ROLEMASTER
CREATE OR REPLACE PROCEDURE waypaymaster_insert (
    wp_waypay NUMBER,
    wp_fechacomputo DATE,
    wp_descripcion VARCHAR2,
    wp_estadoregistro NUMBER,
    wp_codusuario NUMBER
)
IS
BEGIN
    INSERT INTO WAYPAYMASTER (WAYPAY, FECHACOMPUTO, DESCRIPCION, ESTADOREGISTRO, CODUSUARIO)
    VALUES (wp_waypay, wp_fechacomputo, wp_descripcion, wp_estadoregistro, wp_codusuario);

END waypaymaster_insert;

----------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE waypaymaster_delete (
    wp_waypay INTEGER
)
IS
BEGIN
    DELETE FROM WAYPAYMASTER
    WHERE WAYPAY = wp_waypay;

END waypaymaster_delete;

-----------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE waypaymaster_update (
    wp_waypay INTEGER,
    wp_fechacomputo DATE,
    wp_descripcion VARCHAR2,
    wp_estadoregistro NUMBER,
    wp_codusuario NUMBER
)
IS
BEGIN
    UPDATE WAYPAYMASTER
    SET FECHACOMPUTO = wp_fechacomputo,
        DESCRIPCION = wp_descripcion,
        ESTADOREGISTRO = wp_estadoregistro,
        CODUSUARIO = wp_codusuario
    WHERE WAYPAY = wp_waypay;

END waypaymaster_update;