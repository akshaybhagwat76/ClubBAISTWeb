$("#btnBookTeeTime").click(function () {


    var ReservationList = $("#PhoneNumber").val();
  
    $.get("/BookTeeTimeReservation/ReserverTime", { ReservationList: ReservationList }, function (result) {
        console.log(result);
    });
});