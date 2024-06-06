let minPrice = 0;
let maxPrice = 1000000;
let description = '';
let categoryIds = '';


const getAllProducts = async () => {
    const response = await fetch(`api/products?minPrice=${minPrice}&maxPrice=${maxPrice}&description=${description}${categoryIds}`);
    if (response.ok) {
        const products = await response.json();

        drawProducts(products);
        if (minPrice === 0 || minPrice === "" || maxPrice === "") {
            UpdateMinMaxPrice(products);
        }
        
        document.getElementById('ItemsCountText').textContent = amountOfBasket();
    }
    else {
        const massage = document.createElement('span');
        massage.textContent = "אופס! משהו השתבש...";
        document.getElementById('ProductList').appendChild(massage);
    }
}


const amountOfBasket = () => {
    const quantity = JSON.parse(sessionStorage.getItem("quantity")) || 0;
    return quantity;
}


const drawProducts = (products) => {
    const template = document.getElementById('temp-card');
    let counter = 0;

    products.forEach(product => {
        const clone = template.content.cloneNode(true);

        clone.querySelector('img').src = `Images/${product.imageUrl}`;
        clone.querySelector('h1').textContent = product.title;
        clone.querySelector('.price').textContent = "₪" + product.price;
        clone.querySelector('.description').textContent = product.productName;
        clone.querySelector('button').addEventListener('click', () => { addProductToBasket(product) });

        counter++;
        document.getElementById('ProductList').appendChild(clone);
        const counterSpan = document.getElementById('counter');
        counterSpan.textContent = counter;
    });
}


const addProductToBasket = (product) => {
    let basket = JSON.parse(sessionStorage.getItem('basket'));
    if (basket == null) {
        basket = [{ "product": product, "quantity": 1 }];

    }
    else {
        const index = basket.findIndex(p => p.product.productId === product.productId);
        if (index === -1) {
            basket = [...basket, { "product": product, "quantity": 1 }];
        }
        else {
            basket[index].quantity++;
        }
    }
    sessionStorage.setItem('basket', JSON.stringify(basket));
    let count = document.getElementById('ItemsCountText');
    count.textContent++;
    updateSessionStorageQuantity();
    updateSessionStoragePrice(product);
}


const updateSessionStorageQuantity = () => {
    let quantity = JSON.parse(sessionStorage.getItem('quantity'));
    if (quantity == null) {
        quantity = 1;
    }
    else {
        quantity++;
    }
    sessionStorage.setItem('quantity', JSON.stringify(quantity));
}


const updateSessionStoragePrice = (product) => {
    let price = JSON.parse(sessionStorage.getItem('price'));
    if (price == null) {
        price = product.price;
    }
    else {
        price += product.price;
    }
    sessionStorage.setItem('price', JSON.stringify(price));
}


const UpdateMinMaxPrice = (products) => {
    let min = 1000000;
    let max = 0;
    products.forEach(p => {
        if (p.price < min) {
            min = p.price;
        }
        if (p.price > max) {
            max = p.price;
        }
    })
    minPrice = min;
    document.getElementById('minPrice').value = min;
    maxPrice = max;
    document.getElementById('maxPrice').value = max;
}


const getAllCategories = async () => {
    const response = await fetch('api/categories');
    if (response.ok) {
        const categories = await response.json();
        drawCategories(categories);
    }
}


const drawCategories = (categories) => {
    const template = document.getElementById('temp-category');

    categories.forEach(category => {
        const clone = template.content.cloneNode(true);

        clone.querySelector('.opt').id = category.categoryId;
        clone.querySelector('.opt').value = category.value;
        clone.querySelector('label').setAttribute('for', category.categoryId);
        clone.querySelector('.OptionName').textContent = category.categoryName;
        clone.querySelector('.Count').textContent = category.count;
        clone.querySelector('input').addEventListener('click', () => {
            filterProducts();
        })

        document.getElementById('categoryList').appendChild(clone);
    });
}


const filterProducts = () => {
    minPrice = document.getElementById('minPrice').value;
    maxPrice = document.getElementById('maxPrice').value;
    description = document.getElementById('nameSearch').value;
    

    const opt = document.getElementsByClassName('opt');
    const optArray = Array.from(opt);

    categoryIds = '';
    optArray.forEach(c => {
        if (c.checked) {
            categoryIds += `&categoryIds=${c.id}` ;
        }
    })
    productList = document.getElementById('ProductList').replaceChildren();

    getAllProducts();
}


getAllProducts();
getAllCategories();