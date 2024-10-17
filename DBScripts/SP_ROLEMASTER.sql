--Creación de los SP de ROLEMASTER
CREATE OR REPLACE PROCEDURE rolemaster_insert (
    rm_rol INTEGER,
    rm_fechacomputo DATE,
    rm_descripcion VARCHAR2,
    rm_estadoregistro NUMBER,
    rm_codusuario INT
)
IS
BEGIN
    INSERT INTO ROLEMASTER (ROL, FECHACOMPUTO, DESCRIPCION, ESTADOREGISTRO, CODUSUARIO)
    VALUES (rm_rol, rm_fechacomputo, rm_descripcion, rm_estadoregistro, rm_codusuario);

END rolemaster_insert;

----------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE rolemaster_delete (
    rm_rol INTEGER
)
IS
BEGIN
    DELETE FROM ROLEMASTER
    WHERE ROL = rm_rol;

END rolemaster_delete;

-----------------------------------------------------------------------------------------

CREATE OR REPLACE PROCEDURE rolemaster_update (
    rm_rol INTEGER,
    rm_fechacomputo DATE,
    rm_descripcion VARCHAR2,
    rm_estadoregistro NUMBER,
    rm_codusuario INT
)
IS
BEGIN
    UPDATE ROLEMASTER
    SET FECHACOMPUTO = rm_fechacomputo,
        DESCRIPCION = rm_descripcion,
        ESTADOREGISTRO = rm_estadoregistro,
        CODUSUARIO = rm_codusuario
    WHERE ROL = rm_rol;

END rolemaster_update;

-----------------------------------------------------------------------------------------



-----------------------------------------------------------------------------------------



-----------------------------------------------------------------------------------------