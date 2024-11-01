<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AgregarCliente.aspx.vb" Inherits="PSeguros.AgregarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Registrar cliente</h2>
    <div>
        <label for="txtDocumento">DNI/CUIL/CUIT:</label>
        <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <label for="txtNombre">Nombre completo:</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        <br />
        <label for="txtFechaNacimiento">Fecha de Nacimiento:</label>
        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <br />
        <label for="ddlEstadoCivil">Estado civil:</label>
        <asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="form-control" placeholder="--Seleccionar--" required="true">
        </asp:DropDownList>
        <br />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" AutoPostBack="True" />
    </div>







</asp:Content>
