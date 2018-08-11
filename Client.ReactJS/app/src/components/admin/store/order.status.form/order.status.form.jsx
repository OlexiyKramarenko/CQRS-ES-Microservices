import React from 'react';
import { Redirect } from 'react-router-dom';
import { editOrderStatus, updateOrderStatus, addOrderStatus } from '../../../../actions/store';
import { connect } from 'react-redux';

class OrderStatusForm extends React.Component {

    state = {
        _id: this.props.orderStatus ? this.props.orderStatus._id : null,
        addedBy: this.props.orderStatus ? this.props.orderStatus.addedBy : '',
        addedDate: this.props.orderStatus ? this.props.orderStatus.addedDate : '',
        title: this.props.orderStatus ? this.props.orderStatus.title : '',
        errors: {},
        loading: false,
        redirect: false
    }

    componentWillReceiveProps = (nextProps) => {
        this.setState({
            _id: nextProps.orderStatus._id,
            addedBy: nextProps.orderStatus.addedBy,
            addedDate: nextProps.orderStatus.addedDate,
            title: nextProps.orderStatus.title
        });
    }

    componentDidMount = () => {
        const { match } = this.props;
        if (match.params._id) {
            this.props.editOrderStatus(match.params._id);
        }
    }

    handleSubmit = (e) => {
        e.preventDefault();

        // validation
        let errors = {};

        if (this.state.addedBy === '') errors.addedBy = "'AddedBy' field can't be empty";
        if (this.state.addedDate === '') errors.addedDate = "'Added Date' field сan't be empty";
        if (this.state.title === '') errors.title = "'Title' can't be empty";

        this.setState({ errors });
        const isValid = Object.keys(errors).length === 0

        if (isValid) {

            const {
                _id, addedBy, addedDate, title
            } = this.state;

            this.setState({ loading: true });

            this.saveOrderStatus({
                _id, addedBy, addedDate, title
            })
                .catch((err) => err.response.json()
                    .then(({ errors }) => this.setState({ errors, loading: false })));
        }
    }
    saveOrderStatus = ({
        _id, addedBy, addedDate, title }) => {

        if (_id) {

            return this.props.updateOrderStatus({
                _id, addedBy, addedDate, title
            })
                .then(() => { this.setState({ redirect: true }) }, );

        } else {

            return this.props.addOrderStatus({
                addedBy, addedDate, title
            })
                .then(() => { this.setState({ redirect: true }) }, );
        }
    }


    render() {

        const redirect = <Redirect to={`/manage_order_statuses`} />

        const form = (
            <form onSubmit={this.handleSubmit} >
                <div className="text-danger"></div>
                <div className="form-group">
                    <input type="hidden" asp-for="Id" />
                </div>
                <div className="form-group">
                    <label className="control-label">AddedDate</label>
                    <input type="text" className="form-control" value={this.state.addedDate} />
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
                    <input type="submit" value="Create" className="btn btn-default" />
                </div>
            </form>

        );

        return this.state.redirect ? redirect : form;
    }
}


function mapStateToProps(state, props) {
    const { match } = props;
    if (match.params._id) {
        return {
            orderStatus: state.store.orderStatuses.find(item => item._id === match.params._id)
        }
    }

    return { orderStatus: null };
}

export default connect(mapStateToProps, { editOrderStatus, updateOrderStatus, addOrderStatus })(OrderStatusForm);