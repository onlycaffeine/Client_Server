$(document).ready(function () {
        var btnadd = '#btnAddEmployee';
        var pop = '#dlgPopup';
        var save = "#btnSave";
        var close = "#btnCloseDialog";
        var cancel = "#btnCancel";
        $(btnadd).click(function () {
            $(pop).show();
        })

        $(save).click(function () {
            $(pop).hide();
            loadData();
        })

        $(close).click(function () {
            $(pop).hide();
        })
        $(cancel).click(function () {
            $(pop).hide();
        })
})