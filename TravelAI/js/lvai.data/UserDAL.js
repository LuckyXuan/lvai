/**
 * 用户数据接口。服务器网络访问。
 */
var UserDAL = function() {
	var that = this;
	this.currentUser = null;
	/**
	 * 登录成功后处理函数。
	 */
	this.successLoginHandler = null;
	/**
	 * 登录失败后处理函数。
	 */

	this.faildLoginHandler=null;
	//登录
	//tel:手机号          pwd:密码
	this.login = function(tel, pwd) {
		var ws = new WebService(mui);
		ws.setUrl(WebServiceURL);
		ws.setOpName("login");
		ws.setParas({
			tel: tel,
			pwd: pwd
		});
		ws.setCallBack(callback);
		ws.setErrorCall(errorCallback);
		ws.LoadData();

		function callback(data) {
			var o = eval(data).d;
			var msg = new JsonTools().stringToJson(o);

			if (msg.status == "faild") {
				that.faildLoginHandler(msg.msg);
				return;
			}
			var uinfo = msg.data;
			uinfo.user_birthday = new Date().setCsharpTime(uinfo.user_birthday).toFormatString("yyyy-MM-dd");
			var s = new JsonTools().jsonObjToString(uinfo);
			new localStorageUtils().setItem("userInfo", s);
			that.successLoginHandler(uinfo);
			//alert(JSON.stringify(data)); 
		}

		//失败的回调
		function errorCallback(e) {
			mui.toast(JSON.stringify(e));
		}
	}

	//获取验证码
	//phone : 手机号
	this.getCode = function(phone, callbackHandler, faildHandler) {
		var url = WebServiceURL + "applySMS";
		var ws = new WebService(mui);
		ws.setUrl(WebServiceURL);
		ws.setOpName("applySMS");
		ws.setParas({
			tel: phone
		});
		ws.setCallBack(callback);
		ws.setErrorCall(errorCallback);
		ws.LoadData();

		//成功的回调
		function callback(data) {
			var msg = eval(data);
			msg = msg.d;
			msg = new JsonTools().stringToJson(msg);
			if (msg.status == "faild") {
				faildHandler(msg.msg);
				return;
			}
			callbackHandler(msg);
			//alert(JSON.stringify(data));
		}

		//失败的回调
		function errorCallback(e) {
			mui.toast(JSON.stringify(e));
		}
	}

	//验证是否正确的手机号以及验证码
	//phone:手机号
	//code : 验证码
	this.validSMSCode = function(phone, code, successHandler, faildHandler) {
		//var mask = mui.createMask(callback);//callback为用户点击蒙版时自动执行的回调；
		var ws = new WebService(mui);
		ws.setUrl(WebServiceURL);
		ws.setOpName("validSMSCode");
		ws.setParas({
			tel: phone,
			code: code
		});
		ws.setCallBack(callback);
		ws.setErrorCall(errorCallback);
		ws.LoadData();

		//成功的回调
		function callback(data) {
				//alert(JSON.stringify(data));
				var o = eval(data);
				o = o.d;
				msg = new JsonTools().stringToJson(o);
				if (msg.status == "faild") {
					faildHandler(msg);
					return;
				}
				new localStorageUtils().setItem("userInfo", o)
				successHandler(msg);

			}
			//失败的回调

		function errorCallback(e) {
			alert(JSON.stringify(e));
		}
	}

	//头像上传
		//phone 手机号
		//base64 图片的base64编码
		//successHandler 成功的消息
		//faildHandler	失败的消息
	this.uploadHeadPhoto = function(phone, base64, successHandler, faildHandler) {
		var task = plus.uploader.createUpload(UploadServer, {
				method: "POST"
			},
			function(t, status) { //上传完成
				if (status == 200) {
					successHandler(t.responseText);
				} else {
					faildHandler(status);
				}
			}
		);
		task.addData("Action", "uploadHeadPhoto0");
		task.addData("tel", phone);
		task.addData("base64", base64);
		console.log("开始上传");
		task.start();
	}

	//个人信息更新
	//jsonUserInfo : 个人数据集
	this.updateUserInfo = function(jsonUserInfo,successHandler,faildHandler){
		var ws = new WebService(mui);
			ws.setUrl(WebServiceURL);
			ws.setOpName("updateUserInfo");
			ws.setParas({
				jsonUserInfo:jsonUserInfo
			});
			ws.setCallBack(callback);
			ws.setErrorCall(errorCallback);
			ws.LoadData();
			//成功的回调
			function callback(data) {
				//alert(JSON.stringify(data));
				var o=eval(data);
				o=o.d;
				msg=new JsonTools().stringToJson(o);
				if(msg.status=="faild")
				{
					faildHandler(msg);
					return;
				}
//				new localStorageUtils().setItem("userInfo",o)
				successHandler(msg);
				
			}
			//失败的回调
			function errorCallback(e) {
				alert(JSON.stringify(e));
			}
	}
	
	
	
	//车辆信息更新
	//carJsonstring : 车辆信息的json数据
	this.UpdateCarInfo = function(carJsonstring,successHandler,faildHandler){
		var ws = new WebService(mui);
			ws.setUrl(WebServiceURL);
			ws.setOpName("UpdateCarInfo");
//			var datas = new JsonTools().jsonObjToString(carJsonstring);
			//console.log(JSON.stringify(carJsonstring));
			
			ws.setParas({
				carJsonstring:carJsonstring
			});
			
			ws.setCallBack(callback);
			ws.setErrorCall(errorCallback);
			
			ws.LoadData();
			//成功的回调
			function callback(data) {
				//alert(JSON.stringify(data));
				var o=eval(data);
				o=o.d;
				msg=new JsonTools().stringToJson(o);
				if(msg.status=="faild")
				{
					faildHandler(msg);
					return;
				}
//				new localStorageUtils().setItem("userInfo",o)
				successHandler(msg);
				
			}
			//失败的回调
			function errorCallback(e) {
				alert(JSON.stringify(e));
			}
	}

}