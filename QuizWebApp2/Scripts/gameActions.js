
var questions, current = 0;
var answersHolder = document.getElementById("answers-holder"),
    questionContent = document.getElementById("question-content"),
    nextBtn = document.getElementById("next-button"),
    previousBtn = document.getElementById("previous-button");


    $(document).ready(function () {
        var quizId = document.getElementById("gameId").innerText;

        var path = "http://localhost:57726/api/GameActions/" + quizId;

        $.getJSON(path, function (data) {
            questions = data;
            renderQuestion();

        });

    });

function renderQuestion() {
    questionContent.innerText = questions[current].Content;
    for (var answer in questions[current].Answers) {
        var element = document.createElement("li");
        element.classList.add("list-group-item");
        element.classList.add("answer-item");
        element.innerText = questions[current].Answers[answer].Content;
        answersHolder.appendChild(element);
    };
};

nextBtn.addEventListener("click", function () {
    current++;
    clearElements();
    renderQuestion();
})

function clearElements() {
    answersHolder.innerHTML = "";
    questionContent.innerText = "";
}