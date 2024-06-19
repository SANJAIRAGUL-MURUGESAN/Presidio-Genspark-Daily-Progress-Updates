const quotesContainer = document.getElementById('memories__grid');
const pagination = document.getElementById('pagination');

async function calculatetotal() {
  const response = await fetch('https://dummyjson.com/quotes');
  const data = await response.json();
  return data.total;
}


async function fetchData(total) {
  const urlParams = new URLSearchParams(window.location.search);
  const currentPage = parseInt(urlParams.get('page') || 1);
  const itemsPerPage = parseInt(urlParams.get('limit') || 10);
  const skip = (currentPage - 1) * itemsPerPage;
  fetch(`https://dummyjson.com/quotes?limit=${itemsPerPage}&skip=${skip}`, {
      method: 'GET',
  }).then(async (response) => {
      var data = await response.json();
      console.log(data.quotes);
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
  pq.textContent = product.quote;
  console.log(product.quote)
  memorycard.appendChild(pq)

  const ha = document.createElement('h4');
  ha.textContent = product.author;
  memorycard.appendChild(ha)

  return memorycard;
}


async function renderProducts(data) {
  const productCard = createQuoteCard(data);
  quotesContainer.appendChild(productCard);
}


async function run(){
    const total = await calculatetotal();
    fetchData(total);
  }
  
  run()