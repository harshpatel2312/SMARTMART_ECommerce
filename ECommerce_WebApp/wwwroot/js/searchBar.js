//Made by Arjun
// SearchBar Functionality
$(function() {
    $("#searchInput").autocomplete({
        source: function(request, response) {
            $.ajax({
                url: '/Product/GetProductSuggestions',
                type: "GET",
                dataType: "json",
                data: { term: request.term },
                success: function(data) {
                    console.log("Suggestions:", data);
                    response(data);
                },
                error: function(xhr, status, error) {
                    console.log(xhr.responseText);
                }
            });
        },
        minLength: 2,
        select: function(event, ui) {
            // Submit the form when a suggestion is selected
            $("#searchInput").val(ui.item.value);
            $(this).closest('form').submit();
        }
    });
});
