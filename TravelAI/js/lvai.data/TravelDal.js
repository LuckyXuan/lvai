/**
 * 旅行类。
 */
var travelModel = function() {
	/**
	 * 电话号码。发起人电话号码。
	 */

	this.promoter_userid = "";
	this.travle_id = "";
	this.release_time = "";
	this.destination = ""; //目的地
	this.startplace = ""; //起始地
	this.return_time = ""; //返回时间。
	this.start_time = ""; //出发时间
	this.transportation = "自驾"; //交通工具;
	this.fee = ""; //费用说明
	this.travle_theme = ""; //旅行主题;
	this.travle_personcount = 1; //需要旅伴个数;
	this.companion_condition = ""; //旅伴条件
	this.travle_msg = "" //留言;
	this.pic1 = "" //图片1;
	this.pic2 = "";
	this.pic3 = "";
	this.income_condition = "20万以上"; //收入条件。注意这个和用户基本信息的收入情况一致。
	this.car_condition = "20万以上"; //车辆要求，和车辆信息等级一致。
	this.height_condition = ""; //身高要求。
	this.credit_condition = ""; //信用要求
	this.wantget_gift = ""; //想得到的礼物
	this.wantsend_gift = ""; //想送出的礼物
	this.reg_fee = ""; //申请费用。单位旅币。5旅币|10旅币|15旅币|20旅币|50旅币|100旅币。
}

/**
 * 完成旅行的相关管理。
 */
var TravelDal = function() {
	that = this;
	//旅行实体。
	this.travel = null;
	//相关图片集
	this.imgFiles = [];

	/**
	 * 上传图片集。
	 *successHandler 成功的消息
	 *faildHandler	失败的消息
	 */
	this.UploadPic = function(successHandler, faildHandler) {
		var filenames = "";
		
		var savePath = "";
		var imgs = [];
		
		if(that.travel.pic1){
			imgs.push(that.travel.pic1);	
		}
		if(that.travel.pic2){
			imgs.push(that.travel.pic2);	
		}
		if(that.travel.pic3){
			imgs.push(that.travel.pic3);	
		}
		if(!imgs.length){
			faildHandler();
			return;
		}
		for (var i = 0; i < imgs.length; i++) {
			var filePath = that.travel.promoter_userid + "_" + new Date().toFormatString("yyyyMMddhhmmss") + ".png";
			savePath = "_doc/TravelPhoto/" + filePath;
			fileTool.ImgFileCompress(imgs[i], savePath, "15%", function(existPath, savePath) {
				that.imgFiles.push({
					name: savePath,
					path: savePath
				});
				var fileName = savePath.substring(savePath.lastIndexOf('/') + 1);
				filenames = filenames + fileName + "|";
				if (that.imgFiles.length == imgs.length) {
					
					var task = plus.uploader.createUpload(UploadServer, {
							method: "POST"
						},
						function(t, status) { //上传完成
							if (status == 200) {
								successHandler(t.responseText);
							} else {
								faildHandler(status);
							}
						}
					);
					task.addData("Action", "uploadTravelPhoto");
					task.addData("filename", filenames.substring(0, filenames.length - 1));
					
					for (var i = 0; i < that.imgFiles.length; i++) {
						var f = that.imgFiles[i];
						// task.addData("filename", f.name);
						task.addFile(f.path, {
							key: f.name
						});

					}
					
					task.start();
				}
			},function(e){
				faildHandler("not exist");	
			});
			
		}


	}

	/***
	 * 发布这次旅行。
	 */
	this.RealseTravel = function(successHandler,faildHandler) {
		//发布。
		var t = that.travel;
		var ws = new WebService(mui);
			ws.setUrl(WebServiceURL);
			ws.setOpName("RealseTravel");
			ws.setParas({
				realsetravel: t
			});

			ws.setCallBack(callback);
			ws.setErrorCall(errorCallback);

			ws.LoadData();
			//成功的回调
			function callback(data) {
					var o = eval(data);
					o = o.d;
					var msg = new JsonTools().stringToJson(o);
					if (msg.status == "faild") {
						faildHandler(msg);
						
						alert(JSON.stringify(msg));
						return;
					}
					successHandler(msg);
				}
				//失败的回调

			function errorCallback(e) {
				console.log(JSON.stringify(e));
				faildHandler();
			}

	}

	/**
	 * 获取所有的旅行列表。
	 * tel:发起人  Int
	 * 
	 */
	this.getTravelList = function(tel,succesFun,failFun) {
		tel||(tel = that.travel.promoter_userid);
		var ws = new WebService(mui);
			ws.setUrl(WebServiceURL);
			ws.setOpName("getTravelList");
			ws.setParas({
				tel: tel
			});

			ws.setCallBack(callback);
			ws.setErrorCall(errorCallback);

			ws.LoadData();
			//成功的回调
			function callback(data) {
					var o = eval(data);
					o = o.d;
					var msg = new JsonTools().stringToJson(o);
					if (msg.status == "faild") {
						failFun(msg);
						return;
					}
					succesFun(msg);
				}
				//失败的回调

			function errorCallback(e) {
				console.log(JSON.stringify(e));
				failFun();
			}

		

	}
	
	/**
	 * 先文本后图片一起上传
	 */
	this.UpLoadStara = function(succesFun,failFun) {
		that.RealseTravel(function(_msg){ 
			that.UploadPic(function(responseText){ 
				if(responseText.status=="faild"){
					succesFun({text:true,img:false});
					return; 
				}
				succesFun({text:true,img:true});
			},function(e){ 
				succesFun({text:true,img:false});
				console.log("文字发布成功，图片发布失败！");
			});//UploadPic
		},function(){ 
			failFun({text:false,img:false});
			console.log("信息发布失败！");
		});//RealseTravel
	}
	
	
	/**
	 * json序列化。
	 */
	this.JSONSeriazable = function() {
		return new JsonTools().jsonObjToString(this.travel);
	}

	/**
	 * 反JSON序列化。
	 */
	this.deJSONSeriazable = function(jsonString) {
		var o = new JsonTools().stringToJson(jsonString);
		this.travel = new travelModel();
		this.travel.promoter_userid = new UserDAL().getUserInfo().user_telphone;
		this.travel.release_time = o.release_time;
		this.destination = o.destination; //目的地        
		this.startplace = o.startplace; //起始地
		this.return_time = o.return_time; //返回时间。
		this.start_time = o.start_time; //出发时间
		this.transportation = o.transportation; //交通工具;
		this.fee = o.fee; //费用说明
		this.travle_theme = o.travle_theme; //旅行主题;
		this.travle_personcount = o.travle_personcount; //需要旅伴个数;
		this.companion_condition = o.companion_condition; //旅伴条件
		this.travle_msg = o.travle_msg; //留言
		this.pic1 = o.pic1; //图片1
		this.pic2 = o.pic2;
		this.pic3 = o.pic3;
		this.income_condition = o.income_condition; //收入条件。注意这个和用户基本信息的收入情况一致。
		this.car_condition = o.car_condition; //车辆要求，和车辆信息等级一致。
		this.height_condition = o.height_condition; //身高要求。
		this.credit_condition = o.credit_condition; //信用要求
		this.wantget_gift = o.wantget_gift; //想得到的礼物
		this.wantsend_gift = o.wantsend_gift; //想送出的礼物
		this.reg_fee = o.reg_fee; //申请费用。单位旅币。5旅币|10旅币|15旅币|20旅币|50旅币|100旅币。

		return this.travel;
	}

}