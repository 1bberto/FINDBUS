function VisualizarItinerarioRota(ItinerarioRotaID)
{
    $('<div></div>').html('rotaitinerarioid = ' + ItinerarioRotaID).dialog({
        closeOnEscape: false,
        title: 'FINDBUS',
        modal: true,
        draggable: true,
        show: 'drop',
        hide: 'fade',
        buttons: {
            Ok: function () {
                $(this).dialog("close");
            }
        }
    });
}