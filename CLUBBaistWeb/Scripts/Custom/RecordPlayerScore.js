$("#ContentPlaceHolder1_HandicapFactor").click(function () {
    $.get('/RecordPlayerScore/GetCurrentHandicap', function (response) {
        if (response.status) {
            $("#ContentPlaceHolder1_HandicapFactorLabel").text("");
            $("#ContentPlaceHolder1_HandicapFactorLabel").text("Handicap Factor: "+response.message);
        }
    });
});

$("#ContentPlaceHolder1_CalculateTotal").click(function () {

    $("#ContentPlaceHolder1_Back9Total").val("0");
    $("#ContentPlaceHolder1_Front9Total").val("0");
    $("#ContentPlaceHolder1_Edit").attr("disabled", false);
    $("#ContentPlaceHolder1_Record").attr("disabled", false);
    $("#ContentPlaceHolder1_CalculateTotal").attr("disabled", true);

    //$.get('/RecordPlayerScore/CalculateResult', function (response) {
    //    console.log(response);
    //    //if (response.status) {
    //    //    $("#ContentPlaceHolder1_HandicapFactorLabel").text("");
    //    //    $("#ContentPlaceHolder1_HandicapFactorLabel").text("Handicap Factor: " + response.message);
    //    //}
    //});
});
$("#ContentPlaceHolder1_Edit").click(function () {
    $("#ContentPlaceHolder1_Edit").attr("disabled", false);
    $("#ContentPlaceHolder1_Record").attr("disabled", false);
    $("#ContentPlaceHolder1_CalculateTotal").removeAttr("disabled");
});

$("#ContentPlaceHolder1_Record").click(function () {
    var back = $("#ContentPlaceHolder1_Back9Total").val();
    var front = $("#ContentPlaceHolder1_Front9Total").val();
    var teeValue = $("#ContentPlaceHolder1_TeeList").val();
    let total = parseInt(back) + parseInt(front);
    var slope = $("#ContentPlaceHolder1_Slope").val();
    var rating = $("#ContentPlaceHolder1_Rating").val();
    var obj = { total: total, teeValue: teeValue,slope:slope,rating:rating };
    $.get('/RecordPlayerScore/RecordTee', { totalAndTee:JSON.stringify(obj) }, function (response) {
        console.log(response);
        $("#ContentPlaceHolder1_Message").text("");
        $("#ContentPlaceHolder1_Message").text(response.message);

        //if (response.status) {
        //    $("#ContentPlaceHolder1_HandicapFactorLabel").text("");
        //    $("#ContentPlaceHolder1_HandicapFactorLabel").text("Handicap Factor: " + response.message);
        //}
    });
});