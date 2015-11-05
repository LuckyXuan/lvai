/**
 * 相册对象
 */

var albumElement = function(){
	that = this; 
	this.id = "";//相册id
	this.time = "";//相册上传时间
	this.imgs = new Array();//本地路径的图片集  imgs.path  
	
	this.indexImg = 0;//封面
	
	
	this.album_li = null;
	//1初始化控件
	this.initAlbumObj = function(){
		that.album_li = document.createElement('li');
		that.album_li.className ="mui-table-view-cell mui-media mui-col-xs-6";
		that.album_li.id = "album_"+that.id;
		//var imgSrc = plus.io.convertLocalFileSystemURL("_doc/UserAlbum/"+that.imgs[that.indexImg])
		var s='<a href="#">';
		s+='<h5>'+that.time+'</h5>';
		
		for(var i= 0;i<that.imgs.length;i++){
			var imgSrc = plus.io.convertLocalFileSystemURL("_doc/UserAlbum/"+that.imgs[i]);
			if(i!=that.indexImg){
				s+='<img class="mui-media-object" src="'+imgSrc+'" data-preview-src="" data-preview-group="'+that.id+'" style="display: none;" />';
			}else{
				s+='<img class="mui-media-object" src="'+imgSrc+'" data-preview-src="" data-preview-group="'+that.id+'" />';
			}
		}
		s+='<h3>'+that.getImgCount()+'</h3>';
		s+='</a>';
		that.album_li.innerHTML = s;
		
	}
	
	//2设置事件
	this.setFun = function(h,fun){
		that.album_li.addEventListener(h,fun);
	}
	
	
	//3获取一个相册
	this.getAlbumObj = function(){
		return that.album_li;
	}
	//获取图片数量
	this.getImgCount = function(){
		return that.imgs.length;
	}
	//设置封面图片
	this.setIndexImg = function(index){
		that.indexImg = index;
	}
	
}
