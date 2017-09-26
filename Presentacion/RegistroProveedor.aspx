<%@ Page Title="" Language="C#" MasterPageFile="~/PagMaestra.Master" AutoEventWireup="true" CodeBehind="RegistroProveedor.aspx.cs" Inherits="Presentacion.RegistroProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        height: 44px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="1">
        <tr>
            <th colspan="2">
                Ingresar Proveedor
            </th>
        </tr>
        <tr>
            <td class="auto-style1">
                RUT:
            </td>
            <td class="auto-style1">

                <asp:TextBox ID="txtRUT" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                Pass:
            </td>
            <td>

                <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                Nombre Fantasia:
            </td>
            <td>

                <asp:TextBox ID="txtNombreFantasia" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                email:
            </td>
            <td>

                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                telefono:
            </td>
            <td>

                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                VIP:
            </td>

            <td>

                <asp:DropDownList ID="ddlVIP" runat="server">
                    <asp:ListItem Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td>
                Servicio ofrecido:
            </td>

            <td>

                <asp:TextBox ID="txtNomServ" runat="server"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td>
                Tipo de Servicio:
            </td>

            <td>

                <asp:DropDownList ID="ddlTipoServ" runat="server" DataValueField="Id" DataTextField="Nombre">
                   
                </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td>
                Foto:
            </td>

            <td>

                <asp:FileUpload ID="fuFotoServicio" runat="server" />

            </td>
        </tr>
        <tr>
            <td>
                Descripcion:
            </td>

            <td>

                <asp:TextBox ID="txtDescServ" runat="server"></asp:TextBox>

            </td>
        </tr>
                
    </table>
    <br />
    <asp:Button ID="Registrar" runat="server" Text="Ingresar Proveedor" OnClick="Registrar_Click" />
    <br />
<br />
<asp:Label ID="lblMensajeIngresoProv" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="grvNuevoProv" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Visible="False">
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
</asp:Content>
