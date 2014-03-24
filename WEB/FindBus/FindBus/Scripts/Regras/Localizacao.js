/// <reference path="../Libs/jquery-2.0.3.js" />
var infowindow = null;
var contentString = null;
var marker = null;
var map = null;
var markers = [];
var image = '../Content/images/bus (1).png';
var imageponto = image;
var imagempassagem = 'http://labs.google.com/ridefinder/images/mm_20_green.png';
var directionsService = new google.maps.DirectionsService();
var directionsDisplay;
var geocoder;
var urlpost = null;
var posicoesLista = "";
var spinnerVisible = false;
$(function () {
    iniciarMapa();
    $("#btnSalvarRota").click(function () {
        InserirPontos();
    });
});
function InserirPontos() {
    var pontos = [];
    for (var i = 0 ; i < markers.length; i++) {
        console.log(markers[i].getIcon());
        var Ponto = {
            Latitude: markers[i].getPosition().d,
            Longitude: markers[i].getPosition().e,
            PontoParada: markers[i].getIcon() == '../Content/images/bus (1).png'
        }
        pontos.push(Ponto);
    }
    $.ajax({
        type: 'POST',
        url: 'Localizacao/InserirRota',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(pontos),
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
                show: 'fade',
                hide: 'fade',
                buttons: {
                    Ok: function () {
                        $(this).dialog("close");
                    }
                }
            })
        }
    });
}
function VeriricaLocalizacao(url) {
    urlpost = url;
    $.ajax({
        type: 'POST',
        url: urlpost,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ Lat: $("#Latitude").val(), Long: $("#Longitude").val() }),
        contentType: 'application/json',
        error: function (data) {
            alert(data);
        },
        success: function (data) {
            $("#Estado").val(data['Estado']);
            $("#Cidade").val(data['Cidade']);
            $("#Bairro").val(data['Bairro']);
            $("#Rua").val(data['Rua']);
            $('<div></div>').html('<p>Consulta Realizada com Sucesso!</p>')
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
                    }
                }
            })
        }
    });
}
function iniciarMapa() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = new google.maps.LatLng(position.coords.latitude,
                                             position.coords.longitude);
            directionsDisplay = new google.maps.DirectionsRenderer();
            $("#Latitude").val(pos['d']);
            $("#Longitude").val(pos['e']);
            var mapOptions = {
                center: pos,
                zoom: 15,
                position: pos,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById("map"), mapOptions);
            directionsDisplay.setMap(map);
            var directionRendererOptions = {
                suppressMarkers: true,
                polylineOptions: {
                    strokeColor: "#33CC00",
                    strokeOpacity: 10,
                    strokeWeight: 8
                }
            };
            directionsDisplay.setOptions(directionRendererOptions);
            google.maps.event.addListener(map, 'click', function (posicaoclick) {
                placeMarker(posicaoclick.latLng);
            });
        });
    }

}
function placeMarker(location) {
    marker = new google.maps.Marker({
        position: location,
        map: map,
        icon: image
    });
    markers.push(marker);
    addInfoMarker(marker);
    atualizaPosicoesMarkersLista();
}
function addInfoMarker(marker) {
    var message = null;
    var posicaomarker = marker.getPosition();
    google.maps.event.addListener(marker, 'click', function () {
        $.ajax({
            type: 'POST',
            url: 'Localizacao/VerificaLocalizacao',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ Lat: posicaomarker['d'], Long: posicaomarker['e'] }),
            contentType: 'application/json',
            error: function (data) {
                alert(data);
            },
            success: function (data) {
                message = '<div> <b>Ponto ' + markers.indexOf(marker) + 1 + '</b><br/>';
                message += data['Estado'] + data['Cidade'] + data['Bairro'] + data['Rua'] + '</div>';
                console.log(message);
                var infowindow = new google.maps.InfoWindow(
                {
                    content: message
                });
                infowindow.open(map, marker);
            }
        });

    });
}
function verificaKmPontos(lat1, lon1, lat2, lon2) {
    var R = 6371; // Radius of the earth in km
    var dLat = deg2rad(lat2 - lat1);  // deg2rad below
    var dLon = deg2rad(lon2 - lon1);
    var a =
      Math.sin(dLat / 2) * Math.sin(dLat / 2) +
      Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
      Math.sin(dLon / 2) * Math.sin(dLon / 2)
    ;
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var d = R * c; // Distance in km
    return d;
}
function verificaTotalKmPontos() {
    var d = 0;
    for (var i = 0; i < markers.length - 1; i++) {
        d = d + google.maps.geometry.spherical.computeDistanceBetween(markers[i].getPosition(), markers[i + 1].getPosition());
    }
    return d;
}
function deg2rad(deg) {
    return deg * (Math.PI / 180);
}
function FocoMarker(index) {
    var marker = markers[index];
    var position = marker.getPosition();
    map.setCenter(position);
    $("#Latitude").val(position['d']);
    $("#Longitude").val(position['e']);
    VerificaGeolocalizacaoPonto('Localizacao/VerificaLocalizacao');
}
function VerificaGeolocalizacaoPonto(url) {
    $.ajax({
        type: 'POST',
        url: url,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ Lat: $("#Latitude").val(), Long: $("#Longitude").val() }),
        contentType: 'application/json',
        error: function (data) {
            alert(data);
        },
        success: function (data) {
            $("#Estado").val(data['Estado']);
            $("#Cidade").val(data['Cidade']);
            $("#Bairro").val(data['Bairro']);
            $("#Rua").val(data['Rua']);
        }
    });
}
function VerificaGeolocalizacaoReversaPonto(url, marker) {
    var mar = marker;
    var position = mar.getPosition();
    $.ajax({
        type: "POST",
        async: false,
        url: url,
        data: JSON.stringify({ Lat: position['d'], Long: position['e'] }),
        contentType: 'application/json'
    }).done(function (data) {
        console.log(data);
        return data;
    });
}
function RemoveMarker(index) {
    markers[index].setMap(null);
    $("#ListPosicoes").remove("#divmarker" + index);
}
function RemoverMarkerLista(index) {
    $("#divmarker" + index).remove();
}
function atualizaPosicoesMarkersLista() {
    $('#ListPosicoes').find('div').remove();
    $.ajax({ async: false });
    for (var i = 0; i < markers.length; i++) {
        if (i == 0)
            ProcuraLocalizacao(markers[i], i, null)
        else
            ProcuraLocalizacao(markers[i], i, markers[i - 1]);
    }
    montaRota();
    $("#ListPosicoes").append("<div id=totalKmRota class=Marker> Distancia Total : " + verificaTotalKmPontos().toFixed(2) + " Metros </div>");
    $.ajax({ async: true });
}
function ProcuraLocalizacao(mark, i, mark2) {
    var marker = mark.getPosition();
    $.post(window.location.origin + '/Localizacao/VerificaLocalizacao', { Lat: marker.d, Long: marker.e }, (function (data) {
        if (i == 0) {
            $('#ListPosicoes').append("<div id=divmarker" + i + " class=blocoMarker><div onclick=FocoMarker(" + i + ") class=Marker>Bairro: " + data.Bairro +
              "<br/>Rua: " + data.Rua +
              "</div> <div class=MarkerRemover style='float:right' onclick=RemoveMarkerListaMapa(" + i + ")><b>X</b></div></div>");
        }
        else {
            $('#ListPosicoes').append("<div id=divmarker" + i + "  class=blocoMarker><div onclick=FocoMarker(" + i + ") class=Marker>Bairro: " + data.Bairro +
            "<br/>Rua: " + data.Rua + "<br/>Distancia do ponto Anterior - " + google.maps.geometry.spherical.computeDistanceBetween(mark.getPosition(), mark2.getPosition()).toFixed(2) + " Metros</div> " +
            "<div class=MarkerRemover style='float:right' onclick=RemoveMarkerListaMapa(" + i + ")><b>X</b></div></div></div>");
        }
    }));
}
function RemoveMarkerListaMapa(ind) {
    RemoveMarker(ind);
    markers = $.grep(markers, function (val, index) {
        return index != ind;
    });
    console.log(markers.length);
    atualizaPosicoesMarkersLista();
}
function montaRota() {
    geocoder = new google.maps.Geocoder();
    if (markers.length > 1) {
        var start = markers[0].getPosition();
        var end = markers[markers.length - 1].getPosition();
        if (markers.length > 2) {
            var pontos = [];
            for (var i = 1; i < markers.length - 1; i++) {
                pontos.push({
                    location: markers[i].getPosition(),
                    stopover: false
                });
            }
            for (var a = 0; a < pontos.length; a++)
                var request = {
                    origin: start,
                    destination: end,
                    waypoints: pontos,
                    optimizeWaypoints: false,
                    travelMode: google.maps.TravelMode.DRIVING
                };
        }
        else {
            var request = {
                origin: start,
                destination: end,
                optimizeWaypoints: false,
                travelMode: google.maps.TravelMode.DRIVING
            };
        }
        directionsDisplay.setMap(map);
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
                map.setZoom(15);
            }
        });
    }
    else {
        directionsDisplay.setMap(null);
    }

}
function DefineTipoImagemPonto() {
    image = imageponto;
}
function DefineTipoImagemPassagem() {
    image = imagempassagem;
}