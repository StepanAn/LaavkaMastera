$(function () {
    $('.nline').mouseenter(function () {
        let line = $(this).children('hr');
        $(line[0]).animate({ width: '0%' }, 'slow', 'linear')
            .animate({ width: '100%' }, 'slow', 'linear');
    });
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