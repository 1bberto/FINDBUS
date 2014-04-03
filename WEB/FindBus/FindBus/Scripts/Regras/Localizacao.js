/// <reference path="../Libs/jquery-2.0.3.js" />
$(function () {
    $body = $("body");
    $(document).on({
        ajaxStart: function () { $body.addClass("loading"); },
        ajaxStop: function () { $body.removeClass("loading"); }
    })
    iniciarMapa();
    $("#btnSalvarRota").click(function () {
        InserirPontos();
    });
});
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
function InserirPontos() {
    var pontos = [];
    for (var i = 0 ; i < markers.length; i++) {
        console.log(markers[i].getIcon());
        var Ponto = {
            Latitude: markers[i].getPosition().lat(),
            Longitude: markers[i].getPosition().lng(),
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
            $("#Latitude").val(pos.lat());
            $("#Longitude").val(pos.lng());
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
        $("#Latitude").val(posicaomarker.lat());
        Long: $("#Longitude").val(posicaomarker.lng());
        $.ajax({
            type: 'POST',
            url: 'Localizacao/VerificaLocalizacao',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ Lat: posicaomarker.lat(), Long: posicaomarker.lng() }),
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
//function verificaTotalKmPontos() {
//    var R = 6371; // Radius of the earth in km
//    var dLat = null;// deg2rad(lat2 - lat1);  // deg2rad below
//    var dLon = null;// deg2rad(lon2 - lon1);
//    var a = null;
//    var c = null;
//    var d = 0;
//    var marker1 = null;
//    var marker2 = null;
//    for (var i = 0; i < markers.length - 1; i++) {
//        console.log(markers[i].getIcon());
//        marker1 = markers[i].getPosition();
//        marker2 = markers[i + 1].getPosition();
//        console.log("markers");
//        console.log(marker1);
//        console.log(marker2);
//        dLat = deg2rad(marker2['d'] - marker1['d']);
//        dLon = deg2rad(marker2['e'] - marker1['e']);
//        a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
//            Math.cos(deg2rad(marker1['d'])) * Math.cos(deg2rad(marker2['d'])) *
//            Math.sin(dLon / 2) * Math.sin(dLon / 2);
//        c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
//        d = d + (R * c); // Distance in km        
//    }
//    return d;
//}
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
        data: JSON.stringify({ Lat: position.lat(), Long: position.lng() }),
        contentType: 'application/json'
    }).done(function (data) {
        console.log(data);
        return data;
    });
}
function RemoveMarker(index) {
    if (markers[index] != null)
        markers[index].setMap(null);
    $("#ListPosicoes").remove("#divmarker" + index);
}
function RemoverMarkerLista(index) {
    $("#divmarker" + index).remove();
}
function atualizaPosicoesMarkersLista() {
    $('#ListPosicoes').find('div').remove();
    for (var i = 0; i < markers.length; i++) {
        if (i == 0)
            ProcuraLocalizacao(markers[i], i, null)
        else
            ProcuraLocalizacao(markers[i], i, markers[i - 1]);
    }
    if (markers.length <= 10)
        montaRota(0, markers.length - 1);
    else
    {
        montaRota(markers.length - 10, markers.length - 1);
    }
    $("#ListPosicoes").each(function () {
        var $this = $(this);
        $this.append($this.find(".blocoMarker").get().sort(function (a, b) {
            return $(a).data('index') - $(b).data('index');
        }));
    });
    $("#ListPosicoes").append("<div id=totalKmRota class=Marker> Distancia Total : " + verificaTotalKmPontos().toFixed(2) + " Metros </div>");
    $.ajax({ async: true });
}
function ProcuraLocalizacao(mark, i, mark2) {
    var marker = mark.getPosition();
    jQuery.ajax({
        url: window.location.origin + '/Localizacao/VerificaLocalizacao',
        data: { Lat: marker.lat(), Long: marker.lng() },
        sucess: function (data) {
            console.log("deu sucess");
            if (i == 0) {
                $('#ListPosicoes').append("<div id=divmarker" + i + " class=blocoMarker data-sort=" + (i + 1) + "><div onclick=FocoMarker(" + i + ") class=Marker>Bairro: " + data.Bairro +
                  "<br/>Rua: " + data.Rua +
                  "</div> <div class=MarkerRemover style='float:right' onclick=RemoveMarkerListaMapa(" + i + ")><b>X</b></div></div>");
            }
            else {
                $("<div id=divmarker" + i + "  class=blocoMarker  data-sort=" + (i + 1) + " ><div onclick=FocoMarker(" + i + ") class=Marker>Bairro: " + data.Bairro +
                "<br/>Rua: " + data.Rua + "<br/>Distancia do ponto Anterior - " + google.maps.geometry.spherical.computeDistanceBetween(mark.getPosition(), mark2.getPosition()).toFixed(2) + " Metros</div> " +
                "<div class=MarkerRemover style='float:right' onclick=RemoveMarkerListaMapa(" + i + ")><b>X</b></div></div></div>").insertAfter("#divmarker" + (i - 1));
            }
        }
    });
}
function RemoveMarkerListaMapa(ind) {
    RemoveMarker(ind);
    markers = $.grep(markers, function (val, index) {
        return index != ind;
    });
    console.log(markers.length);
    atualizaPosicoesMarkersLista();
}
//function montaRota(ini, end) {
//    geocoder = new google.maps.Geocoder();
//    if (markers.length > 1) {
//        var start = markers[ini].getPosition();
//        var end = markers[end].getPosition();
//        if (markers.length > 2) {
//            var pontos = [];
//            for (var i = ini; i <= end; i++) {
//                if (markers[i] != null) {
//                    pontos.push({
//                        location: markers[i].getPosition(),
//                        stopover: false
//                    });
//                }
//            }
//            for (var a = 0; a < pontos.length; a++)
//                var request = {
//                    origin: start,
//                    destination: end,
//                    waypoints: pontos,
//                    optimizeWaypoints: false,
//                    travelMode: google.maps.TravelMode.DRIVING
//                };
//        }
//        else {
//            var request = {
//                origin: start,
//                destination: end,
//                optimizeWaypoints: false,
//                travelMode: google.maps.TravelMode.DRIVING
//            };
//        }
//        directionsDisplay.setMap(map);
//        directionsService.route(request, function (response, status) {
//            if (status == google.maps.DirectionsStatus.OK) {
//                directionsDisplay.setDirections(response);
//                map.setZoom(15);
//            }
//        });
//    }
//    else {
//        directionsDisplay.setMap(null);
//    }
//}
function montaRota(ini, fin) {
    console.log(ini + " " + fin);
    geocoder = new google.maps.Geocoder();
    if (markers.length > 1) {
        console.log("Marker.length " + markers.length);
        var start = markers[ini].getPosition();
        console.log("start :" + start);
        var end = markers[fin].getPosition();
        if (fin - ini > 1) {
            console.log("Marker.length " + markers.length);
            var pontos = [];
            for (var i = ini + 1; i <= fin - 1; i++) {
                pontos.push({
                    location: markers[i].getPosition(),
                    stopover: false
                });
                console.log("Pontos passagem: " + pontos);
            }
            //for (var a = 0; a < pontos.length; a++)
            var request = {
                origin: start,
                destination: end,
                waypoints: pontos,
                optimizeWaypoints: false,
                travelMode: google.maps.TravelMode.DRIVING
            };
            console.log(request);
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