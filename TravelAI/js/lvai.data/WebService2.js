var WebService = function ($) {
    var url = "";
    var opName = "";
    var paras = {};
	
	
    this.setUrl = function (_url) {
        url = _url;
    }

    this.setOpName = function (_opName) {
        opName = _opName;
    }

    this.setParas = function (_paras) {
        paras = _paras;
 
    }
	
	
    //成功返回数据时，执行的函数。
    var callBack = null;

    this.setCallBack = function (_callBack) {
        callBack = _callBack;
    }

    //错误时，执行的函数。
    var errorCallBack = null;
    this.setErrorCall = function (_errCallBack) {
        errorCallBack = _errCallBack;
		
    }

    //调用功能方法，从服务器取数据的方法。
    this.LoadData = function () {
    	
        var webUrl = url + opName;
        
        
		var datas = JSON.stringify(paras);
		console.log(datas);
        $.ajax(webUrl,{ 
	    			type:"post",  
	    			dataType:"json",
	    			contentType: 'application/json; charset=utf-8',
	    			data:datas,  
	    			timeout:10000,
	    			success:callBack,
	    			error:errorCallBack
	    		});	
    }

}