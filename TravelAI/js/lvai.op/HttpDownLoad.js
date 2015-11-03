/**
 * 文件。
 * 网络资源文件。
 */
var HttpFile = function() {
		/**
		 * 网络路径
		 */
		this.URL = "";
		/**
		 * 文件名。
		 * 23423424.jpg
		 */
		this.FileName = "";
		/**
		 * 文件类型。
		 */
		this.FileType = "";
		/**
		 * 文件路径。
		 * _doc\headPhoto\
		 */
		this.FilePath = "";
	}
	/***
	 * http下载文件列表。
	 */
var HttpDownLoad = function() {
    var that = this;
	/***
	 * 下载开始时发生。
	 */
	this.StartDownLoadHandler = "";
	/**
	 * 下载完成时发生。
	 */
	this.DownLoadComleteHandler = "";
	/**
	 * 下载错误时发生。
	 */
	this.FaildDownLoadHandler = "";
	/**
	 * 下载文件列表。
	 */
	var _fileList = new Array();
	this.FileList=function(){return _fileList;}
	
	
	/**
	 * 下载错误的文件列表。
	 */
	this.FaildFileList = [];
    
	this.AddFile = function(f) {
		
			_fileList.push(f);
			
		}
		/**
		 * 下载。
		 */

	this.DownLoad = function() {
		var downCount = 0;
		that.StartDownLoadHandler();
		var cnt = _fileList.length;
		for (var i = 0; i < cnt; i++) {
			var f = _fileList[i];
			var fileDir = f.FilePath + f.FileName;
			var dtask = null;
			var options = {
				method: "GET",
				filename: fileDir
			};
			dtask = plus.downloader.createDownload(f.URL, options);
			dtask.addEventListener("statechanged", function(task, status) {
				if (!dtask) {
					return;
				}
				switch (task.state) {
					case 1: // 开始
						console.log("开始下载...");
						break;
					case 2: // 已连接到服务器
						console.log("链接到服务器...");
						break;
					case 4: // 下载完成
						console.log("下载完成！"); 
						downCount++;
						if (downCount == cnt) {
							that.DownLoadComleteHandler();
						}
						break;
				}
			});
			dtask.start();
		}
		
	}
}