import React from 'react';
import { NavLink } from 'react-router-dom';

class ManageUsers extends React.Component {

    render() {

        const users = [
            { id: 1, email: "mail.ru" }, 
            { id: 2, email: "gmail" }
        ];

        return (
            <table className="list">
                {
                    users.map(function (item) {
                        <tr>
                            <td>{item.email}</td>
                            <td style={{ width: 130 }}>
                                <NavLink to={`/change_password/${item.id}`}>change password</NavLink>
                                <br />
                                <NavLink to={`/edit_user/${item.id}`}>edit</NavLink>
                                <br />
                                <a>delete</a>
                            </td>
                        </tr>
                    })
                }
            </table>
        )
    }
}

export default ManageUsers;