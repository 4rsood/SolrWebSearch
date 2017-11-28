using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;



public partial class WebUserControls_SearchPagerControl : System.Web.UI.UserControl 
{

    bool _boolFalse = false;
    bool _boolTrue = true;

    int iStart = 0;
    int iStartResultNum = 0;
    int iEndResultNum = 0;
    int iMaxPages = 0;

    Label lblNavigationBottom;
    Label lblBlankLine;

    const String CollectionGCIntranet = "GCIntranet";
    const String CollectionGCPedia = "GCpedia";
    const String CollectionGCConnex = "GCConnex";

    const String GCintranet = "1";
    const String GCpedia = "1";
    const String GCconnex = "3";

    const String CollectionGCPediaUsers = "GCPedia_Users";
    const String CollectionGCPediaTalks = "GCPedia_Talks";
    const String CollectionGCPediaPages = "GCPedia_Pages";
    const String CollectionGCPediaCategories = "GCPedia_Categories";
    const String CollectionGCPediaFiles = "GCPedia_Files";
    const String CollectionGCPediaHelp = "GCPedia_Help";
    const String CollectionGCPediaTemplate = "GCPedia_Template";

    const String CollectionGCConnexBlog = "GCConnex_Blog";
    const String CollectionGCConnexBookmarks = "GCConnex_Bookmarks";
    const String CollectionGCConnexMembers = "GCConnex_Members";
    const String CollectionGCConnexTalks = "GCConnex_Talks";
    const String CollectionGCConnexPages = "GCConnex_Pages";
    const String CollectionGCConnexCategories = "GCConnex_Categories";
    const String CollectionGCConnexFiles = "GCConnex_Files";
    const String CollectionGCConnexGroups = "GCConnex_Groups";
    const String CollectionGCConnexHelp = "GCConnex_Help";
    const String CollectionGCConnexIdeas = "GCConnex_Ideas";
    const String CollectionGCConnexDiscussion = "GCConnex_Discussion";
    const String CollectionGCConnexForums = "GCConnex_Forums";
    const String CollectionGCConnexWire = "GCConnex_Wire";
    const String CollectionGCConnexComments = "GCConnex_Comments";
    const String CollectionGCConnexPhotos = "GCConnex_Photos";
    const int NavBarLen = 10;
    private readonly bool True;
    public static string sUrl = null;
    public static string sTitle = null;
    public static string sDescription = null;
    public static string dDateModified = null;

    gcsearch _gcsearch = new gcsearch();

    protected void Page_Init(object sender, EventArgs e)
    {
    }

    protected void Page_PreInit(object sender, EventArgs e)
    {
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        initialize();
        loadSearchForm();
        displayGCPediaLinks();
        displayGCConnexLinks();

      

        if (String.IsNullOrEmpty(_gcsearch.queryBasic).Equals(false))
        {
            // loadColections();
             performSearch();
            }
        }

