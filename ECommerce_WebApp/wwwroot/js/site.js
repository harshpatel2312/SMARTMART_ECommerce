// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    // Toggle sidebar on hamburger button click
    $('#sidebarToggle').on('click', function () {
        $('.sidebar').toggleClass('active');
        $('#sidebarOverlay').toggleClass('active');
        $('.main-content').toggleClass('shifted');
    });

    // Hide sidebar when clicking on overlay
    $('#sidebarOverlay').on('click', function () {
        $('.sidebar').removeClass('active');
        $('#sidebarOverlay').removeClass('active');
        $('.main-content').removeClass('shifted');
    });
});




