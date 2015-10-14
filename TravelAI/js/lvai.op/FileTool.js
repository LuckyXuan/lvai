var fileTool = {

	//检验文件是否存在
	//paths: 文件路径例如："_www/test.html"
	fileExist: function(paths, successHandler, faildHandler) {
		plus.io.resolveLocalFileSystemURL(paths, successHandler, faildHandler);
	},
	fileDown: function(paths, successHandler, faildHandler) {
		var dtask = null;
		var options = {
			method: "GET",
			filename: "_doc/HeadPhoto/"
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

}