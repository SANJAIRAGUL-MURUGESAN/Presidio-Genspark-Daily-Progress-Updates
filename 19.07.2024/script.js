const lettersContainer = document.querySelector('.letters-container');
const selectedWordDisplay = document.getElementById('selected-word');
const submitWordButton = document.getElementById('submit-word');
const clearWordButton = document.getElementById('clear-word');
const refreshLettersButton = document.getElementById('refresh-letters');
const scoreElement = document.getElementById('score');
const wordsList = document.getElementById('words-list');
const progressFill = document.getElementById('progress-fill');
const progressLevel = document.getElementById('progress-level');

const letters = ['A', 'B', 'C', 'D', 'E', 'F', 'G']; 
const requiredLetter = 'A';
const validWords = ['BEAD', 'FACE', 'DEAF', 'AGED','BADGE', 'CAFÉ', 'CADE','CEFA']; 

let score = 0;
let foundWords = [];
let selectedWord = "";

const scoreLevels = [
    { score: 0, level: "Beginner" },
    { score: 10, level: "Good Start" },
    { score: 20, level: "Moving Up" },
    { score: 30, level: "Good" },
    { score: 40, level: "Solid" },
    { score: 50, level: "Nice" },
    { score: 60, level: "Great" },
    { score: 70, level: "Amazing" },
    { score: 80, level: "Genius" }
];

function shuffleLetters(array) {
    for (let i = array.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [array[i], array[j]] = [array[j], array[i]];
    }
    return array;
}

function initializeLetters() {
    lettersContainer.innerHTML = ''; 
    letters.forEach(letter => {
        const letterElement = document.createElement('div');
        letterElement.classList.add('letter');
        if (letter === requiredLetter) {
            letterElement.classList.add('required');
        }
        letterElement.textContent = letter;
        letterElement.addEventListener('click', () => {
            selectedWord += letter;
            selectedWordDisplay.textContent = selectedWord;
        });
        lettersContainer.appendChild(letterElement);
    });
}

submitWordButton.addEventListener('click', () => {
    if (isValidWord(selectedWord)) {
        if (!foundWords.includes(selectedWord)) {
            foundWords.push(selectedWord);
            updateScore(selectedWord);
            addWordToList(selectedWord);
        } else {
            alert('You already found this word!');
        }
    } else {
        alert('Invalid word!');
    }
    clearSelectedWord();
});

clearWordButton.addEventListener('click', clearSelectedWord);

refreshLettersButton.addEventListener('click', () => {
    shuffleLetters(letters);
    initializeLetters();
    clearSelectedWord();
});

function clearSelectedWord() {
    selectedWord = "";
    selectedWordDisplay.textContent = selectedWord;
}

function isValidWord(word) {
    return word.includes(requiredLetter) && validWords.includes(word);
}

function updateScore(word) {
    score += word.length;
    scoreElement.textContent = score;
    updateProgressBar();
}

function updateProgressBar() {
    const maxScore = 80; 
    const scorePercentage = Math.min((score / maxScore) * 100, 100);
    progressFill.style.width = `${scorePercentage}%`;

    let level = "Genius";
    for (const scoreLevel of scoreLevels) {
        if (score < scoreLevel.score) {
            level = scoreLevels[scoreLevels.indexOf(scoreLevel) - 1].level;
            break;
        }
    }
    progressLevel.textContent = level;
}

function addWordToList(word) {
    const listItem = document.createElement('li');
    listItem.textContent = word;
    wordsList.appendChild(listItem);
}

initializeLetters();
