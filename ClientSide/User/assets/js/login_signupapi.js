function signUp() {
	var xhr = new XMLHttpRequest();
	var url = 'http://localhost:55842/api/Signup';
	xhr.open('POST', url, true);
	xhr.setRequestHeader('Content-Type', 'application/json');
	xhr.onreadystatechange = function() {
		console.log('xhr.readyState=>' + xhr.readyState);
		console.log('xhr.status=>' + xhr.status);
		console.log('xhr.responseText=>' + xhr.responseText);
		if (xhr.readyState === 4 && xhr.status === 200) {
			var json = JSON.parse(xhr.responseText);
			console.log(json.id + ', ' + json.name + ', ' + json.description);
		}
	};
	var email = document.getElementById('email').value;
	var password = document.getElementById('password').value;
	var name = document.getElementById('uname').value;
	var dob = document.getElementById('dobyear').value;
	var gender = document.getElementById('gender').value;
	var phone = document.getElementById('phone').value;

	var data = JSON.stringify({
		email: email,
		password: password,
		name: name,
		dob: dob,
		gender: gender,
		phoneNo: phone
	});
	console.log(data);
	xhr.send(data);
	//alert('Register success. Please Login');
	// location.replace("vehicle.html")
	//window.location.href = 'index.html';
}
