//按钮的监听事件
function MenuInit() {
	//打开主界面
	document.getElementById('info').addEventListener('tap', function() {
		mui.openWindow({
			url: 'protal/main.html',
			id: 'main',
			styles: {
				zindex: 500
			}
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