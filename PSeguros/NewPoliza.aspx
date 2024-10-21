<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="NewPoliza.aspx.vb" Inherits="PSeguros.NewPoliza" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h2>Nueva Póliza de Seguro</h2>
        <label for="txtRamo">Ramo:</label>
        <asp:TextBox ID="txtRamo" runat="server" TextMode="Number"></asp:TextBox>
        <br />

        <label for="txtProducto">Producto:</label>
        <asp:TextBox ID="txtProducto" runat="server" TextMode="Number"></asp:TextBox>
        <br />

        <label for="txtPoliza">Póliza:</label>
        <asp:TextBox ID="txtPoliza" runat="server" TextMode="Number"></asp:TextBox>
        <br />

        <label for="txtClienteTitular">Cliente Titular:</label>
        <asp:TextBox ID="txtClienteTitular" runat="server"></asp:TextBox>
        <br />

        <label for="txtFechaEfecto">Fecha de Efecto:</label>
        <asp:TextBox ID="txtFechaEfecto" runat="server" TextMode="Date"></asp:TextBox>
        <br />

        <label for="txtFechaVigencia">Fecha de Vigencia:</label>
        <asp:TextBox ID="txtFechaVigencia" runat="server" TextMode="Date"></asp:TextBox>
        <br />

        <label for="txtDomicilio">Domicilio:</label>
        <asp:TextBox ID="txtDomicilio" runat="server"></asp:TextBox>
        <br />

        <label for="txtSumaAsegurada">Suma Asegurada:</label>
        <asp:TextBox ID="txtSumaAsegurada" runat="server" TextMode="Number"></asp:TextBox>
        <br />

        <label for="txtWayPay">Forma de Pago (WayPay):</label>
        <asp:TextBox ID="txtWayPay" runat="server" TextMode="Number"></asp:TextBox>
        <br />
    </div>

</asp:Content>
