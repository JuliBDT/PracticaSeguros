<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Roles.aspx.vb" Inherits="PSeguros.Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Ingreso de Roles</h2>
    <div>
        <label for="ddlRamo">Ramo:</label>
        <asp:DropDownList ID="ddlRamos" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRamo_SelectedIndexChanged">
        </asp:DropDownList>
        <br />

        <label for="ddlProducto">Producto:</label>
        <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-control" AutoPostBack="True">
        </asp:DropDownList>
        <br />

        <label for="ddlRol">Rol:</label>
        <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control" TextMode="Number">
        </asp:DropDownList>
        <br />

        <label for="txtClienteTitular">Cliente:</label>
        <asp:TextBox ID="txtClienteTitular" runat="server" CssClass="form-control"></asp:TextBox>
        <br />

        <label for="txtFechaEfecto">Fecha de Efecto:</label>
        <asp:TextBox ID="txtFechaEfecto" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        <br />
        
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" AutoPostBack="True" />
    </div>

</asp:Content>
