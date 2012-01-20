function CreateAjaxCall(url, callback, httpMethod, isAsync) 
{
    xmlhttp = new XMLHttpRequest()
    xmlhttp.onreadystatechange = callback
    xmlhttp.open(httpMethod, url, isAsync)
    xmlhttp.send()
}

function AddMedia() 
{
    $("#input_data").hide("fast",
                          function () {
                              $("#Loading").show("slow");
                              $("#playlist").hide("slow");
                          });
       
    
    var url = "http://localhost:5709/Radio/InsertMedia?url=" + document.getElementById('text_input').value;
    
    var callback =  function() 
	{
	    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) 
	    {
	        var playlist = eval('(' + xmlhttp.responseText + ')');
	        var result = '';
	            
	        for (var i = 0; i < playlist.length; i++) 
	        {
	            result += "<p class='music'>"+ playlist[i].Band + "-" + playlist[i].Song + "</p>";
	                
	        }

	        document.getElementById("playlist").innerHTML = result;

	        $("#Loading").hide("fast", 
	                            function () {
	                                $("#input_data").show("slow");
	                                $("#playlist").show("slow");
	                            });
	        
	    }
	}
    CreateAjaxCall(url, callback, "POST", true);
}

