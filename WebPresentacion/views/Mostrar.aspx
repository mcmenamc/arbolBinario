<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="Mostrar.aspx.cs" Inherits="WebPresentacion.views.Mostrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .color {
            background-color: #D3D3D3;
            margin: 20px 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form id="form1" runat="server">

        <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        


    </form>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <script>
        $(document).ready( function () {
            $('#myTable').DataTable();
        } );
    </script>

</asp:Content>
