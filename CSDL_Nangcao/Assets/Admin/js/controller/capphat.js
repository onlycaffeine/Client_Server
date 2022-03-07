$(document).ready(function () {
    $('#btnAddEmployee').click(function () {
        $("#dlgPopup").show();
    })

    $("#btnSave").click(function () {
        $("#dlgPopup").hide();
        loadData();
    })

    $('#btnCloseDialog').click(function () {
        $("#dlgPopup").hide();
    })
    $('#btnCancel').click(function () {
        $("#dlgPopup").hide();
    })
})