    void initialize()
    {
        if (String.IsNullOrEmpty(Request.QueryString["q"]).Equals(_boolFalse))
            _gcsearch.queryBasic = Request.QueryString["q"];
        else if (String.IsNullOrEmpty(Request.QueryString["ctl00$MainContent$SearchPageControl$q"]).Equals(_boolFalse))
            _gcsearch.queryBasic = Request.QueryString["ctl00$MainContent$SearchPageControl$q"];
        else if (String.IsNullOrEmpty(Request.Form["q"]).Equals(_boolFalse))
            _gcsearch.queryBasic = Request.Form["q"];
        else if (String.IsNullOrEmpty(Request.Form["ctl00$MainContent$SearchPageControl$q"]).Equals(_boolFalse))
            _gcsearch.queryBasic = Request.Form["ctl00$MainContent$SearchPageControl$q"];
        else if (String.IsNullOrEmpty(Request.Form["wb-srch-q"]).Equals(_boolFalse))
            _gcsearch.queryBasic = Request.Form["wb-srch-q"];

        q.Text = _gcsearch.queryBasic;
        if (String.IsNullOrEmpty(_gcsearch.sort).Equals(_boolFalse))
        {
            _gcsearch.sort = Request.QueryString["b"];
        }

        if (String.IsNullOrEmpty(Request.QueryString["lr"]).Equals(_boolFalse))
        {
            _gcsearch.lang = Request.QueryString["lr"];
        }

        if (String.IsNullOrEmpty(Request.QueryString["chk1"]).Equals(_boolFalse))
        {
            _gcsearch.chkAll = Request.QueryString["chk1"];
        }


        if (String.IsNullOrEmpty(Request.QueryString["chk2"]).Equals(_boolFalse))
        {
            _gcsearch.chkGCIntranet = Request.QueryString["chk2"];
        }

        if (String.IsNullOrEmpty(Request.QueryString["chk3"]).Equals(_boolFalse))
        {
            _gcsearch.chkGCpedia = Request.QueryString["chk3"];
        }

        if (String.IsNullOrEmpty(Request.QueryString["chk4"]).Equals(_boolFalse))
        {
            _gcsearch.chkGCconnex = Request.QueryString["chk4"];
        }

        if (String.IsNullOrEmpty(Request.QueryString["gcc"]).Equals(_boolFalse))
        {
            _gcsearch.gcp = Request.QueryString["gcc"];
        }

        if (String.IsNullOrEmpty(Request.QueryString["gcp"]).Equals(_boolFalse))
        {
            _gcsearch.gcp = Request.QueryString["gcp"];
        }

        if (String.IsNullOrEmpty(Request.QueryString["s"]).Equals(_boolFalse))
        {
            _gcsearch.gcSource = Request.QueryString["s"];
        }
        if (String.IsNullOrEmpty(Request.QueryString["b"]).Equals(_boolFalse))
        {
            _gcsearch.gcSource = Request.QueryString["b"];
        }
        _gcsearch.pageLang = Resources.Resources.GSALang;
    }

    void loadSearchForm()
    {
        if (_gcsearch.chkAll != null && (_gcsearch.chkAll.Equals("on") || _gcsearch.chkAll.Equals("True")))
            chk1.Checked = true;
        else
        {
            if (_gcsearch.chkGCIntranet != null && (_gcsearch.chkGCIntranet.Equals("True") || _gcsearch.chkGCIntranet.Equals("on")))
                chk2.Checked = true;

            if (_gcsearch.chkGCpedia != null && (_gcsearch.chkGCpedia.Equals("True") || _gcsearch.chkGCpedia.Equals("on")))
            {
                chk3.Checked = true;
                //populateGCpediaFilter();
                PlaceHolderGCPedia.Visible = true;
            }

            if (_gcsearch.chkGCconnex != null && (_gcsearch.chkGCconnex.Equals("True") || _gcsearch.chkGCconnex.Equals("on")))
            {
                chk4.Checked = true;
                //populateGCconnexFilter();
                    PlaceHolderGCConnex.Visible = true;
            }
        }


        //if (_gcsearch.chkGCIntranet == null && _gcsearch.chkGCpedia == null && _gcsearch.chkGCconnex == null)
        if (chk2.Checked.Equals(false) && chk3.Checked.Equals(false) && chk4.Checked.Equals(false))
        {
            _gcsearch.chkAll = "True";
            chk1.Checked = true;
        }
        else
        {
            _gcsearch.chkAll = "False";
            chk1.Checked = false;
        }

        if (String.IsNullOrEmpty(_gcsearch.queryBasic).Equals(_boolFalse))
        {
            Label lblSortByDate = new Label();
            HyperLink hyperlinkSortByDate = new HyperLink();
            HyperLink hyperlinkSortByRelevancy = new HyperLink();
            String sortURL = Request.Url.ToString();
            if (sortURL.Contains("b=d"))
                sortURL = sortURL.Replace("b=d", "b=r");
            else if (sortURL.Contains("b=r"))
                sortURL = sortURL.Replace("b=r", "b=d");
            else
                sortURL = sortURL + "&b=d";
            lblSortBy.Visible = true;
            lblSortByDate.Text = "<br />" + Resources.Resources.SortBy;
            ;
            //if (_gcsearch.sort.Equals("d"))
            //{
            //    hyperlinkSortByRelevancy.Visible = true;
            //    hyperlinkSortByRelevancy.Text = Resources.Resources.Relevancy;
            //    hyperlinkSortByRelevancy.NavigateUrl = sortURL;
            //    PlaceHolderSort.Controls.Add(hyperlinkSortByRelevancy);
            //}
            //else
            //{
            //    hyperlinkSortByDate.Visible = true;
            //    hyperlinkSortByDate.Text = Resources.Resources.Relevancy;
            //    hyperlinkSortByDate.NavigateUrl = sortURL;
            //    PlaceHolderSort.Controls.Add(hyperlinkSortByDate);
            //}
        }
    }

