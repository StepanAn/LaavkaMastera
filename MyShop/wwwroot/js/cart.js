'use strict';
$(function () {
    $('.remove').click(function () {
        let removeItem = $(this).parents('.item');
        let totalPriceTag = $(removeItem[0]).find('.total-price');
        let amountTag = $(removeItem[0]).find('.amount');
        let totalPrice = +$(totalPriceTag[0]).html();
        let amount = +$(amountTag[0]).html();
        editToolbar(-totalPrice, -amount);
        //var allPrice = $('#all-price').html();
        //var allAmount = $('#all-amount').html();
        //allAmount -= $(amount).html();
        //allPrice -= $(totalPriceTag).html();
        //$('#all-price').html(allPrice);
        //$('#all-amount').html(allAmount);
        //allPrice -= $(totalPriceTag).html();
        $(removeItem[0]).remove();
        chekAndRemoveCart();
    });
    $('.plus').click(plus);
    $('.minus').click(minus);
});
function plus() {
    //var amount = $(this).siblings('span');
    //var parent = $(this).parents('.item');
    //var priceTag = $(parent[0]).find('.price');
    //var totalPriceTag = $(parent[0]).find('.total-price');
    //var price = $(priceTag[0]).html();
    //var colvo = $(amount[0]).html();
    //var allPrice = $('#all-price').html();
    //var allAmount = $('#all-amount').html();
    //colvo++;
    //allAmount++;
    //var totalPrice = price * colvo;
    //$(totalPriceTag[0]).html(totalPrice);
    //$(amount[0]).html(colvo);
    //var newAllPrice = parseInt(price) + parseInt(allPrice);
    //$('#all-price').html(newAllPrice);
    //$('#all-amount').html(allAmount);
    edit(this, 1);
    chekAndRemoveCart();
}
function minus() {
    //var amount = $(this).siblings('span');
    //var parent = $(this).parents('.item');
    //var priceTag = $(parent[0]).find('.price');
    //var totalPriceTag = $(parent[0]).find('.total-price');
    //var price = $(priceTag[0]).html();
    //var colvo = $(amount[0]).html();
    //var allPrice = $('#all-price').html();
    //var allAmount = $('#all-amount').html();
    //colvo--;
    //allAmount--;
    //if (colvo == 0) {
    //    $(parent).remove();
    //}
    //var totalPrice = price * colvo;
    //$(totalPriceTag[0]).html(totalPrice);
    //$(amount[0]).html(colvo);
    //var newAllPrice = parseInt(allPrice) - parseInt(price);
    //$('#all-price').html(newAllPrice);
    //$('#all-amount').html(allAmount);
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
    let priceOffset = price * changeValue;
    let totalPrice = price * amount;
    editToolbar(priceOffset, changeValue);
    $(totalPriceTag[0]).html(totalPrice);
    $(amountTag[0]).html(amount);
}
function editToolbar(priceOffset, amountOffset) {
    let allPrice = +$('#all-price').html();
    let allAmount = +$('#all-amount').html();
    allPrice += +priceOffset;
    allAmount += +amountOffset;
    $('#all-price').html(allPrice);
    $('#all-amount').html(allAmount);

}
function chekAndRemoveCart() {
    let allAmount = +$('#all-amount').html();
    if (!allAmount) {
        $('.container-lg').remove();
        $('#cart-content').html('<div class="h4 non">В вашей корзине нет товаров</div>');
    }
}