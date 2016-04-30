$(document).ready(function () {
    $('body').on("click", ".modalMTC", function () {
        var url = $(this).attr('data-url');
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
                bloquoteModal();
            },
            success: function (data) {
                desbloqObject();
                desbloqModal();
                $(seccionModal).html(data);
                $(seccionContenedor).modal('show');
            }
        });
    });
    $('body').on("click", ".modalMTC2", function () {
        var url = $(this).attr('data-url');
        var divModal = $(this).attr('data-div');
        var divContenedor = $(this).attr('data-contenedor');

        var seccionModal = ".seccionModal2";
        var seccionContenedor = ".contenedor2";

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
                bloquoteModal();
            },
            success: function (data) {
                desbloqObject();
                desbloqModal();
                $(seccionModal).html(data);
                $(seccionContenedor).modal('show');
            }
        });
    });
    $('body').on("click", ".modalMTC3", function () {
        var url = $(this).attr('data-url');
        var divModal = $(this).attr('data-div');
        var divContenedor = $(this).attr('data-contenedor');

        var seccionModal = ".seccionModal3";
        var seccionContenedor = ".contenedor3";

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
                bloquoteModal();
            },
            success: function (data) {
                desbloqObject();
                desbloqModal();
                $(seccionModal).html(data);
                $(seccionContenedor).modal('show');
            }
        });
    });
    $('body').on("click", ".closeModalId", function () {
        var modal = $(this).attr('modal-data-id');
        $(modal).modal('hide');
    });


    $(document.body).on('keypress', 'input[type=text]', function (e) {
        if (permite(e, $(this).attr('data-valid'))) {
            return true;
        }
        e.preventDefault();
        return false;
    });

    $("input[type=search]").keypress(function (e) {
        if (permite(e, $(this).attr('data-valid'))) {
            return true;
        }
        e.preventDefault();
        return false;
    });
    $("textarea").keypress(function (e) {
        if (permite(e, $(this).attr('data-valid'))) {
            return true;
        }
        e.preventDefault();
        return false;
    });

    bootbox.setDefaults({
        locale: "es"
    });
});
$(document).on('show.bs.modal', '.modal', function (event) {
    var zIndex = 1040 + (10 * $('.modal:visible').length);
    $(this).css('z-index', zIndex);
    setTimeout(function () {
        $('.modal-backdrop').not('.modal-stack').css('z-index', zIndex - 1).addClass('modal-stack');
    }, 0);
});
$(document).ajaxError(function (event, request, settings) {

    var notification = $("#notification").kendoNotification({
        position: {
            pinned: true,
            top: 30,
            right: 30
        },
        autoHideAfter: 0,
        stacking: "down",
        templates: [{
            type: "info",
            template: $("#emailTemplate").html()
        }, {
            type: "error",
            template: $("#errorTemplate").html()
        }, {
            type: "upload-success",
            template: $("#successTemplate").html()
        }]

    }).data("kendoNotification");

    notification.show({
        title: "Error de Conexion",
        message: "Su maquina perdio la conexion con el servidor actualize la pagina"
    }, "error");
});
function modalAjaxReporte(url, Data) {
    seccionModal = ".seccionModalReporte";
    seccionContenedor = ".contenedorReporte";

    $.ajax({
        url: url,
        data: Data,
        beforeSend: function () {
            bloquoteObject();
            bloquoteModal();
        },
        success: function (data) {
            $(seccionModal).html(data);
            $(seccionContenedor).modal('show');
            desbloqObject();
            desbloqModal();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            console.log(xhr.responseText);
            console.log(thrownError);
            desbloqObject();
            desbloqModal();
        }
    });
}
function modalAjaxRequestGet(url, divModal, divContenedor, Data) {
    var seccionModal = ".seccionModal";
    var seccionContenedor = ".contenedor";

    seccionModal = ($.trim(divModal).length > 0) ? "#" + divModal : seccionModal;

    seccionContenedor = ($.trim(divContenedor).length > 0) ? "#" + divContenedor : seccionContenedor;

    url = (Data) ? (($.trim(Data).length > 0) ? url + "?" + $.trim(Data) : "") : url;

    $.ajax({
        url: url,
        beforeSend: function () {
            bloquoteObject();
            bloquoteModal();
        },
        success: function (data) {
            $(seccionModal).html(data);
            $(seccionContenedor).modal('show');
            desbloqObject();
            desbloqModal();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            console.log(xhr.responseText);
            console.log(thrownError);
        }
    });
}
function modalAjaxRequestGet2(url, divModal, divContenedor, Data) {
    var seccionModal = ".seccionModal2";
    var seccionContenedor = ".contenedor2";

    seccionModal = ($.trim(divModal).length > 0) ? "#" + divModal : seccionModal;

    seccionContenedor = ($.trim(divContenedor).length > 0) ? "#" + divContenedor : seccionContenedor;

    url = (Data) ? (($.trim(Data).length > 0) ? url + "?" + $.trim(Data) : "") : url;

    $.ajax({
        url: url,
        beforeSend: function () {
            bloquoteObject();
            bloquoteModal();
        },
        success: function (data) {
            $(seccionModal).html(data);
            $(seccionContenedor).modal('show');
            desbloqObject();
            desbloqModal();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status);
            console.log(xhr.responseText);
            console.log(thrownError);
        }
    });
}
function modalAjaxRequestGet3(url, divModal, divContenedor, Data) {
    var seccionModal = ".seccionModal3";
    var seccionContenedor = ".contenedor3";

    seccionModal = ($.trim(divModal).length > 0) ? "#" + divModal : seccionModal;

    seccionContenedor = ($.trim(divContenedor).length > 0) ? "#" + divContenedor : seccionContenedor;

    url = (Data) ? (($.trim(Data).length > 0) ? url + "?" + $.trim(Data) : "") : url;

    $.ajax({
        url: url,
        beforeSend: function () {
            bloquoteObject();
            bloquoteModal();
        },
        success: function (data) {
            desbloqObject();
            desbloqModal();
            $(seccionModal).html(data);
            $(seccionContenedor).modal('show');
        }
    });
}
function prepareReport(divID, nomReporte, detParam) {
    $.ajax({
        url: '/Reportes/postReportParam',
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ detParam: detParam }),
        beforeSend: function () {
            bloquoteObject('');
        },
        success: function (response) {
            var DataObject = response.Object;
            if (DataObject.flag) {
                ViewReport(divID, nomReporte);
            }
            else {
                $("#" + divID).html('');
                $("#" + divID).html('<strong><h3>' + DataObject.message + '</h3></strong>');
            }
            desbloqObject('');
        }
    }).fail(function (jqxhr, textStatus, error) {
        var err = textStatus + ', ' + error;
        desbloqObject('');
        console.log("Request Failed: " + err);
        $("#" + divID).html('');
        $("#" + divID).html('<strong><h3>Request Failed: ' + err + '</h3></strong>');
    });
}
function modalClose(divModal) {
    var seccionModal = "#contenedor";
    seccionModal = ($.trim(divModal).length > 0) ? "#" + divModal : seccionModal;
    $(seccionModal).modal('hide');
}
function modalClose2(divModal) {
    var seccionModal = "#contenedor2";
    seccionModal = ($.trim(divModal).length > 0) ? "#" + divModal : seccionModal;
    $(seccionModal).modal('hide');
}
function actionRequestGet(url, Data) {
    url = (Data) ? ($.trim(Data).length > 0) ? url + "?" + $.trim(Data) : "" : url;
    window.location = url;
}
function activaTab(id, tab) {
    $('#' + id + ' a[href="#' + tab + '"]').tab('show');
}
function errorAddModelo(divError, listaError, errorData) {
    $("#" + divError).removeAttr("style");
    $("#" + listaError).empty();
    $.each(errorData, function (key, value) {
        if (value != null) {
            if (key == "*") {
                $("#" + listaError).append("<li>" + value + "</li>");
            }
            else {
                $("#" + key).removeClass("valError").addClass("valError");
                $("#" + listaError).append("<li>" + value[value.length - 1].ErrorMessage + "</li>");
            }
        }
    });
}

