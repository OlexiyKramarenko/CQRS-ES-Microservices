import React from 'react';
import { NavLink } from 'react-router-dom';
import { manageShippingMethods, deleteShippingMethod } from '../../../../actions/store';
import { connect } from 'react-redux';

class ManageShippingMethods extends React.Component {

    componentDidMount() {
        this.props.manageShippingMethods();
    }

    render() {
        const shippingMethods = [
            {
                id: 1,
                title: "Some title",
                price: 10
            }
        ];
        return (
            <table className="list">
                <tr>
                    <td>Title</td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                {
                    this.props.shippingMethods.map(function (item) {
                        <tr key={item.id}>
                            <td>{item.title}</td>
                            <td>{item.price}</td>
                            <td>
                                <NavLink to={`/edit_shipping_method/${item.id}`}>Edit</NavLink>
                            </td>
                            <td>
                                <span onClick={() => this.props.deleteShippingMethod(item.id)}>Delete</span>
                            </td>
                        </tr>
                    })
                }
            </table>
        )
    }
}


function mapStateToProps(state) {
    return {
        shippingMethods: state.store.shippingMethods ? [] : state.store.shippingMethods
    }
}

export default connect(mapStateToProps, { manageShippingMethods, deleteShippingMethod })(ManageShippingMethods);