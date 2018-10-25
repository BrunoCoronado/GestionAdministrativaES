using GestionAdministrativaES.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionAdministrativaES.Views.Administracion
{
    public partial class RecuperarContraseña : System.Web.UI.Page
    {
        private UsuarioControlador usuarioControlador = new UsuarioControlador();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bntValidarPalabraClave_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Usuario usuario = usuarioControlador.validarPalabraClave(txtUsuario.Value, txtPalabraClave.Value);
                lblUsuario.InnerText = usuario.nick;
                lblNombre.InnerText = usuario.nombre;
                lblCarnet.InnerText = Convert.ToString(usuario.Carnet);

                try
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    mail.From = new MailAddress("trext23111997@gmail.com");
                    try
                    {
                        mail.To.Add(usuario.correo);
                    }
                    catch
                    {

                    }
                    mail.Bcc.Add("bcoronado.morales@gmail.com");
                    mail.Subject = "RECUPERAR CONTRASEÑA";
                    mail.Body = "La contraseña es la siguiente: \n" +usuario.contraseña;

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("trext23111997@gmail.com", "23111997Trex");
                    SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
                    Response.Write("<script>window.alert('Mail enviado');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>window.alert('Error! mail no enviado');</script>");
                }

            }
            catch
            {

            }
        }

        protected void btnCambiarContraseña_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Value.Equals(txtConfirmarContraseña.Value) & lblUsuario.InnerText != "")
            {
                usuarioControlador.cambiarContraseña(lblUsuario.InnerText, txtContraseña.Value);
            }
            else
            {
                Response.Write("<script>window.alert('Error! Verificar Palabra Clave y Contraseña');</script>");
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx", true);
        }
    }
}