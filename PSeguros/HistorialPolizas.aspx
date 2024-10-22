<%@ Page Title="" Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="HistorialPolizas.aspx.vb" Inherits="PSeguros.HistorialPolizas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Historial de Pólizas</h2>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="alert alert-danger" />

    <div>
        <!--
        <asp:GridView ID="gvPolizas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None" AllowPaging="True" PageSize="10" DataKeyNames="RAMO,PRODUCTO,POLIZA" >
            <Columns>
                <asp:BoundField DataField="RAMO" HeaderText="Ramo" SortExpression="RAMO" />
                <asp:BoundField DataField="PRODUCTO" HeaderText="Producto" SortExpression="PRODUCTO" />
                <asp:BoundField DataField="POLIZA" HeaderText="Póliza" SortExpression="POLIZA" />
                <asp:BoundField DataField="CLIENTE_TITULAR" HeaderText="Cliente Titular" SortExpression="CLIENTE_TITULAR" />
                <asp:BoundField DataField="NULLDATE" HeaderText="Fecha de Baja Lógica" SortExpression="NULLDATE" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="FECHA_EFECTO" HeaderText="Fecha de Efecto" SortExpression="FECHA_EFECTO" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="FECHA_VIGENCIA" HeaderText="Fecha de Vigencia" SortExpression="FECHA_VIGENCIA" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="DOMICILIO" HeaderText="Domicilio" SortExpression="DOMICILIO" />
                <asp:BoundField DataField="SUMA_ASEGURADA" HeaderText="Suma Asegurada" SortExpression="SUMA_ASEGURADA" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="WAYPAY" HeaderText="Forma de Pago" SortExpression="WAYPAY" />
            </Columns>
        </asp:GridView> -->
        <asp:GridView ID="gvPolizasFalso" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None" AllowPaging="True" PageSize="10">
        <Columns>
            <asp:BoundField DataField="RAMO" HeaderText="Ramo" />
            <asp:BoundField DataField="PRODUCTO" HeaderText="Producto" />
            <asp:BoundField DataField="POLIZA" HeaderText="Póliza" />
            <asp:BoundField DataField="CLIENTE_TITULAR" HeaderText="Cliente Titular" />
            <asp:BoundField DataField="FECHA_EFECTO" HeaderText="Fecha de Efecto" />
            <asp:BoundField DataField="FECHA_VIGENCIA" HeaderText="Fecha de Vigencia" />
        </Columns>
    </asp:GridView>
    </div>

</asp:Content>
