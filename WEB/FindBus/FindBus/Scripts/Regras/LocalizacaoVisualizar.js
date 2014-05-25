/// <reference path="../Libs/jquery-2.0.3.js" />
/// <reference path="../Libs/jquery-ui-1.10.3.js" />
/// <reference path="../Libs/maps.js" />
$(function () {
    $body = $("body");
    $(document).on({
        ajaxStart: function () { $body.addClass("loading"); },
        ajaxStop: function () { $body.removeClass("loading"); }
    })
    iniciarMapa();

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
var Localizacoes = [];
var infowindow = null;
var LocationsData = [];
function iniciarMapa() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = new google.maps.LatLng(position.coords.latitude,
                                             position.coords.longitude);
            directionsDisplay = new google.maps.DirectionsRenderer();
            var mapOptions = {
                center: pos,
                zoom: 15,
                position: pos,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById("map"), mapOptions);
            map.setTilt(45);
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
            CarregaTodosPontosRota(map, $("#RotaID").val())
        });
    }
}
function placeMarker(location) {
    marker = new google.maps.Marker({
        position: location,
        map: map,
        icon: image,
    });
    markers.push(marker);
    atualizaPosicoesMarkersLista();
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
        //d = d + google.maps.geometry.spherical.computeDistanceBetween(markers[i].getPosition(), markers[i + 1].getPosition());
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
}
function VerificaGeolocalizacaoReversaPonto(url, marker) {
    var mar = marker;
    var position = mar.getPosition();
    $.ajax({
        type: "GET",
        async: false,
        url: url,
        data: { Lat: position.lat(), Long: position.lng() },
        contentType: 'application/json'
    }).done(function (data) {
        return data;
    });
}
function atualizaPosicoesMarkersLista() {
    $('#ListPosicoes').find('div').remove();
    Localizacoes = [];
    $.ajax({ async: true });
    for (var i = 0; i < markers.length; i++) {
        if (i == 0)
            ProcuraLocalizacao(markers[i], i);
        else
            ProcuraLocalizacao(markers[i], i);
    }
    montarListaPontos();
    montarPaginacaoPontos();
    if (markers.length <= 10)
        montaRota(0, markers.length - 1);
    else {
        montaRota(markers.length - 10, markers.length - 1);
    }
    $("#ListPosicoes").append("<div id=totalKmRota class=Marker data-sort=0> Distancia Total : " + verificaTotalKmPontos().toFixed(2) + " Metros </div>");
    $.ajax({ async: true });
}
function montarListaPontos() {
    for (var i = 0; i < markers.length; i++) {
        if (i == 0) {
            if (markers[i].getIcon() == '../Content/images/bus (1).png')
                $('#ListPosicoes').append("<div id=divmarker" + i + " class=blocoMarkerPontoParada data-sort=" + (i + 1) + "><div onclick=FocoMarker(" + i + ") class=Marker>" +
                "<i>Cidade</i>: <b>" + Localizacoes[i].Cidade + "</b>" +
                "<br/><i>Bairro</i>: <b>" + Localizacoes[i].Bairro + "</b>" +
                "<br/><i>Rua</i>: <b>" + Localizacoes[i].Rua + "</b>" +
                 "</div></div>");
            else
                $('#ListPosicoes').append("<div id=divmarker" + i + " class=blocoMarkerPontoPassagem data-sort=" + (i + 1) + "><div onclick=FocoMarker(" + i + ") class=Marker>" +
                "<i>Cidade</i>: <b>" + Localizacoes[i].Cidade + "</b>" +
                "<br/><i>Bairro</i>: <b>" + Localizacoes[i].Bairro + "</b>" +
                "<br/><i>Rua</i>: <b>" + Localizacoes[i].Rua + "</b>" +
                "</div></div>");
        }
        else {
            if (markers[i].getIcon() == '../Content/images/bus (1).png')
                $('#ListPosicoes').append("<div id=divmarker" + i + "  class=blocoMarkerPontoParada  data-sort=" + (i + 1) + "><div onclick=FocoMarker(" + i + ") class=Marker>" +
                "<i>Cidade</i>: <b>" + Localizacoes[i].Cidade + "</b>" +
                "<br/><i>Bairro</i>: <b>" + Localizacoes[i].Bairro + "</b>" +
                "<br/><i>Rua</i>: <b>" + Localizacoes[i].Rua + "</b>" +
                "<br/><i>Distancia do ponto Anterior</i>: <b>" + google.maps.geometry.spherical.computeDistanceBetween(markers[i].getPosition(), markers[i - 1].getPosition()).toFixed(2) + " Metros </b></div> " +
                "</div></div>");
            else
                $('#ListPosicoes').append("<div id=divmarker" + i + "  class=blocoMarkerPontoPassagem  data-sort=" + (i + 1) + " ><div onclick=FocoMarker(" + i + ") class=Marker>" +
                "<i>Cidade</i>: <b>" + Localizacoes[i].Cidade + "</b>" +
                "<br/><i>Bairro</i>: <b>" + Localizacoes[i].Bairro + "</b>" +
                "<br/><i>Rua</i>: <b>" + Localizacoes[i].Rua + "</b>" +
                "<br/><i>Distancia do ponto Anterior</i>: <b>" + google.maps.geometry.spherical.computeDistanceBetween(markers[i].getPosition(), markers[i - 1].getPosition()).toFixed(2) + " Metros </b> </div> " +
                "</div></div>");
        }
    }
}
function montarPaginacaoPontos() {
    var pontoInicial = 0;
    var pagina = 0;
    var TotalPontos = 0;
    $("#PaginacaoPontos").find('li').remove();
    while (TotalPontos < markers.length - 1) {
        pontoInicial = (9 * pagina);
        TotalPontos += 9;
        if (TotalPontos < markers.length)
            $("#PaginacaoPontos").append("<li><a href='#' onclick=montaRota(" + pontoInicial + "," + (pontoInicial + 9) + ")>" + (pagina + 1) + "</a></li>");
        else
            $("#PaginacaoPontos").append("<li><a href='#' onclick=montaRota(" + pontoInicial + "," + (markers.length - 1) + ")>" + (pagina + 1) + "</a></li>");
        pagina++;
    }
}
function ProcuraLocalizacao(mark, i) {
    var marker = mark.getPosition();
    $.ajax({
        type: 'GET',
        url: '/Localizacao/VerificaLocalizacao',
        data: { Lat: marker.lat(), Long: marker.lng() },
        cache: true,
        async: false,
        success: function (data) {
            console.log(data);
            if (i == 0) {
                var Localizacao = {
                    Bairro: data.Bairro,
                    Cidade: data.Cidade,
                    Estado: data.Estado,
                    Rua: data.Rua,
                    Latitude: markers[i].getPosition().lat(),
                    Longitude: markers[i].getPosition().lng(),
                    PontoParada: markers[i].getIcon() == '../Content/images/bus (1).png',
                    OrdemPonto: i + 1,
                    DistanciaPontoAnterior: 0
                };
                Localizacoes.push(Localizacao);
            }
            else {
                var Localizacao = {
                    Bairro: data.Bairro,
                    Cidade: data.Cidade,
                    Estado: data.Estado,
                    Rua: data.Rua,
                    Latitude: markers[i].getPosition().lat(),
                    Longitude: markers[i].getPosition().lng(),
                    PontoParada: markers[i].getIcon() == '../Content/images/bus (1).png',
                    OrdemPonto: i + 1,
                    DistanciaPontoAnterior: google.maps.geometry.spherical.computeDistanceBetween(markers[i].getPosition(), markers[i - 1].getPosition()).toFixed(2).replace('.', ',')
                };
                Localizacoes.push(Localizacao);
            }
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
    return;
}
function montaRota(ini, fin) {
    geocoder = new google.maps.Geocoder();
    if (markers.length > 1) {
        var start = markers[ini].getPosition();
        var end = markers[fin].getPosition();
        if (fin - ini > 1) {
            var pontos = [];
            for (var i = ini + 1; i <= fin - 1; i++) {
                pontos.push({
                    location: markers[i].getPosition(),
                    stopover: false
                });
            }
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
function CarregaTodosPontosRota(mapa, rotaID) {
    $.ajax({
        type: 'GET',
        url: '/Localizacao/RetornaPontosRota',
        contentType: 'application/json; charset=utf-8',
        data: { rotaID: rotaID },
        contentType: 'application/json',
        error: function (data) {
            console.log(data);            
        },
        success: function (data) {
            $.each(data, function (index, value) {
                var myLatLng = new google.maps.LatLng(parseFloat(value.Latitude.replace(',', '.')).toFixed(20), parseFloat(value.Longitude.replace(',', '.')).toFixed(20));
                marker = new google.maps.Marker({
                    position: myLatLng,
                    map: mapa,
                    icon: value.PontoParada == true ? image : imagempassagem,
                    title: 'Ponto-' + (index + 1) + '\n' + retornaDadosPonto(myLatLng, value.PontoParada)
                });
                markers.push(marker);
                google.maps.event.addListener(marker, 'click', function () {
                    map.setCenter(this.getPosition());                    
                });
            })
            atualizaPosicoesMarkersLista();
        }
    })
}
function retornaDadosPonto(position, pontoParada) {    
    var mensagemRetorno = null;
    $.ajax({
        type: 'GET',
        url: '/Localizacao/VerificaLocalizacao',
        data: { Lat: position.lat(), Long: position.lng() },
        cache: true,
        async: false,
        success: function (data) {
            mensagemRetorno = "Bairro: " + data.Bairro + "\n";
            mensagemRetorno += "Cidade: " + data.Cidade + "\n";
            mensagemRetorno += "Estado: " + data.Estado + "\n";
            mensagemRetorno += "Rua: " + data.Rua + "\n";
            mensagemRetorno += "Ponto de Parada: " + (pontoParada == true ? "Sim" : "Não") + "\n";
        },
        error: function (xhr, status, error) {
            alert(error);
        }
    });
    return mensagemRetorno;
}