var ajaxdata = (function() {
    var $mask, $maskMsg;

    function convertArratToBase64(obj) {
        for (var p in obj) {
            if (Object.prototype.toString.call(obj[p]) === "[object Array]") {
                obj[p] = BASE64.encode(obj[p]);
            }
        }
    }
    return {
        show: function() {
            $mask.show();
            $maskMsg.show();
        },
        get: function (url, data, successFunc, async, showMask) {
            this.request(URL, data, successFunc, "GET", async, showMask);
        },
        post: function(url, data, successFunc, async, showMask) {
            this.request(URL, data, successFunc, "POST", async, showMask);
        },
        request: function(url, data, successFunc, method, async, showMask) {
            async = async != undefined ? async : true;
            showMask = showMask != undefined ? showMask : true;
            if (showMask) {
                this.show();
            }
            $.ajax({
                url: url,
                type: method,
                data: convertArratToBase64(data),
                dataType: "json",
                success: function(result, textStatus, jqXHR) {
                    successFunc(result);
                    if (showMask) {
                        ajaxdata.hide();
                    }
                },
                error: function(XMLHttpRequest, textStatus, errorThrown) {
                    if (XMLHttpRequest.responseText.indexOf("<title>未授权 - 智造360</title>") > 0
                       || XMLHttpRequest.responseText.indexOf("<title>登录 - 智造360</title>") > 0) {
                        $.messager.alert("服务异常", XMLHttpRequest.responseText, "error");
                    }
                    else {
                        $.messager.alert("服务异常", errorThrown, "error");
                    }
                    if (showMask) {
                        ajaxdata.hide();
                    }
                }
            });
        }
    }

}());

var BASE64 = {
    encode: function (text) {
        if (/([^\u0000-\u00ff])/.test(text)) {
            throw new Error("Can't base64 encode non-ASCII characters.");
        }
        if (!text) return null;
        var digits = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/",
            i = 0,
            cur,
            prev,
            byteNum,
            result = [];
        while (i < text.length) {
            cur = Object.prototype.toString.call(text) === "[object Array]" ? text[i] : text.charCodeAt(i);
            byteNum = i % 3;
            switch (byteNum) {
                case 0: //first byte
                    result.push(digits.charAt(cur >> 2));
                    break;
                case 1: //second byte
                    result.push(digits.charAt((prev & 3) << 4 | (cur >> 4)));
                    break;

                case 2: //third byte
                    result.push(digits.charAt((prev & 0x0f) << 2 | (cur >> 6)));
                    result.push(digits.charAt(cur & 0x3f));
                    break;
            }
            prev = cur;
            i++;
        }

        if (byteNum === 0) {
            result.push(digits.charAt((prev & 3) << 4));
            result.push("==");
        } else if (byteNum === 1) {
            result.push(digits.charAt((prev & 0x0f) << 2));
            result.push("=");
        }
        return result.join("");
    }
};

var ajax= (function() {
    return{
        post: function() {
            return;
        }
    } 
})