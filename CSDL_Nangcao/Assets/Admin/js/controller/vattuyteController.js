var user = {
    init: function () {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/Vattuyte/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text('Kích hoạt');
                    }
                    else {
                        btn.text('Khoá');
                    }
                }
            });
        });
    }
}
user.init();


$(document).ready(function () {
    //loadData();
    //loadDepartmentComboboxData();
    // Thực hiện gán các evens cho các element
    $('#btnAddEmployee').click(function () {
        // Hiển thị form chi tiết nhân viên:
        $("#dlgPopup").show();
        // Reset form: (xóa tất cả dữ liệu cũ đã nhập)
        //$("input").val(null);

        // Lấy mã nhân viên mới và hiển thị lên ô nhập mã nhân viên:

        //$.ajax({
        //    type: "GET",
        //    url: "http://cukcuk.manhnv.net/api/v1/Employees/NewEmployeeCode",
        //    success: function (response) {
        //        $('#txtEmployeeCode').val(response);
        //        // Focus vào ô nhập liệu đầu tiên:
        //        $('#txtEmployeeCode').focus()
        //    }
        //});

    })

    $("#btnSave").click(function () {
        //// Thu thập các thông tin đã liệu:
        //const employeeCode = $('#txtEmployeeCode').val();
        //const fullName = $('#txtFullName').val();
        //const dateOfBirh = $('#dtDateOfBirth').val();
        //const gender = $('#cbxGender').data('value');
        //const address = $('#txtAddress').val();
        //const email = $('#txtEmail').val();
        //const phoneNumber = $('#txtPhoneNumber').val();
        //const departmentId = $('#cbxDepartment').data('value');
        //const salary = $('#txtSalary').val();

        //// Build thành object nhân viên:
        //let employee = {
        //    "EmployeeCode": employeeCode,
        //    "FullName": fullName,
        //    "Gender": gender,
        //    "DateOfBirth": dateOfBirh,
        //    "PhoneNumber": phoneNumber,
        //    "Email": email,
        //    "Address": address,
        //    "Salary": salary,
        //    "DepartmentId": departmentId
        //}
        //debugger
        //console.log(employee);
        //// Sử dụng ajax Gọi lên Api cất dữ liệu:
        //$.ajax({
        //    type: "POST",
        //    url: "http://cukcuk.manhnv.net/api/v1/Employees",
        //    data: JSON.stringify(employee),
        //    dataType: "json",
        //    async: false,
        //    contentType: "application/json",
        //    success: function (response) {
        //        console.log(response);
        //    },
        //    error: function (res) {
        //        debugger
        //        console.log(res);
        //    }
        //});
        // Ẩn form chi tiết:
        $("#dlgPopup").hide();
        // Load lại dữ liệu:
        loadData();
    })

    $('#btnCloseDialog').click(function () {
        $("#dlgPopup").hide();
    })
    $('#btnCancel').click(function () {
        $("#dlgPopup").hide();
    })
})



var i = 0;

$('#btn_create_Mission').click(function () {
    var t = $("#Table_Missions tbody")
    var l = '<tr id="trPart' + i + '">';
    l += '<td hidden=hidden">';
    l += '<input id="td_ID_Mission_Detalis' + i + '" type="text" value="0" />';
    l += '</td>';

    l += '<td>';
    l += '<input id="td_Text_Mission' + i + '" type="text" />';
    l += '</td>';
    l += '<td>';
    l += '<input id="td_Value_Mission' + i + '" type="text" />';
    l += '</td>';
    l += '<td>';
    l += '<button id="btn_delete_mission' + i + '" type="button" onclick="deletePart(' + i + ')">DELETE PART MISSION</button>';
    l += '</tr>';
    t.append(l);
    i = i + 1;
}

)

function deletePart(position) {
    $("#trPart" + position).remove();
}

function clickSubmit() {
    var result = { idMission: $("#Name_Mission").val(), nameMission: $("#Name_Mission").val(), parts: [] };
    for (j = 0; j < i; j++) {
        if ($("#td_Text_Mission" + j) != undefined && $("#td_Text_Mission" + j).val() != undefined) {
            var partVal = {
                namePartMission: $("#td_Text_Mission" + j).val(),
                valPartMission: $("#td_Value_Mission" + j).val()
            };
            result.parts.push(partVal);
        }
    }
    console.log(result);
}