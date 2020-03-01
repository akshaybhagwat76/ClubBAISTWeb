function findApplication(element) {
    var action = element.value;
    var appId = $("#ContentPlaceHolder1_ApplicationID").val();
    if (appId != "") {
        $("#ContentPlaceHolder1_ApplicationID").removeClass("required");

        $.get('/ReviewMember/FindApp', { findApplication: action + "," + appId }, function (data) {
            if (!data.status) {
                $("#ContentPlaceHolder1_Message").addClass("error").text(data.message);

            }
            else {
                $("#ContentPlaceHolder1_Message").removeClass("error").text(data.message);
            }
        });
    }
    else {
        $("#ContentPlaceHolder1_ApplicationID").addClass("required");
    }
}