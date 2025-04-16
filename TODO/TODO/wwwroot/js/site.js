// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
  $(".sortableDraft, .sortableDoing, .sortableTest").sortable({
    connectWith: ".sortableDraft, .sortableDoing, .sortableTest",
    revert: true,
    cursor: "move",
    receive: function (event, ui) {
      // TODO: Mostrar no console quantos itens tem em casa board
      // Criar a funcionalidade de adicionar um novo card, board (no back)

      let boardElement = ($(event.target).closest("[data-board]")).attr("data-board");
      var idElement = $(event.target).find('#idCard').val();

      console.log("O elemento com o id " + idElement + " foi para o card: " + boardElement);

    }
  });
});
