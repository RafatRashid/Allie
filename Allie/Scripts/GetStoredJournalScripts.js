$(document).ready(function () {
    $("#inputdiv").show();
    $("#outputdiv").hide();

    $("#view").click(function () {
        $("#inputdiv").hide();
        $("#outputdiv").show();
    });
});