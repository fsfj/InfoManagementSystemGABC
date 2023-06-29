//Load Data in Table when documents is ready

Date.prototype.dateToInput = function () {
    return this.getFullYear() + '-' + ('0' + (this.getMonth() + 1)).substr(-2, 2) + '-' + ('0' + this.getDate()).substr(-2, 2);
}
Date.prototype.timeToInput = function () {
    return ('0' + (this.getHours())).substr(-2, 2) + ':' + ('0' + this.getMinutes()).substr(-2, 2);
}

$(document).ready(function () {
    loadData();
    activaTab('list')
});

$(function () {
    $('#imageFile').change(function () {
        var input = this;
        var url = $(this).val();
        var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
        if (input.files && input.files[0] && (ext == "gif" || ext == "png" || ext == "jpeg" || ext == "jpg")) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#img').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
        else {
            $('#img').attr('src', '@Url.Content("~/Content/Images/preview.png")');
        }
    });

    $('#eImageFile').change(function () {
        var input = this;
        var url = $(this).val();
        var ext = url.substring(url.lastIndexOf('.') + 1).toLowerCase();
        if (input.files && input.files[0] && (ext == "gif" || ext == "png" || ext == "jpeg" || ext == "jpg")) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#eImg').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
        }
        else {
            $('#eImg').attr('src', '@Url.Content("~/Content/Images/preview.png")');
        }
    });

});
//Load Data function  
function loadData() {
    $.ajax({
        url: "/Employees/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                //html += '<td>' + item.EmployeeID + '</td>';
                html += '<td>' + item.LastName + '</td>';
                html += '<td>' + item.FirstName + '</td>';
                html += '<td>' + item.MiddleName + '</td>';
                html += '<td>' + formatDate(new Date(parseInt(item.DateHired.replace("/Date(", "").replace(")/", ""), 10))) + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.Id + ')">Edit</a> | <a href="#" onclick="Delele(' + item.Id + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }


    var empObj = {
        LastName: $('#lastName').val(),
        FirstName: $('#firstName').val(),
        MiddleName: $('#middleName').val(),
        DateHired: $('#dateHired').val()
    };

    var formData = new FormData();
    var totalFiles = document.getElementById("imageFile").files.length;
    for (var i = 0; i < totalFiles; i++) {
        var file = document.getElementById("imageFile").files[i];
        formData.append("imageFile", file);
    }
    formData.append("LastName", $('#lastName').val())
    formData.append("FirstName", $('#firstName').val())
    formData.append("MiddleName", $('#middleName').val())
    formData.append("DateHired", $('#dateHired').val())

    $.ajax({
        url: "/Employees/Add",
        data: formData,
        type: "POST",
        processData: false,
        contentType: false,
        //contentType: "application/json;charset=utf-8",
        //dataType: "json",
        success: function (result) {
            activaTab('list')
            loadData();
            clearTextBox();
            //$('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Employee ID  
function getbyID(EmpID) {
    $('#LastName').css('border-color', 'lightgrey');
    $('#FirstName').css('border-color', 'lightgrey');
    $('#MiddleName').css('border-color', 'lightgrey');
    $('#DateHired').css('border-color', 'lightgrey');

    $.ajax({
        url: "/Employees/getbyID/" + EmpID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#eId').val(result.Id);
            $('#eLastName').val(result.LastName);
            $('#eFirstName').val(result.FirstName);
            $('#eMiddleName').val(result.MiddleName);
            $('#eDateHired').val(new Date(parseInt(result.DateHired.replace("/Date(", "").replace(")/", ""), 10)).dateToInput());
  
            $('#eImg').attr('src', `data:image/png;base64,${result.ImageStrings}`)

            $('#myModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function Update() {
    //var res = validate();
    //if (res == false) {
    //    return false;
    //}
    //var empObj = {
    //    EmployeeID: $('#EmployeeID').val(),
    //    Name: $('#Name').val(),
    //    Age: $('#Age').val(),
    //    State: $('#State').val(),
    //    Country: $('#Country').val(),
    //};

    var formData = new FormData();
    var totalFiles = document.getElementById("eImageFile").files.length;
    for (var i = 0; i < totalFiles; i++) {
        var file = document.getElementById("eImageFile").files[i];
        formData.append("imageFile", file);
    }
    formData.append("Id", $('#eId').val())
    formData.append("LastName", $('#eLastName').val())
    formData.append("FirstName", $('#eFirstName').val())
    formData.append("MiddleName", $('#eMiddleName').val())
    formData.append("DateHired", $('#eDateHired').val())

    $.ajax({
        url: "/Employees/Update",
        data: formData,
        type: "PUT",
        processData: false,
        contentType: false,
        //contentType: "application/json;charset=utf-8",
        //dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#eId').val("");
            $('#eLastName').val("");
            $('#eFirstName').val("");
            $('#eMiddleName').val("");
            $('#eDateHired').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Employees/Delete/" + ID,
            type: "DELETE",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#lastName').val('');
    $('#firstName').val('');
    $('#middleName').val('');
    $('#dateHired').val('');
    //$('#btnUpdate').hide();
    //$('#btnAdd').show();
    $('#lastName').css('border-color', 'lightgrey');
    $('#firstName').css('border-color', 'lightgrey');
    $('#middleName').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate(value) {
    var isValid = true;
    if ($('#lastName').val().trim() == "") {
        $('#lastName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#lastName').css('border-color', 'lightgrey');
    }

    if ($('#firstName').val().trim() == "") {
        $('#firstName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#firstName').css('border-color', 'lightgrey');
    }

    if ($('#middleName').val().trim() == "") {
        $('#middleName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#middleName').css('border-color', 'lightgrey');
    }

    return isValid;
}

//function formatDate(date) {
//    var d = new Date(date),
//        month = '' + (d.getMonth() + 1),
//        day = '' + d.getDate(),
//        year = d.getFullYear();

//    if (month.length < 2)
//        month = '0' + month;
//    if (day.length < 2)
//        day = '0' + day;

//    return [month, day, year].join('/');
//}
function activaTab(tab) {
    $('.nav-tabs a[href="#' + tab + '"]').tab('show');
};
