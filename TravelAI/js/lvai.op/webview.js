/***
 * 隐藏显示的页面，显示点击的页面
 * @param {Object} ws  父窗体
 * @param {Object} e   点击的元素
 */
function preateHide(ws, e) {
	for (var i = 0; i < ws.children().length; i++) {
		if (ws.children()[i].id == e.id) {
			if (ws.children()[i].isVisible()) {
				return;
			} else {
				ws.children()[i].show();
			}
		} else {
			ws.children()[i].hide();
		}
	}
};



var showSideslip = false,
	isInTransition = false;

/***
 * 打开侧滑页面
 * @param {Object} ws  主页面
 * @param {Object} Sideslip 侧滑页面
 */
function OpenSideslip(ws, Sideslip) {
	//防止在侧滑动画时多次侧滑
	if (isInTransition) {
		return;
	}
	if (!showSideslip) {
		isInTransition = true;
		Sideslip.setStyle({
			mask: 'rgba(0,0,0,0)',
			zindex: 100
		});
		Sideslip.show('none', 0, function() {
			//主窗体开始侧滑并显示遮罩
			ws.setStyle({
				mask: 'rgba(0,0,0,0.4)',
				left: '70%',
				transition: {
					duration: 150
				}
			});
			mui.later(function() {
				isInTransition = false;
				Sideslip.setStyle({
					mask: "none"
				}); //移除menu的mask
			}, 160);
			showSideslip = true;
		});
	}
};

/***
 * 关闭侧滑页面
 * @param {Object} ws  主页面
 * @param {Object} Sideslip 侧滑页面
 */
function CloseSideslip(ws, Sideslip) {
	if (isInTransition) {
		return;
	}
	if (showSideslip) {
		//关闭遮罩;
		//主窗体开始侧滑;
		isInTransition = true;
		ws.setStyle({
			mask: 'none',
			left: '0',
			transition: {
				duration: 200
			}
		});
		showSideslip = false;
		//等动画结束后，隐藏菜单webview，节省资源
		mui.later(function() {
			isInTransition = false;
			Sideslip.hide();
		}, 300);
	}
};


// 预创建二级页面
var preate = {};
/***
 * 创建二级页面
 * @param {Object} url 网址
 * @param {Object} id  唯一标示
 * @param {Object} top 顶部距离
 * @param {Object} bottom 底部距离
 * @param {Object} isShow 是否为首页
 */
function CreatePage(url, id, top, bottom,windowWidth, isShow) {
	if (!preate[id]) {
		var w = plus.webview.create(url, id, {
			top: top,
			bottom: bottom
		},{
			listCarWidth: windowWidth+""
		});
		preate[id] = w;
		if (!isShow) {
			w.hide();
		}
		return w;
	}
};

/***
 *上拉刷新
 * @param {Object} ws 当前页面对象
 * @param {Object} Callback 刷新后执行的函数
 */
function PullUpRefresh(ws, Callback) {
	ws.setPullToRefresh({
		support: true,
		height: "50px",
		range: "200px",
		contentdown: {
			caption: "下拉可以刷新"
		},
		contentover: {
			caption: "释放立即刷新"
		},
		contentrefresh: {
			caption: "正在刷新..."
		}
	}, Callback);
};