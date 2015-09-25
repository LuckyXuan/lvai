//按钮的监听事件
function MenuInit() {
	//打开主界面
	document.getElementById('info').addEventListener('tap', function() {
		var phone = document.getElementById("phone");
		var code = document.getElementById("code");
		UserDAL.validSMSCode(phone.value, code.value);
		mui.openWindow({
			url: 'protal/main.html',
			id: 'main'
		});
	});
};