
<%@ Page Title="Insertar Credencial" Language="C#"  MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="Insertar.aspx.cs" Inherits="WebPresentacion.Insertar"  EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="Al" runat="server" class="alert alert-primary alert-dismissible fade show mt-3" role="alert">
        <asp:Label ID="Alerta" runat="server" Text="Label"></asp:Label>
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
    <form id="form1" runat="server" method="post" class="row justify-content-center mt-4 mb-4 g-3 needs-validation shadow-sm bg-light rounded" novalidate >
        <div class="col-auto">
        <h3>Generador de credenciales</h3>
        </div>
        <div class="col-12">
            <div class="row justify-content-center pa-0">
                <div class="col-5 col-md-2">
                    <img class="img-fluid img" alt="Logo Insertar" src="https://cdn2.iconfinder.com/data/icons/interface-116/200/enter-password-2--enter-password-INTERFACE-LOGIN-USER-CREDENTIALS-UI-PROFILE-MAN-LAPTOP-PC-MAN-512.png" />
                </div>
            </div>
        </div>
        <div class="col-12 col-md-10 mt-0">
            <label for="TxtCurp" class="form-label">Curp:</label>
            <input type="text" id="TxtCurp" name="TxtCurp" class="form-control" required />
            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Por favor, coloque su CURP.
            </div>
        </div>

        <div class="col-12 col-md-10 ">
            <label class="form-label" for="TxtNombre">Nombre:</label>
            <input type="text" id="TxtNombre" name="TxtNombre" class="form-control" required />
            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Por favor, coloque su Nombre Completo.
            </div>
        </div>

        <div class="col-12 col-md-5">
            <label class="form-label" for="DropEstados">Estado:</label>
            <select id="DropEstados" name="DropEstados" class="form-select" required></select>
            <%--<asp:DropDownkList ID="DropEstado"   CssClass="form-select" runat="server"></asp:DropDownkList>--%>
            <input  type="hidden" id="TxtEstado" name="TxtEstado"/>
            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Por favor, elija un nombre de Estado.
            </div>
        </div>

        <div class="col-12 col-md-5">
            <label class="form-label" for="DropMunicipios">Municipio:</label>
            <select id="DropMunicipios" name="DropMunicipios" class="form-select" required></select>
            <input  type="hidden" id="TxtMunicipio" name="TxtMunicipio"/>
            <%--<asp:DropDownList ID="DropMunicipio" CssClass="form-select" runat="server"></asp:DropDownList>--%>
            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Por favor, elija un nombre de Municipio.
            </div>
        </div>
        <div class="col-12 col-md-10">
            <label class="form-label" for="TxtDomicilio">Domicilio:</label>
            <input type="text" id="TxtDomicilio" name="TxtDomicilio" class="form-control" required />
            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Por favor, elija un nombre de Domicilio.
            </div>
        </div>
        <div class="col-12 col-md-5">
            <label class="form-label" for="TxtSeccion">Sección:</label>
            <input type="number" id="TxtSeccion" name="TxtSeccion" class="form-control" required />
            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Proporcione un código Sección válido.
            </div>
        </div>
        <div class="col-12 col-md-5">
            <label class="form-label" for="TxtVigencia">Vigencia:</label>
            <input type="number" class="form-control" name="TxtVigencia"  id="TxtVigencia" required/>


            <div class="valid-feedback">
                ¡Se ve bien!
            </div>
            <div class="invalid-feedback">
                Proporcione el año de vigencia4.
            </div>
        </div>
        <div class="col-5 mt-4 mb-3 d-flex justify-content-center">
            <button id="BtnCredencial" class="btn btn-primary" type="submit">Generar Credencial</button>
        </div>
    </form>
    <script>

        var URLactual = jQuery(location)[0].origin + '/Catalogues'
        const DropEstados = $('#DropEstados');
        const DropMunicipios = $('#DropMunicipios');

        (() => {
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

        $(document).ready(function () {
            DropEstados.empty().append('<option value=""></option>');
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

            $("#TxtVigencia").datepicker({
                format: "yyyy",
                viewMode: "years",
                minViewMode: "years",
                autoclose: true
            });
        });

        DropEstados.change(function () {
            const estado = $(this).val();
            $("#TxtEstado").val($("#DropEstados :selected").text());
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

        DropMunicipios.change(function () {
            $("#TxtMunicipio").val($("#DropMunicipios :selected").text());
        });
    </script>
</asp:Content>
