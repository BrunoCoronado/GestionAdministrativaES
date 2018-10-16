using ExcelDataReader;
using GestionAdministrativaES.Controllers;
using GestionAdministrativaES.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GestionAdministrativaES.Views.Administracion
{
    public partial class CargaMasiva : System.Web.UI.Page
    {
        private UsuarioControlador usuarioControlador = new UsuarioControlador();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Login.usuario.rol.idRol != 1)
                {
                    switch (Login.usuario.rol.idRol)
                    {
                        case 2:
                            Response.Redirect("../OperadorDelSistema/Menu.aspx", true);
                            break;
                        case 3:
                            Response.Redirect("../Catedratico/Menu.aspx", true);
                            break;
                        case 4:
                            Response.Redirect("../Estudiante/Menu.aspx", true);
                            break;
                    }
                }
            }
            catch
            {
                Response.Redirect("../Login.aspx",true);
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + filename);
                    usuarioControlador.cargaMasivaUsuarios(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            
        }
    }
}