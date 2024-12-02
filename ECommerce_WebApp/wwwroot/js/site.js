//Made by Arjun
// Sidebar Functionality
$(document).ready(function () {
    // Toggle sidebar on hamburger button click
    $('#sidebarToggle').on('click', function () {
        $('#sidebar').toggleClass('active');
        $('#sidebarOverlay').toggleClass('active');
        $('#mainContent').toggleClass('shifted');
    });

    // Hide sidebar when clicking on overlay
    $('#sidebarOverlay').on('click', function () {
        $('#sidebar').removeClass('active');
        $('#sidebarOverlay').removeClass('active');
        $('#mainContent').removeClass('shifted');
    });
});


