$(document).ready(function () {
    $(window).load(function () {


        cargarGridPersonaNatural();

        $("#btnBuscarPersonaNatural").click(function () {
            cargarGridPersonaNatural();

        });

        $("#btnLimpiarPersonaNatural").click(function () {
            $("#descripcion_esp").val('');
            $("#descripcion_ing").val('');

            cargarGridPersonaNatural();
        });



        //$("#addNewPersonaNatural").click(function () {

        //    var url = $(this).attr('data-url');
        //    var divModal = $(this).attr('data-div');
        //    var divContenedor = $(this).attr('data-contenedor');

        //    var seccionModal = ".seccionModal";
        //    var seccionContenedor = ".contenedor";

        //    if (divModal) {
        //        seccionModal = "#" + divModal;
        //    }

        //    if (divContenedor) {
        //        seccionContenedor = "#" + divContenedor;
        //    }

        //    $.ajax({
        //        url: url,
        //        beforeSend: function () {
        //            bloquoteObject();
        //        },
        //        success: function (data) {
        //            desbloqObject();
        //            $(seccionModal).html(data);
        //            $(seccionContenedor).modal('show');
        //        }
        //    });

        //});

        $("#addModifyPersonaNatural").click(function () {


            var dataDetallePersonaNatural = $("#gridPersonaNatural").data("kendoGrid");
            var itemDataPersonaNatural = dataDetallePersonaNatural.dataItem(dataDetallePersonaNatural.select());
            if (itemDataPersonaNatural != undefined) {

                var url = $(this).attr('data-url') + '?Index=' + itemDataPersonaNatural.XID_TIPO_HABILITACION_LIC;
                var divModal = $(this).attr('data-div');
                var divContenedor = $(this).attr('data-contenedor');

                var seccionModal = ".seccionModal";
                var seccionContenedor = ".contenedor";

                if (divModal) {
                    seccionModal = "#" + divModal;
                }

                if (divContenedor) {
                    seccionContenedor = "#" + divContenedor;
                }

                $.ajax({
                    url: url,
                    beforeSend: function () {
                        bloquoteObject();
                    },
                    success: function (data) {
                        desbloqObject();
                        $(seccionModal).html(data);
                        $(seccionContenedor).modal('show');
                    }
                });

            }
            else {
                bootbox.alert("Seleccione un registro de la tabla");
            }


        });


    });
});

function cargarGridPersonaNatural() {

    $("#gridPersonaNatural").html('');


    var dataSource = new kendo.data.DataSource({
        transport: {
            read: {
                type: "POST",
                url: "/PersonaNatural/ListarPersonaNatural",
                contentType: "application/json",
                dataType: 'json'
            },
            parameterMap: function (options, operation) {
                return JSON.stringify({ Bus_Nombre: $('#Bus_Nombre').val(), Bus_Ape_Paterno: $('#Bus_Ape_Paterno').val(), Bus_Ape_Materno: $('#Bus_Ape_Materno').val(), Bus_Nro_Documento: $('#Bus_Nro_Documento').val(), page: options.page, pageSize: options.pageSize });
            }
        },
        schema: {
            data: "l_T_GENM_PERSONA_NATURAL",
            total: "pageSize",
            type: 'json',
            model: {
                fields: {
                    XPERSONANATURAL: { type: "string" },
                    NOMBRE: { type: "string" },
                    APELLIDO_PATENRO: { type: "string" },
                    APELLIDO_MATERNO: { type: "string" },
                    TIPO_DOCUMENTO: { type: "string" },
                    NUMERO_DOCUMENTO: { type: "string" },
                    FLG_ESTADO: { type: "boolean" }


                }
            }
        },
        pageSize: 10,
        serverPaging: true,
        serverFiltering: true,
        serverSorting: true
    });

    var grid = $("#gridPersonaNatural").kendoGrid({

        dataSource: dataSource,
        scrollable: true,
        pageable: true,
        selectable: "multiple",
        //height: 400,
        columns: [
            {
                field: "XPERSONANATURAL",
                title: "XPERSONANATURAL",
                hidden: true
            }, {
                field: "NOMBRE",
                title: "NOMBRE",
                flex: 1
            }, {
                field: "APELLIDO_PATERNO",
                title: "APELLIDO PATERNO",
                flex: 1
            }, {
                field: "APELLIDO_MATERNO",
                title: "APELLIDO MATERNO",
                flex: 1
            }, {
                field: "TIPO_DOCUMENTO",
                title: "TIPO DOCUMENTO",
                flex: 1
            }, {
                field: "NUMERO_DOCUMENTO",
                title: "NRO. DOCUMENTO",
                flex: 1
            }, {
                field: "FLG_ESTADO",
                title: "ACTIVO",
                template: "# if (FLG_ESTADO == true) {# <input type='checkbox' checked='checked' disabled='disabled'/> # } else {# <input type='checkbox' disabled='disabled'/> #} #",
                width: 150
            }]
    }).data("kendoGrid");

}