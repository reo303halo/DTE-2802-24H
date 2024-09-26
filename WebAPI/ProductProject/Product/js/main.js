$(document).ready(function() {
    $('#fetchData').click(function() {
        $.ajax({
            url: 'https://localhost:7062/api/Product',
            type: 'GET',
            dataType: 'json',
            success: function(data) {
                $('#dataContainer').text(JSON.stringify(data));
            },
            error: function(xhr, status, error) {
                console.error('Error fetching data', error);
            }
        });
    });
});