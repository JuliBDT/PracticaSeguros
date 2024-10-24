﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Endosos.aspx.vb" Inherits="PSeguros.Endosos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h2>Endoso de Póliza</h2>
        <label for="ddlRamo">Ramo:</label>
        <asp:DropDownList ID="ddlRamos" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRamo_SelectedIndexChanged">
        </asp:DropDownList>
        <br />

        <label for="ddlProducto">Producto:</label>
        <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-control" AutoPostBack="True">
        </asp:DropDownList>
        <br />

        <label for="ddlPoliza">Póliza:</label>
        <asp:DropDownList ID="ddlPolizas" runat="server" CssClass="form-control" AutoPostBack="True">
        </asp:DropDownList>
        <br />

        <label for="txtClienteTitular">Cliente Titular:</label>
        <asp:TextBox ID="txtClienteTitular" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <label for="txtFechaEfecto">Fecha de Efecto:</label>
        <asp:TextBox ID="txtFechaEfecto" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <br />

        <label for="txtFechaVigencia">Fecha de Vigencia:</label>
        <asp:TextBox ID="txtFechaVigencia" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <br />

        <label for="txtDomicilio">Domicilio:</label>
        <asp:TextBox ID="txtDomicilio" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <label for="txtSumaAsegurada">Suma Asegurada:</label>
        <asp:TextBox ID="txtSumaAsegurada" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        <br />

        <label for="ddlWayPay">Forma de Pago:</label>
        <asp:DropDownList ID="ddlWayPay" runat="server" CssClass="form-control" AutoPostBack="True">
        </asp:DropDownList>
        <br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" AutoPostBack="True" />
        <asp:Button ID="BtnBaja" runat="server" Text="Dar de Baja" OnClick="btnBaja_Click" AutoPostBack="True" />
    </div>

</asp:Content>