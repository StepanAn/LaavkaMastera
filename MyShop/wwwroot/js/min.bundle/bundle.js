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
'use strict';
$(function () {
    $('.remove').click(function () {
        let removeItem = $(this).parents('.item');
        let totalPriceTag = $(removeItem[0]).find('.total-price');
        let amountTag = $(removeItem[0]).find('.amount');
        let totalPrice = totalPriceTag[0].dataset.price;
        let amount = +$(amountTag[0]).html();
        editToolbar(-totalPrice, -amount);
        $(removeItem[0]).remove();
        chekAndRemoveCart();
    });
    $('.plus').click(plus);
    $('.minus').click(minus);
});
function plus() {
    edit(this, 1);
    chekAndRemoveCart();
}
function minus() {
    edit(this, -1);
    chekAndRemoveCart();
}
function edit(targetObject, changeValue) {
    let amountTag = $(targetObject).siblings('span');
    let parent = $(targetObject).parents('.item');
    let priceTag = $(parent[0]).find('.price');
    let totalPriceTag = $(parent[0]).find('.total-price');
    let price = +$(priceTag[0]).html();
    let amount = +$(amountTag[0]).html();
    amount += changeValue;
    if (amount == 0) {
        $(parent).remove();
    }
    let priceOffset = price * +changeValue;
    let totalPrice = price * amount;
    totalPriceTag[0].dataset.price = totalPrice;
    editToolbar(priceOffset, changeValue);
    $(totalPriceTag[0]).html(`${totalPrice},00&#8381;`);
    $(amountTag[0]).html(amount);
}
function editToolbar(priceOffset, amountOffset) {
    let allPriceTag = $('#all-price');
    let allPrice = +allPriceTag[0].dataset.allprice;
    let allAmount = +$('#all-amount').html();
    allPrice += +priceOffset;
    allAmount += +amountOffset;
    allPriceTag[0].dataset.allprice = allPrice;
    $(allPriceTag[0]).html(`${allPrice},00&#8381;`);
    $('#all-amount').html(allAmount);

}
function chekAndRemoveCart() {
    let allAmount = +$('#all-amount').html();
    if (!allAmount) {
        $('.container-lg').remove();
        $('#cart-content').html('<div class="h4 non">В вашей корзине нет товаров</div>');
    }
}
$(function () {
    let thisSlide = 0;
    let slideInterval = 8000;
    let sliders;
    sliders = $('#slider-controller').children();
    $('.kkk').hide('slow', 'linear');
    setInterval(() => {
        $(sliders[thisSlide]).hide('slow', 'linear');
        if (thisSlide >= sliders.length - 1) {
            thisSlide = 0;
        }
        else {
            ++thisSlide;
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
$(function () {
    $('.nline').mouseenter(function () {
        let line = $(this).children('hr');
        $(line[0]).animate({ width: '0%' }, 'slow', 'linear')
            .animate({ width: '100%' }, 'slow', 'linear');
    });
});