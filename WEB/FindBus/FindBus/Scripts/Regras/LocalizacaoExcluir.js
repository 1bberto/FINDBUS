/// <reference path="../Libs/jquery-2.0.3.js" />
/// <reference path="../Libs/jquery-ui-1.10.3.js" />
function ExcluirRota(rotaID) {
    $("<div></div>").html("Deseja Realmente Excluir Rota ?")
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
                    type: 'POST',
                    url: '../Localizacao/Excluir',
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ RotaID: rotaID }),
                    contentType: 'application/json',
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

