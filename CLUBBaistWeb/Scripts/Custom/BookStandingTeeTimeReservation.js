var _$RecordMemeberApplicationForm = null;
$("#BookStandingReservation").click(function () {
    _$RecordMemeberApplicationForm = $('[name="BookStandingTeeTimeReservation"]').serializeFormToObject();
    $("#lblError").removeClass("success").removeClass("error").text('');
    var retval = false;
    $("#BookStandingTeeTimeReservation .required").each(function () {
        if (!$(this).val()) {
            $(this).addClass("error");
            retval = true;
        }
        else {
            $(this).removeClass("error");
        }
    });

    if (retval) {
        $.post('/RecordMemberApplication/AddApplication', { application: _$RecordMemeberApplicationForm }, function (response) {
            if (!response.status) {
                $("#lblError").addClass("error").text(response.message).show();
            }
            else {
                location.href = "/Home/Index";
            }
        });
    }
});