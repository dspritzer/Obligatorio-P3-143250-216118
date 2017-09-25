<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="DesactivarProveedor.aspx.cs" Inherits="Presentacion.DesactivarProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Ingrese Id"></asp:Label>
<asp:TextBox ID="txtidprov" runat="server"></asp:TextBox>
<br />
<asp:Button ID="btnDesactivar" runat="server" OnClick="btnDesactivar_Click" Text="Desactivar" />
<br />
<asp:Label ID="lblMsjDesact" runat="server"></asp:Label>
<br />
</asp:Content>
