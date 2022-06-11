<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="Mostrar.aspx.cs" Inherits="WebPresentacion.views.Mostrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <h3 runat="server">Pre Orden</h3>
        <asp:GridView ID="PreOrden" CssClass="table table-primary" runat="server"></asp:GridView>
        
        <h3 runat="server">Entre Orden</h3>
        <asp:GridView ID="EntreOrden" CssClass="table table-primary" runat="server"></asp:GridView>
        
        <h3 runat="server">Post Orden</h3>
        <asp:GridView ID="PostOrden" CssClass="table table-primary" runat="server"></asp:GridView>
    </form>
</asp:Content>
