
<%@ Page Title="TODO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TODO.aspx.cs" Inherits="NHibernate_Demo.TODO" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    

	<h2>Fetching examples</h2>
	<ul>
		<li>Default fetching strategy</li>
		<li>Join fetching</li>
		<li>Batch fetching</li>
	</ul>

	<h2>Paging examples</h2>
	<ul>
		<li>Grid uten paging i spørring</li>
		<li>Grid med paging i spørring</li>
	</ul>

	<h2>Caching examples</h2>
	<ul>
		<li>Vis spørring uten caching i Nhibernate.Profiler</li>
		<li>Vis spørring med caching i Nhibernate.Profiler</li>
	</ul>

</asp:Content>
