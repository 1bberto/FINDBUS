﻿/// <reference path="../Libs/jquery.tinysort.js" />
/// <reference path="../Libs/jquery-2.0.3.js" />
var retorno = "";
var RotaItinerarioID = null;
var RotaDescricao = null;
function VisualizarItinerarioRota(ItinerarioRotaID, rotaDescricao) {
    console.log(ItinerarioRotaID);
    console.log(rotaDescricao);
    RotaItinerarioID = ItinerarioRotaID;
    RotaDescricao = rotaDescricao;
    $('#dialog').removeData();
    $('#dialog')
    .dialog({
        width: 1200,
        resizable: true,
        draggable: true,
        title: "FindBus",
        model: true,
        show: 'fade',
        hide: 'fade',
        closeText: 'Fechar',
        closeOnEscape: true,
        cache: false,
        url: "../Itinerario/RetornaItinerarioRota?RotaId=" + RotaItinerarioID,
        buttons: {
            Fechar: function () {
                $(this).dialog("close");
            }
        }
    });
}
function HabilitarEdicao(index) {
    $("#HoraSaida" + index).prop('disabled', true);
    $("#HoraChegada" + index).prop('disabled', true);
    $("#Segunda" + index).prop('disabled', false);
    $("#Terca" + index).prop('disabled', false);
    $("#Quarta" + index).prop('disabled', false);
    $("#Quinta" + index).prop('disabled', false);
    $("#Sexta" + index).prop('disabled', false);
    $("#Sabado" + index).prop('disabled', false);
    $("#Domingo" + index).prop('disabled', false);
    $("#btnEditar" + index).remove();
    $("#grupo" + index).prepend("<a onclick='SalvarItinerario(" + index + ")' class='btn btn-success btn-large' id='btnSalvar" + index + "' style='visibility:visible'>Salvar</a>");
    $("#HoraSaida" + index).focus();
}
function adicionarItinerario(index) {
    if (index > 1) {
        $("#tableItinerario > tbody:last").after(
            "<tr id='ListaItinerario" + index + "'>"
                + "<input id=Descricao name='Descricao' type='hidden' value='" + RotaDescricao + "'>"
                + "<td style='width: 10% !important; vertical-align: middle; font-size: 12px'>" + RotaDescricao + "</td>"
                + "<td style='width: 10% !important; vertical-align: middle; font-size: 12px'><input style='text-align: center !important' class='form-control' id='HoraSaida" + index + "' maxlength='5' name='item.HoraSaida' placeholder='Hora Saida' textalign='center' type='text' value='' onblur='ValidaHorario(this)'></td>"
                + "<td style='width: 8% !important; vertical-align: middle; font-size: 12px'><input style='text-align: center !important' class='form-control' id='HoraChegada" + index + "' maxlength='5' name='item.HoraChegada' placeholder='Hora Chagada' textalign='center' type='text' value='' onblur='ValidaHorario(this)'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Segunda" + index + "' name='Segunda' type='checkbox' value='true'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Terca" + index + "' name='Terca' type='checkbox' value='true'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Quarta" + index + "' name='Quarta' type='checkbox' value='true'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Quinta" + index + "' name='Quinta' type='checkbox' value='true'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Sexta" + index + "' name='Sexta' type='checkbox' value='true'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Sabado" + index + "' name='Sabado' type='checkbox' value='true'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Domingo" + index + "' name='Domingo' type='checkbox' value='true'></td>"
                + "<td style='width: 20% !important; text-align: center; font-size: 12px'>"
                    + "<div class='btn-group' id='grupo" + index + "'>"
                        + "<a onclick='SalvarItinerario(" + index + ")' class='btn btn-success btn-large' id='btnSalvar" + index + "' style='visibility:visible'>Salvar</a>"
                        + "<a onclick='ExcluirItinerario(" + index + ")' class='btn btn-danger btn-large'>Excluir</a>"
                    + "</div>"
                + "</td>"
            + "</tr>"
        )
        $("#HoraSaida" + index).focus();
    }
    else {
        $("#tableItinerario tbody:last").after(
            "<tr id='ListaItinerario" + index + "'>"
                + "<input id=Descricao name='Descricao' type='hidden' value='" + RotaDescricao + "'>"
                + "<td style='width: 10% !important; vertical-align: middle; font-size: 12px'>" + RotaDescricao + "</td>"
                + "<td style='width: 10% !important; vertical-align: middle; font-size: 12px'><input style='text-align: center !important' class='form-control' id='HoraSaida" + index + "' maxlength='5' name='item.HoraSaida' placeholder='Hora Saida' textalign='center' type='text' value='' onblur='ValidaHorario(this)'></td>"
                + "<td style='width: 8% !important; vertical-align: middle; font-size: 12px'><input style='text-align: center !important' class='form-control' id='HoraChegada" + index + "' maxlength='5' name='item.HoraChegada' placeholder='Hora Chagada' textalign='center' type='text' value='' onblur='ValidaHorario(this)'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Segunda" + index + "' name='Segunda' type='checkbox' value='true'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Terca" + index + "' name='Terca' type='checkbox' value='true'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Quarta" + index + "' name='Quarta' type='checkbox' value='true'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Quinta" + index + "' name='Quinta' type='checkbox' value='true'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Sexta" + index + "' name='Sexta' type='checkbox' value='true'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Sabado" + index + "' name='Sabado' type='checkbox' value='true'></td>"
                + "<td style='width: 7% !important; vertical-align: middle; font-size: 12px'><input id='Domingo" + index + "' name='Domingo' type='checkbox' value='true'></td>"
                + "<td style='width: 20% !important; text-align: center; font-size: 12px'>"
                    + "<div class='btn-group' id='grupo" + index + "'>"
                        + "<a onclick='SalvarItinerario(" + index + ")' class='btn btn-success btn-large' id='btnSalvar" + index + "' style='visibility:visible'>Salvar</a>"
                        + "<a onclick='ExcluirItinerario(" + index + ")' class='btn btn-danger btn-large'>Excluir</a>"
                    + "</div>"
                + "</td>"
            + "</tr>"
        )
        $("#HoraSaida" + index).focus();
    }
}
function validaData(value) {
    return /^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])?$/i.test(value);
}

