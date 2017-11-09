using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class query_recherche_eng : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool condition = false;
        if (String.IsNullOrEmpty(Request.QueryString["s"]).Equals(condition))
        {
           
            if (Request.QueryString["s"].Equals("3"))
                this.MasterPageFile = "~/MasterPages/MasterPageGCConnex-eng.master";
            else if (Request.QueryString["s"].Equals("2"))
                this.MasterPageFile = "~/MasterPages/MasterPageGCpedia-eng.master";
            else
                this.MasterPageFile = "~/GoC.WebTemplate/GoCWebTemplate.master";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }
}