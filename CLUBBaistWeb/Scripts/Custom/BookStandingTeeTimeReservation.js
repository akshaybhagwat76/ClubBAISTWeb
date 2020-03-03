var _$RecordMemeberApplicationForm = null;
$("#BookStandingReservation").click(function () {debugger
    _$RecordMemeberApplicationForm = $('[name="BookStandingTeeTimeReservation"]').serializeFormToObject();
    $("#lblError").removeClass("success").removeClass("error").text('');
    var retval = false;
    $("#frmBookStandingTeeTimeReservation .required").each(function () {
        if (!$(this).val()) {
            $(this).addClass("error");
            retval = true;
        }
        else {
            $(this).removeClass("error");
        }
    });
    _$RecordMemeberApplicationForm.RequestedTime = $("#Hour").val() + "," + $("#Minute").val() + "," + $("#AMorPM").val();

    if (!retval) {
        $.post('/BookStandingTeeTimeReservation/AddStandingTeeTime', { objBoookstanding: _$RecordMemeberApplicationForm }, function (response) {
            if (!response.status) {
                $("#lblError").addClass("error").text(response.message).show();
            }
            else {
                location.href = "/Home/Index";
            }
        });
    }
});
