<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="WebPresentacion.views.Eliminar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form id="form3" runat="server" class="row justify-content-center mt-4 mb-4 g-3 needs-validation shadow-sm bg-light rounded">

         <div class="col-12 ">
        <h3 class="text-center">Elimina una credencial</h3>
        </div>
        <div class="col-12">
            <div class="row justify-content-center pa-0">
                <div class="col-5 col-md-2">
                    <img class="img-fluid img" alt="Logo Insertar" src="../images/debt-ge86c86862_1280.png" />
                </div>
            </div>
        </div>

        <div class="col-lg-7 d-flex justify-content-center">

            <div>
                <div class="row">
                    <div class="col-12">
                        <div class="mt-0">
                            <label for="TxtCurp" class="form-label">Escriba su Curp:</label>

                            <asp:TextBox ID="TextBox1" CssClass="mb-3 form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-12">
                        <div class="d-grid gap-2">
                            <asp:Button ID="Button1" CssClass="my-3 btn btn-primary d-block"  OnClick="Button1_Click" runat="server" Text="Button" />
                        </div>
                    </div>
                </div>
               
            </div>
        </div>


    </form>

</asp:Content>
