
var game = {
    questions: {},
    current: 0,
    currentQuestionId : 0
}


var answersHolder = document.getElementById("answers-holder"),
    questionContent = document.getElementById("question-content"),
    nextBtn = document.getElementById("next-button"),
    previousBtn = document.getElementById("previous-button");


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

    for (var answer in game.questions[game.current].Answers) {
        var element = document.createElement("li"),
            idSpan = document.createElement("span");

        idSpan.innerText = game.questions[game.current].Answers[answer].AnswerId;
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
    }
    clearElements();
    renderQuestion();
})

previousBtn.addEventListener("click", function () {
    if (game.current > 0) {
        game.current--;
    }
    clearElements();
    renderQuestion();
})

function clearElements() {
    answersHolder.innerHTML = "";
    questionContent.innerText = "";
}

$(document).on('click', ".answer-item", function (event) {
    console.log(event.currentTarget.getElementsByTagName("span")[0].innerText);

    console.log(game.currentQuestionId);

    
});