<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="Restaurar.aspx.cs" Inherits="WebPresentacion.views.Recuperar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="Al" runat="server" class="alert alert-primary alert-dismissible fade show mt-3 d-flex justify-content-between" role="alert">
        <asp:Label ID="Alerta" runat="server" CssClasss="w-100" Text="Label"></asp:Label>
        <div class="">
            <button runat="server" id="VerTabla1" name="VerTabla1" onserverclick="VerTabla" class="btn-primary mx-lg-3">
                <i class="fa-solid fa-check"></i>
            </button>
            <button runat="server" name="RestaurarAutomatic1" id="RestaurarAutomatic1" onserverclick="RestaurarAutomatic" class="btn-primary mx-lg-3">
                <i class="fa-solid fa-check"></i>
            </button>
            <button type="button" data-bs-dismiss="alert" aria-label="Close" class=" btn-danger">
                <i class="fa-solid fa-xmark"></i>
            </button>
        </div>
    </div>
    <form id="form3" runat="server" class="row justify-content-center mt-4 mb-4 g-3 needs-validation shadow-sm bg-light rounded">
        <div class="col-auto">
            <h3>Respaldo y Restauración</h3>
        </div>
        <div class="col-12">
            <div class="row justify-content-center pa-0">
                <div class="col-5 col-md-2">
                    <img class="img-fluid img" alt="Logo Insertar" src="../images/database-g9fc7f8505_1280.png" />
                </div>
            </div>
        </div>
        <div class="col-12" runat="server" id="grid">
            <asp:GridView ID="GridView1" CssClass="table table-primary table-responsive" runat="server"></asp:GridView>
        </div>
        <div class="col-12">
            <div class="row">
                <div class="col-lg-6">
                    <div class="p-3">
                        <label for="ContentPlaceHolder1_FileUpload1" class="form-label">Selecione un archivo.</label>
                        <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />
                    </div>
                    <div class="p-3 col-lg-3 d-flex">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Restaurar Archivo Selecionado" OnClick="RestaurarFileDynamic" />
                    </div>
                </div>
                <div class="col-lg-6 p-3 py-5 d-flex justify-content-around">
                    <a href="../Catalogues/recuperacion.json" class="btn btn-primary my-3" role="button" download="Respaldo.json">Realizar respaldo</a>
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-danger my-3" Text="Eliminar todo el árbol" OnClick="Button2_Click1" />
                </div>
            </div>
        </div>
    </form>

</asp:Content>
