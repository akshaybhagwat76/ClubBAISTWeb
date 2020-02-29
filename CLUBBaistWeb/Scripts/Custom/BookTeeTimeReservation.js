$("#btnBookTeeTime").click(function () {


    var ReservationList = $("#PhoneNumber").val();
  
    $.get("/BookTeeTimeReservation/ReserverTime", { ReservationList: ReservationList }, function (resulut) {
        console.log(resulut);
    });
});