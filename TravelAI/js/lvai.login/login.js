//按钮的监听事件
function MenuInit() {
	//打开主界面
	document.getElementById('info').addEventListener('tap', function() {
		var tel = document.getElementById("tel");
		var pwd = document.getElementById("pwd");
		//UserDAL.login(tel.value,pwd.value);
		mui.openWindow({
			url: 'protal/main.html',
			id: 'main'
		});
	});
	//注册按钮
	document.getElementById('reg').addEventListener('tap', function() {
		mui.fire(reg, 'show', null);
		setTimeout(function() {
			mui.openWindow({
				id: 'reg',
				show: {
					aniShow: 'pop-in'
				},
				waiting: {
					autoShow: false
				}
			});
		}, 0);
	});
};
//预加载
function OnPreload() {
	reg = mui.preload({
		"id": 'reg',
		"url": 'reg.html'
	});
};