const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/comments")
    .build();
hubConnection.on("Send", function (com) {
    let comment = document.createElement('div');
    let date = new Date().toLocaleString()
    comment.innerHTML = 
 `<div class="mt-3">
    <div class="com-img">
          <img src="/img/noavatar92.png" class="avatar" />
    </div>
    <div class="comment-contetnt ms-1">
          <span class="user-name">${com.nameUser}</span>
          <span>${date}</span>
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
$(() => {
    let comments = document.querySelectorAll(".date");
    for (let item of comments) {
        let invalidStringDate = item.dataset.date;
        let stringDate = invalidStringDate.slice(1, invalidStringDate.length - 1);
        let date = new Date(Date.parse(stringDate));
        let hoursOfsset = new Date().getTimezoneOffset() / 60;
        date.setHours(date.getHours() - hoursOfsset);
        let readyDateString = date.toLocaleString();
        item.innerHTML = readyDateString;
    }
});