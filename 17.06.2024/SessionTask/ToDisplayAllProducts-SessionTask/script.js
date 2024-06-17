const productsContainer = document.getElementById('products-container');
const pagination = document.getElementById('pagination');

async function calculatetotal() {
    const response = await fetch('https://dummyjson.com/products');
    const data = await response.json();
    console.log("Total products:", data.total);
    return data.total;
}

async function fetchData(total) {
    const urlParams = new URLSearchParams(window.location.search);
    const currentPage = parseInt(urlParams.get('page') || 1);
    const itemsPerPage = parseInt(urlParams.get('limit') || 10);
    const skip = (currentPage - 1) * itemsPerPage;
    fetch(`https://dummyjson.com/products?limit=${itemsPerPage}&skip=${skip}`, {
        method: 'GET',
    }).then(async (response) => {
        var data = await response.json();
        console.log(data.products);
        data.products.forEach(element => {
            renderProducts(element);
        });
        createPagination(total, currentPage, itemsPerPage);
    }).catch(error => {
        console.error(error);
    });
}


function createProductCard(product) {

    const card = document.createElement('div');
    card.classList.add('col', 'mb-3');
  
    const cardInner = document.createElement('div');
    cardInner.classList.add('card');
  
    const cardImg = document.createElement('img');
    cardImg.classList.add('card-img-top');
    cardImg.src = "./Images/dish2.jpg"; 
    cardInner.appendChild(cardImg);
  
    const cardBody = document.createElement('div');
    cardBody.classList.add('card-body');
  
    const cardTitle = document.createElement('h5');

    cardTitle.classList.add('card-title');
    cardTitle.textContent = product.title; 
    cardBody.appendChild(cardTitle);

    const cardText = document.createElement('p');
    cardText.classList.add('card-text');
    cardText.textContent = product.description;
    cardBody.appendChild(cardText);

    const cardText2 = document.createElement('p');
    cardText2.classList.add('card-text')
    cardText2.textContent = "Discount Percentage : "+product.discountPercentage;
    cardBody.appendChild(cardText2);

    const cardText3 = document.createElement('p');
    cardText3.classList.add('card-text')
    cardText3.textContent = "Rating : "+product.rating+" /5";
    cardBody.appendChild(cardText3);

    const cardText4 = document.createElement('p');
    cardText4.classList.add('card-text')
    cardText4.textContent = "Warranty Info : "+product.warrantyInformation;
    cardBody.appendChild(cardText4);

    const cardText5 = document.createElement('p');
    cardText5.classList.add('card-text')
    cardText5.textContent = "Shipping Info : "+product.shippingInformation;
    cardBody.appendChild(cardText5);
  
    const bottomRow = document.createElement('div');
    bottomRow.classList.add('mb-5', 'd-flex', 'justify-content-between');
  
    const price = document.createElement('h3');
    price.textContent = `$${product.price}`;
    bottomRow.appendChild(price);
  
    const buyButton = document.createElement('button');
    buyButton.classList.add('btn', 'btn-primary');
    buyButton.textContent = 'Buy Now';
    bottomRow.appendChild(buyButton);
  
    cardBody.appendChild(bottomRow);
    cardInner.appendChild(cardBody);
    card.appendChild(cardInner);
  
    return card;
  }

  async function renderProducts(data) {
    productsContainer.innerHTML = ''; 
    const productCard = await createProductCard(data);
    console.log(productCard.title)
    productsContainer.appendChild(productCard);
  }

  function createPagination(totalProducts, currentPage, itemsPerPage) {
    const paginationContainer = document.getElementById('pagination');
    paginationContainer.innerHTML = ''; 
  
    const totalPages = Math.ceil(totalProducts / itemsPerPage);
  
    let prevButton;
    if (currentPage > 1) {
      prevButton = document.createElement('a');
      prevButton.classList.add('page-link');
      prevButton.href = `?page=${currentPage - 1}&limit=${itemsPerPage}`;
      prevButton.textContent = 'Previous';
      paginationContainer.appendChild(prevButton);
    }
  
    for (let i = 1; i <= totalPages; i++) {
      const pageLink = document.createElement('a');
      pageLink.classList.add('page-link');
      pageLink.href = `?page=${i}&limit=${itemsPerPage}`;
      pageLink.textContent = i;
      if (i === currentPage) {
        pageLink.classList.add('active');
      }
      paginationContainer.appendChild(pageLink);
    }
  
    let nextButton;
    if (currentPage < totalPages) {
      nextButton = document.createElement('a');
      nextButton.classList.add('page-link');
      nextButton.href = `?page=${currentPage + 1}&limit=${itemsPerPage}`;
      nextButton.textContent = 'Next';
      paginationContainer.appendChild(nextButton);
    }
  }

  async function run(){
    const total = await calculatetotal();
    console.log("Total:", total);
    fetchData(total);
  }
  
  run()


