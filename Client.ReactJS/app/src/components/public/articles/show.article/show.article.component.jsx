import React from 'react';

class ShowArticle extends React.Component {
    render() {
        return (
            <div id="order-summary">
                <h3> Title</h3>
                Text
                <hr />
                <h3>User feedback</h3>
                <ul style={{ listStyleType: "none" }}>
                    <li>
                        <b> </b>
                        <p> Body</p>
                    </li>
                </ul>
                <br />
                <h3>Post your comment</h3>
                <form>
                    <div className="text-danger"></div>
                    <div className="form-group">
                        <label className="control-label">Name:</label>
                        <input type="text" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label className="control-label">Email:</label>
                        <input type="text" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label className="control-label">Body:</label>
                        <input type="number" className="form-control" />
                    </div>
                    <div className="form-group">
                        <input type="submit" value="Create" className="btn btn-default" />
                    </div>
                </form>
            </div >
        )
    }
}

export default ShowArticle;



