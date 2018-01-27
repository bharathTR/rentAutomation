﻿$(document).ready(function () {
    $("#btnAdd").click(function () {
        var id = $('#id').val();
        var FirstName = $('#TxtFirstName').val();
        var LastName = $('#Txtlastname').val();
        var Contact = $('#Txtcontact').val();
        var City = $('#Txtcity').val();
        var Country = $('#Txtcountry').val();

        if (FirstName == "") {
            alert("Enter First Name");
            $('#TxtFirstName').focus();
            return false;
        }
        if (LastName == "") {
            alert("Enter Last Name");
            $('#Txtlastname').focus();
            return false;
        }

        if (Contact == "") {
            
           alert("Enter Contact No");
            $('#Txtcontact').focus();
            return false;
        }

        if (City == "") {
            alert("Select City");
            $('#Txtcity').focus();
            return false;
        }
        if (Country == "") {
            alert("Select Country");
            $('#Txtcountry').focus();
            return false;
        }

        $.ajax({
            url: "/Customer/NewCustomer",
            type: "Post",
            data: { 'id': id, 'FirstName': FirstName, 'LastName': LastName, 'Contact': Contact, 'City': City, 'Country': Country},
            success: function (response) {
                alert(response[0]);

                if (response[0]== "Updated") {
                    window.location.href = '/Customer/ViewCustomer';
                }
                $('#id').val("");
                $('#TxtFirstName').val("");
                $('#Txtlastname').val("");
                $('#Txtcontact').val("");
                $('#Txtcity').val("");
                $('#Txtcountry').val("");

            },
            error: function (response) {
                alert(response);
            }
        });

        
    });

});
function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}


function ValidateAlpha(evt) {

    evt = (evt) ? evt : window.event;
    var keyCode = (evt.which) ? evt.which : evt.keyCode;
    if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {

        return false;
    }
    return true;
}
