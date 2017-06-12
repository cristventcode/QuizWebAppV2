
// Get questions from API on page load 
$(document).ready(function () {
    var quizId = document.getElementById("gameId").innerText;
    var path = "/api/GameActions/" + quizId;

    $.getJSON(path, function (data) {
        game.questions = data;
        renderQuestion();
    });
});

// Game data object
var game = {
    questions: {},
    current: 0,
}

// Variables for elements
var answersHolder = document.getElementById("answers-holder"),
    questionContent = document.getElementById("question-content"),
    nextBtn = document.getElementById("next-button"),
    previousBtn = document.getElementById("previous-button"),
    answerResultHolder = document.getElementById("answer-result-holder");


// Render out question and answers
function renderQuestion() {
    questionContent.innerText = game.questions[game.current].Content;
    var count = 0;
    for (var answer in game.questions[game.current].Answers) {

        var answerLi = document.createElement("li"),
            answerPosition = document.createElement("span");

        answerPosition.innerText = count++;
        answerPosition.classList.add("hidden");
        answerLi.classList.add("list-group-item");
        answerLi.classList.add("answer-item");
        answerLi.innerText = game.questions[game.current].Answers[answer].Content;

        answerLi.appendChild(answerPosition);
        answersHolder.appendChild(answerLi);
    };
};

// Next button events 
nextBtn.addEventListener("click", function () {
    if (game.current < game.questions.length - 1) {
        game.current++;
    }
    clearElements();
    renderQuestion();
})

// Previous button events
previousBtn.addEventListener("click", function () {
    if (game.current > 0) {
        game.current--;
    }
    clearElements();
    renderQuestion();
})

// Clear elements function
function clearElements() {
    answersHolder.innerHTML = "";
    questionContent.innerText = "";
    answerResultHolder.innerText = "";
}

// On answer click events
$(document).on('click', ".answer-item", function (event) {
    var result = game.questions[game.current].Answers[event.currentTarget.getElementsByTagName("span")[0].innerText].IsCorrect;

    if (result) {
        answerResultHolder.classList.remove("wrong");
        answerResultHolder.classList.add("correct");
    } else {
        answerResultHolder.classList.remove("correct");
        answerResultHolder.classList.add("wrong");
    }

    answerResultHolder.innerText = result.toString().toUpperCase();

});