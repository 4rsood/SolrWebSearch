<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchPagerControl.ascx.cs" Inherits="WebUserControls_SearchPagerControl" EnableViewState="false"  %>
<script type = "text/javascript">

    function updateChkList(chk) {

        var chkList = chk.parentNode.parentNode.parentNode;

        var chks = chkList.getElementsByTagName("input");
        var bool = false;

        for (var i = 0; i < chks.length; i++) {
            if (chks[0] != chk && chk.checked) {
                chks[0].checked = false;
            }
            else if (chks[i] != chk && chk.checked) {
                chks[i].checked = false;
            }
        }

    }

    window.onload = function ()
    {
           if (sessionStorage.getItem('q') == "q") {
                return;
           }

        var name = sessionStorage.getItem('q');
        if (name !== null) $('#inputName').val(name);
    }

    window.onbeforeunload = function () {
        sessionStorage.setItem("q", $('#inputName').val());
        alert(name);
    }

</script>


    <style>

.pagination-ys {
    /*display: inline-block;*/
    padding-left: 0;
    margin: 20px 0;
    border-radius: 4px;
}
 
.pagination-ys table > tbody > tr > td {
    display: inline;
    text-align:center;
}
 
.pagination-ys table > tbody > tr > td > a,
.pagination-ys table > tbody > tr > td > span {
    position: relative;
    float: left;
    padding: 8px 12px;
    line-height: 1.42857143;
    text-decoration: none;
    color: #dd4814;
    background-color: #ffffff;
    border: 1px solid #dddddd;
    margin-left: -1px;
}
 
.pagination-ys table > tbody > tr > td > span {
    position: relative;
    float: left;
    padding: 8px 12px;
    line-height: 1.42857143;
    text-decoration: none;    
    margin-left: -1px;
    z-index: 2;
    color: #aea79f;
    background-color: #f5f5f5;
    border-color: #dddddd;
    cursor: default;
}
 
.pagination-ys table > tbody > tr > td:first-child > a,
.pagination-ys table > tbody > tr > td:first-child > span {
    margin-left: 0;
    border-bottom-left-radius: 4px;
    border-top-left-radius: 4px;
}
 
.pagination-ys table > tbody > tr > td:last-child > a,
.pagination-ys table > tbody > tr > td:last-child > span {
    border-bottom-right-radius: 4px;
    border-top-right-radius: 4px;
}
 
.pagination-ys table > tbody > tr > td > a:hover,
.pagination-ys table > tbody > tr > td > span:hover,
.pagination-ys table > tbody > tr > td > a:focus,
.pagination-ys table > tbody > tr > td > span:focus {
    color: #97310e;
    background-color: #eeeeee;
    border-color: #dddddd;
}

.gvPager {
    text-align:center;
}

    </style>

