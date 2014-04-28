/// <reference path="../Libs/jquery.tinysort.js" />
/// <reference path="../Libs/jquery-2.0.3.js" />
var retorno = "";
function VisualizarItinerarioRota(ItinerarioRotaID) {
    $.ajax({
        type: 'GET',
        url: 'Itinerario/ConsultaItinerario',
        contentType: 'application/json; charset=utf-8',
        data: { ItinerarioID: ItinerarioRotaID },
        contentType: 'application/json',
        error: function (data) {
            console.log(data);
            alert(data);
        },
        success: function (data) {
            retorno = "";
            $.each(data, function (index, value) {
                retorno +=
                '<tr>'
                + '<td>' + value.HoraSaida + '</td>'
                + '<td>' + value.HoraChegada + '</td>'
                + '<td><input type="checkbox" ' + (value.Segunda == 'x' ? "checked=checked" : "") + '/></td>'
                + '<td><input type="checkbox" ' + (value.Terca == 'x' ? "checked=checked" : "") + '/></td>'
                + '<td><input type="checkbox" ' + (value.Quarta == 'x' ? "checked=checked" : "") + '/></td>'
                + '<td><input type="checkbox" ' + (value.Quinta == 'x' ? "checked=checked" : "") + '/></td>'
                + '<td><input type="checkbox" ' + (value.Sexta == 'x' ? "checked=checked" : "") + '/></td>'
                + '<td><input type="checkbox" ' + (value.Sabado == 'x' ? "checked=checked" : "") + '/></td>'
                + '<td><input type="checkbox" ' + (value.Domingo == 'x' ? "checked=checked" : "") + '/></td>'
                + '<td><input type="checkbox" ' + (value.Segunda == 'x' ? "checked=checked" : "") + '/></td>'
                + '</tr>';
            });
            console.log(retorno);
            $('<div></div>').html(
                '<table class="table table-bordered table-striped responsive-utilities table table-responsive">'
                + '<tr style="font-size:10px">'
                + '<th>Hora Saída</th>'
                + '<th>Hora Chegada</th>'
                + '<th>Segunda-Feira</th>'
                + '<th>Segunda-Feira</th>'
                + '<th>Terça-Feira</th>'
                + '<th>Quarta-Feira</th>'
                + '<th>Quinta-Feira</th>'
                + '<th>Sexta-Feira</th>'
                + '<th>Sabado</th>'
                + '<th>Domingo</th>'
                + '</tr>'
                + retorno
                + '</table>'
                ).dialog({
                    closeOnEscape: false,
                    title: 'FINDBUS',
                    modal: true,
                    draggable: true,
                    show: 'drop',
                    hide: 'fade',
                    width: 800,
                    height: 400,
                    buttons: {
                        Ok: function () {
                            $(this).dialog("close");
                        }
                    }
                });
        }
    });
}
