$("#ContentPlaceHolder1_HandicapFactor").click(function () {
    $.get('/RecordPlayerScore/GetCurrentHandicap', function (response) {
        if (response.status) {
            $("#ContentPlaceHolder1_HandicapFactorLabel").text("");
            $("#ContentPlaceHolder1_HandicapFactorLabel").text("Handicap Factor: " + response.message);
        }
    });
});

$("#ContentPlaceHolder1_CalculateTotal").click(function () {
    var firstShots = 0;
    var secondShots = 0;
    $.each($('input[type=number]'), function () {
        if ($(this)[0].className != null && $(this)[0].className != "" && $(this)[0].className != "shots-btnseconds") {
            firstShots += $(this).val() != "" ? parseInt($(this).val()) : 0;
        }
        else if ($(this)[0].className != null && $(this)[0].className != "" && $(this)[0].className == "shots-btnseconds") {
            secondShots += $(this).val() != "" ? parseInt($(this).val()) : 0;
        }
    });

    $("#ContentPlaceHolder1_Back9Total").val(secondShots);
    $("#ContentPlaceHolder1_Front9Total").val(firstShots);
    $("#ContentPlaceHolder1_Edit").attr("disabled", false);
    $("#ContentPlaceHolder1_Record").attr("disabled", false);
    $("#ContentPlaceHolder1_CalculateTotal").attr("disabled", true);

    $.each($('input[type=number]'), function () {
        if ($(this)[0].className != null && $(this)[0].className != "" && $(this)[0].className != "shots-btnseconds" && $(this)[0].className != "required") {
            $(this).css('pointer-events', 'none');
        }
        else if ($(this)[0].className != null && $(this)[0].className != "" && $(this)[0].className == "shots-btnseconds" && $(this)[0].className != "required") {
            $(this).css('pointer-events', 'none');
        }
    });
});
$("#ContentPlaceHolder1_Edit").click(function () {
    $("#ContentPlaceHolder1_Edit").attr("disabled", false);
    $("#ContentPlaceHolder1_Record").attr("disabled", false);
    $("#ContentPlaceHolder1_CalculateTotal").removeAttr("disabled");

    $.each($('input[type=number]'), function () {
        if ($(this)[0].className != null && $(this)[0].className != "" && $(this)[0].className != "shots-btnseconds" && $(this)[0].className != "required") {
            $(this).css('pointer-events', '');
        }
        else if ($(this)[0].className != null && $(this)[0].className != "" && $(this)[0].className == "shots-btnseconds" && $(this)[0].className != "required") {
            $(this).css('pointer-events', '');
        }
    });
});

$("#ContentPlaceHolder1_Record").click(function () {
    var back = $("#ContentPlaceHolder1_Back9Total").val();
    var front = $("#ContentPlaceHolder1_Front9Total").val();
    var teeValue = $("#ContentPlaceHolder1_TeeList").val();
    let total = parseInt(back) + parseInt(front);
    var slope = $("#ContentPlaceHolder1_Slope").val();
    var rating = $("#ContentPlaceHolder1_Rating").val();
    var obj = { total: total, teeValue: teeValue, slope: slope, rating: rating };

    $.get('/RecordPlayerScore/RecordTee', { totalAndTee: JSON.stringify(obj) }, function (response) {
        $("#ContentPlaceHolder1_Message").text("");
        $("#ContentPlaceHolder1_Message").text(response.message);
    });
});
