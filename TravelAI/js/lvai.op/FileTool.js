var fileTool = {

	//检验文件是否存在
	//paths: 文件路径例如："_www/test.html"
	//serverPath: 服务器文件地址
	fileExist: function(paths, serverPath, successHandler, faildHandler) {
		plus.io.resolveLocalFileSystemURL(paths, function() {
			successHandler(paths);
		}, function() {
			faildHandler(paths, serverPath);
		});
	},
	
	/***
	 * 下载资源列表。
	 * @param {JSON} fileUrlList 格式：[{"url":"http://.....","type":1},{}...]
	 * @param {Object} successHandler
	 * @param {Object} faildHandler
	 */
	fileListDownLoad:function(fileList,successHandler,faildHandler)
	{
		var len=fileList.length;
		var downLoadCount=0;
		for(var i=0;i<len;i++)
		{
			var f=fileList[i];
			fileTool.fileDown(f.url,f.type,function(){
				downLoadCount++;
				if(downLoadCount==len)successHandler();
				
			},function(){
				downLoadCount++;
				if(downLoadCount==len)successHandler();
				faildHandler();
				alert(f.url+"下载失败");});
		}
	},
	//文件的下载
	//paths: 服务器文件路径
	//types: 服务器基本地址
	fileDown: function(paths, types, successHandler, faildHandler) {
		var fileDir = "_doc/HeadPhoto/";
		switch (types) {
			case 1:
				{
					fileDir = "_doc/HeadPhoto/";
					break;
				}
			case 2:
				{
					fileDir = "_doc/CarPhoto/";
					break;
				}
			case 3:
				{
					fileDir = "_doc/CarPhoto/thumbCarPhoto/"
					break;
				}
		};
		var dtask = null;
		var options = {
			method: "GET",
			filename: fileDir
		};
		dtask = plus.downloader.createDownload(paths, options);
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
					successHandler();
					break;
			}
		});
		dtask.start();
	},
	//图片文件的压缩
	//existPath：存在的地址 savePath：保存的地址
	//width 缩略图片的比例
	ImgFileCompress: function(existPath, savePath,width, successHandler, faildHandler) {
		plus.zip.compressImage({
			quality: 100,
			overwrite: true,
			src: existPath,
			dst: savePath,
			width: width // 缩小比例
		}, function() {
			successHandler(existPath, savePath);
		}, function() {
			faildHandler();
		});
	},
}