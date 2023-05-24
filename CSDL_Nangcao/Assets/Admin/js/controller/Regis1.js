$(document).ready(function () {
    for (let j = 1; j < 10; j++) {
        $('#btnAddEmployee1pdk00' + j).click(function () {
            $('#dlgPopup1pdk00' + j).show();
        })

        $("#btnSave1pdk00" + j).click(function () {
            $('#dlgPopup1pdk00' + j).hide();
            loadData();
        })

        $("#btnCloseDialog1pdk00" + j).click(function () {
            $('#dlgPopup1pdk00' + j).hide();
        })
        $("#btnCancel1pdk00" + j).click(function () {
            $('#dlgPopup1pdk00' + j).hide();
        })
    }

    for (let i = 10; i < 100; i++) {
        $('#btnAddEmployee1pdk0' + i).click(function () {
            $('#dlgPopup1pdk0' + i).show();
        })

        $("#btnSave1pdk0" + i).click(function () {
            $('#dlgPopup1pdk0' + i).hide();
            loadData();
        })

        $("#btnCloseDialog1pdk0" + i).click(function () {
            $('#dlgPopup1pdk0' + i).hide();
        })
        $("#btnCancel1pdk0" + i).click(function () {
            $('#dlgPopup1pdk0' + i).hide();
        })
    }
})

