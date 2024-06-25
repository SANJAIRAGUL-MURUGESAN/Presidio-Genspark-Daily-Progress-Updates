// Toggle mobile navigation menu
const menuButton = document.querySelector('.btn2');
const mobileNavLinks = document.querySelector('.nav__links--mobile');

menuButton.addEventListener('click', () => {
mobileNavLinks.style.display =
  mobileNavLinks.style.display === 'flex' ? 'none' : 'flex';
});


