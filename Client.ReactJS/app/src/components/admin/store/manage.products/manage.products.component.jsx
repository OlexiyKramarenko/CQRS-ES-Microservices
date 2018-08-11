import React from 'react'; 
import { NavLink } from 'react-router-dom';
import { manageProducts, deleteProduct } from '../../../../actions/store';
import { connect } from 'react-redux';

class ManageProducts extends React.Component {

    componentDidMount() {
        this.props.manageProducts();
    }

    render() {

        const products = [
            {
                id: 1,
                title: "title",
                averageRating: 4,
                votes: 5,
                unitsInStock: 7,
                discountPercentage: 4,
                unitPrice: 3,
                finalUnitPrice: 1
            }
        ];

        return (
            <div>
                {
                    this.props.products.map(function (item) {
                        <div className="listing-item" key={item.id}>
                            <div className="edit_delete_links">
                                <NavLink to={`/edit_product/${item.id}`}>edit</NavLink>&nbsp;&nbsp;
					            <span onClick={() => this.props.deleteProduct(item.id)}>Delete</span>
                            </div>

                            <a className="listing-link">
                                <h3> item.Title</h3>
                            </a>
                            <b>AverageRating:</b> {item.averageRating}<br />
                            <b>Votes:</b>  {item.votes}<br />
                            <b>UnitsInStock:</b> {item.unitsInStock}<br />
                            <b>DiscountPercentage:</b> {item.discountPercentage}<br />
                            <b>UnitPrice:</b> {item.unitPrice}<br />
                            <b>FinalUnitPrice:</b> {item.finalUnitPrice}<br />
                        </div>
                    })
                }
            </div>
        )
    }
}


function mapStateToProps(state) {
    return {
        products: state.store.products ? [] : state.store.products
    }
}

export default connect(mapStateToProps, { manageProducts, deleteProduct })(ManageProducts);