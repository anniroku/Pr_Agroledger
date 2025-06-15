<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Pr_Agroledger.Dashboard" %>

<!DOCTYPE html>

<html lang="es">
<head runat="server">
  <meta charset="UTF-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <title>Dashboard - AgroLedger</title>

  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" />
  <link href="asp.css" rel="stylesheet" />
  <style>
    .sidebar {
        height: 100vh;
        background-color: rgba(32, 90, 35, 0.95);
        color: white;
    }
    .sidebar a {
        color: white;
        text-decoration: none;
        padding: 10px;
        display: block;
    }
    .sidebar a:hover {
        background-color: rgba(32, 90, 35, 0.85);
    }

    /* Animaciones personalizadas */
    .fade-in {
        opacity: 0;
        transform: translateY(20px);
        animation: fadeInUp 0.8s ease forwards;
    }

    @keyframes fadeInUp {
        to {
            opacity: 1;
            transform: translateY(0);
        }
    }

    .fade-delay-1 { animation-delay: 0.2s; }
    .fade-delay-2 { animation-delay: 0.4s; }
    .fade-delay-3 { animation-delay: 0.6s; }
  </style>
</head>
<body>
  <form id="form1" runat="server">
    <div class="container-fluid">
      <div class="row">
        <!-- Sidebar -->
        <div class="col-md-2 sidebar d-flex flex-column p-3">
          <h4>AgroLedger</h4>
          <img src="image/logo_empresa.jpg" alt="Logo AgroLedger" 
       class="img-fluid rounded-circle mb-3" 
       style="width: 100px; height: 100px; object-fit: cover;" />
  <hr />

          <asp:HyperLink ID="hlUsuarios" NavigateUrl="usuarios.aspx" runat="server">Usuarios</asp:HyperLink>
          <asp:HyperLink ID="hlClientes" NavigateUrl="clientes.aspx" runat="server">Clientes</asp:HyperLink>
          <asp:HyperLink ID="hlVentas" NavigateUrl="ventas.aspx" runat="server">Ventas</asp:HyperLink>
          <asp:HyperLink ID="hlProductos" NavigateUrl="productos.aspx" runat="server">Productos</asp:HyperLink>
          <asp:HyperLink ID="hlDetalles" NavigateUrl="detalle_de_venta.aspx" runat="server">Detalles de ventas</asp:HyperLink>
          <asp:HyperLink ID="hlProveedores" NavigateUrl="proveedores.aspx" runat="server">Proveedores</asp:HyperLink>
          <asp:HyperLink ID="hlFacturas" NavigateUrl="registro_factura.aspx" runat="server">Registro de facturas</asp:HyperLink>
          <asp:LinkButton ID="btnCerrarSesion" runat="server" OnClick="btnCerrarSesion_Click">Cerrar sesión</asp:LinkButton>
        </div>

        <!-- Contenido principal -->
        <div class="col-md-10 p-4">
          <h2 class="fade-in">Panel de Facturación</h2>

          <div class="row mt-4">
            <div class="col-md-4 fade-in fade-delay-1">
              <div class="card shadow-sm p-3">
                <h5>Total de Facturas</h5>
                <asp:Label ID="lblTotalFacturas" runat="server" CssClass="fs-3 text-success" />
              </div>
            </div>
            <div class="col-md-4 fade-in fade-delay-2">
              <div class="card shadow-sm p-3">
                <h5>Ingresos del Mes</h5>
                <asp:Label ID="lblIngresosMes" runat="server" CssClass="fs-3 text-primary" />
              </div>
            </div>
            <div class="col-md-4 fade-in fade-delay-3">
              <div class="card shadow-sm p-3">
                <h5>Clientes Registrados</h5>
                <asp:Label ID="lblClientesRegistrados" runat="server" CssClass="fs-3 text-warning" />
              </div>
            </div>
          </div>

          <div class="mt-5 fade-in fade-delay-2">
            <h4>Últimas Facturas</h4>
            <asp:GridView ID="gvFacturas" runat="server" AutoGenerateColumns="false" CssClass="table table-striped">
              <Columns>
                <asp:BoundField DataField="Numero" HeaderText="#" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Total" HeaderText="Total" />
                <asp:TemplateField HeaderText="Estado">
                  <ItemTemplate>
                      <asp:Label ID="lblEstado" runat="server"
                       CssClass='<%# ObtenerClaseEstado(Eval("Estado").ToString()) %>'
                        Text='<%# Eval("Estado") %>' />
                  </ItemTemplate>
                </asp:TemplateField>
              </Columns>
            </asp:GridView>
          </div>
        </div>
      </div>
    </div>
  </form>

  <!-- Bootstrap JS for interactive elements (if needed later) -->
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>