const {JSDOM} = require('jsdom');
const fs = require('fs');
const path = require('path');

test('valid login',()=>{
    const html = fs.readFileSync(path.resolve(__dirname, '../login.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../login.js'), 'utf8');

    const dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });

    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    const { document } = dom.window;

    const username = document.getElementById('username');
    const password = document.getElementById('password');
    const error = document.getElementById('error');

    username.value = 'sanjai';
    password.value = 'sanjai123';

    //Raising the event
    const form = document.getElementById('loginForm');
    const submitEvent = new dom.window.Event('submit');
    form.dispatchEvent(submitEvent);
    
    expect(error.style.display).toBe('none');
})

test('invalid login',()=>{
    const html = fs.readFileSync(path.resolve(__dirname, '../login.html'), 'utf8');
    const script = fs.readFileSync(path.resolve(__dirname, '../login.js'), 'utf8');

    const dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });

    const scriptElement = dom.window.document.createElement('script');
    scriptElement.textContent = script;
    dom.window.document.body.appendChild(scriptElement);

    const { document } = dom.window;

    const username = document.getElementById('username');
    const password = document.getElementById('password');
    const error = document.getElementById('error');

    username.value = 'sanjai';
    password.value = 'sanjai321';

    //Raising the event
    const form = document.getElementById('loginForm');
    const submitEvent = new dom.window.Event('submit');
    form.dispatchEvent(submitEvent);
    
    expect(error.style.display).toBe('block');
})