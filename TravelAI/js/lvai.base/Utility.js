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
	}

}