// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
  $(".sortableDraft, .sortableDoing, .sortableTest").sortable({
    connectWith: ".sortableDraft, .sortableDoing, .sortableTest",
    revert: true,
    cursor: "move",
    receive: function (event, ui) {
      console.log(event.target.classList[0], event);
    }
  });
});
