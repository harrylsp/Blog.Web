// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//编码原理就是创建TextNode节点，附加到容器中，再取容器的innerHTML
function htmlencode(s) {
    var div = document.createElement('div');
    div.appendChild(document.createTextNode(s));
    return div.innerHTML;
}

//解码原理是将字符串赋給容器的innerHTML，再取innerText或textContent.
function htmldecode(s) {
    var div = document.createElement('div');
    div.innerHTML = s;
    return div.innerText || div.textContent;
}

// 编解码 测试
function unitTest() {
    //&lt;p&gt; &amp; &lt;/p&gt;
    alert(htmlencode('<p> & </p>'));

    //<p> & © ABC 中文 中文 </p>
    alert(htmldecode('&lt;p&gt; &amp; &copy; &#65;&#66;&#67; &#20013;&#25991; &#x4E2D;&#x6587; &lt;/p&gt;'));
}
