$(document).ready(function () {
    $(window).load(function () {


        cargarGridPersonaJuridica();

        $("#btnBuscarPersonaJuridica").click(function () {
            cargarGridPersonaJuridica();

        });

        $("#btnLimpiarPersonaJuridica").click(function () {
            $("#descripcion_esp").val('');
            $("#descripcion_ing").val('');

            cargarGridPersonaJuridica();
        });




        $("#addModifyPersonaJuridica").click(function () {


            var dataDetallePersonaJuridica = $("#gridPersonaJuridica").data("kendoGrid");
            var itemDataPersonaJuridica = dataDetallePersonaJuridica.dataItem(dataDetallePersonaJuridica.select());
            if (itemDataPersonaJuridica != undefined) {

                var url = $(this).attr('data-url') + '?Index=' + itemDataPersonaJuridica.XID_TIPO_HABILITACION_LIC;
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

function cargarGridPersonaJuridica() {

    $("#gridPersonaJuridica").html('');


    var dataSource = new kendo.data.DataSource({
        transport: {
            read: {
                type: "POST",
                url: "/PersonaJuridica/ListarPersonaJuridica",
                contentType: "application/json",
                dataType: 'json'
            },
            parameterMap: function (options, operation) {
                return JSON.stringify({ Bus_Ruc: $('#Bus_Ruc').val(), Bus_Razon_Social: $('#Bus_Razon_Social').val(), page: options.page, pageSize: options.pageSize });
            }
        },
        schema: {
            data: "l_T_GENM_PERSONA_JURIDICA",
            total: "pageSize",
            type: 'json',
            model: {
                fields: {
                    XPERSONAJURIDICA: { type: "string" },
                    RUC: { type: "string" },
                    RAZON_SOCIAL: { type: "string" },
                    FLG_ESTADO: { type: "boolean" }


                }
            }
        },
        pageSize: 10,
        serverPaging: true,
        serverFiltering: true,
        serverSorting: true
    });

    var grid = $("#gridPersonaJuridica").kendoGrid({

        dataSource: dataSource,
        scrollable: true,
        pageable: true,
        selectable: "multiple",
        //height: 400,
        columns: [
            {
                field: "XPERSONAJURIDICA",
                title: "XPERSONAJURIDICA",
                hidden: true
            }, {
                field: "RUC",
                title: "RUC",
                flex: 1
            }, {
                field: "RAZON_SOCIAL",
                title: "RAZON SOCIAL",
                flex: 1
            }, {
                field: "FLG_ESTADO",
                title: "ACTIVO",
                template: "# if (FLG_ESTADO == true) {# <input type='checkbox' checked='checked' disabled='disabled'/> # } else {# <input type='checkbox' disabled='disabled'/> #} #",
                width: 150
            }]
    }).data("kendoGrid");

}