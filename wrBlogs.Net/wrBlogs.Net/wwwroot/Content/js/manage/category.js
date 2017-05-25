$(function () {
    
});
/**
 * 翻页
 * @param {int} page 页码
 */
function GoPage(page) {
    var pageIndex = isNaN(parseInt(page)) ? 1 : parseInt(page);
    window.location.href = location.protocol
        + "//"
        + location.host
        + location.pathname
        + "?pageIndex=" + pageIndex;
}











