var createFragment = function(count) {
	var fragment = document.createDocumentFragment();
	var li;
	for (var i = 0; i < count; i++) {
		li = document.getElementById("muban").cloneNode(true);
		li.removeAttribute("style");
		li.getElementsByTagName("img")[0].setAttribute("data-original", "http://www.pokemon.name/w/image/Sprites/PDW/" + ((Math.round(Math.random() * 100000)) % 400 + 100) + ".png");
		li.getElementsByTagName("img")[1].setAttribute("data-original", "http://www.pokemon.name/w/image/Sprites/PDW/" + ((Math.round(Math.random() * 100000)) % 400 + 100) + ".png");
		li.getElementsByTagName("img")[2].setAttribute("data-original", "http://www.pokemon.name/w/image/Sprites/PDW/" + ((Math.round(Math.random() * 100000)) % 400 + 100) + ".png");
		li.getElementsByTagName("img")[3].setAttribute("data-original", "http://www.pokemon.name/w/image/Sprites/PDW/" + ((Math.round(Math.random() * 100000)) % 400 + 100) + ".png");
		fragment.appendChild(li);
	}
	return fragment;
};