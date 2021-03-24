const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/comments")
    .build();
hubConnection.on("Send", function (com) {
    let comment = document.createElement('div');
    comment.innerHTML = 
 `<div class="mt-3">
    <div class="com-img">
          <img src="/img/noavatar92.png" class="avatar" />
    </div>
    <div class="comment-contetnt ms-1">
          <span class="user-name">${com.nameUser}</span>
          <span>${com.commentDate}</span>
          <p>${com.letter}</p>
    </div>
 </div>`;
    $('#comment-box').prepend(comment);
});
$('#send-button').click(function () {
    if ($('#comment').val() != "") {
        let comment = $('#comment').val();
        let userName = $('#user-name').val();
        hubConnection.invoke("Send", { "NameUser": userName, "Letter": comment });
        $('#comment').val("");
    }
});
hubConnection.start();