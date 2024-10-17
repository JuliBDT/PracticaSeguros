CREATE OR REPLACE NONEDITIONABLE PROCEDURE POLIZA_UPDATE (
    p_RAMO NUMBER,
    p_PRODUCTO NUMBER,
    p_POLIZA NUMBER,
    p_CLIENTE_TITULAR VARCHAR2,
    p_NULLDATE DATE,
    p_FECHA_EFECTO DATE,
    p_FECHA_VIGENCIA DATE,
    p_DOMICILIO VARCHAR2,
    p_SUMA_ASEGURADA NUMBER,
    p_WAYPAY NUMBER
)
IS
BEGIN
    -- Previo a cambiar, lo traemos e insertamos en la tabla historial
    INSERT INTO Historial_Polizas ( 
        ramo, 
        producto, 
        poliza, 
        cliente_titular, 
        nulldate, 
        fecha_efecto, 
        fecha_vigencia, 
        domicilio, 
        suma_asegurada, 
        waypay
    )
    SELECT 
        ramo, 
        producto, 
        poliza, 
        cliente_titular, 
        nulldate, 
        fecha_efecto, 
        fecha_vigencia, 
        domicilio, 
        suma_asegurada, 
        waypay
    FROM Poliza
    WHERE ramo = p_RAMO
    AND producto = p_PRODUCTO
    AND poliza = p_POLIZA;
    
    -- Realizamos el update en dicha póliza
    UPDATE POLIZA
    SET CLIENTE_TITULAR = P_CLIENTE_TITULAR,
        NULLDATE = p_NULLDATE,
        FECHA_EFECTO = P_FECHA_EFECTO,
        FECHA_VIGENCIA = P_FECHA_VIGENCIA,
        DOMICILIO = P_DOMICILIO,
        SUMA_ASEGURADA = P_SUMA_ASEGURADA,
        WAYPAY = P_WAYPAY
    WHERE RAMO = p_RAMO AND PRODUCTO = p_PRODUCTO AND POLIZA = p_POLIZA;

END POLIZA_UPDATE;

