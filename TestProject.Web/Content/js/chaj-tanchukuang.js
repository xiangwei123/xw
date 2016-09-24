$.extend({
	openDialog:function(txt){
		$("<div class='overlay'></div>").appendTo("body");
		$("<div class='openDialog'><h1 class='top'>消息</h1><p>"+txt+"</p><a class='btn'>确定</a></div>").appendTo(".overlay");
		$(".openDialog").css("left",$(window).width()/2-150);
		$(".openDialog").css("top",$(window).height()/2-75);
		$(".bodyClass").click(function () {
	        $(".overlay").remove();
	    });
	}
	});