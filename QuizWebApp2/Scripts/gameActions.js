
var game = {
    questions: {},
    current: 0,
    currentQuestionId: 0
}


var answersHolder = document.getElementById("answers-holder"),
    questionContent = document.getElementById("question-content"),
    nextBtn = document.getElementById("next-button"),
    previousBtn = document.getElementById("previous-button"),
    answerResultHolder = document.getElementById("answer-result-holder");


$(document).ready(function () {
    var quizId = document.getElementById("gameId").innerText;
    var path = "http://localhost:57726/api/GameActions/" + quizId;

    $.getJSON(path, function (data) {
        game.questions = data;
        renderQuestion();
    });
});

function renderQuestion() {
    questionContent.innerText = game.questions[game.current].Content;
    game.currentQuestionId = game.questions[game.current].QuestionId;


    var count = 0;

    for (var answer in game.questions[game.current].Answers) {
        var element = document.createElement("li"),
            idSpan = document.createElement("span");

        idSpan.innerText = count++;
        idSpan.classList.add("hidden");

        element.classList.add("list-group-item");
        element.classList.add("answer-item");
        element.innerText = game.questions[game.current].Answers[answer].Content;
        element.appendChild(idSpan);
        answersHolder.appendChild(element);
    };
};

nextBtn.addEventListener("click", function () {
    if (game.current < game.questions.length - 1) {
        game.current++;
        game.currentQuestionId = game.questions[game.current].QuestionId;
    }
    clearElements();
    renderQuestion();
})

previousBtn.addEventListener("click", function () {
    if (game.current > 0) {
        game.current--;
        game.currentQuestionId = game.questions[game.current].QuestionId;
    }
    clearElements();
    renderQuestion();
})

function clearElements() {
    answersHolder.innerHTML = "";
    questionContent.innerText = "";
    answerResultHolder.innerText = "";
}

$(document).on('click', ".answer-item", function (event) {
    var result = game.questions[game.current].Answers[event.currentTarget.getElementsByTagName("span")[0].innerText].IsCorrect;

    if (result) {
        answerResultHolder.classList.remove("wrong");
        answerResultHolder.classList.add("correct");
    } else {
        answerResultHolder.classList.remove("correct");
        answerResultHolder.classList.add("wrong");
    }

    answerResultHolder.innerText = result;

});