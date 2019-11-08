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

	var JsonArray = JSON.parse(xmlHttp.responseText);
	console.log(JsonArray);
	JsonArray.forEach((element) => {
        document.getElementById('fillfeed').innerHTML =' <tr class="tr-shadow" >
                                           
        <td>user name</td>
        <td>
            <span class="block-email">user mail id</span>
        </td>
        <td >11/11/11</td>
        
        <td ><span class="status--process">Processed/Pending</span> <!-- class="denied" -->
            </td> 
        
        <td>
            <div class="table-data-feature">
                <button class="item" data-toggle="tooltip" data-placement="top" title="View" onclick="loadfeedback(id)">
                    <i class="fas fa-gavel"></i>
                </button>
                
             
            </div>
        </td>
    </tr>
    <tr class="spacer"></tr>
    <tr class="tr-shadow">
        
    </tr>'
    });
}
function loadfeedback(id)
{
    
}