function errorAddJS(divError, listaError, errorData) {
    $("#" + divError).removeAttr("style");
    $("#" + listaError).empty();
    $.each(errorData, function (key, value) {
        $.each(value, function (key, value) {
            if (value != null) {
                if (key == "*") {
                    $("#" + listaError).append("<li>" + value + "</li>");
                }
                else {
                    $("#" + key).removeClass("valError").addClass("valError");
                    $("#" + listaError).append("<li>" + value[value.length - 1].ErrorMessage + "</li>");
                }
            }
        });
    });
}
function errorObject(key) {
    $("#" + key).removeClass("valError").addClass("valError");
}
function addAlert(message) {
    var popupNotification = $("#popupNotification").kendoNotification({
        position: {
            pinned: true,
            top: 30,
            right: 30
        },
        autoHideAfter: 2000,
        stacking: "down",
        templates: [{
            type: "error",
            template: "<div class='wrong-pass'><img src='../Content/images/error-icon.png' /><h3>#: titulo #</h3><p> #: mensage # </p></div>"
        }, {
            type: "upload-success",
            template: "<div class='wrong-pass'><img src='../Content/images/success-icon.png' /><h3>#: titulo #</h3><p> #: mensage # </p></div>"
        }]
    });
    popupNotification.data("kendoNotification").show({ titulo: "error", mensage: message }, "error");
}
function addMessage(message) {
    var popupNotification = $("#popupNotification").kendoNotification({
        position: {
            pinned: true,
            top: 30,
            right: 30
        },
        autoHideAfter: 2000,
        stacking: "down",
        templates: [{
            type: "error",
            template: "<div class='wrong-pass'><img src='../Content/images/error-icon.png' /><h3>#: titulo #</h3><p> #: mensage # </p></div>"
        }, {
            type: "upload-success",
            template: "<div class='wrong-pass'><img src='../Content/images/success-icon.png' /><h3>#: titulo #</h3><p> #: mensage # </p></div>"
        }]
    });
    popupNotification.data("kendoNotification").show({ titulo: "error", mensage: message }, "upload-success");
}
function disableDiv(id) {
    $("#" + id).find('input, button, textarea, select, table,tr ,td, th, a').prop("disabled", true);
}
function enabledDiv(id) {
    $("#" + id).find('input, button, textarea, select, table,tr ,td, th, a').prop("disabled", false);
}
function bloquoteObject() {
    $.blockUI({ message: '<img src="/Content/images/loading.gif">', css: { border: 'none', background: 'transparent' } });
}
function desbloqObject() {
    $.unblockUI();
}
function bloquoteModal() {
    $(".modal-content").block({ message: null });
}
function desbloqModal() {
    $(".modal-content").unblock();
}
function desbloqObjectReport() {
    $.unblockUI();
}
function modalResult(tittle, message) {
    bootbox.dialog({
        message: '<strong>' + message + '<strong/>',
        title: tittle,
        buttons: {
            success: {
                label: "Aceptar",
                className: "btn-success",
            }
        }
    });
}

