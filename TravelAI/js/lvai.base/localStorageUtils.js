function localStorageUtils() {

     var storage = window.localStorage;

     this.setItem = function(key,value){
	     storage.setItem(key, value);
	 } 
	 
	 this.getItem = function(key){
		return storage.getItem(key);
	 } 
	 
	 this.removeItem = function(key){
		storage.removeItem(key);
	 } 
	 
	 this.clear = function(){
		storage.clear();
	 } 
	 
	  

} 