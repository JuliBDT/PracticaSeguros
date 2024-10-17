--Creación de los SP de PRODUCTEMASTER
CREATE OR REPLACE PROCEDURE branchmaster_insert (
    bm_ramo             NUMBER,
    bm_fechacomputo     DATE,
    bm_descripcion      VARCHAR2,
    bm_estadoregistro   NUMBER,
    bm_codusuario       NUMBER
)
IS
BEGIN
    INSERT INTO BRANCHMASTER (RAMO, FECHACOMPUTO, DESCRIPCION, ESTADOREGISTRO, CODUSUARIO)
    VALUES (bm_ramo, bm_fechacomputo, bm_descripcion, bm_estadoregistro, bm_codusuario);

END branchmaster_insert;

----------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE branchmaster_delete (
    bm_ramo     NUMBER
)
IS
BEGIN
    DELETE FROM BRANCHMASTER
    WHERE RAMO = bm_ramo;

END branchmaster_delete;

-----------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE branchmaster_update (
    bm_ramo             NUMBER,
    bm_fechacomputo     DATE,
    bm_descripcion      VARCHAR2,
    bm_estadoregistro   NUMBER,
    bm_codusuario       NUMBER
)
IS
BEGIN
    UPDATE BRANCHMASTER
    SET FECHACOMPUTO    = bm_fechacomputo,
        DESCRIPCION     = bm_descripcion,
        ESTADOREGISTRO  = bm_estadoregistro,
        CODUSUARIO      = bm_codusuario
    WHERE RAMO = bm_ramo;

END branchmaster_update;