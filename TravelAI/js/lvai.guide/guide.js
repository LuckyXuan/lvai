//判断是否第一次显示
function OnFirstShow() {
	if (plus.storage.getItem('FirstShow')) {
		//打开登录页面
		mui.openWindow({
			url: 'login.html',
			id: 'login'
		});
	} else {
		document.querySelector("body").removeAttribute('style');
	}
};
//按钮初始化
function OnMenuInit() {
	//立即体验按钮点击事件
	document.getElementById("close").addEventListener('tap', function(event) {
		plus.storage.setItem("FirstShow", "true");
		document.querySelector("body").setAttribute('style', "visibility: hidden;");
		//打开登录页面
		mui.openWindow({
			url: 'login.html',
			id: 'login'
		});
	});
	//图片切换时，触发动画
	document.querySelector('.mui-slider').addEventListener('slide', function(event) {
		//注意slideNumber是从0开始的；
		var index = event.detail.slideNumber + 1;
		if (index == 2 || index == 3) {
			var item = document.getElementById("tips-" + index);
			if (item.classList.contains("mui-hidden")) {
				item.classList.remove("mui-hidden");
				item.classList.add("guide-show");
			}
		}
	});
};