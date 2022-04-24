const cookieName = "cart-items";

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

function ChangeCartCount(Id, TotalPrice, Count) {

    let products = $.cookie(cookieName);
    products = JSON.parse(products)
    let ItemIndex = products.findIndex(p => p.id == Id);

    products[ItemIndex].count = Count;
    const price = products[ItemIndex].unitPrice
    const newPrice = price * parseInt(Count);
    $(`#${TotalPrice}`).text(newPrice);
    $.cookie(cookieName, JSON.stringify(products), { expires: 2, path: "/" });
    updateCart();


    var settings = {
        "url": "https://localhost:7157/api/Inventory",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({
            "productid": Id,
            "count": Count
        }),
    };

    $.ajax(settings).done(function (data) {
        debugger
        if (data.isStock == false) {
            let errorMessage = $("#errorMessage")
            if ($(`#${Id}`).length == 0) {
                errorMessage.append(
                    `<div class="alert alert-info" id="${Id}">محصول${data.productName} از تعداد درخواستی شما در انبار کم تر است</div>
`
                );
            } else {
                if ($(`#${Id}`).length > 1) {
                    $(`#${Id}`).remove();
                }
            }
        } else {
            if (data.isStock == true) {
                $(`#${Id}`).remove();

            }
        }
    });
}