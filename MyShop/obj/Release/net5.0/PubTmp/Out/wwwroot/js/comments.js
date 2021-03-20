const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/comments")
    .build();
hubConnection.on("Send", function (com) {
    var comment = document.createElement('div');
    comment.innerHTML = "<img src=\"/img/noavatar92.png\" class=\"avatar\" /> <div class=\"comment-contetnt\"> <span class=\"user-name\">" + com.nameUser + "</span> <span>" + com.commentDate + "</span> <p>" + com.letter + "</p> </div>";
    $('#comment-box').prepend(comment);
});
$('#send-button').click(function () {
    if ($('#comment').val() != "") {
        var comment = $('#comment').val();
        var userName = $('#user-name').val();
        hubConnection.invoke("Send", { "NameUser": userName, "Letter": comment });
        $('#comment').val("");
    }
});
hubConnection.start();