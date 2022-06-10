<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="WebPresentacion.views.Buscar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="Al" runat="server" class="alert alert-primary alert-dismissible fade show mt-3" role="alert">
        <asp:Label ID="Alerta" runat="server" Text="Label"></asp:Label>
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
    <form runat="server" id="form3" class="row justify-content-center mt-4 mb-4 g-3 needs-validation shadow-sm bg-light rounded">
        <div class="col-12 ">
        <h3 class="text-center">Busca una credencial</h3>
        </div>
        <div class="col-12">
            <div class="row justify-content-center pa-0">
                <div class="col-5 col-md-2">
                    <img class="img-fluid img" alt="Logo Insertar" src="../images/cat-g7f9e26245_1280.png" />
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
                            <asp:Button ID="Button2" CssClass="my-3 btn btn-primary d-block " runat="server" Text="Button" OnClick="Button2_Click" />
                        </div>
                    </div>
                </div>

                <div class="card col-12 mt-4" runat="server" id="card" style="width: 19rem;">
                    <div class="card-body">
                        <h6 class="card-title"><b>Curp:</b></h6>
                        <p class="card-text">
                            <asp:Label ID="Curp" runat="server"></asp:Label>
                        </p>
                    </div>
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <b>Nombre:</b> <asp:Label ID="Nombre" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <b>Domicilio: </b> <asp:Label ID="Domicilio" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <b>Estado:</b> <asp:Label ID="Estado" runat="server"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <b>Municipio:</b> <asp:Label ID="Municipio" runat="server"></asp:Label>
                        </li>
                    </ul>
                    <div class="card-body d-flex justify-content-around">
                        <a href="#" class="card-link">
                            <b>Seccion:</b> <asp:Label ID="Seccion" runat="server"></asp:Label>
                        </a>
                        <a href="#" class="card-link">
                            <b>Vigencia:</b> <asp:Label ID="Vigencia" runat="server"></asp:Label>
                        </a>
                    </div>
                </div>
            </div>
        </div>


    </form>
</asp:Content>
