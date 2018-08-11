import React from 'react';
import { NavLink } from 'react-router-dom';
import './browse.products.style.css';

class ShowProduct extends React.Component {
	render() {

		const products = [
			{ id: 1, averageRating: 4, votes: 1, unitsInStock: 2, discountPercentage: 10, unitPrice: 10, finalUnitPrice: 5 },
			{ id: 2, averageRating: 3, votes: 4, unitsInStock: 3, discountPercentage: 34, unitPrice: 6, finalUnitPrice: 5 }
		];

		return (
			<div id="order-summary">
				<div>
					{
						products.map(function (item) {
							<div className="listing-item" key={item.id}>
								<NavLink to={`/show_product/${item.id}`}
									className="listing-link">
									<h3>{item.title}</h3>
								</NavLink>
								<b>AverageRating:</b>{item.averageRating}<br />
								<b>Votes:</b> {item.votes}<br />
								<b>UnitsInStock:</b>{item.unitsInStock}<br />
								<b>DiscountPercentage:</b>{item.discountPercentage}<br />
								<b>UnitPrice:</b>{item.unitPrice}<br />
								<b>FinalUnitPrice:</b>{item.finalUnitPrice}<br />
							</div>
						})
					}
				</div>
			</div>
		)
	}
}

export default ShowProduct;

