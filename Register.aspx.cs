using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial_2_TP4_Pascual_Silvestri
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = TextBoxEmail.Text;
                string username = TextBoxUsername.Text;
                int age = int.Parse(TextBoxAge.Text);
                string password = TextBoxPassword.Text;
                string repeatPassword = TextBoxRepeatPassword.Text;

                
                if (age > 15 && password == repeatPassword)
                {
                    
                    HttpCookie passwordCookie = new HttpCookie("UserPassword", password);
                    passwordCookie.Expires = DateTime.Now.AddMinutes(30); 
                    Response.Cookies.Add(passwordCookie);

                    // Crear Session con el nombre de usuario
                    Session["Username"] = username;
                    Session["Email"] = email;

                    // Redirigir a otra página o mostrar mensaje de éxito
                    Response.Redirect("GestionArchivos.aspx");
                }
              
            }
        }
    }
}