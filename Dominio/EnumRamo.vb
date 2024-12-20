﻿Public Class EnumRamo

    Public Shared Function obtenerDescripcionRamo(posicion As Integer) As String
        Select Case posicion
            Case 1
                Return "Incendio"
            Case 2
                Return "Combinado Familiar"
            Case 5
                Return "Integral de Comercio"
            Case 7
                Return "Riesgos Varios"
            Case 9
                Return "Robo y Riesgos Similares"
            Case 10
                Return "Vida Colectivo"
            Case 12
                Return "Accidentes Personales"
            Case Else
                Return String.Empty
        End Select
    End Function


    Public Shared Function ObtenerDescripcionProducto(codigo As Integer) As String
        Select Case codigo
            Case 1501
                Return "Incendio"
            Case 2041
                Return "Hogar Clientes BGBA"
            Case 2043
                Return "Hogar Empleados"
            Case 2044
                Return "Hogar Canales Alternativos"
            Case 2045
                Return "Hogar Clientes T. Regionales"
            Case 2046
                Return "Hogar Mercado Abierto"
            Case 2047
                Return "Hogar PRA"
            Case 2048
                Return "Hogar PRA Traspaso"
            Case 2050
                Return "Hogar Segmentado"
            Case 5000
                Return "Integral de Comercio PRA"
            Case 5010
                Return "Integral PYME"
            Case 5250
                Return "Silo Bolsa"
            Case 3000
                Return "Reembolso de Contracargos"
            Case 3078
                Return "Desempleo Multicanal"
            Case 3085
                Return "Seguro de Bicicleta"
            Case 3087
                Return "Seguro de Bicicleta BGBA Emp."
            Case 3091
                Return "ATM Plus"
            Case 3092
                Return "Seguro de Compra Protegida"
            Case 3113
                Return "Microemprendedor"
            Case 3500
                Return "Rotura de Pantalla Naranja X"
            Case 3600
                Return "Seguro de Bicicleta"
            Case 3800
                Return "Proteccion Integral Galicia"
            Case 3801
                Return "PIG Stock"
            Case 3900
                Return "Robo ATM Tarjeta Naranja Ind."
            Case 1655
                Return "Robo en Cajero"
            Case 1668
                Return "Robo Celulares"
            Case 1669
                Return "Robo en Via Publica BGBA"
            Case 1670
                Return "Proteccion Tecno Portatil"
            Case 1671
                Return "Accidentes Personales"
            Case Else
                Return codigo
        End Select
    End Function


    Public Shared Function ObtenerDescripcionRol(codigo As Integer) As String
        Select Case codigo
            Case 1
                Return "Contratante"
            Case 2
                Return "Asegurado"
            Case 3
                Return "Tercero"
            Case 5
                Return "Contacto"
            Case 6
                Return "Contragarante"
            Case 7
                Return "Co-Asegurado"
            Case 16
                Return "Beneficiario"
            Case 25
                Return "Pagador"
            Case 31
                Return "Denunciante"
            Case 90
                Return "Representante legal"
            Case 14
                Return "Descripción de prueba"
            Case Else
                Return "Código no encontrado"
        End Select
    End Function


End Class