    //void loadColections()
    //{

    //    if (_gcsearch.chkAll.Equals("on") || _gcsearch.Equals("True"))
    //    {
    //        _gcsearch.collections = CollectionGCIntranet + "|" + CollectionGCPedia + "|" + CollectionGCConnex;
    //        return;
    //    }
    //    if (String.IsNullOrEmpty(_gcsearch.collections))
    //    {
    //        if (_gcsearch.chkGCIntranet.Equals("on") || _gcsearch.chkGCIntranet.Equals("True"))
    //        {
    //            _gcsearch.collections = CollectionGCIntranet;
    //        }
    //        else
    //        {
    //            _gcsearch.collections = "|" + CollectionGCIntranet;
    //        }
    //    }
    //    if (String.IsNullOrEmpty(_gcsearch.collections))
    //    {
    //        if (String.IsNullOrEmpty(_gcsearch.gcp).Equals(false))

    //            _gcsearch.collections = _gcsearch.collections + getgcpCollectionName(_gcsearch.gcp);

    //        else if (_gcsearch.chkGCpedia.Equals("on") || _gcsearch.chkGCpedia.Equals("True"))

    //            _gcsearch.collections = _gcsearch.collections + CollectionGCPedia;
    //    }
    //    else
    //    {
    //        if (String.IsNullOrEmpty(_gcsearch.gcp).Equals(false))

    //            _gcsearch.collections = _gcsearch.collections + "|" + getgcpCollectionName(_gcsearch.gcp);

    //        else if (_gcsearch.chkGCpedia.Equals("on") || _gcsearch.chkGCpedia.Equals("True"))

    //            _gcsearch.collections = _gcsearch.collections + "|" + CollectionGCPedia;
    //    }

    //    if (String.IsNullOrEmpty(_gcsearch.collections))
    //    {
    //        if (String.IsNullOrEmpty(_gcsearch.gcc).Equals(false))

    //            _gcsearch.collections = _gcsearch.collections + getgccCollectionName(_gcsearch.gcc);

    //        else if (_gcsearch.chkGCconnex.Equals("on") || _gcsearch.chkGCconnex.Equals("True"))

    //            _gcsearch.collections = _gcsearch.collections + CollectionGCConnex;

    //    }

    //    else
    //    {

    //        if (String.IsNullOrEmpty(_gcsearch.gcc).Equals(false))
    //        {
    //            _gcsearch.collections = _gcsearch.collections + "|" + getgccCollectionName(_gcsearch.gcc);
    //        }
    //        else if (_gcsearch.chkGCconnex.Equals("on") || _gcsearch.chkGCconnex.Equals("True"))
    //        {
    //            _gcsearch.collections = _gcsearch.collections + "|" + CollectionGCConnex;
    //        }
    //    }
    //}

    String getgcpCollectionName(String gcp)
    {
        return (" ");
    }

    String getgccCollectionName(String gcc)
    {
        return (" ");
    }


    void performSearch()
    {
        XPathDocument document = new XPathDocument("http://localhost:53260/queryresults.xml");
        XPathNavigator navigator = document.CreateNavigator();

        XPathNodeIterator nodes = navigator.Select("/response/result/doc");

        foreach (XPathNavigator nav in nodes)
        {
            if (nav.HasChildren)
            {
                nav.MoveToFirstChild();
                while (nav.MoveToNext())
                {
                    if (nav.Name.Equals("arr"))
                    {
                        if (nav.OuterXml.Contains("Content-Location"))
                            sUrl = nav.InnerXml.Replace("<str>", String.Empty).Replace("</str>", String.Empty);
                        else if (nav.OuterXml.Contains("dcterms.title"))
                            sTitle = nav.InnerXml.Replace("<str>", String.Empty).Replace("</str>", String.Empty);
                        else if (nav.OuterXml.Contains("description"))
                            sDescription = nav.InnerXml;
                        else if (nav.OuterXml.Contains("dcterms.modified"))
                            dDateModified = nav.InnerXml;
                        if (sUrl != null && sTitle != null)
                        {
                            writeResults(sUrl, sTitle, sDescription, dDateModified);
                            sUrl = null;
                            sTitle = null;
                        }

                    }
                }
            }

        }
    }

