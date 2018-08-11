import React from 'react';
import PropTypes from 'prop-types';
import { Redirect } from 'react-router-dom';
import { editProduct, updateProduct, addProduct } from '../../../../actions/store';
import { connect } from 'react-redux';

class ProductForm extends React.Component {

    state = {
        _id: this.props.product ? this.props.product._id : null,
        departmentId: this.props.product ? this.props.product.departmentId : null,
        title: this.props.product ? this.props.product.title : '',
        description: this.props.product ? this.props.product.description : '',
        sku: this.props.product ? this.props.product.sku : '',
        unitPrice: this.props.product ? this.props.product.unitPrice : '',
        discountPercentage: this.props.product ? this.props.product.discountPercentage : '',
        unitsInStock: this.props.product ? this.props.product.unitsInStock : '',
        smallImageUrl: this.props.product ? this.props.product.smallImageUrl : '',
        fullImageUrl: this.props.product ? this.props.product.fullImageUrl : '',

        errors: {},
        loading: false,
        redirect: false
    }

    componentWillReceiveProps = (nextProps) => {
        this.setState({
            _id: nextProps.product._id,
            departmentId: nextProps.product.departmentId,
            title: nextProps.product.title,
            description: nextProps.product.description,
            sku: nextProps.product.sku,
            unitPrice: nextProps.product.unitPrice,
            discountPercentage: nextProps.product.discountPercentage,
            unitsInStock: nextProps.product.unitsInStock,
            smallImageUrl: nextProps.product.smallImageUrl,
            fullImageUrl: nextProps.product.fullImageUrl
        });
    }

    componentDidMount = () => {
        const { match } = this.props;
        if (match.params._id) {
            this.props.editProduct(match.params._id);
        }
    }
    handleSubmit = (e) => {
        e.preventDefault();

        // validation
        let errors = {};

        if (this.state.title === '') errors.title = "'Title' field can't be empty";
        if (this.state.description === '') errors.description = "'Description' field сan't be empty";
        if (this.state.sku === '') errors.sku = "'SKU' can't be empty";
        if (this.state.unitPrice === '') errors.unitPrice = "'UnitPrice'  can't be empty";
        if (this.state.discountPercentage === '') errors.discountPercentage = "'DiscountPercentage'  can't be empty";
        if (this.state.unitsInStock === '') errors.unitsInStock = "'Units In Stock'  can't be empty";
        if (this.state.smallImageUrl === '') errors.smallImageUrl = "'Small Image Url'  can't be empty";
        if (this.state.fullImageUrl === '') errors.fullImageUrl = "'Full Image Url'  can't be empty";

        this.setState({ errors });
        const isValid = Object.keys(errors).length === 0

        if (isValid) {

            const {
                _id, title, description, sku, unitPrice,
                discountPercentage, unitsInStock, smallImageUrl, fullImageUrl
            } = this.state;

            this.setState({ loading: true });

            this.saveProduct({
                _id, title, description, sku, unitPrice,
                discountPercentage, unitsInStock, smallImageUrl, fullImageUrl
            })
                .catch((err) => err.response.json()
                    .then(({ errors }) => this.setState({ errors, loading: false })));
        }
    }
    saveProduct = ({
        _id, title, description, sku, unitPrice,
        discountPercentage, unitsInStock, smallImageUrl, fullImageUrl }) => {

        if (_id) {

            return this.props.updateProduct({
                _id, title, description, sku, unitPrice,
                discountPercentage, unitsInStock, smallImageUrl, fullImageUrl
            })
                .then(() => { this.setState({ redirect: true }) }, );

        } else {

            return this.props.addProduct({
                title, description, sku, unitPrice,
                discountPercentage, unitsInStock, smallImageUrl, fullImageUrl
            })
                .then(() => { this.setState({ redirect: true }) }, );
        }
    }


    render() {
        const redirect = <Redirect to={`/manage_products/${this.state.departmentId}`} />

        const form = (
            <form onSubmit={this.handleSubmit}>
                <div className="text-danger"></div>
                <div className="form-group">
                    <input type="hidden" />
                </div>
                <div className="form-group">
                    <label className="control-label">Title</label>
                    <input type="text" className="form-control" value={this.state.title} />
                </div>
                <div className="form-group">
                    <label className="control-label">Description</label>
                    <input type="text" className="form-control" value={this.state.description} />
                </div>
                <div className="form-group">
                    <label className="control-label">SKU</label>
                    <input type="text" className="form-control" value={this.state.sku} />
                </div>
                <div className="form-group">
                    <label className="control-label">UnitPrice</label>
                    <input type="text" className="form-control" value={this.state.unitPrice} />
                </div>
                <div className="form-group">
                    <label className="control-label">DiscountPercentage</label>
                    <input type="text" className="form-control" value={this.state.discountPercentage} />
                </div>
                <div className="form-group">
                    <label className="control-label">UnitsInStock</label>
                    <input type="text" className="form-control" value={this.state.unitsInStock} />
                </div>
                <div className="form-group">
                    <label className="control-label">SmallImageUrl</label>
                    <input type="text" className="form-control" value={this.state.smallImageUrl} />
                </div>
                <div className="form-group">
                    <label className="control-label">FullImageUrl</label>
                    <input type="text" className="form-control" value={this.state.fullImageUrl} />
                </div>
                <div className="form-group">
                    <input type="submit" value="Update" className="btn btn-default" />
                </div>
            </form>
        );

        return this.state.redirect ? redirect : form;
    }
}
 
ProductForm.propTypes = {
    
    title: PropTypes.element.isRequired,
    description: PropTypes.element.isRequired,
    sku: PropTypes.element.isRequired,
    unitPrice: PropTypes.element.isRequired,
    discountPercentage: PropTypes.element.isRequired,
    unitsInStock: PropTypes.element.isRequired 
};

function mapStateToProps(state, props) {
    const { match } = props;
    if (match.params._id) {
        return {
            product: state.store.products.find(item => item._id === match.params._id)
        }
    }

    return { product: null };
}

export default connect(mapStateToProps, { editProduct, updateProduct, addProduct })(ProductForm);