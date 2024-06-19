const quotesContainer = document.getElementById('memories__grid');
const pagination = document.getElementById('pagination');
const sortButton = document.getElementById('sortButton');

async function calculatetotal() {
  const response = await fetch('https://dummyjson.com/quotes');
  const data = await response.json();
  return data.total;
}


async function fetchData(isSorted) {
  const urlParams = new URLSearchParams(window.location.search);
  const currentPage = parseInt(urlParams.get('page') || 1);
  const itemsPerPage = parseInt(urlParams.get('limit') || 5);
  const skip = (currentPage - 1) * itemsPerPage;
  fetch(`https://dummyjson.com/quotes?limit=${itemsPerPage}&skip=${skip}`, {
      method: 'GET',
  }).then(async (response) => {
      var data = await response.json();
      console.log(data.quotes);
      if (isSorted) {
        data.quotes.sort((a, b) => {
          const authorA = a.author.toLowerCase();
          const authorB = b.author.toLowerCase();
          return authorA < authorB ? -1 : authorA > authorB ? 1 : 0;
        });
      }
      data.quotes.forEach(element => {
        console.log(element)
          renderProducts(element);
      });
      
  }).catch(error => {
      console.error(error);
  });
}

function createQuoteCard(product) {

  const memorycard = document.createElement('div');
  memorycard.classList.add('memories__card');

  const pq = document.createElement('p');
  pq.textContent = `"${product.quote}"`;
  console.log(product.quote)
  memorycard.appendChild(pq)

  const ha = document.createElement('h4');
  ha.textContent = `-${product.author}`;
  memorycard.appendChild(ha)

  return memorycard;
}


async function renderProducts(data) {
  const productCard = createQuoteCard(data);
  quotesContainer.appendChild(productCard);
}


function renderPagination(total, currentPage, itemsPerPage) {
    const totalPages = Math.ceil(total / itemsPerPage);
    const paginationElement = document.getElementById('pagination');
    paginationElement.innerHTML = ''; // Clear existing pagination
  
    const prevButton = document.createElement('a');
    prevButton.href = `?page=${currentPage - 1}&limit=${itemsPerPage}`;
    prevButton.textContent = 'Previous';
    prevButton.classList.add('pagination-link');
    if (currentPage === 1) {
      prevButton.classList.add('disabled');
      prevButton.removeAttribute('href');
    }
    paginationElement.appendChild(prevButton);
  
    const startPage = 1; // Start pagination from page 1
  
    for (let i = startPage; i <= Math.min(startPage + 4, totalPages); i++) {
      if (i === currentPage) {
        const currentPageSpan = document.createElement('span');
        currentPageSpan.textContent = i;
        currentPageSpan.classList.add('pagination-link', 'active');
        paginationElement.appendChild(currentPageSpan);
      } else {
        const pageLink = document.createElement('a');
        pageLink.href = `?page=${i}&limit=${itemsPerPage}`;
        pageLink.textContent = i;
        pageLink.classList.add('pagination-link');
        paginationElement.appendChild(pageLink);
      }
    }
  
    if (currentPage < totalPages) {
      const nextButton = document.createElement('a');
      nextButton.href = `?page=${currentPage + 1}&limit=${itemsPerPage}`;
      nextButton.textContent = 'Next';
      nextButton.classList.add('pagination-link');
      paginationElement.appendChild(nextButton);
    }
  }

async function run(){
    const total = await calculatetotal();
    const urlParams = new URLSearchParams(window.location.search);
    const currentPage = parseInt(urlParams.get('page') || 1);
    const itemsPerPage = parseInt(urlParams.get('limit') || 5);
    fetchData(false);
    renderPagination(total, currentPage, itemsPerPage);
  }
  
  run()

  sortButton.addEventListener('click', () => {
    fetchData(true); // Call fetchData with sorting flag
  });


  