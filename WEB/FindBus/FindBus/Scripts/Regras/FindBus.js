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
function ExcluirUsuario(usuID) {
    $("<div></div>").html("Deseja Realmente Excluir Usuario ?")
    .dialog({
        closeOnEscape: false,
        title: 'FINDBUS',
        modal: true,
        draggable: true,
        show: 'fade',
        hide: 'fade',
        buttons: {
            Sim: function () {
                $.ajax({
                    type: 'GET',
                    url: '../Usuario/Excluir',
                    contentType: 'application/json; charset=utf-8',
                    data: { usuID: usuID },
                    error: function (data) {
                        alert(data);
                    },
                    success: function (data) {
                        $("<div></div>").html(data)
                        .dialog({
                            closeOnEscape: false,
                            title: 'FINDBUS',
                            modal: true,
                            draggable: true,
                            show: 'fade',
                            hide: 'fade',
                            buttons: {
                                Ok: function () {
                                    location.reload(false);
                                }
                            }
                        });

                    }
                });
            },
            Não: function () {
                $(this).dialog("close");
            }
        }
    });
}
function AtualizarUsuario(url) {
    if ($("#Login").val() == "") {
        $("<div></div>").html("Login deve Ser preenchido")
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
                    $("#Login").focus();
                }
            }
        });
    }
    else
        if ($("#Senha").val() == "") {
            $("<div></div>").html("Senha deve Ser preenchida")
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
                        $("#Senha").focus();
                    }
                }
            });
        }
        else {
            $.ajax({
                type: 'POST',
                url: url,
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ UsuarioID: $("#UsuarioID").val(), NomeUsuario: $("#Login").val(), Senha: $("#Senha").val(), NivelAcesso: $("#NivelAcesso").val() }),
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
                                window.location = "../Usuario/Index";
                            }
                        }
                    })
                }
            });
        }
}
function AdicionarUsuario(url) {
    if ($("#Login").val() == "") {
        $("<div></div>").html("Login deve Ser preenchido")
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
                    $("#Login").focus();
                }
            }
        });
    }
    else
        if ($("#Senha").val() == "") {
            $("<div></div>").html("Senha deve Ser preenchida")
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
                        $("#Senha").focus();
                    }
                }
            });
        }
        else {
            var existeRota = verificaNomeUsuario();
            if (existeRota == false) {
                $.ajax({
                    type: 'POST',
                    url: url,
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ UsuarioID: $("#UsuarioID").val(), NomeUsuario: $("#Login").val(), Senha: $("#Senha").val(), NivelAcesso: $("#NivelAcesso").val() }),
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
                                    window.location = "../Usuario/Index";
                                }
                            }
                        })
                    }
                });
            }
            else {
                $("<div></div>").html("Nome de usuário já cadastrado")
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
                        $("#Login").val('');
                        $("#Login").focus();
                    }
                }
            });
            }
        }
}
function verificaNomeUsuario() {
    var retorno = true;
    $.ajax({
        type: 'GET',
        data: { nomeUsuario: $("#Login").val() },
        cache: true,
        async: false,
        url: '../Usuario/VerificaNomeUsuario',
        success: function (data) {
            retorno = data.Retorno == true ? true : false;
        },
        error: function (xhr, status, error) {
            console.log(error);
        }
    });
    return retorno;
}