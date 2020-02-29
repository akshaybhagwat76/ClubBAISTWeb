$("#btnLogin").click(function () { 
    var MemberNameVal = $("#txtMemberName").val();
    var PasswordVal = $("#txtPassword").val();
    
    $.post("LogIn/CheckLogin", { MemberNumber: MemberNameVal, Password: PasswordVal }, function (result) {
        if (result == "Login Successfully") {
            window.location.href = '/Home/Index'
        }
        else {
            $("#Message").html(result);
        }
    });
});