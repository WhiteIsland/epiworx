<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Epiworx.WebMvc.Models.ModelBase>" %>
<div id="find">
    <input type="text" id="FindText" placeholder="Search for..." value="<%= this.Request.QueryString["text"] %>" /><img src="<%: this.Url.Content("~/Content/Find.png") %>" alt="Find" id="FindButton" />
    <select id="FindCategory">
        <option value="Hour"<% if (Model.FindCategory == "Hour") { %> selected="selected"<%} %>>Hours</"option>
        <option value="Task"<% if (Model.FindCategory == "Task") { %> selected="selected"<%} %>>Tasks</"option>
    </select>
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
        var url = "<%= this.Url.Action("Index", "") %>";
        var value = $("#FindText").val();
        if (value != "") {
            url = url + $("#FindCategory").val();
            url = url + "?isArchived=0&text=" + value;
            location.href = url;
        }
    }
</script>
