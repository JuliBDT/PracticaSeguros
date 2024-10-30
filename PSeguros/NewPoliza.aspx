<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="NewPoliza.aspx.vb" Inherits="PSeguros.NewPoliza" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" onsubmit="return validarFormulario()">
        <h2>Nueva Póliza de Seguro</h2>
        <section class="col-md-4">
            <label for="ddlRamo">Ramo:</label>
            <asp:DropDownList ID="ddlRamos" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRamo_SelectedIndexChanged" required="true">
            </asp:DropDownList>
            <br />

            <label for="ddlProducto">Producto:</label>
            <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-control" required="true">
            </asp:DropDownList>
            <br />

            <label for="ddlClienteTitular">Cliente Titular:</label>
            <asp:DropDownList ID="ddlClienteTitular" runat="server" CssClass="form-control" required="true"></asp:DropDownList>
            <br />

            <label for="txtDomicilio">Domicilio:</label>
            <asp:TextBox ID="txtDomicilio" runat="server" CssClass="form-control" required="true"></asp:TextBox>
            <br />

            <label for="txtSumaAsegurada">Suma Asegurada:</label>
            <asp:TextBox ID="txtSumaAsegurada" runat="server" CssClass="form-control" TextMode="Number" required="true"></asp:TextBox>
            <br />
        </section>

        <section class="col-md-4">
            <label for="txtFechaEfecto">Fecha de Efecto:</label>
            <asp:TextBox ID="txtFechaEfecto" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            <br />

            <label for="txtFechaVigencia">Fecha de Vigencia:</label>
            <asp:TextBox ID="txtFechaVigencia" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            <br />
            
            <label for="ddlWayPay">Forma de Pago:</label>
            <asp:DropDownList ID="ddlWayPay" runat="server" CssClass="form-control" required="true">
            </asp:DropDownList>
            <br />
        </section>


        <asp:Button ID="btnGuardar" runat="server" CssClass="btn-success" Text="Guardar" OnClick="btnGuardar_Click" OnClientClick="return validarFormulario();" />

    </div>
    <script>
        function validarFormulario() {
            var ramo = document.getElementById("<%= ddlRamos.ClientID %>").value;
            var producto = document.getElementById("<%= ddlProductos.ClientID %>").value;
            var cliente = document.getElementById("<%= ddlClienteTitular.ClientID %>").value;
            var domicilio = document.getElementById("<%= txtDomicilio.ClientID %>").value;
            var sumaAsegurada = document.getElementById("<%= txtSumaAsegurada.ClientID %>").value;
            var fechaEfecto = document.getElementById("<%= txtFechaEfecto.ClientID %>").value;
            var fechaVigencia = document.getElementById("<%= txtFechaVigencia.ClientID %>").value;
            var waypay = document.getElementById("<%= ddlWayPay.ClientID %>").value;

            if (ramo === "0") {
                alert("Por favor, seleccione un ramo.");
                return false;
            }

            if (producto === "0") {
                alert("Por favor, seleccione un producto.");
                return false;
            }

            if (cliente === "0") {
                alert("Por favor, seleccione un cliente.");
                return false;
            }

            if (domicilio.trim() === "") {
                alert("Por favor, ingrese el domicilio.");
                return false;
            }

            if (sumaAsegurada.trim() === "") {
                alert("Por favor, ingrese la suma asegurada.");
                return false;
            }

            if (fechaEfecto === "") {
                alert("Si no ingresa una fecha de efecto, se aplicará la fecha de hoy.");
                return true;
            }

            if (fechaVigencia === "") {
                alert("Si no ingresa una fecha de vigencia, se aplicará la fecha de hoy.");
                return true;
            }

            if (waypay === "0") {
                alert("Por favor, seleccione una forma de pago.");
                return false;
            }

            return true;
        }
    </script>

</asp:Content>
