$(function () {
    $('#dialog').dialog({
        autoOpen: true,
        width: 400,
        resizable: false,
        modal: true,
        buttons: {
            "Close": function () {
                $(this).dialog("close");
            }
        }
    });
});