var orderUpdateCtr = {
    Init: function () {
        this.RegisterEvent();
    },
    RegisterEvent: function () {
        $('#add-order-detail').on('click', function () {
            // Tạo một hàng mới
            var newRow = $('<tr>');
            var productIdCell = $('<td>').append($('<input>').attr('name', 'OrderDetails[' + $('.order-detail').length + '].PId').addClass('form-control'));
            var quantityCell = $('<td>').append($('<input>').attr('name', 'OrderDetails[' + $('.order-detail').length + '].ODQuantity').addClass('form-control'));
            var priceCell = $('<td>').append($('<input>').attr('name', 'OrderDetails[' + $('.order-detail').length + '].ODPrice').addClass('form-control'));
            var removeBtnCell = $('<td>').append($('<button>').addClass('btn btn-danger remove-order-detail').text('Remove'));
            newRow.append(productIdCell);
            newRow.append(quantityCell);
            newRow.append(priceCell);
            newRow.append(removeBtnCell);
            // Thêm hàng mới vào cuối bảng
            $('#order-details-table tbody').append(newRow);
        });

        // Xóa hàng
        $('#order-details-table').on('click', '.remove-order-detail', function () {
            $(this).closest('tr').remove();
        });
    }
};

