
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
    if (!retval) {
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

var $radios = $('input[name=NumberOfPlayers]').change(function () {
    var value = $radios.filter(':checked').val();
    if (value == "2") {
        $("#MemberName2").prop('disabled', false);
        $("#MemberName3").val('');
        $("#MemberName4").val('');

        $("#MemberName3").prop('disabled', true);
        $("#MemberName4").prop('disabled', true);

    }
    if (value == "3") {
        $("#MemberName3").prop('disabled', false);
        $("#MemberName2").val('');
        $("#MemberName4").val('');

        $("#MemberName2").prop('disabled', true);
        $("#MemberName4").prop('disabled', true);

    }
    if (value == "4") {
        $("#MemberName4").prop('disabled', false);
        $("#MemberName2").val('');
        $("#MemberName3").val('');

        $("#MemberName2").prop('disabled', true);
        $("#MemberName3").prop('disabled', true);
    }
    if (value == "1") {
        $("#MemberName2").val('');
        $("#MemberName3").val('');
        $("#MemberName4").val('');

        $("#MemberName4").prop('disabled', true);
        $("#MemberName2").prop('disabled', true);
        $("#MemberName3").prop('disabled', true);
    }
});

$("#DisplayTeeTime").click(function () {
    $.get('/BookTeeTimeReservation/DisplayTeeRecords', { date: $("#ViewTeeTimeBox").val() }, function (response) {
        if (response != "") {
            var tableData = JSON.parse(response);
            var tr;
            $('#TeeTimesTable > tbody').html("");

            for (var i = 0; i < response.length; i++) {
                tr = $('<tr/>');
                tr.append("<td>" + new Date(tableData[i].Time).toLocaleTimeString() + "</td>");
                tr.append("<td>" + tableData[i].MemberName1 + "</td>");
                tr.append("<td>" + tableData[i].MemberName2 + "</td>");
                tr.append("<td>" + tableData[i].MemberName3 + "</td>");
                $('table#TeeTimesTable').append(tr);
            }
        }
    });
});