function VisualizarEtinerarioRota(EtinerarioRotaID)
{
    $('<div></div>').html('rotaetinerarioid = ' + EtinerarioRotaID).dialog({
        closeOnEscape: false,
        title: 'FINDBUS',
        modal: true,
        draggable: true,
        show: 'bounce',
        hide: 'fade',
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
}