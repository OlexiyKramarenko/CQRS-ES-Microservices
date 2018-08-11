import React from 'react';
import { NavLink } from 'react-router-dom';
import './shopping.cart.style.css';

class ShoppingCart extends React.Component {
    render() {
        const shoppingCartItems = [
            { id: 1, title: "title_1", unitPrice: 5, quantity: 10 },
            { id: 2, title: "title_2", unitPrice: 1, quantity: 5 },
            { id: 3, title: "title_3", unitPrice: 3, quantity: 8 }
        ];
        return (

            <div style={{ width: 600 }}>
                <form>
                    <table id="shoping-cart">

                        <tr>
                            <td>Product</td>
                            <td>Price</td>
                            <td>Quantity</td>
                        </tr>

                        {shoppingCartItems.map(function (item) {
                            <tr>
                                <td><input type="hidden" />{item.title}</td>
                                <td>{item.unitPrice}</td>
                                <td><input type="text" /></td>
                            </tr>
                        })}

                    </table>
                    <input type="submit" value="Update" />
                </form> 
                <NavLink to="/checkout">Checkout</NavLink>
            </div> 
        )
    }
}

export default ShoppingCart;