function ValidaHorario(item) {
    console.log(item.id);
    var valido = validaData(item.value);
    if (valido == false) {
        $('<div></div>').html('<p>Formato Inválido</p>')
        .dialog({
            closeOnEscape: false,
            title: 'FINDBUS',
            modal: true,
            draggable: true,
            show: 'fade',
            hide: 'fade',
            buttons: {
                Ok: function () {
                    $(this).dialog("close");
                    item.value = "";
                    item.focus();
                }
            }
        });
    }
}
function SalvarItinerario(index) {
    if ($("#HoraSaida" + index).val() == '') {
        MontarDialog("Campo Hora Saída Deve Ser Preenchido", $("#HoraSaida" + index));
    }
    else
        if ($("#HoraChegada" + index).val() == '') {
            MontarDialog("Campo Hora Chegada Deve Ser Preenchido", $("#HoraChegada" + index));
        }
        else {
            var Itinerario =
                {
                    rotaid: RotaItinerarioID,
                    Descricao: RotaDescricao,
                    HoraSaida: $("#HoraSaida" + index).val(),
                    HoraChegada: $("#HoraChegada" + index).val(),
                    Segunda: $("#Segunda" + index).is(':checked'),
                    Terca: $("#Terca" + index).is(':checked'),
                    Quarta: $("#Quarta" + index).is(':checked'),
                    Quinta: $("#Quinta" + index).is(':checked'),
                    Sexta: $("#Sexta" + index).is(':checked'),
                    Sabado: $("#Sabado" + index).is(':checked'),
                    Domingo: $("#Domingo" + index).is(':checked')
                };
            InserirItinerarioRota(Itinerario);
            DesabilitaEdicao(index);
            refresh_dialog();
        }
}
function InserirItinerarioRota(Itinerario) {
    $.ajax({
        type: 'POST',
        url: '../Itinerario/InserirItinerarioRota',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ itinerario: Itinerario }),
        contentType: 'application/json',
        error: function (data) {
            alert(data);
        },
        success: function (data) {
            $('<div></div>').html('<p>' + data + '</p>')
            .dialog({
                closeOnEscape: false,
                title: 'FINDBUS',
                modal: true,
                draggable: true,
                show: 'clip',
                hide: 'clip',
                buttons: {
                    Ok: function () {
                        $(this).dialog("close");

                    }
                }
            })
        }
    });
    refresh_dialog();
}
function DesabilitaEdicao(index) {
    $("#HoraSaida" + index).prop('disabled', true);
    $("#HoraChegada" + index).prop('disabled', true);
    $("#Segunda" + index).prop('disabled', true);
    $("#Terca" + index).prop('disabled', true);
    $("#Quarta" + index).prop('disabled', true);
    $("#Quinta" + index).prop('disabled', true);
    $("#Sexta" + index).prop('disabled', true);
    $("#Sabado" + index).prop('disabled', true);
    $("#Domingo" + index).prop('disabled', true);
    $("#btnSalvar" + index).remove();
    $("#grupo" + index).prepend("<a onclick='HabilitarEdicao(" + index + ")' class='btn btn-info btn-large' id='btnEditar" + index + "' style='visibility:visible'>Editar</a>");
    $("#HoraSaida" + index).focus();
}
function ExcluirItinerario(index) {
    $('<div></div>').html('<p>Deseja Realmente Excluir?</p>')
    .dialog({
        closeOnEscape: false,
        title: 'FINDBUS',
        modal: true,
        draggable: true,
        show: 'clip',
        hide: 'clip',
        buttons: {
            Sim: function () {
                $(this).dialog("close");
                ConfirmaExcluirItinerario(index);
            },
            Não: function () {
                $(this).dialog("close");
            }
        }
    });
}
function ConfirmaExcluirItinerario(index) {
    var Itinerario =
        {
            rotaid: $("#RotaID").val(),
            Descricao: $("#Descricao").val(),
            HoraSaida: $("#HoraSaida" + index).val(),
            HoraChegada: $("#HoraChegada" + index).val(),
            Segunda: $("#Segunda" + index).is(':checked'),
            Terca: $("#Terca" + index).is(':checked'),
            Quarta: $("#Quarta" + index).is(':checked'),
            Quinta: $("#Quinta" + index).is(':checked'),
            Sexta: $("#Sexta" + index).is(':checked'),
            Sabado: $("#Sabado" + index).is(':checked'),
            Domingo: $("#Domingo" + index).is(':checked')
        };
    ExcluirItinerarioRota(Itinerario);
    $("#ListaItinerario" + index).remove();
    refresh_dialog();
}
function ExcluirItinerarioRota(Itinerario) {
    $.ajax({
        type: 'POST',
        url: '../Itinerario/ExcluirItinerarioRota',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ itinerario: Itinerario }),
        contentType: 'application/json',
        error: function (data) {
            alert(data);
        },
        success: function (data) {
            $('<div></div>').html('<p>' + data + '</p>')
            .dialog({
                closeOnEscape: false,
                title: 'FINDBUS',
                modal: true,
                draggable: true,
                show: 'clip',
                hide: 'clip',
                buttons: {
                    Ok: function () {
                        $(this).dialog("close");

                    }
                }
            })
        }
    });
}

var orig_create = $.ui.dialog.prototype._create;
$.ui.dialog.prototype._create = function () {
    orig_create.apply(this, arguments);
    var self = this;
    if (this.options.url != '') {
        self.element.load(self.options.url); // auto load the url selected
    };
};

$.widget("ui.dialog", $.ui.dialog, {
    refresh: function () {
        if (this.options.url != '') {
            this.element.load(this.options.url);
        }
    }
});
function refresh_dialog() {
    // refresh:
    $('#dialog').dialog("refresh");
}
function MontarDialog(mensagem, item) {
    $('<div></div>').html('<p>' + mensagem + '</p>')
    .dialog({
        closeOnEscape: false,
        title: 'FINDBUS',
        modal: true,
        draggable: true,
        show: 'clip',
        hide: 'clip',
        buttons: {
            Ok: function () {
                $(this).dialog("close");
                item.focus();
            }
        }
    });
}