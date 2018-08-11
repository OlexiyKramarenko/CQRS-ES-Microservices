import React from 'react';
import { NavLink } from 'react-router-dom';

class Default extends React.Component {
    render() {
        return (
            <div>
                <h3>Administration</h3>
                <NavLink to="/manage_users">Manage Users</NavLink>
                search for users by username or e-mail address, read and modify thier profile, roles, and approved status.

                <div className="sectionsubtitle">Actions for Editors</div>
                <ul>
                    <li><NavLink to={"/manage_categories"}>Manage Articles</NavLink>: add/edit/remove categories, articles and comments,
   review & approve articles posted by contributors.</li>
                </ul>

 
                <div className="sectionsubtitle">Actions for Store Keepers</div>
                <ul>
                    <li><NavLink to={"/manage_departments"}>Manage Store Catalog</NavLink>: add/edit/remove store departments, products,
   shipping methods and order statuses.</li>
                </ul>
{/*
                <div className="sectionsubtitle">Actions for Contributors</div>
                <ul>
                    <li><NavLink to={"/add_article"}>Post New Article</NavLink>
                        : post a new article into an existent category.
                        If you're a contributor, your article will have to be approved by an administrator or an editor
   before being published.</li>
                </ul> */}
            </div>
        )
    }
}

export default Default;






