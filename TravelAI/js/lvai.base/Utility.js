var Utility = {
	/**
	��ȡhtml����
	*/
	getParameter: function(param) {
		var query = window.location.search; //��ȡURL��ַ�У���������ַ�  
		var iLen = param.length; //��ȡ��Ĳ�����Ƴ���  
		var iStart = query.indexOf(param); //��ȡ��ò�����Ƶ���ʵ����  
		if (iStart == -1) //-1Ϊû�иò���  
			return "";
		iStart += iLen + 1;
		var iEnd = query.indexOf("&", iStart); //��ȡ�ڶ����������ʵ����  
		if (iEnd == -1) //ֻ��һ������  
			return query.substring(iStart); //��ȡ��������Ĳ���ֵ  
		return query.substring(iStart, iEnd); //��ȡ�ڶ��������ֵ  
	},
	//检查验证码是否合理
	//code : 验证码
	checkValidCode: function(code) {
		var number = configCodeNumber; //验证码位数
		var re = new RegExp("^\\d{" + number + "}$");
		if (re.test(code)) {
			return true;
		}
		return false;
	},

	//检查手机号码是否合理
	//phone : 手机号
	checkPhone: function(phone) {
		var re = /^1\d{10}$/;
		if (re.test(phone)) {
			return true;
		}
		return false;
	},
	//C# 时间戳  转 正常时间
	//time : 时间戳  如  /Date(1354116249000)/
	DatetoJs:function(time){
		time = time.replace("/Date(","").replace(")/","");
		return new Date(parseInt(time)).toLocaleDateString().replace(/\//g,'-');    
	},
	//普通时间转时间戳
	//time  ： 普通时间   如  2008-08-08
	DatetoCsharp:function(time){
		var arr = time.split("-");
		var new_time = new Date(Date.UTC(arr[0],arr[1]-1,arr[2]));
		console.log(new_time.getTime());
		return new_time.getTime();
	}

}