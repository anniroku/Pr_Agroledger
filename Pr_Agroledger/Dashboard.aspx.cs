using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;


namespace Pr_Agroledger
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatos();
            }

        }

        private void CargarDatos()
        {
            lblTotalFacturas.Text = "120";
            lblIngresosMes.Text = "$18,450";
            lblClientesRegistrados.Text = "35";

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[] {
            new DataColumn("Numero", typeof(string)),
            new DataColumn("Cliente", typeof(string)),
            new DataColumn("Fecha", typeof(string)),
            new DataColumn("Total", typeof(string)),
            new DataColumn("Estado", typeof(string))
        });

            dt.Rows.Add("F-001", "Juan Pérez", "2025-05-28", "$480", "Pagado");
            dt.Rows.Add("F-002", "María Rojas", "2025-05-27", "$750", "Pendiente");
            dt.Rows.Add("F-003", "Carlos Gómez", "2025-05-26", "$600", "Pagado");

            gvFacturas.DataSource = dt;
            gvFacturas.DataBind();
        }

        protected string ObtenerClaseEstado(string estado)
        {
            return estado == "Pagado" ? "badge bg-success" : "badge bg-danger";
        }


        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("login.aspx");

        }
    }
}