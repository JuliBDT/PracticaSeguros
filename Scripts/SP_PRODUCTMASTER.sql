--Creación de los SP de PRODUCTEMASTER
CREATE OR REPLACE PROCEDURE productmaster_insert (
    pm_ramo             NUMBER,
    pm_producto         NUMBER,
    pm_fechacomputo     DATE,
    pm_descripcion      VARCHAR2,
    pm_estadoregistro   NUMBER,
    pm_codusuario       NUMBER
)
IS
BEGIN
    INSERT INTO PRODUCTMASTER (RAMO, PRODUCTO, FECHACOMPUTO, DESCRIPCION, ESTADOREGISTRO, CODUSUARIO)
    VALUES (pm_ramo, pm_producto, pm_fechacomputo, pm_descripcion, pm_estadoregistro, pm_codusuario);

END productmaster_insert;

----------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE productmaster_delete (
    pm_ramo     NUMBER,
    pm_producto NUMBER
)
IS
BEGIN
    DELETE FROM PRODUCTMASTER
    WHERE RAMO = pm_ramo AND PRODUCTO = pm_producto;

END productmaster_delete;

-----------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE productmaster_update (
    pm_ramo             NUMBER,
    pm_producto         NUMBER,
    pm_fechacomputo     DATE,
    pm_descripcion      VARCHAR2,
    pm_estadoregistro   NUMBER,
    pm_codusuario       NUMBER
)
IS
BEGIN
    UPDATE PRODUCTMASTER
    SET FECHACOMPUTO    = pm_fechacomputo,
        DESCRIPCION     = pm_descripcion,
        ESTADOREGISTRO  = pm_estadoregistro,
        CODUSUARIO      = pm_codusuario
    WHERE RAMO = pm_ramo AND PRODUCTO = pm_producto;

END productmaster_update;

