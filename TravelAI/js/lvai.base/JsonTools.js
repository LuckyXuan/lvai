var JsonTools=function () {

     this.jsonObjToString = function(jsonObj){ 
		 return JSON.stringify(jsonObj);
	 } 
	 this.stringToJson = function(JsonString){ 
		 return  eval('('+JsonString+')');
	 } 
} 