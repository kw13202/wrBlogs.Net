//$(function () {
//    //显示服务端验证的错误信息
//    if ($("#errorInfo").val()) {
//        $("#alert-content").html($("#errorInfo").val());
//        $('#my-alert').modal({
//            closeViaDimmer: false,
//        });
//    };
//    //验证
//    $("#loginForm").validate({
//        onfocusout: false,
//        onkeyup: false,
//        onclick: false,
//        focusInvalid: false,
//        focusCleanup: true,
//    });
//});
'use strict';
layui.use(['jquery'], function () {
    window.jQuery = window.$ = layui.jquery;
    $(".layui-canvs").width($(window).width());
    $(".layui-canvs").height($(window).height());
    $(".layui-canvs").jParticle({
        background: "#141414",
        color: "#E6E6E6"
    });
});


