/**
 * 用户数据接口。服务器网络访问。
 */
var UserDAL = function() {
	var that=this;
	this.currentUser = null;
	/**
	 * 登录成功后处理函数。
	 */
	this.successLoginHandler = null;
	/**
	 * 登录失败后处理函数。
	 */
	this.faildLoginHandler=null;
	
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
          var o=eval(data).d;
          var msg=new JsonTools().stringToJson(o);
          
          if(msg.status=="faild")
          {
          	that.faildLoginHandler(msg.msg);
          	return ;
          }
			 var uinfo=msg.data;
			 var s=new JsonTools().jsonObjToString(uinfo);
			new localStorageUtils().setItem("userInfo", s);
            that.successLoginHandler(data);
			//alert(JSON.stringify(data)); 
		}

		//失败的回调
		function errorCallback(e) {
			mui.toast(JSON.stringify(e));
		}
	}

	//获取验证码
	//phone : 手机号
	this.getCode = function(phone,callbackHandler,faildHandler) {
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
			var msg=eval(data);
			msg=msg.d;
			msg=new JsonTools().stringToJson(msg);
			if(msg.status=="faild")
			{
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
	this.validSMSCode = function(phone, code,successHandler,faildHandler) {
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
			var o=eval(data);
			o=o.d;
			msg=new JsonTools().stringToJson(o);
			if(msg.status=="faild")
			{
				faildHandler(msg);
				return;
			}
			new localStorageUtils().setItem("userInfo",o)
			successHandler(msg);
			
		}
		//失败的回调
		function errorCallback(e) {
			alert(JSON.stringify(e));
		}
	}

}