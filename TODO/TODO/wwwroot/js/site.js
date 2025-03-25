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
      // Enviar uma OS
      // Criar um novo board
      // Mostrar cada item de cada lugar (Titulo, número os, tags e quem fez)
      // Feito - Colocar uma opção para trocar os dados do board, nome e deletar ele

      var boardElement = ($(event.target).closest("[data-board]")).attr("data-board");
      console.log(boardElement);

    }
  });
});
