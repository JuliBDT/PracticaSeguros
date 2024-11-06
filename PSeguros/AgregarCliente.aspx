<%@ Page Title="Agregar Cliente" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="AgregarCliente.aspx.vb" Inherits="PSeguros.AgregarCliente" %>
<asp:Content ID="Content1"  ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container my-4">
    <h2 class="text-start">Registrar cliente</h2>
    <div class="row justify-content-start">
        <div class="col-md-6">
            <label for="txtDocumento" class="form-label">DNI/CUIL/CUIT:</label>
            <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control"></asp:TextBox>
            <br />

            <label for="txtNombre" class="form-label">Nombre completo:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            <br />

            <label for="txtFechaNacimiento" class="form-label">Fecha de Nacimiento:</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            <br />

            <label for="ddlEstadoCivil" class="form-label">Estado civil:</label>
            <asp:DropDownList ID="ddlEstadoCivil" runat="server" CssClass="form-control" placeholder="--Seleccionar--" required="true">
            </asp:DropDownList>
            <br />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary w-100 mt-3" OnClick="btnGuardar_Click" AutoPostBack="True" />
        </div>
    </div>
</div>


</asp:Content>
