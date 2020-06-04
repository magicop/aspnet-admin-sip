//$(function () {
//    $('[data-toggle="tooltip"]').tooltip()
//});

$(document).ready(function () {

    $('#TblPrestacion').DataTable({
        "pageLength": 10,
        "pagingType": "full_numbers",
        "bLengthChange": false,
        "bInfo": false,
        "oLanguage": {
            "sSearch": "Búsqueda rápida",
            buttons: {
                print: 'Imprimir'
                //copy: 'Copiar'
            },
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        },
        dom: 'Bfrtip',
        buttons: [
        //{
        //    extend: 'copyHtml5',
        //    exportOptions: {
        //        columns: [0, 6]
        //    }
        //},
        //'excelHtml5',
        //{
        //    extend: 'excelHtml5',
        //    text: 'Excel',
        //    exportOptions: {
        //        modifier: {
        //            page: 'current'
        //        }
        //    }
        //},
        'pdfHtml5',
        //{
        //    extend: 'pdfHtml5',
        //    exportOptions: {
        //        columns: [0, 6]
        //    }
        //},
        'print'
        ]
    });

    $('#TblPrestadores').DataTable({
        "pageLength": 10,
        "pagingType": "full_numbers",
        "bLengthChange": false,
        "bInfo": false,
        "oLanguage": {
            "sSearch": "Búsqueda rápida",
            buttons: {
                print: 'Imprimir'
                //copy: 'Copiar'
            },
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        },
        dom: 'Bfrtip',
        buttons: [
        //{
        //    extend: 'copyHtml5',
        //    exportOptions: {
        //        columns: [0, 6]
        //    }
        //},
        //'excelHtml5',
        //{
        //    extend: 'excelHtml5',
        //    text: 'Excel',
        //    exportOptions: {
        //        modifier: {
        //            page: 'current'
        //        }
        //    }
        //},
        'pdfHtml5',
        //{
        //    extend: 'pdfHtml5',
        //    exportOptions: {
        //        columns: [0, 6]
        //    }
        //},
        'print'
        ]
    });

    $('#TblSolicitudes').DataTable({
        "pageLength": 10,
        "pagingType": "full_numbers",
        "bLengthChange": false,
        "bInfo": false,
        "oLanguage": {
            "sSearch": "Búsqueda rápida",
            buttons: {
                print: 'Imprimir'
                //copy: 'Copiar'
            },
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            }
        },
        dom: 'Bfrtip',
        buttons: [
        //{
        //    extend: 'copyHtml5',
        //    exportOptions: {
        //        columns: [0, 6]
        //    }
        //},
        //'excelHtml5',
        //{
        //    extend: 'excelHtml5',
        //    text: 'Excel',
        //    exportOptions: {
        //        modifier: {
        //            page: 'current'
        //        }
        //    }
        //},
        'pdfHtml5',
        //{
        //    extend: 'pdfHtml5',
        //    exportOptions: {
        //        columns: [0, 6]
        //    }
        //},
        'print'
        ]
    });


});
