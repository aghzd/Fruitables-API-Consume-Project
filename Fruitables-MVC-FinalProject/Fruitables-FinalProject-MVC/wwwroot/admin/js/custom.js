"use strict";




let deleteProductImageBtns = document.querySelectorAll(".delete-pimg-btn");

deleteProductImageBtns.forEach(btn => {
    btn.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        fetch('/Admin/ProductImage/Delete/' + id, {
            method: 'POST'
        })
            .then(res => res.text())
            .then(res => {
                btn.parentNode.parentNode.remove();
            })
    })
});





let deleteSliderImageBtns = document.querySelectorAll(".delete-simg-btn");

deleteSliderImageBtns.forEach(btn => {
    btn.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        fetch('/Admin/SliderImage/Delete/' + id, {
            method: 'POST'
        })
            .then(res => res.text())
            .then(res => {
                btn.parentNode.parentNode.remove();
            })
    })
});


let deleteCategoryBtns = document.querySelectorAll(".delete-categ-btn");

deleteCategoryBtns.forEach(btn => {
    btn.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        fetch('/Admin/Category/Delete/' + id, {
            method: 'POST'
        })
            .then(res => res.text())
            .then(res => {
                btn.parentNode.parentNode.remove();
            })
    })
}); 


let deleteProductBtns = document.querySelectorAll(".delete-product-btn");

deleteProductBtns.forEach(btn => {
    btn.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        fetch('/Admin/Product/Delete/' + id, {
            method: 'POST'
        })
            .then(res => res.text())
            .then(res => {
                btn.parentNode.parentNode.remove();
            })
    })
}); 


let deleteSliderInfoBtns = document.querySelectorAll(".delete-sinfo-btn");

deleteSliderInfoBtns.forEach(btn => {
    btn.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        fetch('/Admin/SliderInfo/Delete/' + id, {
            method: 'POST'
        })
            .then(res => res.text())
            .then(res => {
                btn.parentNode.parentNode.remove();
            })
    })
}); 


let deleteStatsCardBtns = document.querySelectorAll(".delete-scard-btn");

deleteStatsCardBtns.forEach(btn => {
    btn.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        fetch('/Admin/StatsCard/Delete/' + id, {
            method: 'POST'
        })
            .then(res => res.text())
            .then(res => {
                btn.parentNode.parentNode.remove();
            })
    })
}); 




let deleteStoreFeatureBtns = document.querySelectorAll(".delete-sfeature-btn");

deleteStoreFeatureBtns.forEach(btn => {
    btn.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        fetch('/Admin/StoreFeature/Delete/' + id, {
            method: 'POST'
        })
            .then(res => res.text())
            .then(res => {
                btn.parentNode.parentNode.remove();
            })
    })
}); 


let deleteProductOfferBtns = document.querySelectorAll(".delete-poffer-btn");

deleteProductOfferBtns.forEach(btn => {
    btn.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        fetch('/Admin/ProductOffer/Delete/' + id, {
            method: 'POST'
        })
            .then(res => res.text())
            .then(res => {
                btn.parentNode.parentNode.remove();
            })
    })
}); 


let deleteContactBtns = document.querySelectorAll(".delete-contact-btn");

deleteContactBtns.forEach(btn => {
    btn.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        fetch('/Admin/Contact/Delete/' + id, {
            method: 'POST'
        })
            .then(res => res.text())
            .then(res => {
                btn.parentNode.parentNode.remove();
            })
    })
});