function myTrim(x) {
    return String(x).replace(/^\s+|\s+$/gm, '');
}
function padCero(str, max) {
    str = str.toString();
    return str.length < max ? padCero("0" + str, max) : str;
}
function ViewReport(divID, nomReporte) {
    bloquoteObject('');
    $("#" + divID).html('');
    $("#" + divID).html('<iframe src="/Content/Reporte/rptInterface.aspx?NOMREPORT=' + nomReporte + '" style="width:100%; height : 450px;border:thin;" onload="desbloqObjectReport();"></iframe>');
}
function prepareReport(divID, nomReporte, detParam) {
    $.ajax({
        url: '/Reportes/postReportParam',
        type: "POST",
        contentType: "application/json",
        data: JSON.stringify({ detParam: detParam }),
        beforeSend: function () {
            bloquoteObject('');
        },
        success: function (response) {
            var DataObject = response.Object;
            if (DataObject.flag) {
                ViewReport(divID, nomReporte);
            }
            else {
                $("#" + divID).html('');
                $("#" + divID).html('<strong><h3>' + DataObject.message + '</h3></strong>');
            }
            desbloqObject('');
        }
    }).fail(function (jqxhr, textStatus, error) {
        var err = textStatus + ', ' + error;
        desbloqObject('');
        $("#" + divID).html('');
        $("#" + divID).html('<strong><h3>Request Failed: ' + err + '</h3></strong>');
    });
}

