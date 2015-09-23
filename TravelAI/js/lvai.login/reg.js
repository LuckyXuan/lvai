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
};