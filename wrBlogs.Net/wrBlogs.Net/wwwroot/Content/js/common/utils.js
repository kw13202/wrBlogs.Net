var Utils = (function () {
    'use strict';

    /**
     * 获取URL参数
     * @param name 参数名
     */
    var QueryString = function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
        var r = window.location.search.substr(1).match(reg);
        if (r != null)
            return unescape(r[2]);
        return null;
    };

    return {
        QueryString:QueryString,
    };
})();

window.config = {
    pageSize: 10,

};
















