<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="NewPoliza.aspx.vb" Inherits="PSeguros.NewPoliza" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h2>Nueva Póliza de Seguro</h2>
        <label for="ddlRamo">Ramo:</label>
        <asp:DropDownList ID="ddlRamo" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRamo_SelectedIndexChanged">
        </asp:DropDownList>
        <br />

        <label for="ddlProducto">Producto:</label>
        <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged">
        </asp:DropDownList>
        <br />

        <label for="ddlPoliza">Póliza:</label>
        <asp:DropDownList ID="ddlPoliza" runat="server" CssClass="form-control">
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

        <label for="txtWayPay">Forma de Pago (WayPay):</label>
        <asp:TextBox ID="txtWayPay" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
        <br />

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
    </div>

</asp:Content>
