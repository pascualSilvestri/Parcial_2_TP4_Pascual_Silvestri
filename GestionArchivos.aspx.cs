using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;
using System.Web;
using System;

namespace Parcial_2_TP4_Pascual_Silvestri
{
    public partial class GestionArchivos : System.Web.UI.Page
    {
        private string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Obtener el nombre de usuario de la sesión
            username = Session["Username"] as string;

            if (string.IsNullOrEmpty(username))
            {
                //Redirigir a register si no existe session
                Response.Redirect("Register.aspx");
            }

            if (!IsPostBack)
            {
                cargarGrilla();
            }
        }

        public void cargarGrilla()
        {
            string path = $"{Server.MapPath(".")}/{username}";

            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                List<Archivo> fileList = new List<Archivo>();
                foreach (string file in files)
                {
                    var fileNew = new Archivo(Path.GetFileName(file), file);
                    fileList.Add(fileNew);
                }
                GridView1.DataSource = fileList;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string path = $"{Server.MapPath(".")}/{username}";
            string result = string.Empty;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (HttpPostedFile archivo in FileUpload1.PostedFiles)
            {
                if (archivo.ContentLength > 1000)
                {
                    result += $"El archivo {archivo.FileName} supera los 1000 bytes - ";
                }
                else
                {
                    if (File.Exists($"{path}/{archivo.FileName}"))
                    {
                        result += $"El archivo {archivo.FileName} ya existe - ";
                    }
                    else
                    {
                        archivo.SaveAs($"{path}/{archivo.FileName}");
                    }
                }
            }

            Label1.Text = result;
            cargarGrilla();
        }

        protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Descargar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow registro = GridView1.Rows[index];
                string filePath = $"{Server.MapPath(".")}/{username}/{registro.Cells[1].Text}";

                if (File.Exists(filePath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    Response.TransmitFile(filePath);
                    Response.End();
                }
                else
                {
                    Label1.Text = "El archivo no existe.";
                }
            }
        }
    }

   
}