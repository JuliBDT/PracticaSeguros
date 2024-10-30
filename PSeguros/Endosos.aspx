<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Endosos.aspx.vb" Inherits="PSeguros.Endosos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div onsubmit="return validarFormulario();">
        <h2>Endoso de Póliza</h2>

        <div class="row" >
            <section class="col-md-4">
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

                <label for="ddlClienteTitular">Cliente Titular:</label>
                <asp:DropDownList ID="ddlClienteTitular" runat="server" CssClass="form-control" required="true"></asp:DropDownList>
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
            </section>
            <section class="col-md-4">
                <h4>Agregar rol</h4>
                <label>
                    <input type="checkbox" runat="server" id="chkHabilitarRol" ClientIDMode="Static" onclick="toggleSeccionRol()">Habilitar
                </label>
                <br />
                <div id="frmRol">
                                                        
                    <label for="ddlRol">Rol:</label>
                    <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control" TextMode="Number" >
                    </asp:DropDownList>
                    <br />

                    <label for="ddlClienteRol">Usuario de rol:</label>
                    <asp:DropDownList ID="ddlClienteRol" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                    <br />

                    <label for="txtFechaEfectoRol">Fecha de Efecto:</label>
                    <asp:TextBox ID="txtFechaEfectoRol" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <br />
                    

                </div>
            </section>

        </div>
        

        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" AutoPostBack="True" OnClientClick="return validarFormulario();"/>
        <asp:Button ID="BtnBaja" runat="server" Text="Dar de Baja" OnClick="btnBaja_Click" AutoPostBack="True" />
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

            var rol = document.getElementById("<%= ddlRol.ClientID %>")
            var clienteRol = document.getElementById("<%= ddlClienteRol.ClientID %>")
            var fechaEfectoRol = document.getElementById("<%= txtFechaEfectoRol.ClientID %>")

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

            if (document.getElementById("<%= chkHabilitarRol.ClientID %>").checked) {
                if (rol === "0") {
                    alert("Por  favor, ingrese un rol")
                    return false;
                }
                if (clienteRol === "0") {
                    alert("Por  favor, ingrese un cliente para el rol")
                    return false;
                }
                if (fechaEfectoRol === "") {
                    alert("Si no ingresa una fecha de efecto, se aplicará la fecha de hoy.");
                    return true;
                }
            }


            return true;
        }

        function toggleSeccionRol() {
            var seccionRol = document.getElementById("frmRol");
            var habilitar = document.getElementById("chkHabilitarRol").checked;

            // Cambia el estado de los elementos en la sección
            Array.from(seccionRol.querySelectorAll("select, input")).forEach(function (element) {
                element.disabled = !habilitar;
            });
        }

        // Deshabilita la sección al cargar la página
        document.addEventListener("DOMContentLoaded", function () {
            toggleSeccionRol();
        });
    </script>

</asp:Content>