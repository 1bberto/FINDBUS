/// <reference path="../Views/Home/Index.cshtml" />
function AtualizaVersao(url) {
    $.ajax({
        type: 'POST',
        url: url,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ VersaoAPK: $("#VersaoAPK").val(), VersaoBase: $("#VersaoBase").val() }),
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
function AdicionaCidade(url) {
    $.ajax({
        type: 'POST',
        url: url,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ cidadeID: 0, descricao: $("#Cidade").val(), uf: $("#Uf option:selected").val(), dataInclusaoRegistro: '' }),
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
                        $("#Cidade").val("");
                        $('#Uf option:first-child').attr("selected", "selected");
                    }
                }
            })
        }
    });
}
function RealizaLogin(url) {
    $.ajax({
        type: 'POST',
        url: url,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ Login: $("#Login").val(), Senha: $("#Senha").val() }),
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
                        window.location = "/Home";
                    }
                }
            })
        }
    });
}
function AdicionaVersao(btn) {
    //var $form = $(btn).parents('form');
    var $form = $("#Base");
    aler($form);
    $.ajax({
        type: "POST",
        url: $form.attr('action'),
        data: $form.serialize(),
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
                        window.location = "/Home";
                    }
                }
            })
        }
    });
    return false;// if it's a link to prevent post
}