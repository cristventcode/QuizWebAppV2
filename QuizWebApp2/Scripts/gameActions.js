
var questions;

var 

$(document).ready(function () {
    var quizId = document.getElementById("gameId").innerText;

    var path = "http://localhost:57726/api/GameActions/" + quizId;

    $.getJSON(path, function (data) {
        questions = data;
        startGame();
    });

});

function renderGame() {
    console.log(questions);
}