<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Buggy.aspx.cs" Inherits="NHibernate_Demo.Demo.NPlusOne.Buggy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<asp:GridView ID="grdProductSalesTransactions" runat="server" 
		DataSourceID="odsProductSalesTransactions"
		AutoGenerateColumns="false">
		<Columns>
			<asp:BoundField HeaderText="Product Name" DataField="Name"/>
			<asp:BoundField HeaderText="Number of sales transactions" DataField="TransactionCount" />
			<asp:BoundField HeaderText="Number of distinct customers" DataField="TransactionCount" />
		</Columns>
	</asp:GridView>

	<asp:ObjectDataSource ID="odsProductSalesTransactions" runat="server" SelectMethod="GetSalesTransactions" TypeName="NHibernate_Demo.Demo.NPlusOne.Buggy" />


</asp:Content>
