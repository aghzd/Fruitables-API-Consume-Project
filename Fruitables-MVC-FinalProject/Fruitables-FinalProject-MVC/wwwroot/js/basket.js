//"use strict";
//function addToBasket(productId) {
//    fetch("https://localhost:7178/api/Basket/Add", {
//        method: "POST",
//        headers: {
//            "Content-Type": "application/json"
//        },
//        credentials: "include",
//        body: JSON.stringify({
//            productId: productId,
//            quantity: 1
//        })
//    })
//        .then(() => loadBasket());
//}

////function loadBasket() {
////    fetch("https://localhost:7178/api/Basket/Get", {
////        credentials: "include"
////    })
////        .then(res => res.json())
////        .then(data => {
////            let html = "";
////            data.basketItems.forEach(item => {
////                html += `
////                    <div>
////                        ${item.productName} - ${item.quantity}
////                        <button onclick="deleteItem(${item.productId})">X</button>
////                    </div>`;
////            });
////            document.getElementById("basket").innerHTML = html;
////        });
////}

////function loadBasket() {
////    fetch("https://localhost:7178/api/Basket/Get", {
////        credentials: "include"
////    })
////        .then(res => res.json())
////        .then(data => {
////            let html = "";
////            let total = 0;

////            data.basketItems.forEach(item => {
////                let itemTotal = item.price * item.quantity;
////                total += itemTotal;

////                html += `
////                    <div>
////                        ${item.productName} - ${item.quantity} x ${item.price} = ${itemTotal.toFixed(2)} ₼
////                        <button onclick="deleteItem(${item.productId})">X</button>
////                    </div>`;
////            });

////            html += `<hr />
////                     <strong>Total: ${total.toFixed(2)} ₼</strong>`;

////            document.getElementById("basket").innerHTML = html;
////        });
////}


//function loadBasket() {
//    fetch("https://localhost:7178/api/Basket/Get", {
//        credentials: "include"
//    })
//        .then(res => res.json())
//        .then(data => {
//            let html = "";
//            let total = 0;

//            data.basketItems.forEach(item => {
//                let itemTotal = item.price * item.quantity;
//                total += itemTotal;

//                html += `
//            <tr>
//                <td>${item.productName}</td>
//                <td>${item.price} ₼</td>
//                <td>${item.quantity}</td>
//                <td>${itemTotal.toFixed(2)} ₼</td>
//                <td>
//                    <button onclick="deleteItem(${item.productId})"
//                        class="btn btn-sm btn-danger">
//                        <i class="fa fa-times"></i>
//                    </button>
//                </td>
//            </tr>`;
//            });

//            document.getElementById("basket-body").innerHTML = html;
//            document.getElementById("basket-total").innerHTML =
//                `<strong>Total: ${total.toFixed(2)} ₼</strong>`;
//        });
//}

//function deleteItem(productId) {
//    fetch(`https://localhost:7178/api/Basket/Delete/${productId}`, {
//        method: "DELETE",
//        credentials: "include"
//    })
//        .then(() => loadBasket());
//}

//loadBasket();






document.querySelectorAll(".add-to-basket-btn").forEach(btn => {
    btn.addEventListener("click", function (e) {
        e.preventDefault();
        const productId = parseInt(this.dataset.id);
        addToBasket(productId);
    });
});

function addToBasket(productId) {
    fetch("https://localhost:7178/api/Basket/Add", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        credentials: "include",
        body: JSON.stringify({ productId: productId, quantity: 1 })
    }).then(() => loadBasket());
}

// Basket-i yüklə
function loadBasket() {
    fetch("https://localhost:7178/api/Basket/Get", { credentials: "include" })
        .then(res => res.json())
        .then(data => {
            let html = "";
            let total = 0;

            data.basketItems.forEach(item => {
                let itemTotal = item.price * item.quantity;
                total += itemTotal;

                html += `
                    <tr>
                        <td>${item.productName}</td>
                        <td>${item.price} ₼</td>
                        <td>
                            <div class="input-group quantity" style="width: 120px;">
                                <button class="btn btn-sm btn-minus" onclick="updateQuantity(${item.productId}, ${item.quantity - 1})">-</button>
                                <input type="text" class="form-control text-center" value="${item.quantity}" readonly>
                                <button class="btn btn-sm btn-plus" onclick="updateQuantity(${item.productId}, ${item.quantity + 1})">+</button>
                            </div>
                        </td>
                        <td>${itemTotal.toFixed(2)} ₼</td>
                        <td>
                            <button class="btn btn-sm btn-danger" onclick="deleteItem(${item.productId})">
                                <i class="fa fa-times"></i>
                            </button>
                        </td>
                    </tr>`;
            });

            document.getElementById("basket-body").innerHTML = html;
            document.getElementById("basket-total").innerHTML =
                `<strong>Total: ${total.toFixed(2)} ₼</strong>`;
        });
}

// Məhsulu basket-dən sil
function deleteItem(productId) {
    fetch(`https://localhost:7178/api/Basket/Delete/${productId}`, {
        method: "DELETE",
        credentials: "include"
    }).then(() => loadBasket());
}

// Məhsulun sayını yenilə
function updateQuantity(productId, quantity) {
    if (quantity < 1) return; // 0-dan aşağı olmasın

    fetch(`https://localhost:7178/api/Basket/Update`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        credentials: "include",
        body: JSON.stringify({ productId: productId, quantity: quantity })
    }).then(() => loadBasket());
}

// Səhifə yüklənəndə basket-i göstər
loadBasket();