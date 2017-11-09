using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for gcsearch
/// </summary>
public class gcsearch
{

    bool _boolFalse = false;
    bool _boolTrue = true;
    public String _sort;
    public String _lang;
    public String _pagelang;
    public String _chkAll;
    public String _chkGCIntranet;
    public String _chkGCpedia;
    public String _chkGCconnex;

    public String _chkGCPediaAll;
    public String _chkGCPediaUsers;
    public String _chkGCPediaTalks;
    public String _chkGCPediaPages;
    public String _chkGCPediaCategories;
    public String _chkGCPediaFiles;
    public String _chkGCPediaHelp;


    public String _gcp;
    public String _gcc;
    public String _gcSource;


    String sDidYouMean = String.Empty;
    String pageLabel = String.Empty;
    String sSite = String.Empty;

    public String queryBasic = String.Empty;
    public String sGCSource = String.Empty;
    public String collections = String.Empty;
    public String sSortBy = String.Empty;



    int iStart = 0;
    int iStartResultNum = 0;
    int iEndResultNum = 0;
    int iMaxPages = 0;


    public const String CollectionGCIntranet = "GCIntranet";
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

    public String sort
    {
        get { return _sort; }
        set { _sort = value; }
    }

    public String lang
    {
        get { return _lang; }
        set { _lang = value; }
    }
    public String pageLang
    {
        get { return _pagelang; }
        set { _pagelang = value; }
    }

    public String chkAll
    {
        get { return _chkAll; }
        set { _chkAll = value; }
    }

    public String chkGCIntranet
    {
        get { return _chkGCIntranet; }
        set { _chkGCIntranet = value; }
    }
    public String chkGCpedia
    {
        get { return _chkGCpedia; }
        set { _chkGCpedia = value; }
    }
    public String chkGCconnex
    {
        get { return _chkGCconnex; }
        set { _chkGCconnex = value; }
    }

    public String chkGCpediaAll
    {
        get { return _chkGCPediaAll; }
        set { _chkGCPediaAll = value; }
    }

    public String chkGCpediaUsers
    {
        get { return _chkGCPediaUsers; }
        set { _chkGCPediaUsers = value; }
    }
    public String chkGCpediaTalks
    {
        get { return _chkGCPediaTalks; }
        set { _chkGCPediaTalks = value; }
    }

    public String chkGCpediaPages
    {
        get { return _chkGCPediaPages; }
        set { _chkGCPediaPages = value; }
    }
    public String chkGCpediaCategories
    {
        get { return _chkGCPediaCategories; }
        set { _chkGCPediaCategories = value; }
    }

    public String chkGCpediaFiles
    {
        get { return _chkGCPediaFiles; }
        set { _chkGCPediaFiles = value; }
    }
    public String chkGCpediaHelp
    {
        get { return _chkGCPediaHelp; }
        set { _chkGCPediaHelp = value; }
    }
    public String gcp
    {
        get { return _gcp; }
        set { _gcp = value; }
    }
    public String gcc
    {
        get { return _gcc; }
        set { _gcc = value; }
    }
    public String gcSource
    {
        get { return _gcSource; }
        set { _gcSource = value; }
    }

}