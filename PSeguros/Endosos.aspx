<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Endosos.aspx.vb" Inherits="PSeguros.Endosos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Endoso de Póliza</h2>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />

    <div>
        <label for="txtRamo">Ramo:</label>
        <asp:TextBox ID="txtRamo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        <br />

        <label for="txtProducto">Producto:</label>
        <asp:TextBox ID="txtProducto" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        <br />

        <label for="txtPoliza">Póliza:</label>
        <asp:TextBox ID="txtPoliza" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        <br />

        <label for="txtClienteTitular">Cliente Titular:</label>
        <asp:TextBox ID="txtClienteTitular" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
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

        <label for="txtWayPay">Forma de Pago (WayPay):</label>
        <asp:TextBox ID="txtWayPay" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        <br />

    </div>

</asp:Content>
