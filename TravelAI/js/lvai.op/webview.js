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
