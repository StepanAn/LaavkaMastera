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
$(function () {
    $('.remove').click(function () {
        var removeItem = $(this).parents('tr');
        $(removeItem[0]).remove();
        var idents = $('tbody').find('.ident');
        for (var i = 0; i < idents.length; i++) {
            $(idents[i]).html(i + 1);
        }
    });
    $('.plus').click(Plus);
    $('.minus').click(Minus);
});
function Plus(/*i = 1*/) {
    var amount = $(this).siblings('span');
    var parent = $(this).parents('tr');
    var priceTag = $(parent[0]).find('.price');
    var totalPriceTag = $(parent[0]).find('.total-price');
    var price = $(priceTag[0]).html();
    var colvo = $(amount[0]).html();
    /*if(i==1)*/
    colvo++;
    var totalPrice = price * colvo;
    $(totalPriceTag[0]).html(totalPrice);
    $(amount[0]).html(colvo);
}
function Minus() {
    var amount = $(this).siblings('span');
    var parent = $(this).parents('tr');
    var priceTag = $(parent[0]).find('.price');
    var totalPriceTag = $(parent[0]).find('.total-price');
    var price = $(priceTag[0]).html();
    var colvo = $(amount[0]).html();
    colvo--;
    if (colvo == 0) {
        $(parent).remove();
        var idents = $('tbody').find('.ident');
        for (var i = 0; i < idents.length; i++) {
            $(idents[i]).html(i + 1);
        }
    }
    var totalPrice = price * colvo;
    $(totalPriceTag[0]).html(totalPrice);
    $(amount[0]).html(colvo);
}
var thisSlide = 0;
var slideInterval = 2000;
var sliders;
$(function () {
    sliders = $('#slider-controller').children();
    $('.kkk').hide('slow', 'linear');
    setInterval(function () {
        $(sliders[thisSlide]).hide('slow', 'linear');
        if (thisSlide >= sliders.length - 1) {
            thisSlide = 0;
        }
        else {
            thisSlide++;
        }
        $(sliders[thisSlide]).show('slow', 'linear');
    }, slideInterval);

})

$(function () {
    var open = false;
    $('#button').width(30).height(30);

    $('#button').click(function () {
        if (open != true) {
            $('#menu').animate({ left: '0px' }, 'slow', 'linear');
            $('#button').animate({ 'margin-left': '350px' }, 'slow', 'linear');
            open = true;
        }
        else {
            $('#menu').animate({ left: '-350px' }, 'slow', 'linear');
            $('#button').animate({ 'margin-left': '0px' }, 'slow', 'linear');
            open = false;
        }
    })
})