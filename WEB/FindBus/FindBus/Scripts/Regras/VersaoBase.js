/// <reference path="../Libs/jquery-2.0.3.js" />
$(function () {
    $("#btnSalvarVersaoBase").click(function () {
        var request = new XMLHttpRequest();
        var f = new FormData();
        var files = $("#arquivo").get(0).files[0];
        var versao = $("#versao").val()
        console.log(versao.length);
        if (versao.length == 0) {
            $('<div></div>').html('<p>Versao Base deve ser preenchida</p>')
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
          });
        }
        else {
            if (files == undefined) {
                $('<div></div>').html('<p>Arquivo deve ser Selecionado</p>')
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
               });
            }
            else {
                f.append('versao', versao);
                f.append('arquivo', files);
                request.open("POST", "AdicionarVersaoBase", true);
                request.send(f);
                request.onloadend = function (data) {
                    $('<div></div>').html('<p>' + data.target.responseText.replace('"', '').replace('"', '') + '</p>')
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
                                $("#versao").val("");
                                $("#arquivo").val("");
                            }
                        }
                    })
                };
            }
        }
    });
});