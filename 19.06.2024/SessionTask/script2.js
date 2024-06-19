const quotesContainer = document.getElementById('memories__grid');
const pagination = document.getElementById('pagination');
var quotes = [];
const authorname = document.getElementById('authorname');

async function calculatetotal() {
  const response = await fetch('https://dummyjson.com/quotes');
  const data = await response.json();
  var count = 0;
  data.quotes.forEach(element => {
    if(element.author == "Rumi"){
      console.log('Inside')
      quotes.push(element)
      count = count+1;
    }
  });
  return count;
}


async function fetchData(total) {

  console.log(authorname.value)
  // Fetch all quotes
  const response = await fetch('https://dummyjson.com/quotes');
  const data = await response.json();

  // Filter quotes by author "Rumi"
  const ramuQuotes = data.quotes.filter(element => element.author === authorname.value.trim());

  // Implement pagination logic
  const itemsPerPage = 5;
  const numPages = Math.ceil(total / itemsPerPage);

  // Assuming pagination is a global variable
  pagination.innerHTML = ''; // Clear previous pagination links

  for (let page = 1; page <= numPages; page++) {
    const pageButton = document.createElement('button');
    pageButton.textContent = page;
    pageButton.addEventListener('click', () => {
      displayQuotes(ramuQuotes, page, itemsPerPage);
    });
    pagination.appendChild(pageButton);
  }

  // Display initial page
  displayQuotes(ramuQuotes, 1, itemsPerPage);
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

function displayQuotes(quotes, currentPage, itemsPerPage) {
  // Clear existing quotes
  quotesContainer.innerHTML = '';

  // Calculate start and end index for current page
  const startIndex = (currentPage - 1) * itemsPerPage;
  const endIndex = startIndex + itemsPerPage;

  // Slice the quotes array for the current page
  const currentQuotes = quotes.slice(startIndex, endIndex);

  // Render quotes for the current page
  currentQuotes.forEach(quote => {
    renderProducts(quote);
  });
}



  form.addEventListener('submit',async(e)=>{
    e.preventDefault();
    const total = await calculatetotal();
    if(total == 0){
      alert('No Quotes found for your author search')
      return
    }
    fetchData(total);
})
  