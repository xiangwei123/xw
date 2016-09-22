$(function () {
    Date.prototype.Format = function(fmt) { //author: meizz   
        var o = {
            "M+": this.getMonth() + 1, //月份   
            "d+": this.getDate(), //日   
            "h+": this.getHours(), //小时   
            "m+": this.getMinutes(), //分   
            "s+": this.getSeconds(), //秒   
            "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
            "S": this.getMilliseconds() //毫秒   
        };
        if (/(y+)/.test(fmt))
            fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
        for (var k in o)
            if (new RegExp("(" + k + ")").test(fmt))
                fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
        return fmt;
    };
    Date.prototype.addDay = function(day) {
        return new Date((this / 1000 + day * 86400) * 1000);
    };
    Date.prototype.subDay = function (day) {
        return new Date((this / 1000 - day * 86400) * 1000);
    };
});
var app = function () {
    return {
        handleResponse: function(response) {
            try {
                if (typeof (response) == typeof ("")) {
                    response = JSON.parse(response);
                }
                if (response.Succeed) {
                    return true;
                } else if (response.Disallow) {
                    this.alert.info("没有登录!");
                } else {
                    this.alert.error(response.ErrorMessage);
                };
            } catch (e) {
                console.error(e);
            }
            return false;
        },
        getResponseData: function(response) {
            try {
                if (typeof (response) == typeof ("")) {
                    response = JSON.parse(response);
                }
                if (this.handleResponse(response)) {
                    return response.Data;
                }
            } catch (e) {
                console.error(e);
            }
            return null;
        },
        alert: {
            info: function(text, title, fn) {
                $.messager.alert(title || '提示', text, 'info', fn);
            },
            warn: function(text, title, fn) {
                $.messager.alert(title || '警告', text, 'warning', fn);
            },
            error: function(text, title, fn) {
                $.messager.alert(title || '错误', text, 'error', fn);
            }
        },
        confirm: function(msg, fn, title) {
            $.messager.confirm(title || '确认对话框', msg, function(r) {
                if (r && fn) {
                    fn();
                }
            });
        },
        tree: {
            convertData: function(data, idField, textField, subField) {
                var treeData = [];
                for (var i = 0; i < data.length; i++) {
                    var item = data[i];
                    var treeItem = {
                        id: item[idField],
                        text: item[textField],
                        attributes: item,
                        children: []
                    }
                    if (item[subField] && item[subField].length > 0) {
                        treeItem.children = this.convertData(item[subField], idField, textField, subField);
                    }
                    treeData.push(treeItem);
                }
                return treeData;
            }
        },
        getImageDataURLs: function(e, fn) {
            if (!window.FileReader) return;
            var files = e.files || e.target.files || e.dataTranser.files;
            for (var i = 0, f; f = files[i]; i++) {
                if (!f.type.match('image.*')) {
                    continue;
                }
                var reader = new FileReader();
                reader.onload = (function(theFile) {
                    return function(e1) {
                        fn && fn(e1.target.result);
                    }
                })(f);
                reader.readAsDataURL(f);
            }

        }
     
    };
}();
