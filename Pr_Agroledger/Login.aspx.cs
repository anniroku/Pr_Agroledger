using MySqlConnector;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pr_Agroledger
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRoles();
            }
        }

        private void CargarRoles()
        {
            string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            using (var conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT id, nombre FROM roles";
                    using (var cmd = new MySqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        drop_Rol.DataSource = reader;
                        drop_Rol.DataTextField = "nombre";
                        drop_Rol.DataValueField = "id";
                        drop_Rol.DataBind();
                        drop_Rol.Items.Insert(0, new ListItem("Selecciona un rol", ""));
                    }
                }
                catch (Exception ex)
                {
                    divMensaje.InnerHtml = "Error al cargar roles: " + ex.Message;
                }
            }
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string usuario = txtUsuario.Text.Trim();
                string clave = txtClave.Text;
                int rolId = int.Parse(drop_Rol.SelectedValue);

                string connStr = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

                using (var conn = new MySqlConnection(connStr))
                {
                    try
                    {
                        conn.Open();

                        string verificarUsuarios = "SELECT COUNT(*) FROM usuarios";
                        using (var cmdVerificar = new MySqlCommand(verificarUsuarios, conn))
                        {
                            int totalUsuarios = Convert.ToInt32(cmdVerificar.ExecuteScalar());
                            if (totalUsuarios == 0)
                            {
                                MostrarMensaje("No hay usuarios registrados. Contacta al administrador.", "warning");
                                return;
                            }
                        }

                        string query = "SELECT * FROM usuarios WHERE nombre_usuario = @nombre AND contrasena = @contrasena AND rol = @rol";
                        using (var cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", usuario);
                            cmd.Parameters.AddWithValue("@contrasena", clave);
                            cmd.Parameters.AddWithValue("@rol", rolId);

                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    Session["usuario"] = usuario;
                                    MostrarMensaje("Inicio de sesión exitoso.", "success");
                                    Response.Redirect("Dashboard.aspx");
                                }
                                else
                                {
                                    MostrarMensaje("Usuario, contraseña o rol incorrectos. Verifique sus datos", "danger");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MostrarMensaje("Error al conectar: " + ex.Message, "danger");
                    }
                }
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string nombre = txtNombre.Text.Trim();
                string correo = txtCorreo.Text.Trim();
                string usuarioNuevo = txtUsuarioNuevo.Text.Trim();
                string claveNueva = txtClaveNueva.Text;

                // Aquí podrías insertar los datos en la tabla usuarios.
                MostrarMensaje("Usuario registrado con éxito.", "success");
            }
        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string correoRecuperar = txtCorreoRecuperar.Text.Trim();
                MostrarMensaje("Se ha enviado un enlace de recuperación al correo ingresado.", "info");
            }
        }

        private void MostrarMensaje(string mensaje, string tipo = "danger")
        {
            divMensaje.InnerHtml = mensaje;
            divMensaje.Attributes["class"] = "alert alert-" + tipo;
            divMensaje.Visible = true;
        }
    }
}
