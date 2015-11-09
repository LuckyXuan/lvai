
/**
 * 旅行类。
 */
var travelModel=function()
{
	/**
	 * 电话号码。发起人电话号码。
	 */
	this.promoter_userid="";
	this.travle_id="";
	this.release_time="";
    this.destination="";//目的地
	this.startplace="";//起始地
	this.return_time="";//返回时间。
	this.start_time="";//出发时间
	this.transportation="自驾";//交通工具;
	this.fee="";//费用说明
	this.travle_theme="";//旅行主题;
	this.travle_personcount=1;//需要旅伴个数;
	this.companion_condition="";//旅伴条件
	this.travle_msg=""//留言;
	this.pic1=""//图片1;
	this.pic2="";
	this.pic3="";
	this.income_condition="20万以上";//收入条件。注意这个和用户基本信息的收入情况一致。
    this.car_condition="20万以上";//车辆要求，和车辆信息等级一致。
	this.height_condition="";//身高要求。
	this.credit_condition="";//信用要求
	this.wantget_gift="";//想得到的礼物
	this.wantsend_gift="";//想送出的礼物
	this.reg_fee="";//申请费用。单位旅币。5旅币|10旅币|15旅币|20旅币|50旅币|100旅币。
}

/**
 * 完成旅行的相关管理。
 */
var TravelDal=function()
{
	//旅行实体。
	this.travel=null;
	
	/**
	 * 上传一张图片。
	 */
	this.UploadPic=function(_index)
	{
		
		
	}
	
    /***
     * 发布这次旅行。
     */
	this.RealseTravel=function(_callbackHanlder)
	{
		//发布。
		
		
	}
	
	/**
	 * 获取所有的旅行列表。
	 */
   this.getTravelList=function(_callbackHandler)
   {
   	
   	
   	
   }
   
   	/**
	 * json序列化。
	 */
	this.JSONSeriazable=function()
	{
		return new JsonTools().jsonObjToString(this.travel);
	}
	
	/**
	 * 反JSON序列化。
	 */
	this.deJSONSeriazable=function(jsonString)
	{
		var o= new JsonTools().stringToJson(jsonString);
		this.travel=new travelModel();
		this.travel.promoter_userid=new UserDAL().getUserInfo().user_telphone;
		this.travel.release_time=o.release_time;
        this.destination=o.destination;//目的地        
		this.startplace=o.startplace;//起始地
		this.return_time=o.return_time;//返回时间。
		this.start_time=o.start_time;//出发时间
		this.transportation=o.transportation;//交通工具;
		this.fee=o.fee;//费用说明
		this.travle_theme=o.travle_theme;//旅行主题;
		this.travle_personcount=o.travle_personcount;//需要旅伴个数;
		this.companion_condition=o.companion_condition;//旅伴条件
		this.travle_msg=o.travle_msg;//留言
		this.pic1=o.pic1;//图片1
		this.pic2=o.pic2;
		this.pic3=o.pic3;
		this.income_condition=o.income_condition;//收入条件。注意这个和用户基本信息的收入情况一致。
    	this.car_condition=o.car_condition;//车辆要求，和车辆信息等级一致。
		this.height_condition=o.height_condition;//身高要求。
		this.credit_condition=o.credit_condition;//信用要求
		this.wantget_gift=o.wantget_gift;//想得到的礼物
		this.wantsend_gift=o.wantsend_gift;//想送出的礼物
		this.reg_fee=o.reg_fee;//申请费用。单位旅币。5旅币|10旅币|15旅币|20旅币|50旅币|100旅币。
		
		return this.travel;
	}
	
}
