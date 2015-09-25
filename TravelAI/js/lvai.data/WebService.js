var WebService = function () {

   //地址。
    var url = "";
    this.setURL = function (_url) {
        url = _url;
    }
    //方法名称。
    var opName = "";
    this.setOpName = function (_opName) {
        opName = _opName;
    }
    /**
	*参数
	*hash数组
	*/
    var paras = "";
    this.setParas = function (parasArray) {
	var isFirst=true;
       for(key in parasArray){
	   if(isFirst) {
	    paras+="?"+key+"="+parasArray[key];
	   isFirst=false;
	   }
	   else
	    paras+="&"+key+"="+parasArray[key];
	   }
    }
	
	this.clearParas=function(){
		paras="";
	};


    //成功后数据返回处理函数。
    //带有个参数，参数为返回后的数据。
    //function (result) {  //返回json类型数据   
    //            alert(result.loginmsg);
     //       }
    var callBack = null;
    this.setCallBack = function (_callBack) {
        callBack = _callBack;
    }


    var errorCallBack = null;
    this.setErrorCallBack = function (_errorCallBack) {
        errorCallBack = _errorCallBack;
    }

    this.LoadData = function () {
        var webUrl = url + opName + paras ;
        $.ajax({
            type : "GET",
            url: webUrl, //所请求的webservice服务url地址                 
            dataType : "jsonp",
            jsonp: 'callback',
            success: callBack,
            Error: errorCallBack
        });
    }
}