function isDate(string) { //string estará en formato dd/mm/yyyy (dí­as < 32 y meses < 13)
    var ExpReg = /^([0][1-9]|[12][0-9]|3[01])(\/|-)([0][1-9]|[1][0-2])\2(\d{4})$/
    return (ExpReg.test(string));
}

function validate_fechaMayorQue(fechaInicial, fechaFinal) {
    var valuesStart = fechaInicial.split("/");
    var valuesEnd = fechaFinal.split("/");

    // Verificamos que la fecha no sea posterior a la actual
    var dateStart = new Date(valuesStart[2], (valuesStart[1] - 1), valuesStart[0]);
    var dateEnd = new Date(valuesEnd[2], (valuesEnd[1] - 1), valuesEnd[0]);
    if (dateStart >= dateEnd) {
        return 0;
    }
    return 1;
}
function dateFormat(objDate) {
    if (objDate == "" || objDate == null) {
        return "";
    }
    else {
        return new Date(objDate.replace('/', '-').replace('/', '-').replace(/(\d{2})-(\d{2})-(\d{4})/, "$2/$1/$3"))
    }
}
function KendoMultiselectValueStr(valor) {
    var str = "";
    $.each(valor, function (index, value) {
        str = str + "," + value;
    });
    return str;
}
$.fn.toggleDisable = function () {
    return this.each(function () {
        if (typeof this.disabled != "undefined") {
            if (this.disabled) {
                //this.disabled = false;
            } else {
                this.disabled = true;
            }
        }
    });
}
$.fn.toggleEnable = function () {
    return this.each(function () {
        if (typeof this.disabled != "undefined") {
            if (this.disabled) {
                this.disabled = false;
            } else {
                //this.disabled = true;
            }
        }
    });
}
$.fn.toggleOnReadonly = function () {
    return this.each(function () {
        if (typeof this.readonly != "undefined") {
            if (this.readonly) {
                //this.disabled = false;
            } else {
                this.readonly = true;
            }
        }
    });
}
$.fn.toggleOffReadonly = function () {
    return this.each(function () {
        if (typeof this.readonly != "undefined") {
            if (this.readonly) {
                this.readonly = false;
            } else {
                //this.disabled = true;
            }
        }
    });
}



function validaTeclas(e, tip) {

    var tecla = document.all ? tecla = e.keyCode : tecla = e.which;

    var soloLetras = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ ";
    var soloAlphan = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ 0123456789";
    var soloNumero = "0123456789";
    var soloDecima = "0123456789.";
    var sinCeros = "123456789";
    var soloNumerocoma = "0123456789,-";
    var soloTelefonos = "#*0123456789";

    switch (tip) {
        case 'text':
            return (soloLetras.indexOf(String.fromCharCode(tecla)) > -1);
            break;
        case 'alpha':
            return (soloAlphan.indexOf(String.fromCharCode(tecla)) > -1);
            break;
        case 'number':
            return (soloNumero.indexOf(String.fromCharCode(tecla)) > -1);
            break;
        case 'numeric':
            return (soloDecima.indexOf(String.fromCharCode(tecla)) > -1);
            break;
        case 'sinceros':
            return (sinCeros.indexOf(String.fromCharCode(tecla)) > -1);
            break;
        case 'numcoma':
            return (soloNumerocoma.indexOf(String.fromCharCode(tecla)) > -1);
            break;
        case 'telefono':
            return (soloTelefonos.indexOf(String.fromCharCode(tecla)) > -1);
            break;
    }
}

function soloLetras(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " áéíóúabcdefghijklmnñopqrstuvwxyzÁÉÍÓÚABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
    especiales = "8-37-39-46";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function campoTelefono(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = "*#0123456789";
    especiales = "8-37-39-46";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}

function campoNumero(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = "0123456789";
    especiales = "8-37-39-46";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}


function campoFecha(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = "/0123456789";
    especiales = "8-37-39-46";

    tecla_especial = false
    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}