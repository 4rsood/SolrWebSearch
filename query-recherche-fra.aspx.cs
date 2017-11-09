using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class query_recherche_fra : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        bool condition = false;
        if (String.IsNullOrEmpty(Request.QueryString["s"]).Equals(condition))
        {
            if (Request.QueryString["s"].Equals("4"))
                this.MasterPageFile = "~/MasterPages/MasterPageGCDirectory-fra.master";
            else if (Request.QueryString["s"].Equals("3"))
                this.MasterPageFile = "~/MasterPages/MasterPageGCconnex-fra.master";
            else if (Request.QueryString["s"].Equals("2"))
                this.MasterPageFile = "~/MasterPages/MasterPageGCpedia-fra.master";
            else
                this.MasterPageFile = "~/GoC.WebTemplate/GoCWebTemplate.master";
        }
    }
}