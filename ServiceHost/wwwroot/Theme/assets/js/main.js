﻿const cookieName = "cart-items";

function addToCart(id, name, price, picture) {
    let products = $.cookie(cookieName);
    if (products === undefined) {
        products = [];
    } else {
        products = JSON.parse(products);
    }

    const count = $("#productCount").val();
    const currentProduct = products.find(x => x.id === id);
    if (currentProduct !== undefined) {
        products.find(x => x.id === id).count = parseInt(currentProduct.count) + parseInt(count);
    } else {
        const product = {
            id,
            name,
            unitPrice: price,
            picture,
            count
        }

        products.push(product);
    }

    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();
}

function updateCart() {
    var products = $.cookie(cookieName);
    products = JSON.parse(products);
    $("#cart_items_count").text(products.length)

    let cartItems = $("#cart_items_wrapper")
    cartItems.html('');

    products.forEach(x => {
        const product = `<div class="single-cart-item">
                            <a href="javascript:void(0)" class="remove-icon" onclick="removeFromCart('${x.id}')">
                                <i class="ion-android-close"></i>
                            </a>
                            <div class="image">
                                <a href="single-product.html">
                                    <img src="/UpdolerFile/${x.picture}"
                                         class="img-fluid" alt="">
                                </a>
                            </div>
                            <div class="content">
                                <p class="product-title">
                                    <a href="single-product.html">محصول: ${x.name}</a>
                                </p>
                                <p class="count">تعداد: ${x.count}</p>
                                <p class="count">قیمت واحد: ${x.unitPrice}</p>
                            </div>
                        </div>`;

        cartItems.append(product);


    });

}

function removeFromCart(id) {
    let products = $.cookie(cookieName)
    products = JSON.parse(products)
    let product = products.findIndex(x => x.id === id)
    products.splice(product, 1)
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart()
}