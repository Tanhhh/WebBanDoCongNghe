$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id')
        var quatity = 1;
        var tQuantity = $('#quantity_value').text();
        if (tQuantity != '')
        {
            quatity = parseInt(tQuantity);
        }
        $.ajax({
            url: '/ShoppingCart/AddToCart',
            type: 'POST',
            data: { id: id, quantity: quatity },
            success: function (rs) {
                if (rs.Success)
                {
                    $('#checkout_items').html(rs.Count);
                    alert(rs.msg)
                }
            }
        });
    });

    $('body').on('click', '.btnUpdate', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = $('#Quantity_'+id).val();
        Update(id, quantity);
    });

    $('body').on('click', '.btnDelete', function (e) {
        e.preventDefault();
        var id = $(this).data('id')
        var conf = confirm('Bạn có muốn xóa sản phẩm này không?');
        if(conf== true )
        {
            $.ajax({
                url: '/ShoppingCart/Delete',
                type: 'POST',
                data: { id: id },
                success: function (rs) {
                    if (rs.Success) {
                        $('#checkout_items').html(rs.Count);
                        $('#trow_' + id).remove();
                        LoadCart()
                    }
                }
            });
        }
    });
});
function ShowCount() {
    $.ajax({
        url: '/ShoppingCart/ShowCount',
        type: 'Get',
        success: function (rs) {
                $('#checkout_items').html(rs.Count);
        }
    });
}

function LoadCart() {
    $.ajax({
        url: '/ShoppingCart/Partial_Item_Cart',
        type: 'Get',
        success: function (rs) {
            $('#load_data').html(rs);
        }
    });
}
function Update(id,quantity) {
    $.ajax({
        url: '/ShoppingCart/Update',
        type: 'POST',
        data: { id: id, quantity: quantity },
        success: function (rs) {
            if (rs.Success) {
                LoadCart()
                location.reload()
            }
        }
    });
}

