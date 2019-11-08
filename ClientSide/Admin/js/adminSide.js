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

	var JsonArray = JSON.parse(xmlHttp.responseText);
	console.log(JsonArray);

	JsonArray.forEach((element) => {
		if (element.status == 'processed') {
			var classcode = 'class="status--process">Processed';
		} else {
			var classcode = 'class="status--denied">Pending';
		}
		document.getElementById('fillfeed').innerHTML =
			' <tr class="tr-shadow" ><td>' +
			element.name +
			'</td><td><span class="block-email">' +
			element.email +
			'</span></td><td >' +
			element.date +
			'</td><td ><span ' +
			classcode +
			'</span> <!-- class="denied" --></td> <td><div class="table-data-feature"><button class="item" data-toggle="tooltip" data-placement="top" title="View" onclick="loadfeedback(' +
			element.id +
			')"><i class="fas fa-gavel"></i> </button> </div></td> </tr><tr class="spacer"></tr><tr class="tr-shadow"> </tr>';
	});
}
function loadfeedback(id) {
	var msgid = id;
	window.location.href = 'feedback-response.html?' + id;
	console.log(msgid);
}
