/***
 *
 * @param {Object} csharpTimeString
 */
Date.prototype.setCsharpTime = function(csharpTimeString) {
		var time = csharpTimeString.replace("/Date(", "").replace(")/", "");
		this.setTime(parseInt(time));
		return this;
		//new Date(parseInt(time)).toLocaleDateString().replace(/\//g,'-'); 
	}
	/**
	 * yyyy-MM-dd hh:mm:ss
	 * @param {Object} formatString
	 * yyyy-MM-dd
	 * yyyy/MM/dd hh:mm:ss
	 */
Date.prototype.toFormatString = function(formatString) {
	var yyyy = this.getFullYear();
	var MM = this.getMonth() + 1;
	MM = MM > 9 ? "" + MM : "0" + MM;
	var dd = this.getDate();
	dd = dd > 9 ? "" + dd : "0" + dd;
	var hh = this.getHours();
	hh = hh > 9 ? "" + hh : "0" + hh;
	var mm = this.getMinutes();
	mm = mm > 9 ? "" + mm : "0" + mm;
	var ss = this.getSeconds();
	ss = ss > 9 ? "" + ss : "0" + ss;
	var result = formatString.replace("yyyy", yyyy);
	result = result.replace("MM", MM);
	result = result.replace("dd", dd);
	result = result.replace("hh", hh);
	result = result.replace("mm", mm);
	result = result.replace("ss", ss);
	return result;

}

Date.prototype.toCSharpDateString=function()
{
		return "/Date(" + this.getTime() +")/";
	
}

/**
 * 
 
 var timeString = time.replace("/Date(","").replace(")/","");
	var time=parseInt(timeString);
	var d=new Date();
	d.setTime(time);
		return new Date(parseInt(time)).toLocaleDateString().replace(/\//g,'-'); 
 */