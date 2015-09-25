/**
 * 用户数据接口。服务器网络访问。
 */
var UserDAL=
{
   	currentUser:null,
   	login:function(tel,pwd){
   		if(this.checkPhone(tel)&&pwd){
   			var ws = new WebService(mui);
    			ws.setUrl(WebServiceURL);
    			ws.setOpName("login");
    			ws.setParas({tel:tel,pwd:pwd});
    			ws.setCallBack(callback);
    			ws.setErrorCall(errorCallback);
    			ws.LoadData();
   		}else{
   			mui.toast("帐号或者密码不合理");
   		} 
   		//成功的回调
    	function callback(data){
    		alert(JSON.stringify(data));
    	}
    		
    	//失败的回调
    	function errorCallback(e){
    		alert(JSON.stringify(e));
    	}
   		
   		
   		
   	},
   	//检查手机号码是否合理
  	//phone : 手机号
    checkPhone:function(phone){ 	    
		var re = /^1\d{10}$/;
		if (re.test(phone)){		
			return true;
		}
		return false;
	} ,
	
	
	//检查手机号码是否合理
  	//code : 验证码
    checkCode:function(code){
    	var number = configCodeNumber;//验证码位数
		var re = new RegExp("^\\d{"+number+"}$");
		if (re.test(code)){		
			return true;	
		}
		return false;
	} ,
	
   	//获取验证码
	//phone : 手机号
   	getCode:function(phone){
   		var url = WebServiceURL+"applySMS";
    		if(this.checkPhone(phone)){//检验手机号是否合理
    			var ws = new WebService(mui);
    			ws.setUrl(WebServiceURL);
    			ws.setOpName("applySMS");
    			ws.setParas({tel:phone});
    			ws.setCallBack(callback);
    			ws.setErrorCall(errorCallback);
    			ws.LoadData();
    			
    		}else{   			
    			mui.toast("请输入正确的手机号");
    			return;
    		}
    		
    		//成功的回调
    		function callback(data){
    			alert(JSON.stringify(data));
    		}
    		
    		//失败的回调
    		function errorCallback(e){
    			alert(JSON.stringify(e));
    		}
    		
    		
    		//获取验证码按钮的倒计时
			function btnNo(){
				var s = 20;
				var btn = document.getElementById("getCode");
				btn.disabled = true;
				var time = setInterval(function(){
					s--;
					btn.innerHTML = s+"秒后获取";
					if(s<0){
						btn.disabled = false;
						btn.innerHTML = "获取验证码";
						clearInterval(time);	
					}
				},1000);
			}	
    		
   	},
   	
	//验证是否正确的手机号以及验证码
	//phone:手机号
	//code : 验证码
	validSMSCode:function(phone,code){
			//var mask = mui.createMask(callback);//callback为用户点击蒙版时自动执行的回调；
			if(this.checkPhone(phone)&&this.checkCode(code)){
				var ws = new WebService(mui);
    			ws.setUrl(WebServiceURL);
    			ws.setOpName("validSMSCode");
    			ws.setParas({tel:phone,code:code});
    			ws.setCallBack(callback);
    			ws.setErrorCall(errorCallback);
    			ws.LoadData();
				
			}else{
    			mui.toast("请输入正确的手机号以及验证码");
    			return;
    		}
			
			//成功的回调
    		function callback(data){
    			alert(JSON.stringify(data));
    		}
    		
    		//失败的回调
    		function errorCallback(e){
    			alert(JSON.stringify(e));
    		}
    		
			
		},
		
   	
   	
   
	
	
	
}
