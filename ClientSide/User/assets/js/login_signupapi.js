async function signUp() {
	var email = document.getElementById('email').value;
	var password = document.getElementById('password').value;
	var name = document.getElementById('uname').value;
	var dob = document.getElementById('dobyear').value;
	var gend = document.getElementById('gender');

	var gender = gend.options[gend.selectedIndex].text;
	var phone = document.getElementById('phone').value;

	var xmlHttp = new XMLHttpRequest();
	xmlHttp.open(
		'GET',
		'http://127.0.0.1:55842/api/Signup/' +
			email +
			'/' +
			password +
			'/' +
			name +
			'/' +
			dob +
			'/' +
			gender +
			'/' +
			phone,
		false
	); // false for synchronous request
	xmlHttp.send();
	console.log(xmlHttp.responseText);
}

async function login() {
	var email = document.getElementById('email').value;
	var password = document.getElementById('password').value;

	var xmlHttp = new XMLHttpRequest();
	xmlHttp.open('GET', 'http://127.0.0.1:55842/api/Signup/' + email + '/' + password, false); // false for synchronous request
	xmlHttp.send();
	console.log(xmlHttp.responseText);
}

function populateStore() {
	/*var xmlhttp = new XMLHttpRequest();
	var url = 'http://localhost:8080/vehicles';
	xmlhttp.open('GET', url, true);
	xmlhttp.send(null);
	xmlhttp.onreadystatechange = function() {
		if (xmlhttp.readyState == 4) {
			if (xmlhttp.status == 200) {
				var responseResult = eval('(' + xmlhttp.responseText + ')');
				// console.log(xmlhttp.responseText);

				console.log(responseResult);

				var data_array = responseResult;

				var html_text = '';
				var i = 1;
				var id;
				for (var key in responseResult) {
					//   id = parseInt(responseResult[key].venue_id);
					if (parseInt(responseResult[key].paid) == 0) {
						var paidd = 'Free';
					} else {
						paidd = responseResult[key].paid;
						paid += ' INR';
					}

					html_text += '<div class="col-lg-6">';
					html_text += '<div class="nk-product-cat-2">';
					html_text += '<a class="nk-product-image" href="#">';
					html_text += '<img src="assets/images/' + responseResult[key].image + '" alt="App Image"></a>';

					html_text += '<div class="nk-product-cont">';
					html_text +=
						' <h3 class="nk-product-title h5">' +
						responseResult[key].title +
						'</h3><div class="nk-gap-1"></div>';

					html_text +=
						' <div class="nk-product-rating" data-rating="' +
						responseResult[key].rating +
						'"> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="fa fa-star"></i> <i class="far fa-star"></i></div>';
					html_text += '<div class="nk-gap-1"></div>';
					html_text += '' + responseResult[key].desc + '<div class="nk-gap-2"></div>';
					html_text +=
						' <div class="nk-product-price">' +
						responseResult[key].desc +
						'</div><div class="nk-gap-1"></div>';
					html_text +=
						'  <button type="button" class="nk-btn nk-btn-rounded nk-btn-color-dark-3 nk-btn-hover-color-main-1">' +
						paidd +
						'</button> </div>  </div> </div>';

					html_text += '<div class="col-md-4 mb-3" >';

					html_text += '<div class="card shadow" style="width: 18rem";>';
					html_text += '<img src="images/' + responseResult[key].vimage + '" class="card-img-top" alt="...">';
					html_text += '<div class="card-body" ><h5>' + responseResult[key].vname + '</h5>';
					html_text += '<p class="card-text">' + responseResult[key].vdesc + '</p>';
					html_text += ' <p><b>Price:' + responseResult[key].vprice + '</p></b>';
					html_text +=
						'<button type=button class="btn btn-primary" onclick="bookit(' +
						vehicleid +
						',' +
						money +
						')">Book Vehicle</button>';
					html_text += ' </div></div></div>';
				}
				document.getElementById('appdata').innerHTML = html_text;
			} else alert('Error e->' + xmlhttp.responseText);
		}
	};*/
}
