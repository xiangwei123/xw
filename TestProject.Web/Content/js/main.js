//(function() {
//    abp.event.on('abp.notifications.received', function (userNotification) {
//        abp.notifications.showUiNotifyForUserNotification(userNotification);
//    });
//})();

function showvideo(url) {
    var flashvars = {
        f: '/Content/video/'+url,
        c: 0,
        p: 1,
    };
    var params = { bgcolor: '#FFF', allowFullScreen: true, allowScriptAccess: 'always', wmode: 'transparent' };
    CKobject.embedSWF('/Content/ckplayer/ckplayer.swf', 'video', 'ckplayer_a1', '800', '600', flashvars, params);
}

