import React from 'react'; 
import { NavLink } from 'react-router-dom';
import { manageOrderStatuses, deleteOrderStatus } from '../../../../actions/store';
import { connect } from 'react-redux';

class ManageOrderStatuses extends React.Component {
	
    componentDidMount() {
        this.props.manageOrderStatuses();
    }

	render() {
		const orderStatuses = [
			{ id: 1, title: "title" }
		];

		return (
			<table className="list">

				<tr>
					<td>Title</td>
					<td></td>
					<td></td>
				</tr>

				{
					this.props.orderStatuses.map(function (item) {
						<tr key={item.id}>
							<td>{item.title}</td>
							<td>
								<NavLink to={`/edit_order_status/${item.id}`} >Edit</NavLink>
							</td>
							<td>
								<span onClick={() => this.props.deleteOrderStatus(item.id)}>Delete</span>
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
		orderStatuses: !state.store.orderStatuses ? [] : state.store.orderStatuses
	}
}

export default connect(mapStateToProps, { manageOrderStatuses, deleteOrderStatus })(ManageOrderStatuses);