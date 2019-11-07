async function signUp() {
	var email = document.getElementById('email').value;
	var password = document.getElementById('password').value;
	var name = document.getElementById('uname').value;
	var dob = document.getElementById('dobyear').value;
	var gend = document.getElementById('gender');

	var gender = gend.options[gend.selectedIndex].text;
	var phone = document.getElementById('phone').value;

	var xmlHttp = new XMLHttpRequest();
	xmlHttp.open('GET', 'http://127.0.0.1:55842/api/Signup/'+ email +'/''+ +''', false); // false for synchronous request
	xmlHttp.send();
	console.log(xmlHttp.responseText);

	//alert('Register success. Please Login');
	// location.replace("vehicle.html")
	//window.location.href = 'index.html';
}
