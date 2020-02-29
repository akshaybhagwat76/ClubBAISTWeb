var _$RecordMemeberApplicationForm = null;

$("#btn-submit").click(function () {
    _$RecordMemeberApplicationForm = $('[name="frmRecordMemeberApplication"]').serializeFormToObject();
    $("#lblError").removeClass("success").removeClass("error").text('');
    var retval = true;
    $("#frmRecordMemeberApplication .required").each(function () {
        if (!$(this).val()) {
            $(this).addClass("error");
            retval = false;
        }
        else {
            $(this).removeClass("error");
        }
    });
    if (retval) {
        var email = $("#email").val().trim();
        if (email && !isEmail(email)) {
            $("#email").addClass('error');
        }
        else {
            $("#email").removeClass('error');
        }
        console.log(_$RecordMemeberApplicationForm);
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