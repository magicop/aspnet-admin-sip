"use strict";
var sipApp = angular.module("angularSip", ["hSweetAlert","angularSpinner"]);
//sipApp.controller("sipController", ["$scope", "$http", function ($scope, $http, sweet) {
sipApp.controller("sipController", ["$scope", "$http", "sweet", "$timeout", "usSpinnerService", "$rootScope", function ($scope, $http, sweet, $timeout, usSpinnerService,  $rootScope) {


    var fn = {
        validaRut: function (rutCompleto) {
            if (!/^[0-9]+-[0-9kK]{1}$/.test(rutCompleto)) return false;
            var tmp = rutCompleto.split("-");
            return (fn.dv(tmp[0])) === tmp[1].toLowerCase();
        },
        dv: function (t) {
            var m = 0, s = 1;
            for (; t; t = Math.floor(t / 10))
                s = (s + t % 10 * (9 - m++ % 6)) % 11;
            return s ? (s - 1).toString() : "k";
        }
    };

    sweet.show({
        title: "Beneficio Cuenta Segura /Conocida",
        text: "Ingrese Run de afiliado:",
        type: "input",
        showCancelButton: false,
        closeOnConfirm: false,
        animation: "slide-from-top",
        inputPlaceholder: "Formato: 12345678-9"
    }, function (inputValue) {
        if (inputValue === false) {
            return false;
        }
        if (inputValue === "") {
            sweet.showInputError("Debe ingresar Run de un afiliado válido!");
            return false;
        }
        else
        {
                
            if (!/^[1-9]{1}([0-9]{0,9}-[0-9|K|k]{1})$/.test(inputValue)) {
                sweet.showInputError("Formato de Run no válido!");
                return false;
            }

            if (!fn.validaRut(inputValue)) {
                sweet.showInputError("Run no válido!");
                return false;
            }
        }

        var tmp = inputValue.split("-");
        inputValue = tmp[0];

        usSpinnerService.spin("spinner-1");
        $http.get("/api/afiliado/" + inputValue).
           success(function (data) {
                if (data.TIENECOBERTURASIP !== "S") {
                   usSpinnerService.stop("spinner-1");
                   sweet.showInputError("El Afiliado tiene un plan sin cobertura para el beneficio!");
                   return false;
               }
               sweet.show("Afiliado!", data.AFIL_TNOMBRES + " " + data.AFIL_TAPELLIDO_PATERNO , "success");
               $scope.getAfiliado(inputValue);
                return true;
            }).
           error(function (data, status, headers, config) {
               usSpinnerService.stop("spinner-1");
                sweet.showInputError("El Run ingresado no corresponde a un afiliado vigente!");
                return false;
           });

    });


    $scope.getAfiliado = function (run) {
        usSpinnerService.spin("spinner-1");
        $http.get("/api/afiliado/" + run).
            success(function (data) {
                console.log(data);
                $scope.afiliado = data;
                $scope.getPrestaciones();
                usSpinnerService.stop("spinner-1");
            }).
            error(function (data, status, headers, config) {
                console.log(status);
                usSpinnerService.stop("spinner-1");
            });
        
    };
    $scope.getPrestaciones = function () {
        usSpinnerService.spin("spinner-1");
        $http.get("/api/prestacion/" + $scope.afiliado.ISAP_CEMPRESA + "/" + $scope.afiliado.PLSA_CCOD).
            success(function (data) {
                $scope.prestaciones = data;
                usSpinnerService.stop("spinner-1");
                if ($scope.afiliado.TIENERESTRICCIONES !== "N") {
                    sweet.show("Atención!", "Plan de salud con restricciones para algunas prestaciones", "success");
                }
            }).
            error(function (data, status, headers, config) {
                usSpinnerService.stop("spinner-1");
            });

    };
    $scope.getPrestador = function () {
        usSpinnerService.spin("spinner-1");
        $http.get("/api/prestador/" + $scope.afiliado.ISAP_CEMPRESA + "/" + $scope.ddlPrestacion + "/" + $scope.afiliado.PLSA_CCOD).
            success(function (data) {
                $scope.prestadores = data;
                usSpinnerService.stop("spinner-1");
            }).
            error(function (data, status, headers, config) {
                usSpinnerService.stop("spinner-1");
                console.log(status);
            });
    };
    $scope.getCondiciones = function () {
        usSpinnerService.spin("spinner-1");
        $http.get("/api/condicion/B/" + $scope.ddlPrestacion).
            success(function (data) {
                $scope.condiciones = data;
                usSpinnerService.stop("spinner-1");
            }).
            error(function (data, status, headers, config) {
                usSpinnerService.stop("spinner-1");
                console.log(status);
            });
    };
    $scope.getBeneficiarios = function () {
        usSpinnerService.spin("spinner-1");
        $http.get("/api/beneficiario/" +  $scope.afiliado.AFIL_NRUT + "/" + $scope.ddlPrestacion).
            success(function (data) {
                $scope.beneficiarios = data.Beneficiarios;
                usSpinnerService.stop("spinner-1");
            }).
            error(function (data, status, headers, config) {
                usSpinnerService.stop("spinner-1");
                sweet.show({
                    title: "Oops!",
                    text: "Ocurrio un error al obtener la lista de beneficiarios <br /><span style=\"color:#F8BB86\">" + status + "</span>",
                    html: true
                });
            });
    };
    $scope.GeneraPresupuesto = function () {

        if ((typeof $scope.ddlBeneficiario === "undefined") ||
             (typeof $scope.ddlPrestacion === "undefined") 
            )
        {
            sweet.show("Oops...", "Debe seleccionar Prestación y/o Beneficiario!" , "error");
            return false;
        }


        usSpinnerService.spin("spinner-1");
        $http({
            method: "POST",
            url: "/api/sip/presupuesto",
            headers: { 'Content-Type': "application/x-www-form-urlencoded", 'Authorization': "Basic U0lQOlNJUDIwMTU="},
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: {
                    RunAfiliado: $scope.afiliado.AFIL_NRUT,
                    RunBeneficiario: $scope.ddlBeneficiario,
                    PrestacionID: $scope.ddlPrestacion,
                    PrestadorID: $scope.prestadorSelected,
                    Canal: "WEB",
                    Isapre: $scope.afiliado.ISAP_CEMPRESA,
                    RunEjecutivo: $scope.runejecutivo,
                    PlanSalud: $scope.afiliado.PLSA_CCOD,
                    TramoSip: $scope.afiliado.TRAMO
            }
        }).success(function (data) {
            if (data !== -99) {
            $http.get("/api/sip/presupuesto/" + data + "/pdf", { responseType: "arraybuffer" }).
                        success(function (data) {
                            var file = new Blob([data], { type: "application/pdf" });
                            var fileUrl = URL.createObjectURL(file);

                            //download.downloadFile(fileUrl);

                            var ua = window.navigator.userAgent;
                            var msie = ua.indexOf("MSIE ");
                            if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./)) {
                                console.log('IE');
                               // window.open();
                                window.navigator.msSaveOrOpenBlob(file, "presupuesto.pdf");
                            } else {
                                var a = document.createElement("a");
                                a.href = fileUrl;
                                a.target = "_blank";
                                a.download = "presupuesto.pdf";
                                document.body.appendChild(a);
                                a.click();
                            }

                            usSpinnerService.stop("spinner-1");

                        }).
                        error(function (data, status, headers, config) {
                            usSpinnerService.stop("spinner-1");
                            sweet.show("Oops...", status, "error");
                        });
                 
            } else {
                 usSpinnerService.stop("spinner-1");
                sweet.show("Oops...", "Ya existe una solicitud para esa prestación", "error");

            }
        });

    };
    $scope.GeneraSolicitud = function () {

        
        if ((typeof $scope.ddlBeneficiario === "undefined") ||
             (typeof $scope.ddlPrestacion === "undefined") ||
             (typeof $scope.prestadorSelected === "undefined")
            ) {
            sweet.show("Oops...", "Debe seleccionar Prestación, Beneficiario y Prestador!", "error");
            return false;
        }

        var prestador = $scope.prestadorSelected.split(":")[0];
        var tramo = $scope.prestadorSelected.split(":")[1];

        usSpinnerService.spin("spinner-1");
        $http({
            method: "POST",
            url: "/api/sip/solicitud",
            headers: { 'Content-Type': "application/x-www-form-urlencoded", 'Authorization': "Basic U0lQOlNJUDIwMTU="},
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: {
                RunAfiliado: $scope.afiliado.AFIL_NRUT,
                RunBeneficiario: $scope.ddlBeneficiario,
                PrestacionID:  $scope.ddlPrestacion,
                PrestadorID: prestador,
                Canal: "WEB",
                Isapre: $scope.afiliado.ISAP_CEMPRESA,
                RunEjecutivo: $scope.runejecutivo,
                PlanSalud: $scope.afiliado.PLSA_CCOD,
                TramoSip: tramo
            }
        }).success(function (data) {
            if (data !== -99) {
                var solicitudId = data;
                $http.get("/api/sip/solicitud/" + data + "/pdf", { responseType: "arraybuffer" }).
                            success(function (data) {
                                var file = new Blob([data], { type: "application/pdf" });
                                var fileUrl = URL.createObjectURL(file);

                                var ua = window.navigator.userAgent;
                                var msie = ua.indexOf("MSIE ");
                                if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./)) {
                                    console.log('IE');
                                    // window.open();
                                    window.navigator.msSaveOrOpenBlob(file, "solicitud.pdf");
                                } else {
                                    var a = document.createElement("a");
                                    a.href = fileUrl;
                                    a.target = "_blank";
                                    a.download = "solicitud.pdf";
                                    document.body.appendChild(a);
                                    a.click();
                                }


                                usSpinnerService.stop("spinner-1");
                                sweet.show({
                                    title: "Recuerde firmar el documento",
                                    text: "Una vez firmado, envíe una copia al prestador.",
                                    type: "info",
                                    showCancelButton: false,
                                    closeOnConfirm: false,
                                    showLoaderOnConfirm: true
                                }, function (inputValue) {
                                    $http.get("/api/sip/solicitud/" + solicitudId + "/mail").
                                    success(function () {
                                        $timeout(function () {
                                            sweet.show("Copia enviada al prestador");
                                        }, 2000);
                                    }).
                                     error(function (data, status, headers, config) {
                                         usSpinnerService.stop("spinner-1");
                                            sweet.show("No se pudo enviar la copia al prestador");
                                     });
                                });


                            }).
                            error(function (data, status, headers, config) {
                                usSpinnerService.stop("spinner-1");
                        sweet.show({
                                    title: "Oops!",
                                    text: "No se pudo generar el documento pdf <br /><span style=\"color:#F8BB86\">" + status + "</span>",
                                    html: true
                                });
                            });

            } else {
                usSpinnerService.stop("spinner-1");
                sweet.show("Oops...", "Ya existe una solicitud para esa prestación", "error");
            }

        });

    };
    $scope.getSip = function () {
        $scope.getPrestador();
        $scope.getCondiciones();
        $scope.getBeneficiarios();
    };


    $scope.ReimprimirSolicitud = function () {
        sweet.show({
            title: "Reimpresión de solicitud",
            text: "Ingrese Folio de la solicitud:",
            type: "input",
            showCancelButton: false,
            closeOnConfirm: true,
            animation: "slide-from-top",
        }, function (inputValue) {
            if (inputValue === false) {
                return false;
            }
            if (inputValue === "") {
                sweet.showInputError("Debe ingresar Folio válido!");
                return false;
            }
            else
            {
                
                if (!/^[0-9]+$/.test(inputValue)) {
                    sweet.showInputError("Formato de Folio no válido!");
                    return false;
                }
            }

            usSpinnerService.spin("spinner-1");
            $http.get("/api/sip/solicitud/copia/" + inputValue + "/pdf", { responseType: "arraybuffer" }).
                    success(function (data) {
                        var file = new Blob([data], { type: "application/pdf" });
                        var fileUrl = URL.createObjectURL(file);
                        console.log('id solicitud:' + inputValue);
                        var ua = window.navigator.userAgent;
                        var msie = ua.indexOf("MSIE ");
                        if (msie > 0 || !!navigator.userAgent.match(/Trident.*rv\:11\./)) {
                            console.log('IE');
                            // window.open();
                            console.log('IEXPLORER' + inputValue);
                            window.navigator.msSaveOrOpenBlob(file, "solicitud.pdf");
                            usSpinnerService.stop("spinner-1");
                            return true;
                        } else {
                            console.log('OTRO' + inputValue);
                            var a = document.createElement("a");
                            a.href = fileUrl;
                            a.target = "_blank";
                            a.download = "solicitud.pdf";
                            document.body.appendChild(a);
                            a.click();
                            usSpinnerService.stop("spinner-1");
                            return true;
                        }
                    }).
                    error(function (data, status, headers, config) {
                        usSpinnerService.stop("spinner-1");
                        sweet.show({
                            title: "Oops!",
                            text: "No se pudo generar el documento pdf <br /><span style=\"color:#F8BB86\">" + status + "</span>",
                            html: true
                        });
                    });
        });
    }


}]);