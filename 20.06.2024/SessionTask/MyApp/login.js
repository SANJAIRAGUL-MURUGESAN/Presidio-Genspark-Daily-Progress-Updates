const users = [
    { username: "sanjai", password: "sanjai123" },
    { username: "ragul", password: "ragul123" }
];

const loginForm = document.getElementById('loginForm');
const error = document.getElementById('error');

document.getElementById('loginForm').addEventListener('submit',async function(event) {
    event.preventDefault();
    
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    const foundUser = users.find(user => user.username === username && user.password === password);
    
    if (foundUser) {
        error.style.display = 'none';
        alert('Login Successful!!');
    } else {
        error.style.display = 'block';
    }
});

