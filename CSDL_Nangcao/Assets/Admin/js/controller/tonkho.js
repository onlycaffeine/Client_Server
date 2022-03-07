$(document).ready(function () {
    for (let j = 1; j < 10; j++) {
        $('#btnAddEmployeelo00' + j).click(function () {
            $('#dlgPopuplo00' + j).show();
        })

        $("#btnSavelo00" + j).click(function () {
            $('#dlgPopuplo00' + j).hide();
            loadData();
        })

        $("#btnCloseDialoglo00" + j).click(function () {
            $('#dlgPopuplo00' + j).hide();
        })
        $("#btnCancello00" + j).click(function () {
            $('#dlgPopuplo00' + j).hide();
        })
    }

    for (let i = 10; i < 100; i++) {
        $('#btnAddEmployeelo0' + i).click(function () {
            $('#dlgPopuplo0' + i).show();
        })

        $("#btnSavelo0" + i).click(function () {
            $('#dlgPopuplo0' + i).hide();
            loadData();
        })

        $("#btnCloseDialoglo0" + i).click(function () {
            $('#dlgPopuplo0' + i).hide();
        })
        $("#btnCancello0" + i).click(function () {
            $('#dlgPopuplo0' + i).hide();
        })
    }
})