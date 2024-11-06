<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="PSeguros._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <!-- Encabezado -->
            <section class="text-center my-5">
                <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Fotos/logo.jpg" AlternateText="Logo" CssClass="mb-4" Width="150px" />
                <h1 id="aspnetTitle" class="display-4" style="font-family: 'Roboto Slab', serif;">Bienvenido a JuMat Seguros</h1>
                <p class="lead">Tu tranquilidad es nuestra prioridad.</p>
                <p class="text-muted">En JuMat Seguros, nos comprometemos a proteger lo que más importa: tu familia, tu hogar, tu vehículo y tu futuro. Ofrecemos una amplia gama de seguros personalizados para satisfacer tus necesidades.</p>
            </section>

            <!-- Productos y Razones para elegirnos -->
            <div class="row my-5">
                <section class="col-md-6 mb-4" aria-labelledby="gettingStartedTitle">
                    <h2 id="gettingStartedTitle" class="h4">Nuestros productos</h2>
                    <ul class="list-group list-group-flush mb-3">
                        <li class="list-group-item">Seguro de Hogar: Protege tu hogar y tus pertenencias</li>
                        <li class="list-group-item">Seguro de Automóvil: Conduce con tranquilidad</li>
                        <li class="list-group-item">Seguro de Vida: Asegura el futuro de tus seres queridos</li>
                        <li class="list-group-item">Seguro de Salud: Accede a la mejor atención médica</li>
                    </ul>
                    <a class="btn btn-primary btn-md" href="https://go.microsoft.com/fwlink/?LinkId=301948">Conoce más &raquo;</a>
                </section>

                <section class="col-md-6 mb-4" aria-labelledby="librariesTitle">
                    <h2 id="librariesTitle" class="h4">Por qué elegir JuMat</h2>
                    <ul class="list-group list-group-flush mb-3">
                        <li class="list-group-item">Cobertura integral y personalizada</li>
                        <li class="list-group-item">Precios competitivos</li>
                        <li class="list-group-item">Asistencia 24/7</li>
                        <li class="list-group-item">Equipo experto y comprometido</li>
                    </ul>
                    <a class="btn btn-primary btn-md" href="https://go.microsoft.com/fwlink/?LinkId=301949">Conoce más &raquo;</a>
                </section>        
            </div>

            <!-- Cotización gratuita -->
            <section class="text-center py-4 bg-light">
                <h2 class="h4">Obtén una cotización gratuita</h2>
                <p class="text-muted">Llena nuestro formulario de contacto y un asesor especializado te brindará una cotización personalizada.</p>
            </section>

            <!-- Contacto y redes sociales -->
            <div class="row text-center mt-5">
                <section class="col-md-6 mb-4">
                    <h2 class="h4">Contáctanos</h2>  
                    <p><i class="fas fa-phone"></i> Teléfono: 01 800 JUMAT (58628)</p>
                    <p><i class="fas fa-envelope"></i> Correo electrónico: info@jumatseguros.com</p>
                    <p><i class="fas fa-map-marker-alt"></i> Dirección: Calle Falsa 123, CABA</p>
                </section>
                
                <section class="col-md-6 mb-4">
                    <h2 class="h4">Síguenos</h2>  
                    <p><i class="fab fa-facebook"></i> Facebook: @JuMatSeguros</p>
                    <p><i class="fab fa-twitter"></i> Twitter: @JuMatSeguros</p>
                    <p><i class="fab fa-instagram"></i> Instagram: @JuMatSeguros</p>
                </section>
            </div>
        </div>
        <style>

        </style>
    </main>    
</asp:Content>
