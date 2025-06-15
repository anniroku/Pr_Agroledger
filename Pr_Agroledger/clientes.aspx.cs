using System;
using System.Web.UI;

namespace Pr_Agroledger
{
    public partial class clientes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "Corrige los errores antes de continuar.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Obtener los datos
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Mostrar mensaje de éxito
            lblMensaje.Visible = true;
            lblMensaje.Text = "Cliente registrado exitosamente.";
            lblMensaje.ForeColor = System.Drawing.Color.Green;

            // Limpiar campos
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
        }
    }
}
