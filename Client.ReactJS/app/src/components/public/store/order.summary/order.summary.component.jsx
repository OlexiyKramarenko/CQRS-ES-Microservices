import React from 'react';

class ShowProduct extends React.Component {
    render() {
        const orderSummaryViewModel =
            {
                subtotal: 10,
                shippingMethod: "m",
                total: 10,
                shoppingCartItems: [
                    {
                        title: "title 1",
                        unitPrice: 5,
                        quantity: 4
                    }]
            };

        return (
            <div id="order-summary">
                <h4>Order Details</h4>
                {
                    orderSummaryViewModel.shoppingCartItems(function (item) {
                        <div style={{
                            backgroundColor: "whitesmoke",
                            minWidth: 350,
                            padding: 5
                        }}>
                            > {item.title} - {item.unitPrice}  (Quantity = {item.quantity})
                        </div>
                    })
                }

                <br />

                <div><i>Subtotal</i> = {orderSummaryViewModel.subtotal}</div><br />
                <div><i>Shipping Method</i> = {orderSummaryViewModel.shippingMethod}</div><br />
                <div><i>Total</i> = {orderSummaryViewModel.total}</div><br />

                <h4>Shipping Details</h4>

                <div>{orderSummaryViewModel.shippingDetails}</div>
                <br />

                <button className="btn btn-default">Sumbit Order</button>
            </div>
        )
    }
}

export default ShowProduct;