    protected void writeResults(string sUrl, string sTitle, string sDescription, string sDateModified)
    {
        Label lblResult = new Label();
        Label lblSource = new Label();
        int startindex = 0;
        string substring = ".ca/";
        string _path = null;
        panelResults.Visible = true;
        panelResults.Visible = true;

        if (sUrl.Contains(substring))
        {
            startindex = sUrl.IndexOf(substring) + substring.Length - 1;
            _path = sUrl.Substring(startindex, sUrl.Length-startindex);
        }
        else
            _path = sUrl;
        lblResult.Text = "<a href=\"" + sUrl + "\">" + sTitle + "</a><br />" + _path + "<br />";
        if (sUrl.Contains("gcconnex"))
        {
            lblSource.Text = "<strong>" + Resources.Resources.source + "</strong>" + "GCconnex" + "<br /><br />";

        }
        PlaceHolderSearchResults.Visible = true;
        PlaceHolderSearchResults.Controls.Add(lblResult);
        PlaceHolderSearchResults.Controls.Add(lblSource);
        }

        
        void displayGCPediaLinks()
    {
        String _link = buildGClink("2");
        Label lblGCpedia = new Label();

        if (_gcsearch.chkGCpedia != null && (_gcsearch.chkGCpedia.Equals("True") || _gcsearch.chkGCpedia.Equals("on")))
        {
            lblGCpedia.Visible = true;

            PlaceHolderGCPedia.Visible = true;
            lblGCPall.Text = _link + "&gcp=1'>" + Resources.Resources.all + "</a><br />";
            lblGCPusers.Text = _link + "&gcp=2'>" + Resources.Resources.users + "</a><br />";
            lblGCPtalks.Text = _link + "&gcp=3'>" + Resources.Resources.talks + "</a><br />";
            lblGCPTemplates.Text = _link + "&gcp=5'>" + "Template" + "</a><br />";
            lblGCPcategories.Text = _link + "&gcp=6'>" + Resources.Resources.categories + "</a><br />";
            lblGCPfiles.Text = _link + "&gcp=7'>" + Resources.Resources.files + "</a><br />";
            lblGCPhelp.Text = _link + "&gcp=8'>" + Resources.Resources.help + "</a><br />";
        }
    }

    void displayGCConnexLinks()
    {
        String _link = buildGClink("3");
        Label lblGCpedia = new Label();
        if (_gcsearch.chkGCconnex != null && (_gcsearch.chkGCconnex.Equals("True") || _gcsearch.chkGCconnex.Equals("on")))
        {
            lblGCConnex.Visible = true;
            PlaceHolderGCConnex.Visible = true;

            lblGCCall.Text = _link + "&gcc=1'>" + Resources.Resources.all + "</a><br />";
            lblGCCmembers.Text = _link + "&gcc=2'>" + Resources.Resources.members + "</a><br />";
            lblGCCgroups.Text = _link + "&gcc=3'>" + Resources.Resources.groups + "</a><br />";
            lblGCCblogs.Text = _link + "&gcc=4'>" + Resources.Resources.blogs + "</a><br />";
            lblGCCDiscussion.Text = _link + "&gcc=5'>" + Resources.Resources.discussion + "</a><br />";
            lblGCCfiles.Text = _link + "&gcc=6'>" + Resources.Resources.files + "</a><br />";
            lblGCCForums.Text = _link + "&gcc=7'>" + Resources.Resources.forums + "</a><br />";
            lblGCCcomments.Text = _link + "&gcc=8'>" + Resources.Resources.comments + "</a><br />";
            lblGCCwire.Text = _link + "&gcc=9'>" + Resources.Resources.wirepost + "</a><br />";
            lblGCCideas.Text = _link + "&gcc=10'>" + Resources.Resources.ideas + "</a><br />";
            lblGCCpages.Text = _link + "&gcc=11'>" + Resources.Resources.pages + "</a><br />";
            lblGCCphotos.Text = _link + "&gcc=12'>" + Resources.Resources.photos + "</a><br />";
        }
    }


