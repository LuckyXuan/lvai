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

	this.faildLoginHandler = null;
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
			console.log(uinfo.user_birthday);
			if (uinfo.user_birthday) {
				uinfo.user_birthday = new Date().setCsharpTime(uinfo.user_birthday).toFormatString("yyyy-MM-dd");
			}
			var s = new JsonTools().jsonObjToString(uinfo);
			new localStorageUtils().setItem("userInfo", s);
			that.successLoginHandler(uinfo);
			//alert(JSON.stringify(data)); 
		}

		//失败的回调
		function errorCallback(e) {
			that.faildLoginHandler("网络异常，请检查网络重新登录");
			//mui.toast(JSON.stringify(e));
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
				var msg = new JsonTools().stringToJson(o);
				if (msg.status == "faild") {
					faildHandler(msg);
					return;
				}
				var s = new JsonTools().jsonObjToString(msg.data);
				new localStorageUtils().setItem("userInfo", s);
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
					alert(status);
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
	this.updateUserInfo = function(jsonUserInfo, successHandler, faildHandler) {
		var ws = new WebService(mui);
		ws.setUrl(WebServiceURL);
		ws.setOpName("updateUserInfo");
		ws.setParas({
			jsonUserInfo: jsonUserInfo
		});
		ws.setCallBack(callback);
		ws.setErrorCall(errorCallback);
		ws.LoadData();
		//成功的回调
		function callback(data) {
				//alert(JSON.stringify(data));
				var o = eval(data);
				o = o.d;
				var msg = new JsonTools().stringToJson(o);
				if (msg.status == "faild") {
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

	//获取车辆信息
	//tel   ：  手机号码
	this.getCarInfo = function(tel, successHandler, faildHandler) {
		var ws = new WebService(mui);
		ws.setUrl(WebServiceURL);
		ws.setOpName("getCarInfo");
		ws.setParas({
			tel: tel
		});

		ws.setCallBack(callback);
		ws.setErrorCall(errorCallback);

		ws.LoadData();
		//成功的回调
		function callback(data) {
				//alert(JSON.stringify(data));
				var o = eval(data);
				o = o.d;
				if (o) {
					var jsono = new JsonTools().stringToJson(o);
					new localStorageUtils().setItem("userCar", new JsonTools().jsonObjToString(jsono.data));
				} else {
					new localStorageUtils().setItem("userCar", "");
				}
				var msg = new JsonTools().stringToJson(o);
				if (msg.status == "faild") {
					faildHandler();
					return;
				}
				successHandler();

			}
			//失败的回调

		function errorCallback(e) {
			console.log(11);
			alert(JSON.stringify(e));
		}
	}
	
	
	//获取个人音频信息
	//tel   ：  手机号码
	this.getUserAudio = function(tel, successHandler, faildHandler) {
		var ws = new WebService(mui);
		ws.setUrl(WebServiceURL);
		ws.setOpName("getAudio");
		ws.setParas({
			tel: tel
		});

		ws.setCallBack(callback);
		ws.setErrorCall(errorCallback);

		ws.LoadData();
		//成功的回调
		function callback(data) {
				//alert(JSON.stringify(data));
				var o = eval(data);
				o = o.d;
				var msg = new JsonTools().stringToJson(o);
				if (msg.status == "faild") {
					faildHandler();
					return;
				}
				if (msg.data.audio_url) {
					new localStorageUtils().setItem("userAudio", new JsonTools().jsonObjToString(msg.data));
				} else {
					new localStorageUtils().setItem("userAudio", "");
				}
				
				successHandler();

			}
			//失败的回调

		function errorCallback(e) {
			alert(JSON.stringify(e));
		}
	}

	//车辆信息更新
	//carJsonstring : 车辆信息的json数据
	this.UpdateCarInfo = function(carJsonstring, successHandler, faildHandler) {
			var ws = new WebService(mui);
			ws.setUrl(WebServiceURL);
			ws.setOpName("UpdateCarInfo");
			//			var datas = new JsonTools().jsonObjToString(carJsonstring);
			//console.log(JSON.stringify(carJsonstring));

			ws.setParas({
				carJsonstring: carJsonstring
			});

			ws.setCallBack(callback);
			ws.setErrorCall(errorCallback);

			ws.LoadData();
			//成功的回调
			function callback(data) {
					var o = eval(data);
					o = o.d;
					var msg = new JsonTools().stringToJson(o);
					if (msg.status == "faild") {
						faildHandler(msg);
						return;
					}
					successHandler(msg);
				}
				//失败的回调

			function errorCallback(e) {
				alert(JSON.stringify(e));
			}
		}
		//车辆图片上传
		//phone 手机号
		//index 图片的序号只支持3张图片上传
		//files 图片文件
		//successHandler 成功的消息
		//faildHandler	失败的消息
	this.uploadCarPhoto = function(phone, index, files, successHandler, faildHandler) {
		var filess = files;
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
		task.addData("Action", "uploadCarPhoto0");
		task.addData("tel", phone);
		task.addData("index", index.toString());
		for (var i = 0; i < filess.length; i++) {
			var f = filess[i];
			task.addData("filename", f.name);
			task.addFile(f.path, {
				key: f.name
			});

		}
		task.start();
	}

	//个人音频上传
	//phone:手机号
	//files:音频文件
	this.uploadUserAudio = function(phone, files, successHandler, faildHandler) {
			var filess = files;
			var task = plus.uploader.createUpload(UploadServer, {
					method: "POST"
				},
				function(t, status) { //上传完成
					console.log(status);
					if (status == 200) {
						successHandler(t.responseText);
					} else {
						faildHandler(status);
					}
				}
			);
			task.addData("Action", "upUserAudio");
			task.addData("tel", phone);
			for (var i = 0; i < filess.length; i++) {
				var f = filess[i];
				task.addFile(f.path, {
					key: f.path
				});
				task.addData("filename",f.name);
			}
			console.log("开始上传");
			task.start();
		}
		//个人视频上传
		//phone:手机号
		//files:视频文件
	this.uploadVideo = function(phone, files, type, successHandler, faildHandler) {
			var filess = files;
			var task = plus.uploader.createUpload(UploadServer, {
					method: "POST"
				},
				function(t, status) { //上传完成
					console.log(status);
					if (status == 200) {
						successHandler(t.responseText);
					} else {
						faildHandler(status);
					}
				}
			);
			task.addData("Action", "uploadVideo");
			task.addData("tel", phone);
			task.addData("type", type);
			for (var i = 0; i < filess.length; i++) {
				var f = filess[i];
				task.addFile(f.path, {
					key: f.name
				});
			}
			console.log("开始上传");
			task.start();
		}
		//个人背景图片上传
		//phone:手机号
		//files:背景图片文件
	this.uploadBgPhoto = function(phone, files, successHandler, faildHandler) {
		var filess = files;
		var task = plus.uploader.createUpload(UploadServer, {
				method: "POST"
			},
			function(t, status) { //上传完成
				console.log(status);
				if (status == 200) {
					successHandler(t.responseText, filess[0].name);
				} else {
					faildHandler(status);
				}
			}
		);
		task.addData("Action", "uploadUserCenterBg");
		task.addData("tel", phone);
		for (var i = 0; i < filess.length; i++) {
			var f = filess[i];
			task.addData("filename", f.name);
			task.addFile(f.path, {
				key: f.name
			});
		}
		console.log("开始上传");
		task.start();
	}

	//个人相册上传
	//
	this.uploadAlbum = function(phone, files, filenames, successHandler, faildHandler) {

			var filess = files;
			var task = plus.uploader.createUpload(UploadServer, {
					method: "POST"
				},
				function(t, status) { //上传完成
					console.log(status);
					if (status == 200) {
						successHandler(t.responseText, filenames);
					} else {
						faildHandler(status);
					}
				}
			);
			task.addData("Action", "uploadAlbum");
			task.addData("tel", phone);
			task.addData("fileNameList", filenames);

			for (var i = 0; i < filess.length; i++) {
				var f = filess[i];
				task.addFile(f.path, {
					key: f.name
				});

			}
			console.log("开始上传个人相册");
			task.start();
		}
		//签到
		//tel:手机号
	this.signlog = function(tel, callbackHandler, faildHandler) {
		var ws = new WebService(mui);
		ws.setUrl(WebServiceURL);
		ws.setOpName("signlog");
		ws.setParas({
			tel: tel
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

		//失败的提示
		function errorCallback(e) {
			//mui.toast(JSON.stringify(e));
			mui.toast("服务器连接失败");
		}
	}

	//更新GPS信息
	//tel:手机号
	//lng  lat   :   经纬度
	this.GPSLocation = function(tel, lng, lat, callbackHandler, faildHandler) {
			var ws = new WebService(mui);
			ws.setUrl(WebServiceURL);
			ws.setOpName("GPSLocation");
			ws.setParas({
				tel: tel,
				lng: lng,
				lat: lat
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

			//失败的提示
			function errorCallback(e) {
				//mui.toast(JSON.stringify(e));
				mui.toast("服务器连接失败");
			}
		}
		/**
		 * 获取当前用户信息。
		 */
	this.getUserInfo = function() {
			var userInfo = new localStorageUtils().getItem("userInfo");
			return new JsonTools().stringToJson(userInfo);
		}
		/***
		 *获取当前用户车辆信息。
		 */
	this.getUserCar = function() {
		var userCarTxt = new localStorageUtils().getItem("userCar");
		if (userCarTxt) {
			return new JsonTools().stringToJson(userCarTxt);
		} else {
			return null;
		}
	}

	//获取用户相册
	this.getUserAlbumInfo = function(tel, callbackHandler, faildHandler) {
		var ws = new WebService(mui);
		ws.setUrl(WebServiceURL);
		ws.setOpName("getUserAlbumInfo");
		ws.setParas({
			tel: tel
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
		}

		//失败的提示
		function errorCallback(e) {
			//mui.toast(JSON.stringify(e));
			mui.toast("相册服务器连接失败");
		}
	}
	
	/**
	 * 删除一个相册
	 * tel :手机号
	 * album_id : 相册id
	 */
	this.deleteAlbumModel = function(tel,album_id,callbackHandler,faildHandler){
		var ws = new WebService(mui);
		ws.setUrl(WebServiceURL);
		ws.setOpName("deleteAlbumModel");
		ws.setParas({
			tel: tel,
			album_id:album_id
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
		}

		//失败的提示
		function errorCallback(e) {
			//mui.toast(JSON.stringify(e));
			mui.toast("相册服务器连接失败");
		}
	}
}