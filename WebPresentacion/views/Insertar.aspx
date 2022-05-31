
<%@ Page Title="Insertar Credencial" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="Insertar.aspx.cs" Inherits="WebPresentacion.Insertar"  EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="Al" runat="server" class="alert alert-primary alert-dismissible fade show mt-3" role="alert">
        <asp:Label ID="Alerta" runat="server" Text="Label"></asp:Label>
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
    <form id="form1" runat="server" class="row justify-content-center mt-4 mb-4 g-3 needs-validation shadow-sm bg-light rounded" novalidate >
        <div class="col-auto">
        <h3>Generador de credenciales</h3>
        </div>
        <div class="col-12">
            <div class="row justify-content-center pa-0">
                <div class="col-5 col-md-2">
                    <img class="img-fluid img" src="https://cdn2.iconfinder.com/data/icons/interface-116/200/enter-password-2--enter-password-INTERFACE-LOGIN-USER-CREDENTIALS-UI-PROFILE-MAN-LAPTOP-PC-MAN-512.png" />
                </div>
            </div>
        </div>
        <div class="col-12 col-md-10 mt-0">
            <label for="TxtCurp" class="form-label">Curp:</label>
            <input type="text" runat="server" id="TxtCurp" class="form-control" required />
            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Por favor, coloque su CURP.
            </div>
        </div>

        <div class="col-12 col-md-10 ">
            <label class="form-label">Nombre:</label>
            <input type="text" runat="server" id="TxtNombre" class="form-control" required />
            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Por favor, coloque su Nombre Completo.
            </div>
        </div>

        <div class="col-12 col-md-5">
            <label class="form-label">Estado:</label>
            <%--<select runat="server" id="DropEstados" name="DropEstados" class="form-select" required></select>--%>
            <asp:DropDownList ID="DropEstado"   CssClass="form-select" runat="server"></asp:DropDownList>
            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Por favor, elija un nombre de Estado.
            </div>
        </div>

        <div class="col-12 col-md-5">
            <label class="form-label">Municipio:</label>
            <%--<select runat="server" id="DropMunicipios" name="DropMunicipios" class="form-select" required></select>--%>
            <asp:DropDownList ID="DropMunicipio" CssClass="form-select" runat="server"></asp:DropDownList>
            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Por favor, elija un nombre de Municipio.
            </div>
        </div>

        <div class="col-12 col-md-10">
            <label class="form-label">Domicilio:</label>
            <input type="text" runat="server" id="TxtDomicilio" class="form-control" required />
            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Por favor, elija un nombre de Domicilio.
            </div>
        </div>
        <div class="col-12 col-md-5">
            <label class="form-label">Sección:</label>
            <input type="number" runat="server" id="TxtSeccion" class="form-control" required />
            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Proporcione un código Sección válido.
            </div>
        </div>
        <div class="col-12 col-md-5">
            <label class="form-label">Vigencia:</label>
            <%--<input type="number" runat="server" id="TxtVigencia" class="form-control" required />--%>
            <input type="number" runat="server"  class="form-control"  id="TxtVigencia" required/>


            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Proporcione el año de vigencia4.
            </div>
        </div>
        <div class="col-5 mt-4 mb-3 d-flex justify-content-center">
            <asp:Button ID="Button1" runat="server" class="btn btn-primary"  OnClick="Button1_Click" Text="Generar Credencial" />
        </div>
    </form>
    <script>

        var URLactual = jQuery(location)[0].origin + '/Catalogues'
        const DropEstados = $('#ContentPlaceHolder1_DropEstado');
        const DropMunicipios = $('#ContentPlaceHolder1_DropMunicipio');

        ( () => {
            DropMunicipios.prop('disabled', true);
            const forms = document.querySelectorAll('.needs-validation')
            Array.from(forms).forEach(form => {
                form.addEventListener('submit', event => {
                    if (!form.checkValidity()) {
                        event.preventDefault()
                        event.stopPropagation()
                    }

                    form.classList.add('was-validated')
                }, false)
            })
        })()

        $(document).ready(function (){
            $.ajax({
                type: 'GET',
                url: URLactual + '/Estados.json',
                dataType: 'json',
                success: function (data) {
                    $.each(data, function (index, value) {
                        DropEstados.append($('<option>', {
                            value: value.id,
                            text: value.nombre
                        }));
                    });
                }
            });

            $("#ContentPlaceHolder1_TxtVigencia").datepicker({
                format: "yyyy",
                viewMode: "years",
                minViewMode: "years",
                autoclose: true
            });
        });

        DropEstados.change(function () {
            const estado = $(this).val();
            DropMunicipios.empty().append('<option value=""></option>').prop('disabled', false);
            if (estado != "") {
                $.ajax({
                    type: 'GET',
                    url: URLactual + '/Municipios.json',
                    dataType: 'json',
                    success: function (data) {
                        const muni = data.filter(municipio => municipio.estado_id == estado);
                        $.each(muni, function (index, value) {
                            DropMunicipios.append($('<option>', {
                                value: value.id,
                                text: value.nombre
                            }));
                        })
                    }
                });
            } else {
                DropMunicipios.prop('disabled', true);
            }
        });
    </script>
</asp:Content>
