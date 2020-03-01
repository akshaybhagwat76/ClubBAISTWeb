
var _$RecordMemeberApplicationForm = null;
$("#btnBookTeeTime").click(function () {
    var ApplicationForm = {};

    _$RecordMemeberApplicationForm = $('[name="frmBookTeeTimeReservation"]').serializeFormToObject();
    $("#lblError").removeClass("success").removeClass("error").text('');
    var retval = false;
    $("#frmBookTeeTimeReservation .required").each(function () {
        if (!$(this).val() && !$(this).prop("disabled")) {
            $(this).addClass("error");
            retval = true;
        }
        else {
            $(this).removeClass("error");
        }
    });

    var ReservationList = $("#PhoneNumber").val();

    $.get("/BookTeeTimeReservation/ReserverTime", { ReservationList: ReservationList }, function (result) {
        console.log(result);
    });


    if (retval) {
        $.post('/BookTeeTimeReservation/SaveDataBookTeeTimeReservation', { objBoookstanding: _$RecordMemeberApplicationForm }, function (response) {

            if (!response.status) {
                $("#Message").addClass("error").text(response.message).show();
            }
            else {
                $("#Message").addClass("error").text(response.message).show();
            }
        });
    }
});