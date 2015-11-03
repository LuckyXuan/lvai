/**
 * 文件接口。1.写入到本地键值对。
 *        2.读取本地键值对。
 *        3.写入本地文件。（调用plus，保存在安卓机或者苹果机上面。）
 *        4.读取本地文件。（调用plus，读取安卓机或者苹果机上面的本系统下面的文件。）
 */
var FileAccess=function()
{
	
	 this.writeLocalStorage=function(key,value)
	 {
	 	var storage = window.localStorage; 
	 	storage.setItem(key,value);
	 }
	 
	this.readLocalStorage=function(key)
    {
    	var storage = window.localStorage; 
    	storage.getItem(key);
    }
    
    this.writeFile=function(path,file)
	{
		
		
	}
	this.readFile=function(path)
	{
		return null;
		
	}
}
