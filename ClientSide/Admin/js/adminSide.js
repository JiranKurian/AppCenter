function apkUpload() {
	var email = document.getElementById('appname').value;
	var email = document.getElementById('appname').value;
	var email = document.getElementById('appname').value;
	var email = document.getElementById('appname').value;
	var email = document.getElementById('appname').value;
	var email = document.getElementById('appname').value;
	var email = document.getElementById('appname').value;
	var email = document.getElementById('appname').value;
}

function feedbackload() {
	var xmlHttp = new XMLHttpRequest();
	xmlHttp.open('GET', 'http://127.0.0.1:55842/api/Feedback', false); // false for synchronous request
	xmlHttp.send();

	console.log(xmlHttp.responseText);

	/*var JsonArray = JSON.parse(xmlHttp.responseText);
	console.log(JsonArray);

	JsonArray.forEach((element) => {});*/
}
