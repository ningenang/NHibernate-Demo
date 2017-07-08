<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NHibernate_Demo._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-4">
            <h2>Lesing av data</h2>

			<b>SELECT N + 1</b>
            <ul>
                <li>
					<a runat="server" href="~/Demo/NPlusOne/Buggy.aspx">Med SELECT N + 1 (treig)</a>
                </li>
				<li>
					<a runat="server" href="~/Demo/NPlusOne/Fixed.aspx">Uten SELECT N + 1 (kjapp)</a>
				</li>
            </ul>

			<b>Paging i query</b>
			<ul>
				<li>
					<a runat="server" href="~/Demo/Paging/Buggy.aspx">Uten paging i query</a>
                </li>
				<li>
					<a runat="server" href="~/Demo/Paging/Fixed.aspx">Med paging i query</a>
				</li>
			</ul>
			
        </div>
    </div>

</asp:Content>
