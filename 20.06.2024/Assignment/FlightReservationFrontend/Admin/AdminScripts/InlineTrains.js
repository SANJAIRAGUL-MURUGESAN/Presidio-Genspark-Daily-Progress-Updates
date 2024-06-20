const productsContainer = document.getElementById('products-container');
const pagination = document.getElementById('pagination');

async function calculatetotal() {

    const response = await fetch('http://localhost:5062/api/Admin/GetAllInlineTrainsByAdminTotal', {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer '+localStorage.getItem('token'),
            'Content-Type': 'application/json',
         },
    })

    if (!response.ok) {
        const data = await res.json();
        console.log(data.errorCode)
        alert(data.message);
    }

    const count = await response.json();
    console.log("Total Inline Trains:", count);
    return count; 
}

async function fetchData(total) {
    const urlParams = new URLSearchParams(window.location.search);
    const currentPage = parseInt(urlParams.get('page') || 1);
    const itemsPerPage = parseInt(urlParams.get('limit') || 10);
    const skip = (currentPage - 1) * itemsPerPage;
    fetch(`http://localhost:5062/api/Admin/GetAllInlineTrainsByAdmin?limit=${itemsPerPage}&skip=${skip}`, {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer '+localStorage.getItem('token'),
            'Content-Type': 'application/json',
         },
    }).then(async (response) => {
        var data = await response.json();
        // console.log(data);
        data.forEach(element => {
            console.log(element)
            renderProducts(element);
        });
        createPagination(total, currentPage, itemsPerPage);
    }).catch(error => {
        console.error(error);
    });
}


function createTrainCard(product) {

    const card = document.createElement('div');
    card.classList.add('col', 'mb-3');
  
    const cardInner = document.createElement('div');
    cardInner.classList.add('card');
  
    const cardImg = document.createElement('img');
    cardImg.classList.add('card-img-top');
    cardImg.src = "../assets/traincard1.jpg"; 
    cardInner.appendChild(cardImg);
  
    const cardBody = document.createElement('div');
    cardBody.classList.add('card-body');
  
    const cardTitle = document.createElement('h5');

    cardTitle.classList.add('card-title');
    cardTitle.textContent = product.trainName; 
    cardBody.appendChild(cardTitle);

    const cardText = document.createElement('p');
    cardText.classList.add('card-text');
    cardText.textContent = product.description;
    cardBody.appendChild(cardText);
    // <i class="far fa-map-marker-alt"></i>

    // const iconElement = document.createElement('i');
    // iconElement.classList.add('far', 'fa-map-marker-alt');

    // const cardText2 = document.createElement('p');
    // cardText2.classList.add('card-text')
    // cardText2.textContent = "Train Departure platform : "+product.startingPoint;
    // cardBody.appendChild(iconElement)
    // cardBody.appendChild(cardText2);

    // Create a <span> element to wrap the text
    // const iconElement = document.createElement('i');
    // iconElement.classList.add('bi','bi-geo-alt-fill')
    const textSpan = document.createElement('span');
    textSpan.innerHTML = `<span style="color : red"><i class="bi bi-geo-alt-fill"></i></span> <span style="font-weight: bold;"> Train Departure platform:</span> <span style="color: red">${product.startingPoint}</span>`;
    const cardText2 = document.createElement('p');
    cardText2.classList.add('card-text');
    // cardText2.appendChild(iconElement);
    cardText2.appendChild(textSpan);
    cardBody.appendChild(cardText2);



    const cardText3 = document.createElement('p');
    cardText3.classList.add('card-text')
    cardText3.textContent = "Train Destination city : "+product.endingPoint;
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
    const productCard = await createTrainCard(data);
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


