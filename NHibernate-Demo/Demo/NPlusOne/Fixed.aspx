﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Fixed.aspx.cs" Inherits="NHibernate_Demo.Demo.NPlusOne.Fixed" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<h2>Customers</h2>
	<p>
		Loading data: <asp:Label ID="lblDiagnostic" runat="server"/>
	</p>

	<asp:GridView ID="grdData" runat="server" 
		DataSourceID="odsData"
		AutoGenerateColumns="false">
		<Columns>
			<asp:BoundField HeaderText="First Name" DataField="FirstName"/>
			<asp:BoundField HeaderText="Last Name" DataField="LastName"/>
			<asp:BoundField HeaderText="Emails" DataField="ContactDetails"/>
		</Columns>
	</asp:GridView>

	<asp:ObjectDataSource ID="odsData" runat="server" SelectMethod="GetData" TypeName="NHibernate_Demo.Demo.NPlusOne.Fixed" OnSelecting="odsData_Selecting" OnSelected="odsData_Selected"/>



</asp:Content>