    String buildGClink(String type)
    {
        String _link = "<a href='" + Request.ServerVariables["URL"] + "?q=" + Request.QueryString["q"] + "&a=s";

        if (String.IsNullOrEmpty(Request.QueryString["s"]).Equals(false))
            _link = _link + "&amp;s=" + Request.QueryString["s"];

        if (type.Equals(GCpedia))
        {
            if (_gcsearch.chkGCpedia != null && (_gcsearch.chkGCpedia.Equals("True") || _gcsearch.chkGCpedia.Equals("on")))
                _link = _link + "&chk3=" + _gcsearch.chkGCpedia;
        }
        else if (type.Equals(GCconnex))
        {
            if (_gcsearch.chkGCconnex != null && (_gcsearch.chkGCconnex.Equals("True") || _gcsearch.chkGCconnex.Equals("on")))
                _link = _link + "&chk4=" + _gcsearch.chkGCconnex;
        }
        return _link;
    }

    Boolean _chkbox(CheckBox _chk)
    {
        if (_gcsearch.chkAll.Equals("on") || _gcsearch.chkAll.Equals("True"))
            chk1.Checked = true;

        return (True);
    }
    protected void chk1_CheckedChanged1(object sender, EventArgs e)
    {
        Response.Redirect(Request.Url.ToString() + "?q=" + Request.Form["ctl00$MainContent$SearchPageControl$q"] + "&a=s&chk1=True" + "&chk2=" + Request.Form["ctl00$MainContent$SearchPageControl$chk2"] + "&chk3=" + Request.Form["ctl00$MainContent$SearchPageControl$chk3"] + "&chk4=" + Request.Form["ctl00$MainContent$SearchPageControl$chk4"] + "&s=" + Request.Form["ctl00$MainContent$SearchPageControl$s"]);
    }

     protected void chk2_CheckedChanged(object sender, EventArgs e)
    {
        String _url = Request.UrlReferrer.ToString();
        if (_url.Contains("?").Equals(false))
        {
            if (Request.Form["ctl00$MainContent$SearchPageControl$q"] != null)
                Response.Redirect(_url + "?q=" + Request.Form["ctl00$MainContent$SearchPageControl$q"] + "&chk2=True");
            else
                Response.Redirect(_url + "?chk2=True");
        }
        else if (_url.Contains("&chk2=") && _url.Contains("&chk2=True").Equals(false))
            Response.Redirect(_url.Replace("&chk1=True", String.Empty).Replace("&chk2=", "&chk2=True"));
    }

    protected void chk3_CheckedChanged(object sender, EventArgs e)
    {
        String _url = Request.UrlReferrer.ToString();
        if (_url.Contains("?").Equals(false))
        {
            if (Request.Form["ctl00$MainContent$SearchPageControl$q"] != null)
                Response.Redirect(_url + "?q=" + Request.Form["ctl00$MainContent$SearchPageControl$q"] + "&chk3=True");
            else
                Response.Redirect(_url + "?chk3=True");
        }
        else if (_url.Contains("&chk3=") && _url.Contains("&chk3=True").Equals(false))
            Response.Redirect(_url.Replace("&chk1=True", String.Empty).Replace("&chk3=", "&chk3=True"));
    }

    protected void chk4_CheckedChanged(object sender, EventArgs e)
    {
        String _url = Request.UrlReferrer.ToString();
        if (_url.Contains("?").Equals(false))
        {
            if (Request.Form["ctl00$MainContent$SearchPageControl$q"] != null)
                Response.Redirect(_url + "?q=" + Request.Form["ctl00$MainContent$SearchPageControl$q"] + "&chk4=True");
            else
                Response.Redirect(_url + "?chk4=True");
        }
        else if (_url.Contains("&chk4=") && _url.Contains("&chk4=True").Equals(false))
            Response.Redirect(_url.Replace("&chk1=True", String.Empty).Replace("&chk4=", "&chk4=True"));
    }
}
