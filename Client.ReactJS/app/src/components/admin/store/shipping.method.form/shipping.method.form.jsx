import React from 'react';
import { Redirect } from 'react-router-dom';
import { editShippingMethod, updateShippingMethod, addShippingMethod } from '../../../../actions/store';
import { connect } from 'react-redux';

class ShippingMethodForm extends React.Component {

    state = {
        _id: this.props.shippingMethod ? this.props.shippingMethod._id : null,
        addedBy: this.props.shippingMethod ? this.props.shippingMethod.addedBy : '',
        title: this.props.shippingMethod ? this.props.shippingMethod.title : '',
        price: this.props.shippingMethod ? this.props.shippingMethod.price : '',
        errors: {},
        loading: false,
        redirect: false
    }

    componentWillReceiveProps = (nextProps) => {
        this.setState({
            _id: nextProps.shippingMethod._id,
            addedBy: nextProps.shippingMethod.addedBy,
            title: nextProps.shippingMethod.title,
            price: nextProps.shippingMethod.price
        });
    }

    componentDidMount = () => {
        const { match } = this.props;
        if (match.params._id) {
            this.props.editShippingMethod(match.params._id);
        }
    }
    handleSubmit = (e) => {
        e.preventDefault();

        // validation
        let errors = {};

        if (this.state.addedBy === '') errors.addedBy = "'Added By' field can't be empty";
        if (this.state.title === '') errors.title = "'Title' can't be empty";
        if (this.state.price === '') errors.price = "'Price'  can't be empty";

        this.setState({ errors });
        const isValid = Object.keys(errors).length === 0

        if (isValid) {

            const {
                _id, addedBy, title, price
            } = this.state;

            this.setState({ loading: true });

            this.saveShippingMethod({
                _id, addedBy, title, price
            })
                .catch((err) => err.response.json()
                .then(({ errors }) => this.setState({ errors, loading: false })));
        }
    }
    saveShippingMethod = ({
        _id, addedBy, title, price }) => {

        if (_id) {

            return this.props.updateShippingMethod({
                _id, addedBy, title, price
            })
                .then(() => { this.setState({ redirect: true }) }, );

        } else {

            return this.props.addShippingMethod({
                addedBy, title, price
            })
                .then(() => { this.setState({ redirect: true }) }, );
        }
    }

    render() {
        const redirect = <Redirect to={`/manage_shipping_methods`} />

        const form= (
            <div className="row">
                <div className="col-md-4">
                    <form onSubmit={this.handleSubmit}>
                        <div className="text-danger"></div>
                        <div className="form-group">
                            <input type="hidden" />
                        </div>
                        <div className="form-group">
                            <label className="control-label">AddedBy</label>
                            <input type="text" className="form-control" value={this.state.addedBy} />
                        </div>
                        <div className="form-group">
                            <label className="control-label">Title</label>
                            <input type="text" className="form-control" value={this.state.title} />
                        </div>
                        <div className="form-group">
                            <label className="control-label">Price</label>
                            <input type="text" className="form-control" value={this.state.price} />
                        </div>
                        <div className="form-group">
                            <input type="submit" value="Create" className="btn btn-default" />
                        </div>
                    </form>
                </div>
            </div>
        );
        return this.state.redirect ? redirect : form;
    }
}

function mapStateToProps(state, props) {
    const { match } = props;
    if (match.params._id) {
        return {
            shippingMethod: state.store.shippingMethods.find(item => item._id === match.params._id)
        }
    }

    return { shippingMethod: null };
}

export default connect(mapStateToProps, { editShippingMethod, updateShippingMethod, addShippingMethod })(ShippingMethodForm);