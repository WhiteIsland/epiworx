<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<div id="find">
    <input type="text" id="FindText" value="<%= this.Request.QueryString["text"] %>" /><img src="<%: this.Url.Content("~/Content/Find.png") %>" alt="Find" id="FindButton" />
</div>
<script type="text/javascript">
    $('#FindButton').click(function () {
       find();
    });
 
    $('#FindText').keypress(function(event) { 
	    var keycode = (event.keyCode ? event.keyCode : event.which);
	    if(keycode == '13'){
		    find();
	    }
    });

    function find() {
        var url = "<%= this.Url.Action("Index", "Task") %>";
        var value = $("#FindText").val();
        if (value != "") {
            url = url + "?text=" + value;
            location.href = url;
        }
    }
</script>
