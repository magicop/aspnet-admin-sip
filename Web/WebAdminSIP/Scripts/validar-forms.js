
//$.noConflict();
jQuery(document).ready(function () {

    //$.validator.addMethod('validatenew', function () {
    //    return ($('#codigoProductoOld').val() != $('#codigoProductoNew').val())
    //}, "El código de producto antiguo no puede ser el mismo que el nuevo.");

    //VALIDACIONES $.VALIDATE
    $.extend($.validator.messages, {
        required: "Este campo es obligatorio.",
        remote: "Por favor, rellena este campo.",
        email: "Por favor, escribe una dirección de correo válida",
        url: "Por favor, escribe una URL válida.",
        date: "Por favor, escribe una fecha válida.",
        dateISO: "Por favor, escribe una fecha (ISO) válida.",
        number: "Por favor, escribe un número entero válido.",
        digits: "Por favor, escribe sólo dígitos.",
        creditcard: "Por favor, escribe un número de tarjeta válido.",
        equalTo: "Por favor, escribe el mismo valor de nuevo.",
        accept: "Ingrese una imagen, pdf o word",
        maxlength: $.validator.format("Por favor, no escribas más de {0} caracteres."),
        minlength: $.validator.format("Por favor, no escribas menos de {0} caracteres."),
        rangelength: $.validator.format("Por favor, escribe un valor entre {0} y {1} caracteres."),
        range: $.validator.format("Por favor, escribe un valor entre {0} y {1}."),
        max: $.validator.format("Por favor, escribe un valor menor o igual a {0}."),
        min: $.validator.format("Por favor, escribe un valor mayor o igual a {0}.")
    });

    jQuery(document).off("click");
    jQuery(document).on("click", "#btnAgregarPrestacion", function (e) {

        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#FormAgregarPrestacion");

        $form.validate({
            submitHandler: function ($form) {
                $("error").addClass("alert alert-primary");
                $form.submit();
            },
            rules: {
                isapre: {
                    required: true
                },
                codPaquete: {
                    required: true,
                    minlength: 3,
                    maxlength: 9,
                    number: true
                },
                descripcion: {
                    required: true,
                    minlength: 1,
                    maxlength: 50
                }
            },
            messages: {
                isapre: {
                    required: "Debe ingresar la isapre correspondiente"
                },
                codPaquete: {
                    required: "Debe ingresar el código del paquete",
                    minlength: "El nombre del producto debe ser mayor a {0} caracteres",
                    maxlength: "El nombre del producto debe ser menor a {0} caracteres",
                    number: "Solamente puedes escribir números"
                },
                descripcion: {
                    required: "Debe ingresar la descripción de la prestación",
                    minlength: "La descripción del producto debe ser mayor a {0} caracteres",
                    maxlength: "La descripción del producto debe ser menor a {0} caracteres"

                }
            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });

    jQuery(document).on("click", "#btnBuscarStaff", function (e) {


        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#FormBuscarStaff");

        $form.validate({
            submitHandler: function ($form) {
                //$("body").addClass("loading");
                $form.submit();
            },
            rules: {
                isapre: {
                    required: true
                },
                descripcion: {
                    required: true
                },
                prestador: {
                    required: true
                }
            },
            messages: {
                isapre: {
                    required: "Debe seleccionar la isapre correspondiente"
                },
                descripcion: {
                    required: "Debe seleccionar la prestación"
                },
                prestador: {
                    required: "Debe seleccionar el prestador"
                }

            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });

    jQuery(document).on("click", "#btnBuscarRut", function (e) {


        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#FormSolicitudRut");

        $form.validate({
            submitHandler: function ($form) {
                //$("body").addClass("loading");
                $form.submit();
            },
            rules: {
                rut: {
                    required: true,
                    minlength: 8,
                    maxlength: 8,
                    number: true
                }
            },
            messages: {
                rut: {
                    required: "Debe ingresar el rut del afiliado",
                    minlength: "El rut ingresado debe ser igual a {0} caracteres",
                    maxlength: "El rut ingresado producto debe ser igual a {0} caracteres",
                    number: "Solamente puedes escribir números"
                }

            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });

    jQuery(document).on("click", "#btnBuscarId", function (e) {


        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#FormSolicitudId");

        $form.validate({
            submitHandler: function ($form) {
                //$("body").addClass("loading");
                $form.submit();
            },
            rules: {
                id: {
                    required: true,
                    minlength: 3,
                    maxlength: 7,
                    number: true
                }
            },
            messages: {
                id: {
                    required: "Debe ingresar la id de la solicitud",
                    minlength: "La id ingresada debe ser mayor a {0} caracteres",
                    maxlength: "La id ingresada debe ser menor a {0} caracteres",
                    number: "Solamente puedes escribir números"
                }

            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });

    jQuery(document).on("click", "#btnAgregarRestriccionManual", function (e) {


        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#FormAgregarRestriccionManual");

        $form.validate({
            submitHandler: function ($form) {
                //$("body").addClass("loading");
                $form.submit();
            },
            rules: {
                codplan: {
                    required: true,
                    minlength: 3,
                    maxlength: 30,
                },
                isapre: {
                    required: true
                }
            },
            messages: {
                codplan: {
                    required: "Debe ingresar el código del plan",
                    minlength: "El código del plan debe ser mayor a {0} caracteres",
                    maxlength: "El código del plan debe ser menor a {0} caracteres",
                },
                isapre: {
                    required: "Debe ingresar la isapre correspondiente"
                }

            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });

    jQuery(document).on("click", "#fileUploadExcel", function (e) {


        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#FormAgregarRestriccionExcel");

        $form.validate({
            submitHandler: function ($form) {
                //$("body").addClass("loading");
                $form.submit();
            },
            rules: {
                FileUpload: {
                    required: true
                }
            },
            messages: {
                FileUpload: {
                    required: "Debe seleccionar un archivo"
                }

            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });

    jQuery(document).on("click", "#btnBuscarRestriccion", function (e) {


        $.validator.setDefaults({
            debug: true,
            success: "valid"
        });

        $form = $("#FormBuscarRestriccion");

        $form.validate({
            submitHandler: function ($form) {
                //$("body").addClass("loading");
                $form.submit();
            },
            rules: {
                codplan: {
                    required: true,
                    minlength: 3,
                    maxlength: 30,
                },
                isapre: {
                    required: true
                }
            },
            messages: {
                codplan: {
                    required: "Debe ingresar el código del plan",
                    minlength: "El código del plan debe ser mayor a {0} caracteres",
                    maxlength: "El código del plan debe ser menor a {0} caracteres",
                },
                isapre: {
                    required: "Debe ingresar la isapre correspondiente"
                }

            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });

    jQuery(document).on("click", "#btnAgregarMedico", function (e) {


        $.validator.setDefaults({
            debug: true,
            validatenew: false,
            success: "valid"
        });

        $form = $("#FormAgregarMedico");

        $form.validate({
            submitHandler: function ($form) {
                //$("body").addClass("loading");
                $form.submit();
            },
            rules: {
                rut: {
                    required: true
                },
                nombre: {
                    required: true
                }
            },
            messages: {
                rut: {
                    required: "Debe ingresar el rut correspondiente"
                },
                nombre: {
                    required: "Debe ingresar el nombre correspondiente"
                }
            },
            errorElement: 'div',
            errorLabelContainer: '.errorTxt'
        });
    });
});