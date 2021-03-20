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