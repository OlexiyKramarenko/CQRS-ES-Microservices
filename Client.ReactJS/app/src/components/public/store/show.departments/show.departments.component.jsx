import React from 'react';
import { NavLink } from 'react-router-dom';
import './show.departments.style.css';

class ShowDepartments extends React.Component {
    render() {
        const departments = [
            { id: 1, title: "tit", description: "dasda" }
        ];
        return (
            <div>
                <h3>Store departments</h3>
                <div>Click on the title of the department for which you want to browse the products:</div>
                <br />
                {
                    departments.map(function (item) {
                        <div className="category-item"  key={item.id}>
                            <NavLink to={`browse_products/${item.id}`}>
                                {item.title}
                            </NavLink>
                            <br />
                            <p>{item.description}</p>
                        </div>
                    })
                }
            </div>
        )
    }
}

export default ShowDepartments;