function CreateAjaxCall(url, callback, httpMethod, isAsync) {
    xmlhttp = new XMLHttpRequest()
    xmlhttp.onreadystatechange = callback
    xmlhttp.open(httpMethod, url, isAsync)
    xmlhttp.send()
}

function AddMedia() 
{
    var url = "http://localhost:5709/Radio/InsertMedia?url="+ document.getElementById('text_input').value
    
    var callback =  function() 
	{
	    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) 
	    {
	        var jsonData = eval('(' + xmlhttp.responseText + ')');
	        alert(jsonData);
	        document.getElementById('text_input').value = '';
	    }
	}
    CreateAjaxCall(url, callback, "GET", true)
}

function AfterAddMedia() {
    document.getElementById('addMedia').style.visibility = visible;
}

