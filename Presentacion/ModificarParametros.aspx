<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="ModificarParametros.aspx.cs" Inherits="Presentacion.ModificarParametros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Modificar Arancel"></asp:Label>
<asp:TextBox ID="txtModArancel" runat="server"></asp:TextBox>
<asp:Button ID="btnModifArancel" runat="server" OnClick="btnModifArancel_Click" Text="Modificar" />
<br />
<br />
<br />
<asp:Label ID="Label2" runat="server" Text="Modificar Porcentaje VIP"></asp:Label>
<asp:TextBox ID="txtModPorcVIP" runat="server"></asp:TextBox>
<asp:Button ID="btnModifPorcVIP" runat="server" OnClick="btnModifPorcVIP_Click" Text="Modificar" />
<br />
<br />
<asp:Label ID="lblMensajeModif" runat="server"></asp:Label>
</asp:Content>
