import React from 'react'; 
import { NavLink } from 'react-router-dom';
import { deleteDepartment } from '../../../../actions/store';
import { connect } from 'react-redux';

class ManageDepartments extends React.Component {
	render() {

		const departments = [
			{
				id: 1,
				imageUrl: "url",
				title: "titititle",
				description: "description"
			}
		];

		return (
			<table className="list">
				{
					this.props.departments.map(function (item) {
						<tr key={item.id}>
							<td>{item.imageUrl}</td>
							<td>{item.title} {item.description}</td>
							<td>
								<NavLink to={`/edit_department/${item.id}`}>Edit</NavLink>
							</td>
							<td>
							<span onClick={() => this.props.deleteDepartment(item.id)}>Delete</span>
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
		departments: !state.store.departments ? [] : state.store.departments
	}
}

export default connect(mapStateToProps, { deleteDepartment })(ManageDepartments);