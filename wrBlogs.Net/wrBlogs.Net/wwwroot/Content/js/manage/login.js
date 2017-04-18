$(function () {
    //显示服务端验证的错误信息
    if ($("#errorInfo").val()) {
        $("#alert-content").html($("#errorInfo").val());
        $('#my-alert').modal({
            closeViaDimmer: false,
        });
    };
    //验证
    $("#loginForm").validate({
        onfocusout: false,
        onkeyup: false,
        onclick: false,
        focusInvalid: false,
        focusCleanup: true,
    });
});



