$(document).ready(function () {
    for (let j = 1; j < 10; j++) {
        $('#btnAddEmployeepdk00' + j).click(function () {
            $('#dlgPopuppdk00' + j).show();
        })

        $("#btnSavepdk00" + j).click(function () {
            $('#dlgPopuppdk00' + j).hide();
            loadData();
        })

        $("#btnCloseDialogpdk00" + j).click(function () {
            $('#dlgPopuppdk00' + j).hide();
        })
        $("#btnCancelpdk00" + j).click(function () {
            $('#dlgPopuppdk00' + j).hide();
        })
    }

    for (let i = 10; i < 100; i++) {
        $('#btnAddEmployeepdk0' + i).click(function () {
            $('#dlgPopuppdk0' + i).show();
        })

        $("#btnSavepdk0" + i).click(function () {
            $('#dlgPopuppdk0' + i).hide();
            loadData();
        })

        $("#btnCloseDialogpdk0" + i).click(function () {
            $('#dlgPopuppdk0' + i).hide();
        })
        $("#btnCancelpdk0" + i).click(function () {
            $('#dlgPopuppdk0' + i).hide();
        })
    }
})

    