<asp:Label ID="lblTitle" runat="server" Text="" EnableViewState="false" />

 <asp:Panel id="panelSearch" runat="server" enableviewstate="false">
            <form id="SearchForm1" runat="server" method="post" defaultfocus="q" defaultbutton="sb" action="<%$Resources:Resources, searchAction %>"  enableviewstate="false">
                    <asp:HiddenField id="p" runat="server" /> 
                    <asp:HiddenField id="a" runat="server" value="s" />
                    <asp:HiddenField id="sa" runat="server" value="" />  
                    <asp:HiddenField id="t" runat="server" value="b" />                    
                    <asp:HiddenField id="s" runat="server"  />
               
                
                   <div class="form-inline">
                    <label class="wb-inv" for="q"><span style="float:left;">
                       
                       </span>Type one or more keywords</label>
                    <asp:TextBox id="q" runat="server" class="form-control" MaxLength="1100" width="1075" title="<%$Resources:Resources, typeQuery%>"></asp:TextBox>    
                    <!-- send query button -->
                       <button name="wb-srch-pol" class="btn btn-primary btn-small" id="wb-srch-pol" type="submit"><span class="glyphicon-search glyphicon"></span></button>
                       <!-- new code -- send query button -->
                               <asp:TextBox runat="server" Visible="false" ID="txtURL"></asp:TextBox>                      
                </div>

                       
		<asp:Label ID="lblEmptySearch" ToolTip="<%$Resources:Resources, errorYouMustEnterQuery %>" runat="server"></asp:Label>



                       <asp:Panel id="Panel1" runat="server" enableviewstate="false">
                <span style="float:right;padding-right:5px">

                    <asp:Label ID="Label2" ToolTip="<%$Resources:Resources, refinesearch %>" runat="server"></asp:Label>
                     <asp:HyperLink ID="HyperLink1" ToolTip="<%$Resources:Resources, advancedsearch %>" Visible="false" runat="server" Text="<%$Resources:Resources, advancedsearch %>">HyperLink</asp:HyperLink> 
                    <br /> 
                    <asp:Label ID="Label3" Text="<%$Resources:Resources, SortBy %>" Visible="false" runat="server"></asp:Label>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
							    
                    <h3><asp:Label ID="Label4" Text="<%$Resources:Resources, filterResults %>" Visible="false" runat="server"></asp:Label></h3>
             
                </span> 
            </asp:Panel>      







            <asp:Panel id="pnlBasicSearchLinks" runat="server" enableviewstate="false">
                <span style="float:right;padding-right:5px">

                    <asp:Label ID="lblBasicSearchRefine" ToolTip="<%$Resources:Resources, refinesearch %>" runat="server"></asp:Label>
                     <asp:HyperLink ID="HyperLinkAdvanced" ToolTip="<%$Resources:Resources, advancedsearch %>" Visible="false" runat="server" Text="<%$Resources:Resources, advancedsearch %>">HyperLink</asp:HyperLink> 
                    <br /> 
                    <asp:Label ID="lblSortBy" Text="<%$Resources:Resources, SortBy %>" Visible="false" runat="server"></asp:Label>
                    <asp:PlaceHolder ID="PlaceHolderSort" runat="server"></asp:PlaceHolder>
							    
                    <h3><asp:Label ID="lblFilterResults1" Text="<%$Resources:Resources, filterResults %>" Visible="false" runat="server"></asp:Label></h3>


                     <div class="panel panel-default">	
                               <header class="panel-heading">
							        <h3 class="panel-title"><asp:Label ID="lblFilterResults" Text="<%$Resources:Resources, filterResults %>" runat="server"></asp:Label></h3>
						        </header>                          
                            &nbsp;&nbsp;&nbsp;<h4 class="mrgn-tp-0"><asp:Label ID="Label1" Text=" <%$Resources:Resources, bysource %>" runat="server"></asp:Label></h4>                   
                            &nbsp;&nbsp;<asp:CheckBox ID="chk1" Checked="false" Onclick="updateChkList(this)" Text="<%$Resources:Resources, all2 %>" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" runat="server" OnCheckedChanged="chk1_CheckedChanged1" /><br />											
                            &nbsp;&nbsp;<asp:CheckBox ID="chk2" Checked="false" Onclick="updateChkList(this)" Text="&nbsp;GCintranet" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" runat="server" OnCheckedChanged="chk2_CheckedChanged" /><br />												
                            &nbsp;&nbsp;<asp:CheckBox ID="chk3" Checked="false" Onclick="updateChkList(this)" Text="&nbsp;<%$Resources:Resources, gcpedia2 %>" ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" runat="server" OnCheckedChanged="chk3_CheckedChanged" /><br />																			
                            &nbsp;&nbsp;<asp:CheckBox ID="chk4" Checked="false" Onclick="updateChkList(this)" Text="&nbsp;GCconnex"  ViewStateMode="Enabled" EnableViewState="true" AutoPostBack="true" runat="server" OnCheckedChanged="chk4_CheckedChanged" />
                            <br /><br />   
                     
                           <asp:PlaceHolder ID="PlaceHolderGCPedia" Visible="false" runat="server">                                                                                         
                                <header class="panel-heading">
							        <h3 class="panel-title"><asp:Label ID="lblGCPedia" Text="<%$Resources:Resources, bygcpedia %>" runat="server"></asp:Label></h3>
						        </header><br />                               
                                &nbsp;&nbsp;<asp:Label ID="lblGCPall" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCPusers" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCPtalks" runat="server"></asp:Label>
                                <asp:Label ID="lblGCPpages" Visible="false" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCPTemplates" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCPcategories" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCPfiles" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCPhelp" runat="server"></asp:Label>                          
                             <br />   
                             </asp:PlaceHolder>                                            

                            <asp:PlaceHolder ID="PlaceHolderGCConnex" Visible="false" runat="server">
                                <header class="panel-heading">
							    <h3 class="panel-title"><asp:Label ID="lblGCConnex" Text="<%$Resources:Resources, bygcconnex %>" runat="server"></asp:Label></h3>
						    </header><br />
                                &nbsp;&nbsp;<asp:Label ID="lblGCCall" ClientIDMode="Static" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCCmembers" ClientIDMode="Static" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCCgroups" ClientIDMode="Static" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCCblogs" ClientIDMode="Static" runat="server"></asp:Label>
                                <asp:Label ID="lblGCCDiscussion" ClientIDMode="Static" Visible="false" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCCfiles" ClientIDMode="Static" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCCForums" ClientIDMode="Static" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCCcomments" ClientIDMode="Static" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCCwire" ClientIDMode="Static" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCCideas" ClientIDMode="Static" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCCpages" ClientIDMode="Static" runat="server"></asp:Label>
                                &nbsp;&nbsp;<asp:Label ID="lblGCCphotos" ClientIDMode="Static" runat="server"></asp:Label>
                            <br />                     				
						    </asp:PlaceHolder>        
                                <asp:Label ID="lblResetFilters" Visible="false" runat="server"></asp:Label>
						
                        </div>	

                </span> 
            </asp:Panel>            
                
		<div class="result">			
			<!--
						<div class="row">			
                         

		<section class="col-md-4 srch-fltr">	-->
              <asp:Panel id="pnlBasicSearch" runat="server" enableviewstate="false">
                    <label for="MainContent_SearchPageControl_q">                   
                        <asp:Literal ID="Literal1" text="<%$Resources:Resources, typeQuery%>" Visible="false" runat="server" />
                    </label>                    
                
               
                  
                    <span class="pull-left">                
                        <asp:Button id="sb" class="mrgn-rght-sm" runat="server" Visible="false" text="<%$Resources:Resources, searchnow %>" />
                    </span>
               	
            <span style="float:right;padding-right:5px">					
			
				</span>		
                  </asp:Panel>						
                            </div>
              

<%------------- RESULTS   -------------------%>


<asp:Panel runat="server" ID="panelResults2" Visible="false" EnableViewState="false">

</asp:Panel>
                
 <asp:Panel runat="server" id="panelResults" visible="false" enableviewstate="false">
    
    <asp:PlaceHolder ID="PlaceHolderMessage" runat="server"></asp:PlaceHolder>
    <asp:PlaceHolder ID="PlaceHolderDidYouMean" Visible="false" runat="server"></asp:PlaceHolder>
    <p>
    <asp:PlaceHolder ID="PlaceHolderSearchSummary" runat="server"></asp:PlaceHolder>
    </p>
    <asp:PlaceHolder ID="PlaceHolderTopNavigation" Visible="false" runat="server"></asp:PlaceHolder>
    <!--<asp:Label ID="lblSearchResults" runat="server" Text="<%$Resources:Resources, searchResults %>"></asp:Label> -->
    <p>
    <asp:PlaceHolder ID="PlaceHolderSearchResults" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolderBottomNavigation" runat="server"></asp:PlaceHolder>
	

                            </asp:Panel>
               


  </form>            
                    
    </asp:Panel>